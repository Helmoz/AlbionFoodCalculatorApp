const path = require('path')

function extendWebpackAliases(cfg) {
	cfg.resolve.alias['~'] = __dirname
	cfg.resolve.alias['@'] = path.resolve(__dirname, 'src')
}

module.exports = function(ctx) {
	return {
		boot: ['axios', 'composition-api', 'moment'],

		css: ['app.sass'],

		extras: ['roboto-font', 'material-icons'],

		framework: {
			iconSet: 'material-icons',
			lang: 'en-us',
			all: 'auto',

			components: [],
			directives: [],

			plugins: ['Loading']
		},

		supportIE: false,

		build: {
			scopeHoisting: true,
			vueRouterMode: 'history',
			showProgress: true,
			gzip: false,
			analyze: false,

			extendWebpack(cfg) {
				extendWebpackAliases(cfg),
					cfg.module.rules.push({
						enforce: 'pre',
						test: /\.(js|vue)$/,
						loader: 'eslint-loader',
						exclude: /node_modules/,
						options: {
							formatter: require('eslint').CLIEngine.getFormatter('stylish')
						}
					})
			}
		},

		devServer: {
			https: false,
			port: 8080,
			open: true
		},

		animations: [],

		ssr: {
			pwa: false
		}
	}
}
