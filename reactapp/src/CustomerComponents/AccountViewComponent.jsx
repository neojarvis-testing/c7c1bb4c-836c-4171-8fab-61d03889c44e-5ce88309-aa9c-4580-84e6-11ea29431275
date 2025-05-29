import { Card, Row, Col, Badge } from 'react-bootstrap';
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
                            </Card.Title>
                            <Card.Text>

                            </Card.Text>
                        </Card.Body>

                    </Card>
                </Col>
            </>

        );
    };

    return (
        <>
            <h1 className='page_title'> Accounts </h1>
            {(!accounts || accounts.length === 0) &&
                <div className='message_div'>No accounts were found.</div>
            }
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