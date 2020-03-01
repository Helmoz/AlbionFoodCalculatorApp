<template>
  <transition name="fade">
    <div class="loading" v-if="loading">
      <svg role="img" width="100%" height="100%" aria-labelledby="loading-aria" preserveAspectRatio="none">
        <title id="loading-aria">Loading...</title>
        <rect x="0" y="0" width="100%" height="100%" clip-path="url(#clip-path2)" style="fill:url(#fill);" />
        <defs>
          <clipPath id="clip-path2">
            <rect x="0" y="48" rx="10" ry="10" width="100%" height="56" />
            <rect x="30%" y="110" rx="0" ry="0" width="70%" height="15" />
            <rect x="0" y="140" rx="10" ry="10" width="100%" height="56" />
            <rect x="30%" y="202" rx="0" ry="0" width="70%" height="15" />
          </clipPath>
        </defs>
      </svg>
    </div>
  </transition>
</template>

<script>
  export default {
    name: 'FoodItemPriceLoader',
    props: {
      loading: Boolean
    }
  }
</script>

<style scoped>
  .loading {
    position: absolute;
    top: 0;
    background-color: #fff;
    height: 100%;
    width: 25%;
    z-index: 5;
  }
  .fade-enter-active,
  .fade-leave-active {
    transition: opacity 1s;
  }
  .fade-enter,
  .fade-leave-to {
    opacity: 0;
  }
</style>