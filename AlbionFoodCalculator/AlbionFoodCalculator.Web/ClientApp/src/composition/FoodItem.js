import { reactive, computed, watch, toRefs } from '@vue/composition-api'

export function useFoodItem(store) {
	const foodItemState = reactive({
		selectedfoodItem: computed(() => store.state.foodItem.selectedfoodItem),
		foodItem: computed(() => store.state.foodItem.foodItem),
		city: computed(() => store.state.craftSettings.city)
	})

	watch([() => foodItemState.selectedfoodItem, () => foodItemState.city], () => {
		store.dispatch('foodItem/getFoodItemData', foodItemState.selectedfoodItem)
	})

	return { ...toRefs(foodItemState) }
}
