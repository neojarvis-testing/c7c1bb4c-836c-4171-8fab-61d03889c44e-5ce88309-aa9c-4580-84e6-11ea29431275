import { useState, useContext, useCallback, useEffect } from "react";
import { UserContext } from "../context/UserContext";
import { apiGetUserAccountAsync } from '../apiConfig'
import AccountView from "./AccountViewComponent";

const Account = () => {
    const { user } = useContext(UserContext);
    const [accounts, setAccounts] = useState([]);

    const loadData = useCallback(async () => {
        var response = await apiGetUserAccountAsync(user);
        if (response.success) {
            setAccounts(response.data);
        } else {
            setAccounts([]);
        }
    }, [setAccounts, user]);

    useEffect(() => {
        loadData();
    }, [loadData]);

    return (
        <>
            <div className='container'>
                <AccountView accounts={accounts} />
            </div>
        </>
    );
}

export default Account;