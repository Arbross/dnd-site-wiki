import axios from 'axios';
import { API } from './authAxios';

export const GetOrganizations = async (token) => {
    let response = await axios.get(API + "Organization", { headers: {"Authorization" : `Bearer ${token}`} });
    return response;
}

export const CreateOrganization = async (item, token) => {
    let response = await axios.post(API + "Organization", item, { headers: {"Authorization" : `Bearer ${token}`} });
    return response;
}

export const RemoveOrganization = async (id, token) => {
    let response = await axios.delete(API + "Organization/" + id, { headers: {"Authorization" : `Bearer ${token}`} });
    return response;
}