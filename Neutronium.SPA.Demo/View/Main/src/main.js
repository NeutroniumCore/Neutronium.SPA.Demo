import Vue from 'vue'
import App from './App.vue'
import rawVm from '../data/vm'
import CircularJson from 'circular-json'
import {install, vueInstanceOption} from './install'

function updateVm(vm) {
    var window = vm.__window__
    if (window) {
        delete vm.__window__
        return { ViewModel: vm, Window: window }
    }
    return vm;
}

const vm = updateVm(CircularJson.parse(rawVm));

install(Vue)

var options = vueInstanceOption();
const {router} = options;
router.beforeEach((to, from, next) => {
    const name = to.name;
    const vmFile = `../data/${name}/vm.cjson`
    import(`../data/${name}/vm.cjson`).then(module => {
        const newVm = updateVm(CircularJson.parse(module));
        router.app.ViewModel.CurrentViewModel = newVm.ViewModel.CurrentViewModel;
        next();
    }).catch(error => {
        console.log(error)
        console.log(`Problem loading file: "../data/${name}/vm.cjson". Please create corresponding file to be able to . ViewModel will be set to null.`)
        router.app.ViewModel.CurrentViewModel = null;
        next();
    })
})

const vueRootInstanceOption = Object.assign({}, options, {
    components: {
        App
    },
    data: vm
});
new Vue(vueRootInstanceOption).$mount('#main')
