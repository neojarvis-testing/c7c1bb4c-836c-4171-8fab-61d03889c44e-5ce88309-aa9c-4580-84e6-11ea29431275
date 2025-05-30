import axios from 'axios'

const serviceUrl = `${process.env.REACT_APP_GATEWAY_URL}`;

export const apiLoginAsync = async (loginData) => {
    try {
        const response = await axios.post(`${serviceUrl}/api/login`, loginData);
        return { success: true, data: response.data };
    } catch (error) {
        console.error("apiLogin error:", error);
        return { success: false, message: error.response?.data };
    }
}

export const apiRegisterAsync = async (userData) => {
    try {
        const response = await axios.post(`${serviceUrl}/api/register`, userData);
        return { success: true, data: response.data };
    } catch (error) {
        console.error("apiRegisterAsync error:", error);
        return { success: false, message: error.response?.data };
    }
}

// Accounts

export const apiGetAllAccountAsync = async (token) => {
    try {
        const response = await axios.get(`${serviceUrl}/api/account`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        return { success: true, data: response.data };
    } catch (error) {
        console.error("apiGetAllAccountAsync error:", error);
        return { success: false, message: error.response?.data };
    }
}

export const apiGetUserAccountAsync = async (user) => {
    try {
        const response = await axios.get(`${serviceUrl}/api/account/user/${user.userId}`, {
            headers: {
                'Authorization': `Bearer ${user.token}`
            }
        });
        return { success: true, data: response.data };
    } catch (error) {
        console.error("apiGetUserAccountAsync error:", error);
        return { success: false, message: error.response?.data };
    }
}

export const apiUpdateAccountStatusAsync = async (token, accountId, status) => {
    try {
        const response = await axios.patch(`${serviceUrl}/api/account/${accountId}`, 
        {
            status: status
        }, 
        {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        return { success: true, data: response.data };
    } catch (error) {
        console.error("apiUpdateAccountStatusAsync error:", error);
        return { success: false, message: error.response?.data };
    }
}

export const apiCreateAccountAsync = async (token, account) => {
    try {
        const response = await axios.post(`${serviceUrl}/api/account`, account, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        return { success: true, data: response.data };
    } catch (error) {
        console.error("apiCreateAccountAsync error:", error);
        return { success: false, message: error.response?.data };
    }
}