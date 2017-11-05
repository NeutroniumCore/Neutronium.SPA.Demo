<template>
  <v-navigation-drawer
      :mini-variant="mini"
      :clipped="clipped"
      :value="value"
      @input="drawerChanged"
      app
    >
      <v-list>
        <v-list-tile v-for="(item, i) in items" :key="i" value="true">

          <v-list-tile-action>
            <v-icon light v-html="item.icon"></v-icon>
          </v-list-tile-action>

          <v-list-tile-content>
            <v-list-tile-title v-text="item.title"></v-list-tile-title>
          </v-list-tile-content>

        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
</template>

<script>
const props = {
    items:{
        type: Array,
        required: true
    },
    value:{
      type: Boolean
    },
    mini:{
      type: Boolean,
      default: false
    },
    clipped:{
      type: Boolean,
      default: true
    }
}

export default {
    props,
    methods:{
      drawerChanged(value) {
        this.$emit('input', value)
      }
    }  
}
</script>

<style>

</style>


