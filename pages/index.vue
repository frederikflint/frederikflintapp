<template>
  <div class="container">
    <div>
      <h1 class="title text-base text-4xl sm:text-6xl">
        Tid til min fødselsdag
      </h1>
      <div class="justify-items-center">
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
  </div>
</template>

<script>
export default {
  data() {
    return {
      birthDay: {
        day: 22,
        month: 4,
      },
      seconds: 60,
      minutes: 60,
      hours: 24,
      days: 999,
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
      const currentMonth = currentDate.getMonth()

      let year = currentDate.getFullYear()

      // Check if we are past birthday this year
      if (
        currentMonth > birthMonth ||
        (currentMonth === birthMonth && currentDate.getDay() > birthDay)
      ) {
        year += 1
      }

      const birthDate = new Date(year, birthMonth, birthDay)

      const totalSecondsToBirthday = (birthDate - currentDate) / 1000

      this.days = Math.floor(totalSecondsToBirthday / (60 * 60 * 24))
      this.hours = Math.floor(
        (totalSecondsToBirthday - this.days * 60 * 60 * 24) / (60 * 60)
      )
      this.minutes = Math.floor(
        (totalSecondsToBirthday -
          (this.hours * 60 * 60 + this.days * 60 * 60 * 24)) /
          60
      )

      this.seconds = Math.floor(
        totalSecondsToBirthday -
          (this.minutes * 60 + this.hours * 60 * 60 + this.days * 60 * 60 * 24)
      )
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
