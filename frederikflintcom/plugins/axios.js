export default function ({ $axios }) {
  $axios.onRequest((config) => {
    config.baseURL = '/api'
  })

  $axios.onResponseError((error) => {
    return Promise.resolve(error)
  })
}
