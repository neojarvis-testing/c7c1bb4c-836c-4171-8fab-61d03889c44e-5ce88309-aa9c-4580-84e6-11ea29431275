import "./App.css"
import { BrowserRouter, Routes, Route } from "react-router-dom"
import ErrorPage from "./Components/ErrorPage";
import Login from "./Components/Login";
import { UserProvider } from "./context/UserContext";
import PrivateRoute from "./Components/PrivateRoute";
import Layout from "./Components/Layout"
import HomePage from "./Components/HomePage";

function App() {
    return (
        <>
            <UserProvider>
                <BrowserRouter>
                    <Routes>
                        <Route path="login" element={<Login />} />
                        <Route path="/"
                            element={
                                <PrivateRoute>
                                    <Layout />
                                </PrivateRoute>
                            }
                        >
                            <Route index element={<HomePage />} />
                            <Route path="*" element={<ErrorPage />} />
                        </Route>
                    </Routes>
                </BrowserRouter>
            </UserProvider>
        </>
    )
}

export default App;