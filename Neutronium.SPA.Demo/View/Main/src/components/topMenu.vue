<template>
    <v-toolbar id="top-menu" fixed app>

        <v-toolbar-side-icon @click.stop="toggleMenu"></v-toolbar-side-icon>

        <v-toolbar-title v-text="title"></v-toolbar-title>

        <v-spacer></v-spacer>

        <icon-button :command="window.Minimize" icon="remove">
        </icon-button>

        <icon-button :command="window.Normalize" icon="fa-window-restore">
        </icon-button>

        <icon-button :command="window.Close" icon="close">
        </icon-button>

    </v-toolbar>
</template>

<script>
import iconButton from './IconButton'

const props = {
    value:{
      type: Boolean,
      required: true
    },
    title:{
      type: String,
      required: false
    },
    window:{
      type: Object,
      required: true
    }
}

export default {
    props,

    components:{
        iconButton
    },

    methods:{
        toggleMenu(){
            this.$emit('input', !this.value)
        }
    }
}
</script>

<style>
#top-menu > div{
  -webkit-app-region: drag;
}

#top-menu > div > button{
  -webkit-app-region: no-drag;
}
</style>
