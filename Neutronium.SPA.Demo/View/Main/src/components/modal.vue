<template>
  <v-dialog v-model="value" v-if="viewModel">
      <v-card>
        <v-card-title class="headline">{{viewModel.Title}}}</v-card-title>
        <v-card-text>{{viewModel.Message}}</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <text-button color="green darken-1" :command="viewModel.CancelCommand" @afterExecute="close()">Disagree</text-button>
          <text-button color="green darken-1" :command="viewModel.OkCommand" @afterExecute="close()>Agree</text-button>
        </v-card-actions>
      </v-card>
    </v-dialog>
</template>

<script>
import textButton from '../components/textButton'


const props={
    value:{
        type:Boolean,
        default:true
    },
    viewModel:{
        required:true
    }
}

export default {
  components:{
      textButton
  },
  props,
  methods:{
      close(){
          this.$emit('input',false);
      }
  }
}
</script>
<style>

</style>
