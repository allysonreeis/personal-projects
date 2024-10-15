import Keycloak from 'keycloak-js'

const KeycloakConfig = new Keycloak({
  realm: 'ByteShop-Realm',
  url: 'http://localhost:8080',
  clientId: 'public-ecommerce-client',
})

export default KeycloakConfig
