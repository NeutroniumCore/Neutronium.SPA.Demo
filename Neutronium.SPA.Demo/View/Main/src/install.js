
import 'material-design-icons/iconfont/material-icons.css'
import 'font-awesome/css/font-awesome.css'

import Vue_Router from 'vue-router'
import {router} from './route'
import VueI18n from 'vue-i18n'
import messages from  './message'

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
    VCard,
    VDialog,
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
          VCard,
          VDialog,
          transitions
        }
    })

    Vue.use(Vue_Router)
    Vue.use(VueI18n)
}

function vueInstanceOption() {
    const i18n = new VueI18n({
        locale: 'fr-FR', // set locale
        messages // set locale messages
    });

    //Return vue global option here, such as vue-router, vue-i18n, mix-ins, .... 
    return {
        router,
        i18n
    }
}

export {
    install,
    vueInstanceOption
} 