import './Signup.css'
import Container from 'react-bootstrap/Container'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Card from 'react-bootstrap/Card'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import { useEffect, useState, useContext } from 'react';
import { useFormik } from "formik";
import * as Yup from "yup";
import { UserContext } from "../context/UserContext";
import { apiRegisterAsync } from '../apiConfig'
import { useNavigate } from 'react-router-dom'
import { Toast } from '../lib/common'

const Signup = () => {
    var { user } = useContext(UserContext);
    const navigate = useNavigate();
    const [error, setError] = useState(undefined);

    const formik = useFormik({
        initialValues: {
            email: "",
            username: "",
            mobileNumber: "",
            userRole: "Customer",
            password: "",
            confirmPassword: ""
        },
        validationSchema: Yup.object({
            email: Yup.string()
                .email("Invalid email address")
                .required("Email is required"),
            mobileNumber: Yup.string()
                .matches(/^\d{10}$/, "Phone number must be exactly 10 digits.")
                .required("Phone number is required"),
            userRole: Yup.string()
                .oneOf(["Customer", "Teller", "Manager"], "Invalid role")
                .required("Role is required"),
            password: Yup.string()
                .min(6, "Password must be at least 6 characters")
                .required("Password is required"),
            confirmPassword: Yup.string()
                .oneOf([Yup.ref("password"), undefined], "Passwords must match")
                .required("Confirm Password is required"),
        }),
        onSubmit: async (values) => {
            setError("");
            var response = await apiRegisterAsync({...values, username: values.email});
            console.log("response", response);
            if (response.success) {
                //loginUser(response.data);
                await Toast.fire({
                    icon: "success",
                    title: "User Registration is Successful!"
                });
                navigate("/");
            } else {
                //setError(response.message);
                await Toast.fire({
                    icon: "error",
                    title: response.message
                })
                setError("Something went wrong, Please try with different data");
            }
        },
    });

    useEffect(() => {
        if (user) navigate("/home");
    })

    return (
        <>
            <div className='signup_container'>
                <Container>
                    <Row>
                        <Col className='signup_gradient'>
                            <Card className="p-4 m-4">
                                <Form onSubmit={formik.handleSubmit} noValidate>
                                    <Form.Group className='mb-3 text-center'>
                                        <h2>Signup</h2>
                                    </Form.Group>
                                    <Form.Group className='mb-3'>
                                        <Form.Label className=''>Email*</Form.Label>
                                        <Form.Control type="text" id="email" {...formik.getFieldProps("email")} placeHolder="Email" />
                                        {formik.touched.email && formik.errors.email &&
                                            <Form.Label className='app_error'>{formik.errors.email}</Form.Label>
                                        }
                                    </Form.Group>
                                    <Form.Group className='mb-3'>
                                        <Form.Label className=''>Mobile Number*</Form.Label>
                                        <Form.Control type="text" id="mobileNumber" {...formik.getFieldProps("mobileNumber")} placeHolder="Mobile Number" />
                                        {formik.touched.mobileNumber && formik.errors.mobileNumber &&
                                            <Form.Label className='app_error'>{formik.errors.mobileNumber}</Form.Label>
                                        }
                                    </Form.Group>
                                    <Form.Group className='mb-3'>
                                        <Form.Label className=''>Role*</Form.Label>
                                        <Form.Select id="role" {...formik.getFieldProps("userRole")} >
                                            <option value="Customer">Customer</option>
                                            <option value="Teller">Teller</option>
                                            <option value="Manager">Manager</option>
                                        </Form.Select>
                                        {formik.touched.userRole && formik.errors.userRole &&
                                            <Form.Label className='app_error'>{formik.errors.userRole}</Form.Label>
                                        }
                                    </Form.Group>
                                    <Form.Group className='mb-4'>
                                        <Form.Label className=''>Password*</Form.Label>
                                        <Form.Control type="password" id="password" {...formik.getFieldProps("password")} placeHolder="Password" />
                                        {formik.touched.password && formik.errors.password &&
                                            <Form.Label className='app_error'>{formik.errors.password}</Form.Label>
                                        }
                                    </Form.Group>
                                    <Form.Group className='mb-4'>
                                        <Form.Label className=''>Confirm Password*</Form.Label>
                                        <Form.Control type="password" id="confirmPassword" {...formik.getFieldProps("confirmPassword")} placeHolder="Confirm Password" />
                                        {formik.touched.confirmPassword && formik.errors.confirmPassword &&
                                            <Form.Label className='app_error'>{formik.errors.confirmPassword}</Form.Label>
                                        }
                                    </Form.Group>
                                    { error &&
                                    <Form.Group className='app_error'>
                                        <p>{error}</p>
                                    </Form.Group>
                                    }
                                    <Form.Group className='mb-3'>
                                        <Button type="submit" className='w-100'>Signup</Button>
                                    </Form.Group>
                                    <Form.Group className='mb-3'>
                                        <p>Already have an Account? <a className='app_link' href='/login'>Login</a></p>
                                    </Form.Group>
                                </Form>
                            </Card>
                        </Col>
                    </Row>
                </Container>
            </div>

        </>
    )
}

export default Signup;