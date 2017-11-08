import Router from 'vue-router'
import main from './pages/main.vue'
import about from './pages/about.vue'

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
    route(about, '/about', 'about', 'bubble_chart')
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
    next()
})

export {
    router,
    menu
}
