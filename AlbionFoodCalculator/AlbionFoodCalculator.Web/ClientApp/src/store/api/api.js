import axios from 'axios'

export const api = axios.create({
	baseURL: 'https://albion-food-calculator.herokuapp.com/api',
	headers: {
		'Access-Control-Allow-Origin': '*',
		'Access-Control-Allow-Methods': 'GET,HEAD,OPTIONS,POST,PUT',
		'Access-Control-Allow-Headers': 'Origin, X-Requested-With, Content-Type, Accept, Authorization'
	}
})
