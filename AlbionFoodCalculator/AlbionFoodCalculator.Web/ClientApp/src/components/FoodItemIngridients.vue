<template>
  <div class="row">
    <div class="col-xs-7" style="min-height: 350px">
      <q-table :data="resources" v-if="resources" :columns="columns" row-key="name" hide-bottom flat bordered dense>
        <template v-slot:body-cell-name="props">
          <q-td :props="props">
            <div class="text-h6">
              <FoodItemImage :name="props.row.name" :size="50" />
              {{ props.row.name }}
            </div>
          </q-td>
        </template>
        <template v-slot:body-cell-price="props">
          <q-td :props="props">
            <span>{{ props.row.price }}</span>
          </q-td>
        </template>
        <template v-slot:body-cell-totalCount="props">
          <q-td :props="props">
            <span>{{ getTotalCount(props.row.count) }}</span>
          </q-td>
        </template>
        <template v-slot:body-cell-totalItemPrice="props">
          <q-td :props="props">
            <span>{{ props.row.price * getTotalCount(props.row.count) }}</span>
          </q-td>
        </template>
      </q-table>
    </div>
    <!-- <div class="cox-xs-5">
      Затраты : {{ cost }} <br />
      Доходы: {{ income }} <br />
      Прибыль {{ profit }}
    </div> -->
  </div>
</template>

<script>
  import { useStore } from '../composition/useStore'
  import FoodItemImage from '../components/FoodItemImage'
  import { computed } from '@vue/composition-api'
  import { useGQLResult } from '../composition/useGQLResult'
  import resourcesQuery from '../qraphql/queries/resources.query.gql'

  export default {
    components: {
      FoodItemImage
    },
    setup() {
      const store = useStore()
      const columns = [
        {
          name: 'name',
          label: 'Наименование',
          align: 'left',
          sortable: false,
          style: 'min-width: 240px'
        },
        {
          name: 'count',
          label: 'Количество',
          align: 'center',
          field: 'count',
          sortable: false
        },
        { name: 'price', label: 'Цена', align: 'center', sortable: false },
        { name: 'totalCount', label: 'Итого ресурсов', align: 'center', sortable: false },
        { name: 'totalItemPrice', label: 'Затраты', align: 'center', sortable: false }
      ]

      const itemsCount = computed(() => Math.floor(store.getters['craftSettings/itemsCount'] / 10))

      const { result: resources, loading } = useGQLResult(store, resourcesQuery)

      const getTotalCount = count => itemsCount.value * count

      return { getTotalCount, resources, loading, columns }
    }
  }
</script>
