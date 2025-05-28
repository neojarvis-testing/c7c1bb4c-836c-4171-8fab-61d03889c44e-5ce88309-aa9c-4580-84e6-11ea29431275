import "./ErrorPage.css"

const ErrorPage = () => {
    return(
        <>
            <div className="error_container">
                <img src="/alert.png" alt="Warning" className="alert_icon"/>
                <h1>Oops! Something Went Wrong</h1>
                <p>Please try again later</p>
            </div>
        </>
    )
}

export default ErrorPage;