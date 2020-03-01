import Vue from 'vue'
import Vuex from 'vuex'

import craftSettings from './CraftSettings'
import foodItem from './FoodItem'

Vue.use(Vuex)

export default function() {
  const Store = new Vuex.Store({
    modules: {
      craftSettings,
      foodItem
    },
    strict: process.env.DEV
  })

  return Store
}
