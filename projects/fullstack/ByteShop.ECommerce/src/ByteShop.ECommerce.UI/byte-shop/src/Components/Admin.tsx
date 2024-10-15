import { useContext } from 'react'
import { AuthContext } from '../Auth/Components/AuthContextProvider'

export function Admin() {
	const { token } = useContext(AuthContext)

	return (
		<div>
			<h1>Admin: </h1>
			<p>{token}</p>
		</div>
	)
}
