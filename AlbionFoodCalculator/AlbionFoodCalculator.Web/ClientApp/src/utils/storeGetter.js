import { computed } from '@vue/composition-api'

export function computedMutation(store, moduleName, propertyName, mutationName, getFunction) {
	const defaultGetFunction = () => store.state[moduleName][propertyName]
	const property = computed({
		get: getFunction || defaultGetFunction,
		set: value => store.commit(`${moduleName}/${mutationName}`, value)
	})

	return property
}
