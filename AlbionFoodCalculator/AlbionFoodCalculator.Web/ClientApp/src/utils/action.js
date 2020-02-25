export async function getAction(commit, mutationName, getFunction) {
	commit('shared/setLoading', true, { root: true })
	getFunction
		.then(response => {
			const data = response.data
			commit(mutationName, data)
		})
		.catch(() => {})
		.finally(() => {
			commit('shared/setLoading', false, { root: true })
		})
}
