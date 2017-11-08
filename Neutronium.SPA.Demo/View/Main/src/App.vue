<template>
  <v-app dark>

    <side-menu v-model="drawer" :items="menu">
    </side-menu>

    <top-menu v-model="drawer" :title="viewModel.ApplicationInformation.Name" :window="viewModel.Window">
    </top-menu>
    
    <transition mode="out-in">
      <router-view></router-view>
    </transition>

    <application-footer :year="viewModel.ApplicationInformation.Year">
    </application-footer>

  </v-app>
</template>

<script>

import sideMenu from './components/sideMenu'
import applicationFooter from './components/applicationFooter'
import topMenu from './components/topMenu'

import {menu} from './route'

const props={
  viewModel: Object,
  __window__: Object
};

export default {
  components:{
      sideMenu,
      applicationFooter,
      topMenu
  },
  name: 'app',
  props,
  data () {
    return {
      clipped: false,
      drawer: false,
      fixed: false,
      menu
    }
  }
}
</script>

<style lang="stylus">
  @import './stylus/main'  
</style>
