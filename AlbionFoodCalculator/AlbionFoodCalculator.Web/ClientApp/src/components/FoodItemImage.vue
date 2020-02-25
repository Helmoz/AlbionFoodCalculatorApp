<template>
	<q-avatar rounded :size="`${size}px`">
		<q-img transition="fade" :src="require(`@/assets/foodItems/${name}.png`)">
			<template v-slot:loading>
				<q-spinner-gears size="30px" color="white" />
			</template>
		</q-img>
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
