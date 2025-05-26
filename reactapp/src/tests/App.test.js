import React from 'react';
import { render, fireEvent, screen } from '@testing-library/react';
import { BrowserRouter as Router } from 'react-router-dom';
import { Provider } from 'react-redux';
import { QueryClient, QueryClientProvider } from 'react-query';
import store from '../store';
import Login from '../Components/Login';
import '@testing-library/jest-dom/extend-expect';
// import axios from 'axios';
import Signup from '../Components/Signup';
import ErrorPage from '../Components/ErrorPage';
import HomePage from '../Components/HomePage';
import ViewAllAccountsComponent from '../ManagerComponents/ViewAllAccountsComponent';
import AccountForm from '../CustomerComponents/AccountForm';
import OpenFDForm from '../CustomerComponents/OpenFDForm';
import OpenRDForm from '../CustomerComponents/OpenRDForm';
import TransactionHistory from '../CustomerComponents/TransactionHistoryComponent';
import RecurringDepositComponent from '../CustomerComponents/RecurringDepositComponent';
import FixedDepositComponent from '../CustomerComponents/FixedDepositComponent';
import ManageAccounts from '../TellerComponents/ManageAccounts';
import FixedDepositsComponent from '../ManagerComponents/FixedDepositsComponent';
// import ViewAllLoans from '../CustomerComponents/ViewAllLoans';
// import LoanApplicationForm from '../CustomerComponents/LoanApplicationForm';
// import CustomerPostFeedback from '../CustomerComponents/CustomerPostFeedback';
// import AppliedLoans from '../CustomerComponents/AppliedLoans';
// import ViewLoans from '../LoanManagerComponents/ViewLoans';
// import ViewLoanDisbursement from '../LoanManagerComponents/ViewLoanDisbursement';
// import LoanRequest from '../LoanManagerComponents/LoanRequest';
// import LoanForm from '../LoanManagerComponents/LoanForm';
// import ViewFeedback from '../BranchManagerComponents/ViewFeedback';
// import LoansApproval from '../BranchManagerComponents/LoansApproval';

jest.mock('axios');

// Setup QueryClient
const queryClient = new QueryClient();

describe('Login Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  const renderLoginComponent = (props = {}) => {
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <Login {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };

  
  test('frontend_login_component_renders_the_with_login_heading', () => {
    renderLoginComponent();

  
    const loginHeadings = screen.getAllByText(/Login/i);
    expect(loginHeadings.length).toBeGreaterThan(0);

  });


  test('frontend_login_component_displays_validation_messages_when_login_button_is_clicked_with_empty_fields', () => {
    renderLoginComponent();

    fireEvent.click(screen.getByRole('button', { name: /Login/i }));

    expect(screen.getByText('Email is required')).toBeInTheDocument();
    expect(screen.getByText('Password is required')).toBeInTheDocument();
  });

   
});
describe('Signup Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  const renderSignupComponent = (props = {}) => {
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <Signup {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };
  test('frontend_signup_component_renders_with_signup_heading', () => {
    renderSignupComponent();

    const signupHeadings = screen.getAllByText(/Signup/i);
   expect(signupHeadings.length).toBeGreaterThan(0);

  });

  test('frontend_signup_component_displays_validation_messages_when_submit_button_is_clicked_with_empty_fields', () => {
    renderSignupComponent();

    fireEvent.click(screen.getByRole('button', { name: /Submit/i }));

    expect(screen.getByText('User Name is required')).toBeInTheDocument();
    expect(screen.getByText('Email is required')).toBeInTheDocument();
    expect(screen.getByText('Mobile Number is required')).toBeInTheDocument();
    expect(screen.getByText('Password is required')).toBeInTheDocument();
    expect(screen.getByText('Confirm Password is required')).toBeInTheDocument();
  });

  test('frontend_signup_component_displays_error_when_passwords_do_not_match', () => {
    renderSignupComponent();

    fireEvent.change(screen.getByPlaceholderText('Password'), { target: { value: 'password123' } });
    fireEvent.change(screen.getByPlaceholderText('Confirm Password'), { target: { value: 'password456' } });
    fireEvent.click(screen.getByRole('button', { name: /Submit/i }));

    expect(screen.getByText('Passwords do not match')).toBeInTheDocument();
  });
});

