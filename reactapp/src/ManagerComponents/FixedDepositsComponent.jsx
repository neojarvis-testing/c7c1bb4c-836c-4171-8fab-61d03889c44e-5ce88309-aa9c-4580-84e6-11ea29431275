import React, { useEffect, useState, useContext, useCallback } from 'react';
import { Table, Button } from 'react-bootstrap';
import { UserContext } from '../context/UserContext';
import { apiGetAllFixedDepositsAsync, apiCloseUserFixedDepositsAsync } from '../apiConfig'
import { ConfirmToast, Toast, viewAmount, viewDateTime, getBadgeForDepositStatus } from '../lib/common';
import { Form, Col, Row } from 'react-bootstrap';

const FixedDeposits = () => {
    const [deposits, setDeposits] = useState([]);
    const [allDeposits, setAllDeposits] = useState([]);
    const [filter, setFilter] = useState("All");
    const { user } = useContext(UserContext);

    const loadData = useCallback(async () => {
        var response = await apiGetAllFixedDepositsAsync(user);
        if (response.success) {
            setDeposits(response.data);
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
                <h1 className='page_title'> All Fixed Deposits </h1>
                <Row>
                    <Col sm={12} md={5}>
                        <Form.Group as={Row} className='mb-3'>
                            <Form.Label column sm={3}>Status: </Form.Label>
                            <Col sm={8}>
                                <Form.Select id="accountType" value={filter}
                                    onChange={(e) => setFilter(e.target.value)}>
                                    <option value="All">All</option>
                                    <option value="Closed">Closed</option>
                                    <option value="Active">Active</option>
                                    <option value="ClosedPrematuarely">Closed Prematuarely</option>
                                </Form.Select>
                            </Col>
                        </Form.Group>
                    </Col>
                    <Col></Col>
                </Row>
                {(!deposits || deposits.length === 0) &&
                    <div className='message_div'>No Fixed Deposits for filter {filter}</div>
                }
                {deposits && (deposits.length > 0) &&
                    <>
                        <Table responsive striped bordered>
                            <thead>
                                <tr>
                                    <th className='text-end'>FD ID</th>
                                    <th className='text-end'>Principal Amount</th>
                                    <th className='text-end'>Interest Rate</th>
                                    <th className='text-end'>Tenture (Months)</th>
                                    <th className='text-end'>Matuarity Amount</th>
                                    <th>Created Date</th>
                                    <th>Closed Date</th>
                                    <th className='text-center'>Status</th>
                                    <th>Actions</th>
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
                                        <td>{viewDateTime(deposit.dateClosed)}</td>
                                        <td className='text-center'>{getBadgeForDepositStatus(deposit.status)}</td>
                                        <td>
                                            {(deposit.status === "Active") &&
                                                <Button className='grid-button' variant="primary" onClick={() => {
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
                    </>
                }
            </div>
        </>
    )
}

export default FixedDeposits;