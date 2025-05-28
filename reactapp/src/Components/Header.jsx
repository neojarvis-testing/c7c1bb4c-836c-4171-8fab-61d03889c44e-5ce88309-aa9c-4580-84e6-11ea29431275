import React, { useContext } from 'react';
import { UserContext } from '../context/UserContext';
import { useNavigate } from 'react-router-dom';

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
                            <li className='nav-item'><a className='nav-link' href='/'>Home</a></li>
                            <li className='nav-item'><a className='nav-link' href='/about'>About</a></li>
                            {/* User dropdown */}
                            <li className='nav-item dropdown'>
                                <a className='nav-link dropdown-toggle d-flex align-items-center'
                                    href='#'
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
                                    <span>{user ? user.name : ""}</span>
                                </a>
                                <ul className='dropdown-menu dropdown-menu-end' aria-labelledby='navbarDropdown'>
                                    <li>
                                        <a className='dropdown-item' href='#' onClick={() => handleSignout()}>Log out</a>
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