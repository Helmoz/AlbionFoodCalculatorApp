<template>
	<transition name="fade">
		<div class="loading" v-if="loading">
			<svg role="img" width="1000" height="350" aria-labelledby="loading-aria" viewBox="0 0 1000 350" preserveAspectRatio="none">
				<title id="loading-aria">Loading...</title>
				<rect x="0" y="0" width="100%" height="100%" clip-path="url(#clip-path)" style="fill:url(#fill);" />
				<defs>
					<clipPath id="clip-path">
						<rect x="8" y="0" rx="0" ry="0" width="250" height="32" />
						<rect x="12" y="44" rx="20" ry="20" width="122" height="122" />
						<rect x="175" y="48" rx="0" ry="0" width="250" height="56" />
						<rect x="215" y="110" rx="0" ry="0" width="210" height="15" />
						<rect x="175" y="140" rx="0" ry="0" width="250" height="56" />
						<rect x="215" y="202" rx="0" ry="0" width="210" height="15" />
						<rect x="433" y="0" rx="0" ry="0" width="584" height="350" />
					</clipPath>
					<linearGradient id="fill">
						<stop offset="0.599964" stop-color="#f9f9f9" stop-opacity="1">
							<animate attributeName="offset" values="-2; -2; 1" keyTimes="0; 0.25; 1" dur="1s" repeatCount="indefinite" />
						</stop>
						<stop offset="1.59996" stop-color="#ecebeb" stop-opacity="1">
							<animate attributeName="offset" values="-1; -1; 2" keyTimes="0; 0.25; 1" dur="1s" repeatCount="indefinite" />
						</stop>
						<stop offset="2.59996" stop-color="#f9f9f9" stop-opacity="1">
							<animate attributeName="offset" values="0; 0; 3" keyTimes="0; 0.25; 1" dur="1s" repeatCount="indefinite" />
						</stop>
					</linearGradient>
				</defs>
			</svg>
		</div>
	</transition>
</template>

<script>
	import { useStore } from '../composition/useStore'
	import { computed } from '@vue/composition-api'
	import { ContentLoader } from 'vue-content-loader'

	export default {
		setup() {
			const store = useStore()
			const loading = computed(() => store.state.shared.loading)

			return {
				loading
			}
		}
	}
</script>

<style>
	.loading {
		background: rgba(255, 255, 255, 1);
		display: flex;
		justify-content: center;
		align-items: center;
		width: 100%;
		height: 100%;
		z-index: 5;
		position: absolute;
		transition: 1s;
		top: 0;
		left: 0;
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
