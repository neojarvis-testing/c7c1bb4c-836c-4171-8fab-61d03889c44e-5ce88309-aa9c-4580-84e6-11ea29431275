import { Outlet } from "react-router-dom";
import Header from "./Header"
import Footer from "./Footer"

const Layout = () => {
    return (
        <div className="layout-container">
            <Header />
            <main className="content"
                style={{
                    //backgroundColor: "#212529",
                    marginTop: "1px",
                    marginBottom: "1px",
                    //color: "white",
                    minHeight: "400px",
                    paddingBottom: "80px",
                }}
            >
                <Outlet />
            </main>
            <Footer />
        </div>
    )
}

export default Layout;