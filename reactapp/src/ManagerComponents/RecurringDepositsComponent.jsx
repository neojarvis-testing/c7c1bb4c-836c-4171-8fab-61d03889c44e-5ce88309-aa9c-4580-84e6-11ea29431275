import React, { useEffect, useState, useContext, useCallback } from 'react';
import { Table, Button } from 'react-bootstrap';
import { UserContext } from '../context/UserContext';
import { apiGetAllRecurringDepositsAsync, apiCloseUserRecurringDepositsAsync } from '../apiConfig'
import { ConfirmToast, Toast, viewAmount, viewDateTime, getBadgeForDepositStatus } from '../lib/common';
import { Form, Col, Row } from 'react-bootstrap';

const RecurringDeposits = () => {
    const [deposits, setDeposits] = useState([]);
    const [allDeposits, setAllDeposits] = useState([]);
    const [filter, setFilter] = useState("All");
    const { user } = useContext(UserContext);

    const loadData = useCallback(async () => {
        var response = await apiGetAllRecurringDepositsAsync(user);
        if (response.success) {
            setAllDeposits(response.data);
        } else {
            setDeposits([]);
        }
    }, [setDeposits, user]);

    useEffect(() => {
        loadData();
    }, [loadData]);

    useEffect(() => {
        if (allDeposits && filter) {
            console.log("filter", filter);
            if (filter !== "All") {
                var data = [...allDeposits].filter((i) => i.status === filter);
                setDeposits(data);
            } else {
                setDeposits([...allDeposits]);
            }
        }
    }, [allDeposits, filter]);

    const closeDeposit = async (rdId) => {
        var confirmTitle = "Close Recurring Deposit";
        var confirmText = "Are you sure you want to close recurring deposit?";
        var successMsg = "Recurring Deposit closed successfully";

        if (await ConfirmToast(confirmTitle, confirmText) === true) {
            var response = await apiCloseUserRecurringDepositsAsync(user.token, rdId);
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
                <h1 className='page_title'> All Recurring Deposits </h1>
                <Row>
                    <Col sm={12} md={5}>
                        <Form.Group as={Row} className='mb-3'>
                            <Form.Label column sm={3}>Status: </Form.Label>
                            <Col sm={8}>
                                <Form.Select id="accountType" value={filter}
                                    onChange={(e) => setFilter(e.target.value)}>
                                    <option value="All">All</option>
                                    <option value="Active">Active</option>
                                    <option value="Closed">Closed</option>
                                    <option value="ClosedPrematuarely">Closed Prematuarely</option>
                                </Form.Select>
                            </Col>
                        </Form.Group>
                    </Col>
                    <Col></Col>
                </Row>
                {(!deposits || deposits.length === 0) &&
                    <div className='message_div'>No Recurring Deposits for filter {filter}</div>
                }
                {deposits && (deposits.length > 0) &&
                    <Table responsive striped bordered>
                        <thead>
                            <tr>
                                <th className='text-end'>FD ID</th>
                                <th className='text-end'>Monthly Deposit</th>
                                <th className='text-end'>Interest Rate</th>
                                <th className='text-end'>Tenture (Months)</th>
                                <th className='text-end'>Matuarity Amount</th>
                                <th>Created Date</th>
                                <th className='text-center'>Status</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {deposits.map((deposit, index) => (
                                <tr key={`deposits_${index}`}>
                                    <td className='text-end'>{deposit.rdId}</td>
                                    <td className='text-end'>{viewAmount(deposit.monthlyDeposit)}</td>
                                    <td className='text-end'>{viewAmount(deposit.interestRate)}</td>
                                    <td className='text-end'>{viewAmount(deposit.tentureMonths)}</td>
                                    <td className='text-end'>{viewAmount(deposit.matuarityAmount)}</td>
                                    <td>{viewDateTime(deposit.dateCreated)}</td>
                                    <td className='text-center'>{getBadgeForDepositStatus(deposit.status)}</td>
                                    <td>
                                        {(deposit.status === "Active") &&
                                            <Button className='grid-button' variant="primary" onClick={() => { 
                                                closeDeposit(deposit.rdId); 
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

export default RecurringDeposits;