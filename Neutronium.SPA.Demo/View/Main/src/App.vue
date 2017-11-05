<template>
  <v-app dark>

    <side-menu v-model="drawer" :items="items" :mini="miniVariant">
    </side-menu>

    <top-menu v-model="drawer" :title="viewModel.ApplicationName" :window="viewModel.Window" :mini="miniVariant" @changedMini="changeMini" >
    </top-menu>
    
     <main-application>
     </main-application>

    <application-footer>
    </application-footer>

  </v-app>
</template>

<script>

import sideMenu from './components/sideMenu'
import mainApplication from './components/mainApp'
import applicationFooter from './components/applicationFooter'
import topMenu from './components/topMenu'

const props={
  viewModel: Object,
  __window__: Object
};

export default {
  components:{
      sideMenu,
      mainApplication,
      applicationFooter,
      topMenu
  },
  name: 'app',
  props,
  methods:{
    changeMini(value) {
      this.miniVariant = value
    }
  },
  data () {
    return {
      clipped: false,
      drawer: false,
      fixed: false,
      items: [
        { icon: 'bubble_chart', title: 'Inspire' }
      ],
      miniVariant: false,
    }
  }
}
</script>

<style lang="stylus">
  @import './stylus/main'  
</style>
