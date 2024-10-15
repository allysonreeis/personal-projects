import { useContext, useEffect, useState } from 'react'
import KeycloakConfig from '../Auth/Keycloak.config'
import { Navigate } from 'react-router-dom'
import { AuthContext } from '../Auth/Components/AuthContextProvider'

export function Login() {
	const { token } = useContext(AuthContext)
	const [isAuthenticated, setIsAuthenticated] = useState(false)

	//KeycloakConfig.login()
	useEffect(() => {
		KeycloakConfig.login()
		if (KeycloakConfig.authenticated) {
			setIsAuthenticated(true)
		}
	}, [])

	// return (
	// 	<div>
	// 		<h1>Login: </h1>
	// 		<p>{token}</p>
	// 	</div>
	// )

	return <Navigate to="/admin" />
}
