import React, { useEffect, useState, useContext, useCallback } from 'react';
import { Table, Button } from 'react-bootstrap';
import { UserContext } from '../context/UserContext';
import { apiGetAllAccountAsync, apiUpdateAccountStatusAsync } from '../apiConfig'
import { ConfirmToast, Toast, viewAmount, viewDateTime } from '../lib/common';

const ViewAllAccounts = () => {
    const [accounts, setAccounts] = useState([]);
    const { user } = useContext(UserContext);

    const loadData = useCallback(async () => {
        var response = await apiGetAllAccountAsync(user.token);
        if (response.success) {
            setAccounts(response.data);
        } else {
            setAccounts([]);
        }
    }, [setAccounts, user.token]);

    useEffect(() => {
        loadData();
    }, [loadData]);

    const changeAccountStatus = async (accountId, status) => {
        var confirmTitle = "Activate Account";
        var confirmText = "Are you sure you want to activate account?";
        var successMsg = "Account activated successfully";
        if (status === "Deactivated") {
            confirmTitle = "Deactivate Account";
            confirmText = "Are you sure you want to deactivate account?";
            successMsg = "Account deactivated successfully";
        }

        if (await ConfirmToast(confirmTitle, confirmText) === true) {
            var response = await apiUpdateAccountStatusAsync(user.token, accountId, status);
            if (response.success) {
                Toast.fire({
                    icon: "success",
                    title: successMsg
                });
                loadData();
            }
        }
    }

    return (
        <>
            <div className='container'>
                <h1 className='page_title'> All Accounts </h1>
                {(!accounts || accounts.length === 0) &&
                    <div className='message_div'>No Accounts has created yet</div>
                }
                {accounts && (accounts.length > 0) &&
                    <Table responsive striped bordered>
                        <thead>
                            <tr>
                                <th>Account ID</th>
                                <th>Account Holder</th>
                                <th>Account Type</th>
                                <th className='text-end'>Balance</th>
                                <th>Status</th>
                                <th>Date Created</th>
                                <th>Proof Of Identity</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {accounts.map((account, index) => (
                                <tr key={`all_accounts_${index}`}>
                                    <td>{account.accountId}</td>
                                    <td>{account.accountHolderName}</td>
                                    <td>{account.accountType}</td>
                                    <td className='text-end'>{viewAmount(account.balance)}</td>
                                    <td>{account.status}</td>
                                    <td>{viewDateTime(account.dateCreated)}</td>
                                    <td>{account.proofOfIdentity}</td>
                                    <td>
                                        {(account.status === "Pending" || account.status === "Deactivated") &&
                                            <Button variant="info" onClick={() => { 
                                                changeAccountStatus(account.accountId, "Active"); 
                                            }}>
                                                Activate
                                            </Button>
                                        }

                                        {account.status === "Active" &&
                                            <Button variant="info" onClick={() => { 
                                                changeAccountStatus(account.accountId, "Deactivated"); 
                                            }}>
                                                Dectivate
                                            </Button>
                                        }
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                }
            </div>
        </>
    )
}

export default ViewAllAccounts;