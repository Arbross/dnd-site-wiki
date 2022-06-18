import { useLocation, Navigate, Outlet } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
import Header from '../page_parts/header';
import Footer from '../page_parts/footer';
import { useEffect } from "react";
import { checkToken } from "../page_parts/layout";

const RequireAuth = ({ allowedRoles }) => {
    const { auth } = useAuth();
    const location = useLocation();

    useEffect(() => {
        if (!checkToken())
        {
            sessionStorage.setItem('token', null);
            sessionStorage.setItem('userId', null);
            sessionStorage.setItem('roles', null);
            window.location.reload(false);
        }
    }, []);

    return (
        auth()?.roles?.find(role => allowedRoles?.includes(role))
            ? <LoadPage />
            : auth()?.userId
                ? <Navigate to="/unauthorized" state={{ from: location }} replace />
                : <Navigate to="/login" state={{ from: location }} replace />
    );
}

const LoadPage = () => {
    return(
        <>
            <Header />
            <Outlet />
            <Footer />
        </>
    );
}

export default RequireAuth;