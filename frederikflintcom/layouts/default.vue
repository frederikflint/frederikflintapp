<template>
  <div>
    <nav class="flex items-center justify-between flex-wrap bg-green-900 p-6">
      <div class="flex items-center flex-shrink-0 text-white mr-6">
        <v-btn icon class="mr-2" @click="showSideBar = true">
          <v-icon>mdi-menu</v-icon>
        </v-btn>
        <router-link v-slot="{ navigate }" to="/#">
          <button
            class="font-semibold text-xl tracking-tight"
            @click="navigate"
          >
            frederikflint.com
          </button></router-link
        >
      </div>
    </nav>
    <v-navigation-drawer
      v-model="showSideBar"
      color="#22543d"
      class="bg-green-900"
      absolute
      temporary
    >
      <v-list class="text-white" dense nav>
        <router-link
          v-for="item in items"
          :key="item.title"
          v-slot="{ navigate }"
          class="text-white"
          :to="item.to"
        >
          <v-list-item link>
            <v-list-item-icon class="mr-2" @click="navigate">
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-item-icon>

            <v-list-item-title class="text-white ml-2" @click="navigate">{{
              item.title
            }}</v-list-item-title>
          </v-list-item>
        </router-link>
      </v-list></v-navigation-drawer
    >
    <Nuxt />
  </div>
</template>

<script>
export default {
  data() {
    return {
      showSideBar: false,
      items: [
        { icon: 'mdi-shower', title: 'Showerthoughts', to: '/showerthoughts' },
      ],
    }
  },
}
</script>

<style>
html {
  font-family: 'Source Sans Pro', -apple-system, BlinkMacSystemFont, 'Segoe UI',
    Roboto, 'Helvetica Neue', Arial, sans-serif;
  font-size: 16px;
  word-spacing: 1px;
  -ms-text-size-adjust: 100%;
  -webkit-text-size-adjust: 100%;
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  box-sizing: border-box;
}

*,
*::before,
*::after {
  box-sizing: border-box;
  margin: 0;
}

.button--green {
  display: inline-block;
  border-radius: 4px;
  border: 1px solid #3b8070;
  color: #3b8070;
  text-decoration: none;
  padding: 10px 30px;
}

.button--green:hover {
  color: #fff;
  background-color: #3b8070;
}

.button--grey {
  display: inline-block;
  border-radius: 4px;
  border: 1px solid #35495e;
  color: #35495e;
  text-decoration: none;
  padding: 10px 30px;
  margin-left: 15px;
}

.button--grey:hover {
  color: #fff;
  background-color: #35495e;
}
</style>
