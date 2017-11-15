<template>
    <v-toolbar id="top-menu"  app >

        <v-toolbar-side-icon @click.stop="toggleMenu"></v-toolbar-side-icon>

        <v-toolbar-title v-text="title"></v-toolbar-title>

        <v-spacer></v-spacer>

        <icon-button :command="window.Minimize" icon="remove">
        </icon-button>

        <icon-button :command="window.Normalize" :icon="middleIcon">
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

    computed:{
        middleIcon(){
            return (this.window.State.displayName == 'Normal') ? 'fa-window-maximize' : 'fa-window-restore'
        }
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
