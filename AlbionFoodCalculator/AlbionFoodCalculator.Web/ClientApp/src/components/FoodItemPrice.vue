<template>
	<q-field outlined :label="label" stack-label bottom-slots>
		<template v-slot:hint>
			<div class="text-right">обновлена {{ date | moment('from') }}</div>
		</template>
		<template v-slot:control>
			<span>{{ price }}</span>
		</template>
	</q-field>
</template>

<script>
	export default {
		props: {
			label: String,
			price: Number,
			date: String
		}
	}
</script>
