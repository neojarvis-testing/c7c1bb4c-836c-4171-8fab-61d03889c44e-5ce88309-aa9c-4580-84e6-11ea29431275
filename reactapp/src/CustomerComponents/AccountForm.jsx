import './AccountForm.css'
import Container from 'react-bootstrap/Container'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Card from 'react-bootstrap/Card'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import { useState, useContext } from 'react';
import { useFormik } from "formik";
import * as Yup from "yup";
import { UserContext } from "../context/UserContext";
import { apiCreateAccountAsync } from '../apiConfig'
import { useNavigate } from 'react-router-dom'
import { Toast, ConfirmToast } from '../lib/common'

const AccountForm = () => {
    var { user } = useContext(UserContext);
    const navigate = useNavigate();
    const [error, setError] = useState(undefined);

    const formik = useFormik({
        initialValues: {
            accountId: 0,
            accountHolderName: "",
            accountType: "Savings",
            balance: 0,
            proofOfIdentity: "",
        },
        validationSchema: Yup.object({
            accountHolderName: Yup.string()
                .required("Account Holder Name is required"),
            accountType: Yup.string()
                .oneOf(["Savings", "Current"], "Invalid account type")
                .required("Account Type is required"),
            balance: Yup.number()
                .min(1, "Balance must be grater than zero")
                .required("Balance is required"),
            proofOfIdentity: Yup.string()
                .required("Proof Of Identity is required"),
        }),
        onSubmit: async (values) => {
            setError("");
            var confirmed = await ConfirmToast(
                "Open New Account",
                "Are you sure you want to open a new account?");
            if (confirmed) {
                var response = await apiCreateAccountAsync(user.token, {
                    ...values,
                    status: "Pending",
                    userId: user.userId
                });
                console.log("response", response);
                if (response.success) {
                    await Toast.fire({
                        icon: "success",
                        title: "Open New Account is Successful!"
                    });
                    navigate("/customer/accounts");
                } else {
                    //setError(response.message);
                    await Toast.fire({
                        icon: "error",
                        title: response.message
                    })
                    setError("Something went wrong, Please try with different data");
                }
            }

        },
    });

    return (
        <>
            <Container>
                <Row>
                    <Col sm={0} md={2} lg={3}></Col>
                    <Col sm={12} md={8} lg={6}>
                        <Card className="p-4 m-4">
                            <Form onSubmit={formik.handleSubmit} noValidate>
                                <Form.Group className='mb-3 text-center'>
                                    <h2>Open New Account</h2>
                                </Form.Group>
                                <Form.Group className='mb-3'>
                                    <Form.Label className=''>Account Holder Name*</Form.Label>
                                    <Form.Control type="text" id="accountHolderName" {...formik.getFieldProps("accountHolderName")} placeHolder="Name" />
                                    {formik.touched.accountHolderName && formik.errors.accountHolderName &&
                                        <Form.Label className='app_error'>{formik.errors.accountHolderName}</Form.Label>
                                    }
                                </Form.Group>
                                <Form.Group className='mb-3'>
                                    <Form.Label className=''>Account Type*</Form.Label>
                                    <Form.Select id="accountType" {...formik.getFieldProps("accountType")} >
                                        <option value="Savings">Savings</option>
                                        <option value="Current">Current</option>
                                    </Form.Select>
                                    {formik.touched.accountType && formik.errors.accountType &&
                                        <Form.Label className='app_error'>{formik.errors.accountType}</Form.Label>
                                    }
                                </Form.Group>
                                <Form.Group className='mb-4'>
                                    <Form.Label className=''>Balance*</Form.Label>
                                    <Form.Control type="number" id="balance" {...formik.getFieldProps("balance")} placeHolder="Balance" />
                                    {formik.touched.balance && formik.errors.balance &&
                                        <Form.Label className='app_error'>{formik.errors.balance}</Form.Label>
                                    }
                                </Form.Group>
                                <Form.Group className='mb-4'>
                                    <Form.Label className=''>Proof Of Identity*</Form.Label>
                                    <Form.Control type="text" id="proofOfIdentity" {...formik.getFieldProps("proofOfIdentity")} placeHolder="Proof Of Identity" />
                                    {formik.touched.proofOfIdentity && formik.errors.proofOfIdentity &&
                                        <Form.Label className='app_error'>{formik.errors.proofOfIdentity}</Form.Label>
                                    }
                                </Form.Group>
                                {error &&
                                    <Form.Group className='app_error'>
                                        <p>{error}</p>
                                    </Form.Group>
                                }
                                <Form.Group className='mb-3'>
                                    <Button type="submit" className='me-2'>Save</Button>
                                    <Button type="button" onClick={() => {
                                        navigate("/customer/accounts")
                                    }}>Cancel</Button>
                                </Form.Group>
                            </Form>
                        </Card>
                    </Col>
                </Row>
            </Container>
        </>
    )
}

export default AccountForm;