import { reactive, computed, toRefs } from '@vue/composition-api'

import moment from 'moment'

import { getDefaultChart } from '../utils/chart'

export function useFoodItemChart(store) {
	const foodItemChartState = reactive({
		foodItem: computed(() => store.state.foodItem.foodItem),
		option: computed(() => {
			let chart = getDefaultChart()
			chart.xAxis.data = foodItemChartState.foodItem.history.data.timestamps.map(x => moment(x).format('DD.MM.YYYY'))
			chart.series = []
			chart.series.push({
				name: 'Средняя цена',
				type: 'line',
				data: foodItemChartState.foodItem.history.data.prices_avg,
				smooth: true,
				areaStyle: {}
			})
			chart.series.push({
				name: 'Продано',
				type: 'line',
				smooth: true,
				yAxisIndex: 1,
				data: foodItemChartState.foodItem.history.data.item_count
			})

			return chart
		})
	})

	return { ...toRefs(foodItemChartState) }
}
