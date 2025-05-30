import { useState, useContext, useCallback, useEffect } from "react";
import { UserContext } from "../context/UserContext";
import { apiGetUserAccountAsync } from '../apiConfig'
import AccountView from "./AccountViewComponent";
import { Button, Row, Col } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const Account = () => {
    var navigate = useNavigate();
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
                <Row>
                    <Col>
                        <h1 className='page_title'> Accounts </h1>
                    </Col>
                </Row>
                <Row>
                    <Col className="mb-4">
                        <Button onClick={() => {
                            navigate("create");
                        }}>Open New Account</Button>
                        {(!accounts || accounts.length === 0) &&
                            <div className='message_div'>No accounts were found.</div>
                        }
                    </Col>
                </Row>
                <AccountView accounts={accounts} />
            </div>
        </>
    );
}

export default Account;