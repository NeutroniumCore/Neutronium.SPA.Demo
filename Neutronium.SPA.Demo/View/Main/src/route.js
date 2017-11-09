import Router from 'vue-router'
import main from './pages/main.vue'
import about from './pages/about.vue'
import toPromise from 'neutronium-vue-resultcommand-topromise'

function route (component, path, name, icon, children) {
    return {
        exact: true,
        path,
        name,
        children,
        component,
        meta:{
            icon
        }
    }
}

const allRoutes = [
    route(main,'/main', 'main', 'view_list'),
    route(about, '/about', 'about', 'info')
]

const routes = [...allRoutes, { path: '/', redirect: '/main' }]

const router = new Router({
    mode: 'hash',
    scrollBehavior: () => ({ y: 0 }),
    routes
});

const menu = allRoutes.map(r => ({
    title: `${r.name}`,
    to: r.path,
    icon: r.meta.icon
}))

router.beforeEach((to, from, next) => {
    const app = router.app
    if (!app){
        next()
        return;
    }

    const viewModel = app.ViewModel
    if (!viewModel){
        next()
        return;
    }

    const navigator = viewModel.NavigateCommand;
    if (!navigator){
        next();
        return;
    }

    const promise = toPromise(navigator)(to.name);
    promise.then((ok)=>{
        if (ok) {
            next()
        } else {
            next(false);
        }
    }, (error) =>{
        next(error)
    })
})

export {
    router,
    menu
}
