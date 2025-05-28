import './Login.css'
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
import { apiLoginAsync } from '../apiConfig'
import { useNavigate } from 'react-router-dom'

const Login = () => {
    var { user, loginUser } = useContext(UserContext);
    const navigate = useNavigate();
    const [error, setError] = useState(undefined);

    const formik = useFormik({
        initialValues: {
            email: "",
            password: ""
        },
        validationSchema: Yup.object({
            email: Yup.string()
                .email("Invalid email address")
                .required("Email is required"),
            password: Yup.string()
                .min(6, "Password must be at least 6 characters")
                .required("Password is required"),
        }),
        onSubmit: async (values) => {
            
            setError("");
            var response = await apiLoginAsync(values);
            console.log("response", response);
            if (response.success) {
                loginUser(response.data);
                navigate("/");
            } else {
                setError(response.message);
            }
        },
    });

    useEffect(() => {
        if (user) navigate("/home");
    })

    return (
        <>
            <div className='login_container'>
                <Container>
                    <Row>
                        <Col className='login_gradient p-4'>
                            <h1>BTMS</h1>
                            <p>Manage your finance seemlesly with BTMS. Login into access your account and perform transactions effectively</p>
                        </Col>
                        <Col className='login_gradient'>
                            <Card className="p-4 m-4">
                                <Form onSubmit={formik.handleSubmit} noValidate>
                                    <Form.Group className='mb-3 text-center'>
                                        <h2>Login</h2>
                                    </Form.Group>
                                    <Form.Group className='mb-3'>
                                        <Form.Control type="text" id="email" {...formik.getFieldProps("email")} placeHolder="Email" />
                                        {formik.touched.email && formik.errors.email &&
                                            <Form.Label className='app_error'>{formik.errors.email}</Form.Label>
                                        }
                                    </Form.Group>
                                    <Form.Group className='mb-4'>
                                        <Form.Control type="password" id="password" {...formik.getFieldProps("password")} placeHolder="Password" />
                                        {formik.touched.password && formik.errors.password &&
                                            <Form.Label className='app_error'>{formik.errors.password}</Form.Label>
                                        }
                                    </Form.Group>
                                    { error &&
                                    <Form.Group className='app_error'>
                                        <p>{error}</p>
                                    </Form.Group>
                                    }
                                    <Form.Group className='mb-3'>
                                        <Button type="submit" className='w-100'>Login</Button>
                                    </Form.Group>
                                    <Form.Group className='mb-3'>
                                        <p>Don't have an account? <a className='app_link' href='/signup'>Signup</a></p>
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

export default Login;