import { Navigate, Outlet } from 'react-router-dom'

export function PrivateRoutes() {
	const isAuthenticated = true
	return isAuthenticated ? <Outlet /> : <Navigate to="/login" />
}
