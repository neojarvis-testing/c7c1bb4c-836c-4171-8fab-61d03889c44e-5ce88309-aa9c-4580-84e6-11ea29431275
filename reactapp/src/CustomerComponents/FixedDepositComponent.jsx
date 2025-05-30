import React, { useEffect, useState, useContext, useCallback } from 'react';
import { Table, Button } from 'react-bootstrap';
import { UserContext } from '../context/UserContext';
import { apiGetUserFixedDepositsAsync, apiCloseUserFixedDepositsAsync } from '../apiConfig'
import { ConfirmToast, Toast, viewAmount, viewDateTime, getBadgeForDepositStatus } from '../lib/common';

const FixedDeposit = () => {
    const [deposits, setDeposits] = useState([]);
    const { user } = useContext(UserContext);

    const loadData = useCallback(async () => {
        var response = await apiGetUserFixedDepositsAsync(user);
        if (response.success) {
            setDeposits(response.data);
        } else {
            setDeposits([]);
        }
    }, [setDeposits, user]);

    useEffect(() => {
        loadData();
    }, [loadData]);

    const closeDeposit = async (fdId) => {
        var confirmTitle = "Close Fixed Deposit";
        var confirmText = "Are you sure you want to close fixed deposit?";
        var successMsg = "Fixed Deposit closed successfully";

        if (await ConfirmToast(confirmTitle, confirmText) === true) {
            var response = await apiCloseUserFixedDepositsAsync(user.token, fdId);
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
                <h1 className='page_title'> Fixed Deposits </h1>
                {(!deposits || deposits.length === 0) &&
                    <div className='message_div'>No Fixed Deposits has created yet</div>
                }
                {deposits && (deposits.length > 0) &&
                    <Table responsive striped bordered>
                        <thead>
                            <tr>
                                <th className='text-end'>FD ID</th>
                                <th className='text-end'>Principal Amount</th>
                                <th className='text-end'>Interest Rate</th>
                                <th className='text-end'>Tenture (Months)</th>
                                <th className='text-end'>Matuarity Amount</th>
                                <th>Created Date</th>
                                <th className='text-center'>Status</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {deposits.map((deposit, index) => (
                                <tr key={`deposits_${index}`}>
                                    <td className='text-end'>{deposit.fdId}</td>
                                    <td className='text-end'>{viewAmount(deposit.principalAmount)}</td>
                                    <td className='text-end'>{viewAmount(deposit.interestRate)}</td>
                                    <td className='text-end'>{viewAmount(deposit.tentureMonths)}</td>
                                    <td className='text-end'>{viewAmount(deposit.matuarityAmount)}</td>
                                    <td>{viewDateTime(deposit.dateCreated)}</td>
                                    <td className='text-center'>{getBadgeForDepositStatus(deposit.status)}</td>
                                    <td>
                                        {(deposit.status === "Active") &&
                                            <Button variant="info" onClick={() => {
                                                closeDeposit(deposit.fdId);
                                            }}>
                                                Close
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

export default FixedDeposit;