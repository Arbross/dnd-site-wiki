import axios from 'axios';
import { API } from './authAxios';

export const GetSpells = async (token) => {
    let response = await axios.get(API + "Spell", { headers: {"Authorization" : `Bearer ${token}`} });
    return response;
}

export const CreateSpell = async (item, token) => {
    let response = await axios.post(API + "Spell", item, { headers: {"Authorization" : `Bearer ${token}`} });
    return response;
}

export const RemoveSpell = async (id, token) => {
    let response = await axios.delete(API + "Spell/" + id, { headers: {"Authorization" : `Bearer ${token}`} });
    return response;
}
