import { getAction } from '../../utils/action'
import * as api from '../api/foodItem'

export async function getFoodItemData({ commit, rootState }, selectedfoodItem) {
	getAction(commit, 'setFoodItem', api.getFoodItemData(selectedfoodItem, rootState.craftSettings.city))
}
