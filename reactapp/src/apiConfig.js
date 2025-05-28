import axios from 'axios'

const serviceUrl = `${process.env.REACT_APP_GATEWAY_URL}`;

export const apiLoginAsync = async (loginData) => {
    try {
        const response = await axios.post(`${serviceUrl}/api/login`, loginData);
        return { success: true, data: response.data };
    } catch (error) {
        console.log("apiLogin error:", error);
        return { success: false, message: error.response?.data };
    }
}