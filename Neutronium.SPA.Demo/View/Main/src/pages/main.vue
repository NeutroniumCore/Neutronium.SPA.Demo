<template>
    <main>
      <v-content>
        <v-container fluid>

        <v-layout>
          <v-flex xs12 sm6 offset-sm3>
            <v-card>
              <v-toolbar color="blue" dark>
                <v-toolbar-title>{{$t('Resource.ToDoList')}}</v-toolbar-title>
              </v-toolbar>
              <v-list two-line transition="slide-y-transition">
                <transition-group name="slide-y-transition">
                  <template v-for="item in viewModel.Items">
                    <v-list-tile :key="item.Id">
                      <v-list-tile-content>
                        <v-list-tile-title>
                        <span class="grey--text">{{item.Name}}</span>
                        </v-list-tile-title>
                        <v-list-tile-sub-title>
                          <v-checkbox v-model="item.Done" :label="item.Done? $t('Resource.Completed') : $t('Resource.ToDo')" light></v-checkbox>
                        </v-list-tile-sub-title>
                      </v-list-tile-content>
                      <v-list-tile-action>
                        <icon-button :command="viewModel.RemoveItem" :arg="item" icon="fa-trash"></icon-button>
                      </v-list-tile-action>
                    </v-list-tile>
                    <v-divider :key="item.Id"></v-divider>
                  </template>
                </transition-group>
              </v-list>

               <v-toolbar color="red" dark>
                <v-text-field  v-model="viewModel.Name" name="input-1" :label="$t('Resource.WhatNeedsToBeDone')" @keyup.native.enter="enter"></v-text-field>
                <icon-button :command="viewModel.AddItem" icon="fa-plus-circle"></icon-button>
              </v-toolbar>
            </v-card>

            <text-button :command="viewModel.GoToAbout" :text="$t('Resource.GoToAboutSection')">
            </text-button>

            <text-button :command="viewModel.Restart" :text="$t('Resource.Restart')" color="error">
            </text-button>

          </v-flex>
        </v-layout>

        </v-container>
      </v-content>
    </main>
</template>

<script>
import textButton from '../components/textButton'
import iconButton from '../components/IconButton'

const props={
  viewModel: Object,
}

export default {
  components:{
    textButton,
    iconButton
  },
  methods:{
    enter(){
      const command = this.viewModel.AddItem;
      if (command)
        command.Execute()
    }
  },
  props
}
</script>

<style>
</style>




