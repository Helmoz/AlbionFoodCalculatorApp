<template>
  <transition name="fade">
    <div class="loading" v-if="loading">
      <svg role="img" width="100%" height="100%" aria-labelledby="loading-aria" preserveAspectRatio="none">
        <title id="loading-aria">Loading...</title>
        <rect x="0" y="0" width="100%" height="100%" clip-path="url(#clip-path)" style="fill:url(#fill);" />
        <defs>
          <clipPath id="clip-path">
            <rect x="8" y="0" rx="5" ry="5" width="250" height="32" />
            <rect x="10" y="45" rx="20" ry="20" width="125" height="125" />
          </clipPath>
          <linearGradient id="fill">
            <stop offset="0.599964" stop-color="#f9f9f9" stop-opacity="1">
              <animate attributeName="offset" values="-2; -2; 1" keyTimes="0; 0.25; 1" dur="2s" repeatCount="indefinite" />
            </stop>
            <stop offset="1.59996" stop-color="#ecebeb" stop-opacity="1">
              <animate attributeName="offset" values="-1; -1; 2" keyTimes="0; 0.25; 1" dur="2s" repeatCount="indefinite" />
            </stop>
            <stop offset="2.59996" stop-color="#f9f9f9" stop-opacity="1">
              <animate attributeName="offset" values="0; 0; 3" keyTimes="0; 0.25; 1" dur="2s" repeatCount="indefinite" />
            </stop>
          </linearGradient>
        </defs>
      </svg>
    </div>
  </transition>
</template>

<script>
  export default {
    name: 'FoodItemNameLoader',
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
    left: 0;
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