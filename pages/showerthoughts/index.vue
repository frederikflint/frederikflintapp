<template>
  <v-container>
    <v-card>
      <v-card-title>Random showerthought</v-card-title>
      <v-card-subtitle
        ><a href="https://www.reddit.com/r/Showerthoughts/" target="_blank">
          <v-btn style="padding: 0 0 0 0" text>Visit r/showerthoughts</v-btn>
        </a></v-card-subtitle
      >
      <v-card-text> {{ showerthought }}</v-card-text>
      <v-card-actions>
        <v-btn text @click="fetchShowerthought"> NEW </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      showerthought: 'Fetching...',
    }
  },
  mounted() {
    this.fetchShowerthought()
  },
  methods: {
    fetchShowerthought() {
      this.$axios
        .get('http://www.reddit.com/r/showerthoughts/random.json')
        .then((res) => {
          console.log(res)
          this.showerthought = res.data[0].data.children[0].data.title
        })
    },
  },
}
</script>
