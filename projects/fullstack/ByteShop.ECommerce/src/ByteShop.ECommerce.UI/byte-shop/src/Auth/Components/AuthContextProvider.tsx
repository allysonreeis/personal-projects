import { createContext, useEffect, useState } from 'react'
import KeycloakConfig from '../Keycloak.config'

export const AuthContext = createContext({
	token: '',
})

export function AuthContextProvider({ children }: any) {
	const [token, setToken] = useState('')

	useEffect(() => {
		exhangeAuthCode()
	}, [])

	const exhangeAuthCode = async () => {
		try {
			const isInitializationSuccessful = await KeycloakConfig.init({ onLoad: 'check-sso' })

			if (isInitializationSuccessful) {
				const authorizationCode = new URLSearchParams(window.location.search).get('code')
				const url = new URL('http://localhost:5084/api/auth')

				url.searchParams.append('code', authorizationCode!)

				const response = await fetch(url, {
					method: 'GET',
				}).then((response) => response.json())

				console.log('TOKEN', response)

				setToken(response)
			}
		} catch (error) {
			console.error('Failed to initialize adapter')
		}
	}

	return <AuthContext.Provider value={{ token }}>{children}</AuthContext.Provider>
}
