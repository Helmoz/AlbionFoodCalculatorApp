<template>
  <div>
    <FoodItemChartLoader :loading="load" />
    <v-chart theme="custom" class="chart" autoresize :options="chart" />
  </div>
</template>

<script>
  import ECharts from 'vue-echarts'
  import 'echarts/lib/chart/line'
  import 'echarts/lib/component/tooltip'
  import 'echarts/lib/component/legend'
  import theme from '../assets/chart-theme.json'
  ECharts.registerTheme('custom', theme)

  import { useStore } from '../composition/useStore'
  import { useFoodItemChart } from '../composition/FoodItemChart'
  import FoodItemChartLoader from '../components/Loaders/FoodItemChartLoader'

  export default {
    components: {
      'v-chart': ECharts,
      FoodItemChartLoader
    },
    setup() {
      const store = useStore()

      return {
        ...useFoodItemChart(store)
      }
    }
  }
</script>

<style>
  .chart {
    width: 100%;
    height: 100%;
    min-height: 350px;
  }
</style>
