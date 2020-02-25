<template>
	<q-page>
		<q-card square bordered flat>
			<q-card-section>
				<CraftSettings />
			</q-card-section>
		</q-card>
		<q-card square bordered flat style="margin-top: -1px">
			<q-card-section>
				<FoodType />
			</q-card-section>
		</q-card>
		<q-card square bordered flat style="margin-top: -1px">
			<q-card-section>
				<q-tabs v-model="tab" dense active-color="primary" indicator-color="primary" align="justify" narrow-indicator>
					<q-tab name="price" label="Цена" />
					<q-tab name="ingridients" label="Ингридиенты" />
				</q-tabs>
				<q-separator />
				<q-tab-panels transition-prev="fade" transition-next="fade" keep-alive v-model="tab" animated>
					<q-tab-panel name="price" style="min-height: 350px">
						<Loading />
						<FoodItem />
					</q-tab-panel>
					<q-tab-panel name="ingridients">
						<Loading />
						<FoodItemIngridients />
					</q-tab-panel>
				</q-tab-panels>
			</q-card-section>
		</q-card>
	</q-page>
</template>

<script>
	import CraftSettings from '../components/CraftSettings'
	import FoodType from '../components/FoodType'
	import FoodItem from '../components/FoodItem'
	import FoodItemIngridients from '../components/FoodItemIngridients'
	import Loading from '../components/Loading'

	import { useStore } from '../composition/useStore'

	import { computedMutation } from '../utils/storeGetter'

	import { ref, toRefs, reactive } from '@vue/composition-api'

	export default {
		name: 'PageIndex',
		components: {
			CraftSettings,
			FoodType,
			FoodItem,
			FoodItemIngridients,
			Loading
		},
		setup() {
			const store = useStore()
			const tab = ref('price')
			return {
				tab
			}
		}
	}
</script>
