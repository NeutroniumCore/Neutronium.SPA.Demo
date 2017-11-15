<template>
    <main>
        <v-content>
            <v-flex xs12 sm6 offset-sm3>
            <v-card>
                <v-card-media :src="require('../assets/logo.png')" height="200px" contain>
                </v-card-media>
                <v-card-title primary-title>
                <div>
                    <h3 class="headline mb-0">{{ $t("Resource.ProjectDescription") }}</h3>
                    <div>Located two hours south of Sydney in the <br>Southern Highlands of New South Wales, ...</div>
                </div>
                </v-card-title>
                <v-card-actions>
                <v-btn flat color="orange">Share</v-btn>
                <v-btn flat color="orange">Explore</v-btn>
                </v-card-actions>
            </v-card>
            </v-flex>
        </v-content>
    </main>
</template>

<script>
const props={
  viewModel: Object,
}

export default {
  props
}
</script>

<style>

</style>
