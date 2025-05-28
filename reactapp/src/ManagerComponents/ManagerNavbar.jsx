const ManagerNavBar = () => {
    return (
        <>
            <li className='nav-item'><a className='nav-link' href='/'>Home</a></li>
            <li className='nav-item'><a className='nav-link' href='/accounts'>Accounts</a></li>
            <li className='nav-item'><a className='nav-link' href='/transactions'>Transactions</a></li>
            <li className='nav-item'><a className='nav-link' href='/fixeddeposits'>Fixed Deposits</a></li>
            <li className='nav-item'><a className='nav-link' href='/recurrentdeposits'>Recurrent Deposits</a></li>
        </>
    )
}

export default ManagerNavBar;