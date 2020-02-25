import { reactive, computed, toRefs } from '@vue/composition-api'

export function useFoodItemIngridients(store) {
	const foodItemIngridientState = reactive({
		foodItem: computed(() => store.state.foodItem.foodItem),
		itemsCount: computed(() => store.state.craftSettings.itemsCount)
	})

	const getTotalCount = count => (foodItemIngridientState.itemsCount / 10) * count

	return { ...toRefs(foodItemIngridientState), getTotalCount }
}
