import React, { useContext } from 'react';
import { UserContext } from '../context/UserContext';
import { useNavigate } from 'react-router-dom';
import CustomerNavBar from '../CustomerComponents/CustomerNavbar';
import TellerNavBar from '../TellerComponents/TellerNavbar';
import ManagerNavBar from '../ManagerComponents/ManagerNavbar';
import { Badge } from 'react-bootstrap';

export default function Header() {
    const { logoutUser, user } = useContext(UserContext);
    const navigate = useNavigate();

    const handleSignout = () => {
        logoutUser();
        navigate('/login');
    };

    return (
        <header>
            <nav className='navbar navbar-expand-lg navbar-dark bg-dark shadow sticky-top'>
                <div className='container-fluid'>
                    <a className='navbar-brand d-flex align-items-center' href='/'>
                        <img src='logo512.png'
                            alt="Logo"
                            width="40"
                            height="40"
                            className='rounded-circle me2'
                        />
                        <span className='ms-1'>BTMS</span>
                    </a>
                    {/* Mogile togle Button */}
                    <button
                        className='navbar-toggler'
                        type='button'
                        data-bs-toggle="collapse"
                        data-bs-target="#navbarNav"
                        aria-controls="navbarNav"
                        aria-expanded="false"
                        aria-label="Toggle navigation"
                    >
                        <span className='navbar-toggler-icon'></span>
                    </button>
                    {/* Navigation Links */}
                    <div className='collapse navbar-collapse' id="navbarNav">
                        <ul className='navbar-nav ms-auto'>
                            { user.userRole === "Customer" && <CustomerNavBar />}
                            { user.userRole === "Manager" && <ManagerNavBar />}
                            { user.userRole === "Teller" && <TellerNavBar />}
                            <li>
                                <span className='notification_icon'>&#128276;</span>
                                <span className='notification_count'>2</span>
                            </li>
                            {/* User dropdown */}
                            <li className='nav-item dropdown'>
                                <a className='nav-link dropdown-toggle d-flex align-items-center'
                                    href='/'
                                    id="navbarDropdown"
                                    role="button"
                                    data-bs-toggle="dropdown"
                                    aria-expanded="false"
                                >
                                    <img src="logo192.png"
                                        alt="User"
                                        width="30"
                                        height="30"
                                        className='rounded-circle me-2'
                                    />
                                    <span className='me-2'>{user ? user.name : ""}</span>
                                    <Badge bg="dark">{user ? user.userRole : ""}</Badge>
                                </a>
                                <ul className='dropdown-menu dropdown-menu-end' aria-labelledby='navbarDropdown'>
                                    <li>
                                        <a className='dropdown-item' href='/' onClick={() => handleSignout()}>Log out</a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
    )
}