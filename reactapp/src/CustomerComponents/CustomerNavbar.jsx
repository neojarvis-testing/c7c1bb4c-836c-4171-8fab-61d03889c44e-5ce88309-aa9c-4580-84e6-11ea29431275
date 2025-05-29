import { useEffect, useContext } from "react";
import { UserContext } from "../context/UserContext";
import { useNavigate } from "react-router-dom";
import { Dropdown, DropdownButton } from 'react-bootstrap';

const CustomerNavBar = () => {
    const { user } = useContext(UserContext);
    var navigate = useNavigate();

    useEffect(() => {
        if (user.userRole !== "Customer") {
            navigate("/");
        }
    }, [user.userRole, navigate]);

    return (
        <>
            <li className='nav-item'><a className='nav-link' href='/'>Home</a></li>
            <li className='nav-item'><a className='nav-link' href='/customer/accounts'>Accounts</a></li>
            <li className='nav-item'><a className='nav-link' href='/customer/fixeddeposits'>Fixed Deposits</a></li>
            <li className='nav-item'><a className='nav-link' href='/customer/recurringdeposits'>Recurring Deposits</a></li>
            <li className='nav-item'>
                <DropdownButton variant="secondary" title="Transactions">
                    <Dropdown.Item href="/customer/transaction">Make Transaction</Dropdown.Item>
                    <Dropdown.Item href="/customer/viewtransactions">View Transaction History</Dropdown.Item>
                </DropdownButton>

            </li>
        </>
    )
}

export default CustomerNavBar;