describe('ErrorPage Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });
  const renderErrorComponent = (props = {}) => {
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <ErrorPage {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };
  test('frontend_errorpage_component_renders_with_error_heading', () => {
    renderErrorComponent();
    const headingElement = screen.getByText(/Oops! Something Went Wrong/i);
    expect(headingElement).toBeInTheDocument();
  });

  test('frontend_errorpage_component_renders_with_error_content', () => {
    renderErrorComponent();
    const paragraphElement = screen.getByText(/Please try again later./i);
    expect(paragraphElement).toBeInTheDocument();
  });
});
describe('Home Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });
  const renderHomeComponent = (props = {}) => {
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <HomePage {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };

  
  test('frontend_home_component_renders_with_heading', () => {
    renderHomeComponent();
    const headingElement = screen.getAllByText(/BTMS/i);
    expect(headingElement.length).toBeGreaterThan(0);

  });
  test('frontend_home_component_renders_with_contact_us', () => {
    renderHomeComponent();
    const headingElement = screen.getAllByText(/Contact Us/i);
    expect(headingElement.length).toBeGreaterThan(0);

  });
});

describe('ViewAllAccounts Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  const renderViewAllAccountsComponent = (props = {}) => {
    const queryClient = new QueryClient(); // Create a new QueryClient instance
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <ViewAllAccountsComponent {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };

  test('frontend_ViewAllAccountsComponent_manager_component_renders_the_with_heading', () => {
    renderViewAllAccountsComponent();

    const headingElement = screen.getByText(/All Accounts/i);
    expect(headingElement).toBeInTheDocument();
  });

  test('frontend_viewallloans_customer_component_renders_the_table', () => {
    renderViewAllAccountsComponent();

    const tableElement = screen.getByRole('table');
    expect(tableElement).toBeInTheDocument();
  });
});

describe('AccountCreationForm Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });


  const renderAccountCreationFormComponent = (props = {}) => {
    const queryClient = new QueryClient(); // Create a new QueryClient instance
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <AccountForm {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };

  test('frontend_AccountForm_customer_component_renders_the_with_heading', () => {
    renderAccountCreationFormComponent();

    const headingElement = screen.getByText(/New Account/i);
    expect(headingElement).toBeInTheDocument();
  });

  test('frontend_AccountForm_customer_component_displays_required_validation_messages', async () => {
    renderAccountCreationFormComponent();

    fireEvent.click(screen.getByRole('button', { name: /Create Account/i }));

    expect(await screen.findByText('Account Holder Name is required')).toBeInTheDocument();
    expect(await screen.findByText('Account Type is required')).toBeInTheDocument();
    expect(await screen.findByText('Initial Balance must be greater than 0')).toBeInTheDocument();
    expect(await screen.findByText('Proof of Identity is required')).toBeInTheDocument();
    // expect(await screen.findByText('Remarks are required')).toBeInTheDocument();
    // expect(await screen.findByText('Proof is required')).toBeInTheDocument();
  });
});

describe('CustomerOpenFD Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });


  const renderCustomerOpenFDComponent = (props = {}) => {
    const queryClient = new QueryClient(); // Create a new QueryClient instance
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <OpenFDForm {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };

  test('frontend_customeropenfd_customer_component_renders_the_with_heading', () => {
    renderCustomerOpenFDComponent();

    const headingElement = screen.getByText(/Open Fixed Deposit/i);
    expect(headingElement).toBeInTheDocument();
  });
});


