import React, { createContext, useState, useEffect } from 'react';

const initialContextValue = {
    user: null,
    loginUser: () => {
        console.warn("loginUser is not implemented");
    },
    logoutUser: () => {
        console.warn("logoutUser is not implemented");
    },
}

export const UserContext = createContext(initialContextValue);

export const UserProvider = ({ children }) => {
    const [user, setUser] = useState(() => {
        const savedUser = localStorage.getItem("user");
        return savedUser ? JSON.parse(savedUser) : null;
    });

    const loginUser = (userData) => {
        setUser(userData);
        localStorage.setItem("user", JSON.stringify(userData));
    }

    const logoutUser = () => {
        setUser(null);
        localStorage.removeItem("user");
    }

    useEffect(() => {
        if (user) {
            localStorage.setItem("user", JSON.stringify(user));
        } else {
            localStorage.removeItem("user");
        }
    }, [user]);

    return (
        <UserContext.Provider value={{ user, loginUser, logoutUser }} >
            {children}
        </UserContext.Provider>
    );
};