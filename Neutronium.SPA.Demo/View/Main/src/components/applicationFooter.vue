<<template>
    <v-footer :fixed="fixed" app>
        <span>&copy; 2017</span>
    </v-footer>
</template>

<script>
const props ={
    fixed:{
      type: Boolean,
      default: false
    }
}

export default {
    props
}
</script>

<style>
</style>

