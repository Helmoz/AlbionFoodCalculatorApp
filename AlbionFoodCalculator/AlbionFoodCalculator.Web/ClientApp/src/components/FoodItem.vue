<template>
  <q-item class="q-pa-none" v-if="foodItem">
    <q-item-section top class="col-xs-3">
      <FoodItemNameLoader :loading="loading" />
      <div class="text-h5 text-dark q-pl-sm">{{ foodItem.name }}</div>
      <FoodItemImage :name="foodItem.name" :size="150" />
    </q-item-section>
    <q-item-section top class="col-xs-3 q-mt-xl">
      <FoodItemPriceLoader :loading="loading" />
      <FoodItemPrice label="Минимальная цена продажи" :price="foodItem.minimalSellPrice" :date="foodItem.minimalSellPriceDate" />
      <FoodItemPrice label="Максимальная цена покупки" :price="foodItem.maximalBuyPrice" :date="foodItem.maximalBuyPriceDate" class="q-mt-md" />
    </q-item-section>
    <q-item-section class="col-xs-6">
      <FoodItemChart />
    </q-item-section>
  </q-item>
</template>

<script>
  import { useStore } from '../composition/useStore'

  import FoodItemImage from '../components/FoodItemImage'
  import FoodItemPrice from '../components/FoodItemPrice'
  import FoodItemChart from '../components/FoodItemChart'
  import FoodItemNameLoader from '../components/Loaders/FoodItemNameLoader'
  import FoodItemPriceLoader from '../components/Loaders/FoodItemPriceLoader'

  import { useGQLResult } from '../composition/useGQLResult'
  import foodItemQuery from '../qraphql/queries/foodItem.query.gql'

  export default {
    components: {
      FoodItemImage,
      FoodItemPrice,
      FoodItemChart,
      FoodItemNameLoader,
      FoodItemPriceLoader
    },
    setup(_, context) {
      const store = useStore()

      const { result: foodItem, loading } = useGQLResult(store, foodItemQuery)

      return { foodItem, loading }
    }
  }
</script>
