import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { AuthContextProvider } from '../Auth/Components/AuthContextProvider'
import { PrivateRoutes } from '../Auth/Components/PrivateRoutes'
import { Admin } from '../Components/Admin'
import { Login } from '../Components/Login'

export function Router() {
	return (
		<AuthContextProvider>
			<Routes>
				<Route path="/login" element={<Login />} />

				<Route element={<PrivateRoutes />}>
					<Route path="/admin" element={<Admin />} />
				</Route>
			</Routes>
		</AuthContextProvider>
	)
}
