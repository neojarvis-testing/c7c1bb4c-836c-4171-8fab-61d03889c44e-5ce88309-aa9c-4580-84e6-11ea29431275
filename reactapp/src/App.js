import "./App.css"
import { BrowserRouter, Routes, Route } from "react-router-dom"
import ErrorPage from "./Components/ErrorPage";
import Login from "./Components/Login";

function App() {
    return(
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="login" element={<Login />} />
                    <Route path="*" element={<ErrorPage />} />
                </Routes>
            </BrowserRouter>
        </>
    )
}

export default App;