<template>
  <transition name="fade">
    <div class="loading" v-if="loading">
      <svg role="img" width="100%" height="100%" aria-labelledby="loading-aria" preserveAspectRatio="none">
        <title id="loading-aria">Loading...</title>
        <rect x="0" y="0" width="100%" height="100%" clip-path="url(#clip-path3)" style="fill:url(#fill);" />
        <defs>
          <clipPath id="clip-path3">
            <rect x="0" y="0" rx="20" ry="20" width="100%" height="350" />
          </clipPath>
        </defs>
      </svg>
    </div>
  </transition>
</template>

<script>
  export default {
    name: 'FoodItemChartLoader',
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
    left: 50%;
    height: 100%;
    width: 50%;
    z-index: 5;
    margin-left: 16px;
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