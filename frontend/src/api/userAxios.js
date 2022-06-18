import axios from 'axios';
import { API } from './authAxios';

const GetUserById = async (id, token) => {
    let response = await axios.get(API + "User/" + id, { headers: {"Authorization" : `Bearer ${token}`} });
    return response;
}

export const UpdateUser = async (item, token) => {
    let response = await axios.put(API + "User", item, { headers: {"Authorization" : `Bearer ${token}`} });
    return response;
}

export default GetUserById;
