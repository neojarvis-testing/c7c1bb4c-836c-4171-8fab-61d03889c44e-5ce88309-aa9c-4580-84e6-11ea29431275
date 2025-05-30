import './OpenFDForm.css'
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
import { apiCreateFDAsync } from '../apiConfig'
import { useNavigate, useParams } from 'react-router-dom'
import { Toast, ConfirmToast } from '../lib/common'

const OpenFDForm = () => {
    const { accountId } = useParams();
    var { user } = useContext(UserContext);
    const navigate = useNavigate();
    const [error, setError] = useState(undefined);

    const formik = useFormik({
        initialValues: {
            fDId: 0,
            accountId: accountId,
            principalAmount: 0,
            interestRate: 2.5,
            tentureMonths: 3,
        },
        validationSchema: Yup.object({
            principalAmount: Yup.number()
                .min(1, "Principal Amount must be grater than zero")
                .required("Principal Amount is required"),
            interestRate: Yup.number()
                .min(1, "Interest Rate must be grater than zero")
                .required("Interest Rate is required"),
            tentureMonths: Yup.number()
                .min(1, "Tenture Months must be grater than zero")
                .required("Tenture Months is required"),
        }),
        onSubmit: async (values) => {
            setError("");
            var confirmed = await ConfirmToast(
                "Open FD Account",
                "Are you sure you want to open a new account?");
            if (confirmed) {
                var response = await apiCreateFDAsync(user.token, {
                    ...values,
                    status: "Active",
                    accountId: accountId,
                    userId: user.userId
                });
                console.log("response", response);
                if (response.success) {
                    Toast.fire({
                        icon: "success",
                        title: "Open New FD Account is Successful!"
                    });
                    navigate("/customer/fixeddeposits");
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
                                    <h2>Open New FD Account</h2>
                                </Form.Group>
                                <Form.Group className='mb-3'>
                                    <Form.Label className=''>Principal Amount*</Form.Label>
                                    <Form.Control type="number" id="principalAmount" {...formik.getFieldProps("principalAmount")} placeHolder="Principal Amount" />
                                    {formik.touched.principalAmount && formik.errors.principalAmount &&
                                        <Form.Label className='app_error'>{formik.errors.principalAmount}</Form.Label>
                                    }
                                </Form.Group>
                                <Form.Group className='mb-3'>
                                    <Form.Label className=''>Interest Rate*</Form.Label>
                                    <Form.Control type="number" id="interestRate" {...formik.getFieldProps("interestRate")} placeHolder="Interest Rate" disabled/>
                                    {formik.touched.interestRate && formik.errors.interestRate &&
                                        <Form.Label className='app_error'>{formik.errors.interestRate}</Form.Label>
                                    }
                                </Form.Group>
                                <Form.Group className='mb-3'>
                                    <Form.Label className=''>Tenture Months*</Form.Label>
                                    <Form.Control type="number" id="tentureMonths" {...formik.getFieldProps("tentureMonths")} placeHolder="Tenture Months" />
                                    {formik.touched.tentureMonths && formik.errors.tentureMonths &&
                                        <Form.Label className='app_error'>{formik.errors.tentureMonths}</Form.Label>
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
                                        navigate("/customer/fixeddeposits")
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

export default OpenFDForm;