import { reactive, computed, ref, watch, toRefs } from '@vue/composition-api'

import items from '@/statics/items.json'
import { computedMutation } from '../utils/storeGetter'

export function useFoodType(store) {
	const foodOptions = Object.keys(items)

	const foodTypeState = reactive({
		foodType: ref(foodOptions[0]),
		foodItems: computed(() => items[foodTypeState.foodType]),
		foodItem: computedMutation(store, 'foodItem', 'selectedfoodItem', 'setSelectedfoodItem')
	})

	watch(
		() => foodTypeState.foodType,
		() => (foodTypeState.foodItem = foodTypeState.foodItems[0].name)
	)

	return { ...toRefs(foodTypeState), foodOptions }
}
