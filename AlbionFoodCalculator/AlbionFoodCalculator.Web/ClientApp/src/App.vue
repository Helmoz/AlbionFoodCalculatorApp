<template>
  <div id="q-app">
    <router-view />
  </div>
</template>

<script>
  import { provideStore } from '@/composition/useStore'
  import { provideApollo } from '@/qraphql/client'

  export default {
    setup(_, { root: { $store, $axios } }) {
      provideStore($store)
      provideApollo()
    },
    name: 'App'
  }
</script>
