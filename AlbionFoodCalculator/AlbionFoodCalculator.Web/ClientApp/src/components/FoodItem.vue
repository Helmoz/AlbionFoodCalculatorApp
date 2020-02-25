<template>
	<div>
		<q-item class="q-pa-none" v-if="foodItem">
			<q-item-section top class="col-xs-2">
				<div class="text-h5 text-dark q-pl-sm">{{ foodItem.name }}</div>
				<FoodItemImage :name="foodItem.name" :size="150" />
			</q-item-section>
			<q-item-section top class="col-xs-3 q-mt-xl">
				<FoodItemPrice label="Минимальная цена продажи" :price="foodItem.sell_price_min" :date="foodItem.sell_price_min_date" />
				<FoodItemPrice label="Максимальная цена покупки" :price="foodItem.buy_price_max" :date="foodItem.buy_price_max_date" class="q-mt-md" />
			</q-item-section>
			<q-item-section class="col-xs-7">
				<FoodItemChart />
			</q-item-section>
		</q-item>
	</div>
</template>

<script>
	import { useStore } from '../composition/useStore'

	import FoodItemImage from '../components/FoodItemImage'
	import FoodItemPrice from '../components/FoodItemPrice'
	import FoodItemChart from '../components/FoodItemChart'

	import { useFoodItem } from '../composition/FoodItem'

	export default {
		components: {
			FoodItemImage,
			FoodItemPrice,
			FoodItemChart
		},
		setup(params, context) {
			const store = useStore()

			return {
				...useFoodItem(store)
			}
		}
	}
</script>
