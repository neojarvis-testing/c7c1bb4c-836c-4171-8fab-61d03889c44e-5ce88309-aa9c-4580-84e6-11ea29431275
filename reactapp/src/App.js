import "./App.css"
import { BrowserRouter, Routes, Route } from "react-router-dom"
import ErrorPage from "./Components/ErrorPage";
import Login from "./Components/Login";
import Signup from "./Components/Signup";
import { UserProvider } from "./context/UserContext";
import PrivateRoute from "./Components/PrivateRoute";
import Layout from "./Components/Layout"
import HomePage from "./Components/HomePage";
// Mnager
import ViewAllAccounts from "./ManagerComponents/ViewAllAccountsComponent"
// Customer
import Account from "./CustomerComponents/AccountComponent";
import AccountForm from "./CustomerComponents/AccountForm"
import OpenFDForm from "./CustomerComponents/OpenFDForm";
import FixedDeposit from "./CustomerComponents/FixedDepositComponent";
import RecurringDeposit from "./CustomerComponents/RecurringDepositComponent";
import OpenRDForm from "./CustomerComponents/OpenRDForm";

function App() {
    return (
        <>
            <UserProvider>
                <BrowserRouter>
                    <Routes>
                        <Route path="login" element={<Login />} />
                        <Route path="signup" element={<Signup />} />
                        <Route path="/"
                            element={
                                <PrivateRoute>
                                    <Layout />
                                </PrivateRoute>
                            }
                        >
                            <Route index element={<HomePage />} />
                            {/* Manager */}
                            <Route path="/manager/accounts" element={<ViewAllAccounts />} />
                            {/* Customer */}
                            <Route path="/customer/accounts" element={<Account />} />
                            <Route path="/customer/accounts/create" element={<AccountForm />} />  
                            <Route path="/customer/fixeddeposits" element={<FixedDeposit />} />
                            <Route path="/customer/fixeddeposits/create/:accountId" element={<OpenFDForm />} />
                            <Route path="/customer/recurringdeposits" element={<RecurringDeposit />} />
                            <Route path="/customer/recurringdeposits/create/:accountId" element={<OpenRDForm />} />
                            <Route path="*" element={<ErrorPage />} />
                        </Route>
                    </Routes>
                </BrowserRouter>
            </UserProvider>
        </>
    )
}

export default App;