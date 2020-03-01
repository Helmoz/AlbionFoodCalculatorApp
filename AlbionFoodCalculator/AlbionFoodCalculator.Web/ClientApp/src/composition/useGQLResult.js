import { useQuery, useResult } from '@vue/apollo-composable'
import { reactive, computed } from '@vue/composition-api'

export function useGQLResult(store, query) {
  const variables = reactive({
    name: computed(() => store.state.foodItem.selectedfoodItem),
    city: computed(() => store.state.craftSettings.city)
  })

  const { result: response, loading } = useQuery(query, variables, { fetchPolicy: 'no-cache' })
  const result = useResult(response)

  return { result, loading }
}
