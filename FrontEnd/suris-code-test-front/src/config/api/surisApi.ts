import axios from "axios"

export const API_URL = 'https://localhost:7250/api'

const surisApi = axios.create({
    baseURL: API_URL,
    headers: {
        'Content-Type': 'application/json'
    }
});

export {
    surisApi
}