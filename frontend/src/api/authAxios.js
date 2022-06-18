import axios from 'axios';

export const API = "https://localhost:7279/api/";

export const login = async (email, password) => {
    const response = await axios.post(API + "Account/login", { email: email, password: password });
    return response;
}

export const register = async ({ email, password, firstName, secondName, userName }) => {
    const response = await axios.post(API + "Account/register", { email: email, password: password, firstName: firstName, secondName: secondName, userName: userName });
    return response;
}
