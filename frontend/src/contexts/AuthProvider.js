import { createContext } from "react";

const AuthContext = createContext({});

export const AuthProvider = ({ children }) => {
    const loadToStorage = ({ token, roles, userId }) => {
        window.sessionStorage.setItem("token", token);
        window.sessionStorage.setItem("roles", roles);
        window.sessionStorage.setItem("userId", userId);
    }

    const auth = () => {
        return {
            token: window.sessionStorage.getItem("token"),
            roles: JSON.parse(window.sessionStorage.getItem("roles")),
            userId: window.sessionStorage.getItem("userId")
        };
    }

    return (
        <AuthContext.Provider value={{ loadToStorage, auth }}>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthContext;