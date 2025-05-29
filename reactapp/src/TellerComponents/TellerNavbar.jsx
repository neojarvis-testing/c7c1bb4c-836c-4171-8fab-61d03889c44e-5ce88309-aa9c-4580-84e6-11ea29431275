import { useEffect, useContext } from "react";
import { UserContext } from "../context/UserContext";
import { useNavigate } from "react-router-dom";

const TellerNavBar = () => {
    const { user } = useContext(UserContext);
    var navigate = useNavigate();

    useEffect(() => {
        if (user.userRole !== "Teller")
        {
            navigate("/");
        }
    }, [user.userRole, navigate]);

    return (
        <>
            <li className='nav-item'><a className='nav-link' href='/'>Home</a></li>
            <li className='nav-item'><a className='nav-link' href='/about'>About</a></li>
        </>
    )
}

export default TellerNavBar;