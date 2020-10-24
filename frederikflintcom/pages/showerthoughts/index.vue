<template>
  <v-container>
    <v-card width="100%">
      <v-card-title>Random showerthought</v-card-title>
      <v-card-subtitle style="text-align: left"
        ><a href="https://www.reddit.com/r/Showerthoughts/" target="_blank">
          <v-btn style="padding: 0 0 0 0" text>Visit r/showerthoughts</v-btn>
        </a></v-card-subtitle
      >
      <v-card-text style="text-align: left"> {{ showerthought }}</v-card-text>
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
      this.$axios.get('showerthoughts').then((res) => {
        console.log(res)
        this.showerthought = res.data
      })
    },
  },
}
</script>
