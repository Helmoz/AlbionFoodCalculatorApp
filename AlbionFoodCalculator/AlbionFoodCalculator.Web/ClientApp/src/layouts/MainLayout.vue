<template>
	<q-layout view="lHh Lpr lFf">
		<q-header elevated>
			<q-toolbar>
				<q-toolbar-title>Albion Food Calculator</q-toolbar-title>
			</q-toolbar>
		</q-header>

		<q-page-container>
			<div class="fit row wrap justify-center items-center content-center">
				<div class="col-xs-12 col-sm-8">
					<router-view />
				</div>
			</div>
		</q-page-container>
	</q-layout>
</template>

<script>
	export default {
		name: 'MainLayout',
		setup() {
			return {}
		}
	}
</script>
