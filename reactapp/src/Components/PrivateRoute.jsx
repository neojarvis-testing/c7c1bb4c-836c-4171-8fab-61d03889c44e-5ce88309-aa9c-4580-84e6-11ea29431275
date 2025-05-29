import { useNavigate } from "react-router-dom";
import { UserContext } from "../context/UserContext"
import { useEffect, useContext } from "react";

const PrivateRoute = ({ children }) => {
    const { user } = useContext(UserContext);
    const navigate = useNavigate();

    useEffect(() => {
        if (!user) {
            navigate("/login");
        }
    }, [user, navigate]);

    if (!user) {
        return null;
    }

    return children;
};

export default PrivateRoute;