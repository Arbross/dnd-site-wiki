import { Outlet, useLocation, useNavigate } from "react-router-dom"
import jwt_decode  from "jwt-decode";
import { useEffect } from "react";

export const checkToken = () => {
    let isExpired = false;
    const token = localStorage.getItem('token');

    if (token == null)
    {
        return true;
    }

    let decodedToken = jwt_decode(token, { complete: true });
    let dateNow = new Date();

    if(decodedToken.exp < dateNow.getTime())
        isExpired = true;

    return isExpired;
}

const Layout = () => {
    const navigate = useNavigate();
    const location = useLocation();

    const LoadPage = () => {
        if (checkToken())
        {
            if (location.pathname === "/")
            {
                navigate("/login");
            }
        }
        else if (!checkToken())
        {
            if (location.pathname === "/login" || location.pathname === "/register")
            {
                navigate("/home");
            }
        }
    }

    useEffect(() => {
        LoadPage();
    }, []);

    return (
        <main>
            <Outlet/>
        </main>
    )
}

export default Layout;