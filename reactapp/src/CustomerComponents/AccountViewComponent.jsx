import { Card, Row, Col, Badge, Button, Alert } from 'react-bootstrap';
import { viewAmount, viewDateTime, getBadgeBgForStatus } from '../lib/common';
import "./AccountViewComponent.css"

const AccountView = ({ accounts }) => {
    const renderAcccount = (account, index) => {
        return (
            <>
                <Col sm={12} md={6}>
                    <Card className='m-2 p-4'>
                        <Card.Body>
                            <Card.Title>
                                <div bg="secondary" className='account_type'>{account.accountType}</div>

                                <Row>
                                    <Col className='light_label'>
                                        Account Holder Name
                                    </Col>
                                    <Col className='light_label text-end'>
                                        Balance
                                    </Col>
                                </Row>
                                <Row>
                                    <Col>
                                        {account.accountHolderName}
                                    </Col>
                                    <Col className='text-end'>
                                        {viewAmount(account.balance)}
                                    </Col>
                                </Row>
                                <Row>
                                    <Col className='light_label mt-4'>
                                        Status
                                    </Col>
                                    <Col className='light_label text-end mt-4'>
                                        Creation Date
                                    </Col>
                                </Row>
                                <Row>
                                    <Col>
                                        <Badge bg={getBadgeBgForStatus(account.status)}>{account.status}</Badge>
                                    </Col>
                                    <Col className='text-end p-2' style={{ fontSize: "14px" }}>
                                        {viewDateTime(account.dateCreated)}
                                    </Col>
                                </Row>
                                <Row>
                                    <Col className="mt-4">
                                        {account.status === "Active" && (<>
                                            <Button className='me-2'>Open Fixed Deposit</Button>
                                            <Button>Open Recurring Deposit</Button>
                                        </>)}
                                        {account.status !== "Active" && (<>
                                            <Alert className='font-small m-0 p-2' key="account_inactive" variant="warning">
                                                Account is not active
                                            </Alert>
                                        </>)}
                                    </Col>
                                </Row>
                            </Card.Title>
                        </Card.Body>
                    </Card>
                </Col>
            </>
        );
    };

    return (
        <>
            {accounts && (accounts.length > 0) &&
                <>
                    <Row>
                        {accounts.map((account, index) => (
                            renderAcccount(account, index)
                        ))}
                    </Row>
                </>
            }
        </>
    );
}

export default AccountView;