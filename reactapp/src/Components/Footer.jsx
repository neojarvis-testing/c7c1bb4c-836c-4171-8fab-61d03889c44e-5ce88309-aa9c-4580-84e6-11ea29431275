import React from 'react';

export default function Footer() {
    return (
        <footer className='bg-dark text-white text-center py-3  mt-auto sticky-bottom-footer'>
            <div className='container-fluid'>
                <p className='mb-0 text-white'>
                    Copyright &copy; { new Date().getFullYear() } BTMS.
                </p>
            </div>
        </footer>
    )
};