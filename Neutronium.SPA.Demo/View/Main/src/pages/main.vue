<template>
    <main>
      <v-content>
        <v-container fluid>
          <v-slide-y-transition mode="out-in">
            <v-layout column align-center>
              <img src="../assets/v.png" alt="Vuetify.js" class="mb-5" />
              <blockquote>
                &#8220;First, solve the problem. Then, write the code.&#8221;
                <footer>
                  <small>
                    <em>&mdash;John Johnson</em>
                  </small>
                </footer>
              </blockquote>
            </v-layout>
          </v-slide-y-transition>

        <text-button :command="viewModel.GoToAbout" text="Go To About section">
        <text-button>

        </v-container>
      </v-content>
    </main>
</template>

<script>
import textButton from '../components/textButton'

const props={
  viewModel: Object,
}

export default {
  components:{
    textButton
  },
  props
}
</script>

<style>
</style>




