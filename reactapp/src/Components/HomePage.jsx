import { LazyLoadImage } from 'react-lazy-load-image-component';
import 'react-lazy-load-image-component/src/effects/blur.css'
import "./HomePage.css"
import { Row, Col } from 'react-bootstrap';

const HomePage = () => {
    return (
        <>
            <div className="container">
                <div className='cover_image_container'>
                    <LazyLoadImage
                        alt="BTMS"
                        effect="blur"
                        wrapperProps={{
                            style: { TransitionDelay: "1s" },
                        }}
                        src="loancoverimage.jpg" 
                        className="cover_image" />
                </div>
                <Row>
                    <Col>
                        <h2 className='home_title'>BTMS (Banking Transaction Management System</h2>
                        <p> Manage your banking transactions securely and effectively with BTMS</p>
                    </Col>
                    <Col>
                        <h2 className='home_title'>All your banking needs </h2>
                        <ul className='contact_details'>
                            <li>Deposits</li>
                            <li>Withdrawals</li>
                            <li>Transfers</li>
                            <li>Fixed Deposits (FD) and Recurrent Deposits (RD)</li>
                        </ul>
                        <p> under you'r control. </p>
                    </Col>
                </Row>   
                <Row>
                    <Col>
                        <h2 className='home_title'>Contact Us</h2>
                        <ul className='contact_details'>
                            <li><span className='me-2'> &#9993; </span><a href="mailto:support@bankvault.com">support@bankvault.com</a></li>
                            <li><span className='ms-1 me-2'> &#128383;</span><a href="tel:9876543210">987-654-3210</a></li>
                        </ul>
                    </Col>
                </Row>    
            </div>
        </>
    )
}

export default HomePage;