import Vue from 'vue'
import Vuex from 'vuex'

import craftSettings from './CraftSettings'
import foodItem from './FoodItem'
import shared from './Shared'

Vue.use(Vuex)

export default function() {
	const Store = new Vuex.Store({
		modules: {
			craftSettings,
			foodItem,
			shared
		},
		strict: process.env.DEV
	})

	return Store
}
