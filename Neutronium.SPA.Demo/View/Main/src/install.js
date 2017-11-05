
import 'material-design-icons/iconfont/material-icons.css'
import 'font-awesome/css/font-awesome.css'

import {
    Vuetify,
    VApp,
    VNavigationDrawer,
    VFooter,
    VList,
    VBtn,
    VIcon,
    VGrid,
    VToolbar,
    transitions
  } from 'vuetify'

function install(Vue) {
    Vue.use(Vuetify, {
        components: {
          VApp,
          VNavigationDrawer,
          VFooter,
          VList,
          VBtn,
          VIcon,
          VGrid,
          VToolbar,
          transitions
        }
      })
}

function vueInstanceOption() {
    //Return vue global option here, such as vue-router, vue-i18n, mix-ins, .... 
    return {}
}

export {
    install,
    vueInstanceOption
} 