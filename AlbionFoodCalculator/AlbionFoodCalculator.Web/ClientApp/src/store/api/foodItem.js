import { api } from './api'

export async function getFoodItemData(selectedfoodItem, city) {
	return api.get(`/Price/GetFoodItemInfo?name=${selectedfoodItem}&city=${city}`)
}
