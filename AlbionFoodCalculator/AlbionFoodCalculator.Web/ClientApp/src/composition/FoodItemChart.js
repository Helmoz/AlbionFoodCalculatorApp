import { computed } from '@vue/composition-api'
import moment from 'moment'
import { getDefaultChart } from '../utils/chart'
import { useGQLResult } from './useGQLResult'
import historyQuery from '../qraphql/queries/history.query.gql'

export function useFoodItemChart(store) {
  const { result: history, loading: load } = useGQLResult(store, historyQuery)

  const chart = computed(() => {
    let chart = getDefaultChart()
    chart.xAxis.data = history.value && history.value.timestamps.map(x => moment(x).format('DD.MM.YYYY'))
    chart.series = []
    chart.series.push({
      name: 'Средняя цена',
      type: 'line',
      data: history.value && history.value.pricesAverage,
      smooth: true,
      areaStyle: {}
    })
    chart.series.push({
      name: 'Продано',
      type: 'line',
      smooth: true,
      yAxisIndex: 1,
      data: history.value && history.value.itemCount
    })

    return chart
  })

  return { chart, load }
}
