import axios from 'axios';
import { API } from './authAxios';

export const GetItems = async (token) => {
    let response = await axios.get(API + "Item", { headers: {"Authorization" : `Bearer ${token}`} });
    return response;
}

export const CreateItem = async (item, token) => {
    let response = await axios.post(API + "Item", item, { headers: {"Authorization" : `Bearer ${token}`} });
    return response;
}

export const RemoveItem = async (id, token) => {
    let response = await axios.delete(API + "Item/" + id, { headers: {"Authorization" : `Bearer ${token}`} });
    return response;
}
