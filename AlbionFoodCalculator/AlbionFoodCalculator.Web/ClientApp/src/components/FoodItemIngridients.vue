<template>
	<div class="row">
		<div class="col-xs-7" style="min-height: 350px">
			<q-table :data="foodItem.resourses" v-if="foodItem" :columns="columns" row-key="name" hide-bottom flat bordered dense>
				<template v-slot:body-cell-name="props">
					<q-td :props="props">
						<div class="text-h6">
							<FoodItemImage :name="props.row.resource.name" :size="50" />
							{{ props.row.resource.name }}
						</div>
					</q-td>
				</template>
				<template v-slot:body-cell-price="props">
					<q-td :props="props">
						<span>{{ props.row.resource.price }}</span>
					</q-td>
				</template>
				<template v-slot:body-cell-totalCount="props">
					<q-td :props="props">
						<span>{{ getTotalCount(props.row.count) }}</span>
					</q-td>
				</template>
				<template v-slot:body-cell-totalItemPrice="props">
					<q-td :props="props">
						<span>{{ props.row.resource.price * getTotalCount(props.row.count) }}</span>
					</q-td>
				</template>
			</q-table>
		</div>
	</div>
</template>

<script>
	import { useStore } from '../composition/useStore'
	import { useFoodItemIngridients } from '../composition/FoodItemIngridients'
	import FoodItemImage from '../components/FoodItemImage'

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
			return {
				...useFoodItemIngridients(store),
				columns
			}
		}
	}
</script>
