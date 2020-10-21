<template>
  <div class="container">
    <div v-if="!isBirthday">
      <h1 class="title text-base text-4xl sm:text-6xl">
        Tid til min fødselsdag
      </h1>
      <div class="justify-items-center">
        <div
          class="bg-green-900 m-8 time-box block md:inline-block rounded-lg text-white"
        >
          <p>{{ months }}</p>
          <p>months</p>
        </div>
        <div
          class="bg-green-900 m-8 time-box block md:inline-block rounded-lg text-white"
        >
          <p>{{ days }}</p>
          <p>days</p>
        </div>
        <div
          class="bg-green-900 m-8 time-box block md:inline-block rounded-lg text-white"
        >
          <p>{{ hours }}</p>
          <p>hours</p>
        </div>
        <div
          class="bg-green-900 m-8 time-box block md:inline-block rounded-lg text-white"
        >
          <p>{{ minutes }}</p>
          <p>minutes</p>
        </div>
        <div
          class="bg-green-900 m-8 time-box block md:inline-block rounded-lg text-white"
        >
          <p>{{ seconds }}</p>
          <p>seconds</p>
        </div>
      </div>
    </div>
    <div v-else>
      <h1 class="title text-base text-4xl sm:text-6xl">
        Det er min fødselsdag
      </h1>
      <h1 class="title text-base text-4xl sm:text-6xl">HURRA!!</h1>
    </div>
  </div>
</template>

<script>
const countdown = require('countdown')
export default {
  data() {
    return {
      birthDay: {
        day: 22,
        month: 3,
      },
      seconds: 60,
      minutes: 60,
      hours: 24,
      days: 30,
      months: 12,
      isBirthday: false,
    }
  },
  mounted() {
    this.updateTime()
    window.setInterval(() => this.updateTime(), 1000)
  },
  methods: {
    updateTime() {
      const { day: birthDay, month: birthMonth } = this.birthDay

      const currentDate = new Date()
      let year = currentDate.getFullYear()

      // Check if we are past birthday this year
      if (
        currentDate.getMonth() > birthMonth ||
        (currentDate.getMonth() === birthMonth &&
          currentDate.getDate() > birthDay)
      ) {
        year += 1
      }

      const birthDate = new Date(year, this.birthDay.month, this.birthDay.day)

      const timespan = countdown(currentDate, birthDate)

      if (timespan.months === 0 && timespan.days === 0) {
        this.isBirthday = true

        return
      }

      this.months = timespan.months
      this.days = timespan.days
      this.hours = timespan.hours
      this.minutes = timespan.minutes
      this.seconds = timespan.seconds
    },
  },
}
</script>

<style>
/* Sample `apply` at-rules with Tailwind CSS
.container {
@apply min-h-screen flex justify-center items-center text-center mx-auto;
}
*/
.container {
  margin: 0 auto;
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: flex-start;
  text-align: center;
}

.title {
  margin-top: 20px;
}

.time-box {
  text-align: center;
  min-width: 70px;
}
</style>
