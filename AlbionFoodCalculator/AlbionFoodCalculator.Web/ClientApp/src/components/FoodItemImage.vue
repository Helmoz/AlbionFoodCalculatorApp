<template>
  <q-avatar rounded :size="`${size}px`">
    <img transition="fade" :src="`../img/${name}.png`" />
  </q-avatar>
</template>

<script>
  export default {
    props: {
      name: String,
      size: Number
    }
  }
</script>

<style></style>
