export function itemsCount(state, _, rootState) {
  if (rootState.craftSettings.focusUsage) {
    return Math.floor(rootState.craftSettings.focusPoints / 100)
  }
  return state.itemsCount
}
