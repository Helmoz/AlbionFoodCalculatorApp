import { createHttpLink } from 'apollo-link-http'
import { InMemoryCache } from 'apollo-cache-inmemory'
import { provide } from '@vue/composition-api'
import { DefaultApolloClient } from '@vue/apollo-composable'
import { ApolloClient } from 'apollo-client'

const httpLink = createHttpLink({
  uri: '/graphql'
})

const cache = new InMemoryCache()

const apolloClient = new ApolloClient({
  link: httpLink,
  cache
})

export function provideApollo() {
  provide(DefaultApolloClient, apolloClient)
}
