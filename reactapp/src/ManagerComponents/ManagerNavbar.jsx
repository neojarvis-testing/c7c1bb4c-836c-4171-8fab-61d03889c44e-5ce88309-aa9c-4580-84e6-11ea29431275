import { useEffect, useContext } from "react";
import { UserContext } from "../context/UserContext";
import { useNavigate } from "react-router-dom";

const ManagerNavBar = () => {
    const { user } = useContext(UserContext);
    var navigate = useNavigate();

    useEffect(() => {
        if (user.userRole !== "Manager")
        {
            navigate("/");
        }
    }, [user.userRole, navigate]);

    return (
        <>
            <li className='nav-item'><a className='nav-link' href='/'>Home</a></li>
            <li className='nav-item'><a className='nav-link' href='/manager/accounts'>Accounts</a></li>
            <li className='nav-item'><a className='nav-link' href='/manager/transactions'>Transactions</a></li>
            <li className='nav-item'><a className='nav-link' href='/manager/fixeddeposits'>Fixed Deposits</a></li>
            <li className='nav-item'><a className='nav-link' href='/manager/recurringdeposits'>Recurring Deposits</a></li>
        </>
    )
}

export default ManagerNavBar;