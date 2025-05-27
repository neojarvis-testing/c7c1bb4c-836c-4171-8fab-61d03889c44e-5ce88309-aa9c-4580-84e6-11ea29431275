import './Login.css'
import Container from 'react-bootstrap/Container'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Card from 'react-bootstrap/Card'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'

const Login = () => {
    return (
        <>
            <div className='login_container'>
                <Container>
                    <Row>
                        <Col className='login_gradient p-4'>
                            <h1>Bank Vault</h1>
                            <p>Manage your finance seemlesly with Bank Vault. Login into access your account and perform transactions effectively</p>
                        </Col>
                        <Col className='login_gradient'>
                            <Card className="p-4 m-4">
                                <Form>
                                    <Form.Group className='mb-3 text-center'>
                                        <h2>Login</h2>
                                    </Form.Group>
                                    <Form.Group className='mb-3'>
                                        <Form.Control type="text" placeHolder="Enter Username" />
                                    </Form.Group>
                                    <Form.Group className='mb-4'>
                                        <Form.Control type="password" placeHolder="Enter Password" />
                                    </Form.Group>
                                    <Form.Group className='app_error'>
                                        <p>Don't have an account</p>
                                    </Form.Group>
                                    <Form.Group className='mb-3'>
                                        <Button type="submit" className='w-100'>Login</Button>
                                    </Form.Group>
                                    <Form.Group className='mb-3'>
                                        <p>Don't have an account? <a className='app_link'>Signup</a></p>
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