describe('CustomerOpenRD Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });
  
  const CustomerOpenRD = (props = {}) => {
    const queryClient = new QueryClient(); // Create a new QueryClient instance
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <OpenRDForm {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };

  test('frontend_CustomerOpenRDForm_customer_component_renders_the_with_heading', () => {
    CustomerOpenRD();
    const headingElements = screen.getByText(/Open Recurring Deposit/i);
    expect(headingElements).toBeInTheDocument();

  });

// test('frontend_appliedloans_customer_component_renders_the_table', () => {
//   renderAppliedLoansComponent();

//   const tableElement = screen.getByRole('table');
//   expect(tableElement).toBeInTheDocument();
// });
});


describe('TransactionHistory Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  const renderTransactionHistoryComponent = (props = {}) => {
    const queryClient = new QueryClient(); // Create a new QueryClient instance
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <TransactionHistory {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };
  test('frontend_transactionhistory_customer_component_renders_the_with_heading', () => {
    renderTransactionHistoryComponent();
    const headingElement = screen.getAllByText(/Transaction History/i);
    expect(headingElement.length).toBeGreaterThan(1);
  });

  test('frontend_transactionhistory_customer_component_renders_the_table', () => {
    renderTransactionHistoryComponent();
    
    const tableElement = screen.getByRole('table');
    expect(tableElement).toBeInTheDocument();
  });

});

describe('Customer RecurringDeposit Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  const renderCustomerRecurringDepositComponent = (props = {}) => {
    const queryClient = new QueryClient(); // Create a new QueryClient instance
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <RecurringDepositComponent {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };

  test('frontend_recurringdeposit_customer_component_renders_the_with_heading', () => {
    renderCustomerRecurringDepositComponent();

    const headingElement = screen.getByText(/Your Recurring Deposits/i);
    expect(headingElement).toBeInTheDocument();
  });

  test('frontend_recurringdeposit_customer_component_renders_the_table', () => {
    renderCustomerRecurringDepositComponent();

    const tableElement = screen.getByRole('table');
    expect(tableElement).toBeInTheDocument();
  });
});

describe('Customer FixedDeposit Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  const renderFixedDepositComponent = (props = {}) => {
    const queryClient = new QueryClient(); // Create a new QueryClient instance
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <FixedDepositComponent {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };

  test('frontend_FixedDeposit_customer_component_renders_the_with_heading', () => {
    renderFixedDepositComponent();

    const headingElement = screen.getByText(/Your Fixed Deposits/i);
    expect(headingElement).toBeInTheDocument();
  });

  test('frontend_FixedDeposit_customer_component_renders_the_table', () => {
    renderFixedDepositComponent();

    const tableElement = screen.getByRole('table');
    expect(tableElement).toBeInTheDocument();
  });
});

describe('Teller ManageAccounts Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  const renderManageAccountsComponent = (props = {}) => {
    const queryClient = new QueryClient(); // Create a new QueryClient instance
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <ManageAccounts {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };

  test('frontend_Teller_ManageAccounts_customer_component_renders_the_with_heading', () => {
    renderManageAccountsComponent();

    const headingElement = screen.getByText(/All Accounts/i);
    expect(headingElement).toBeInTheDocument();
  });

  test('frontend_Teller_ManageAccounts_customer_component_renders_the_table', () => {
    renderManageAccountsComponent();

    const tableElement = screen.getByRole('table');
    expect(tableElement).toBeInTheDocument();
  });
});

describe('Manager FixedDeposits Component', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  const renderManagerFixedDepositsComponent = (props = {}) => {
    const queryClient = new QueryClient(); // Create a new QueryClient instance
    return render(
      <Provider store={store}>
        <QueryClientProvider client={queryClient}>
          <Router>
            <FixedDepositsComponent {...props} />
          </Router>
        </QueryClientProvider>
      </Provider>
    );
  };

  test('frontend_Manager_FixedDeposits_customer_component_renders_the_with_Filter', () => {
    renderManagerFixedDepositsComponent();

    const headingElement = screen.getByText(/Filter by Status/i);
    expect(headingElement).toBeInTheDocument();
  });

  test('frontend_Manager_FixedDeposits_customer_component_renders_the_table', () => {
    renderManagerFixedDepositsComponent();

    const tableElement = screen.getByRole('table');
    expect(tableElement).toBeInTheDocument();
  });
});

