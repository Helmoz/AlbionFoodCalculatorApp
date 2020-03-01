import { reactive, toRefs } from '@vue/composition-api'
import { computedMutation } from '../utils/storeGetter'

export function useCraftSettings(store) {
  const craftSettringsState = reactive({
    city: computedMutation(store, 'craftSettings', 'city', 'setCity'),
    focusUsage: computedMutation(store, 'craftSettings', 'focusUsage', 'setFocusUsage'),
    focusPoints: computedMutation(store, 'craftSettings', 'focusPoints', 'setFocusPoints'),
    itemsCount: computedMutation(store, 'craftSettings', 'itemsCount', 'setItemsCount', () => {
      return store.getters['craftSettings/itemsCount']
    })
  })

  return {
    ...toRefs(craftSettringsState)
  }
}
