<template>
  <v-app dark>

    <side-menu v-model="drawer" :items="menu">
    </side-menu>

    <top-menu v-model="drawer" :title="viewModel.ApplicationInformation.Name" :window="viewModel.Window">
    </top-menu>

    <modal v-model="modal" :viewModel="viewModel.Modal">
    </modal>

    <transition mode="out-in">
      <router-view :viewModel="viewModel.CurrentViewModel"></router-view>
    </transition>

    <application-footer :year="viewModel.ApplicationInformation.Year">
    </application-footer>

  </v-app>
</template>

<script>

import sideMenu from './components/sideMenu'
import applicationFooter from './components/applicationFooter'
import topMenu from './components/topMenu'
import modal from './components/modal'

import {menu} from './route'

const props={
  viewModel: Object,
  __window__: Object
};

export default {
  components:{
      sideMenu,
      applicationFooter,
      topMenu,
      modal
  },
  name: 'app',
  props,
  data () {
    return {
      clipped: false,
      drawer: false,
      fixed: false,
      modal:false,
      menu
    }
  },
    mounted(){
      this.$nextTick(()=> this.viewModel.Router.Route = this.$route.name);
  },
  watch:{
    'viewModel.Router.Route': function(name){
      if (name)
        this.$router.push({name});
    },
    'viewModel.Modal': function(value){
      this.modal = (value!= null)
    }
  }
}
</script>

<style lang="stylus">
  @import './stylus/main'  
</style>
