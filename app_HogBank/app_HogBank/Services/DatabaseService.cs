using app_HogBank.Models;
using app_HogBank.Models.Arguments;
using app_HogBank.Resources;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_HogBank.Services
{
    class DatabaseService
    {
        //------------------------------------------------------------------------
        //  Member Variables
        //------------------------------------------------------------------------
        protected OleDbCommand command;
        protected OleDbDataReader dataReader;

        private OleDbConnection connection;
        private ConnectionStringService connectionStringService;

        //------------------------------------------------------------------------
        //  Constructors and Initializers
        //------------------------------------------------------------------------
        public DatabaseService(FormErrorHandler error, FormInfoHandler info)
        {
            connection = new OleDbConnection();
            connectionStringService = new ConnectionStringService();
            connection.ConnectionString = connectionStringService.buildConnectionString();
            connection.Open();

            OnFormError += error;
            OnFormInfo += info;
        }

        public void cleanup()
        {
            removeSubscription();
            connection.Close();
        }

        // Single Use Utility Method that Might Come in Handy Back In Season 3 of Avatar - The Blue Airbender That Could.
        private int getNullablePositiveIntFromDataReader(int index)
        {
            return (!dataReader.IsDBNull(index)) ? dataReader.GetInt32(index) : -1;
        }

        //------------------------------------------------------------------------
        //  Event Handlers and Events
        //------------------------------------------------------------------------
        public delegate void FormErrorHandler(object sender, FormErrorArg args);
        public event FormErrorHandler OnFormError;

        public delegate void FormInfoHandler(object sender, FormInfoArg args);
        public event FormInfoHandler OnFormInfo;

        public void removeSubscription()
        {
            FormErrorHandler handlerError = OnFormError;

            if(handlerError != null)
            {
                foreach (Delegate d in handlerError.GetInvocationList())
                {
                    handlerError -= (FormErrorHandler)d;
                }
            }

            FormInfoHandler handlerInfo = OnFormInfo;
            if(handlerInfo != null)
            {
                foreach (Delegate d in handlerInfo.GetInvocationList())
                {
                    handlerInfo -= (FormInfoHandler)d;
                }
            }
        }

        //=======================================================
        //  Service Methods
        //=======================================================
        public List<LoginVO> GetMatchingLogin(string username, string password)
        {
            List<LoginVO> results = new List<LoginVO>();
            try
            {
                command = new OleDbCommand("SELECT id, username, password FROM RegisteredEntity WHERE username = '" + username + "' AND password = '" + password + "'", connection);
                dataReader = command.ExecuteReader();

                while(dataReader.Read())
                {
                    results.Add(new LoginVO(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2)));
                }
            }
            catch(Exception e)
            {
                if(OnFormError != null)
                {
                    OnFormError(this, new FormErrorArg("Error getting information from database: " + e.Message, e));
                }
            }

            return results;
        }
        
        public CustomerVO GetCustomerInformationFromRegistrationId(int id)
        {
            List<CustomerVO> results = new List<CustomerVO>();
            try
            {
                command = new OleDbCommand("SELECT customer_id, registration_id, first_name, last_name, address, phone_number, email, status, join_date FROM Customer WHERE registration_id = '" + id + "'", connection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Note: I'm not adding the registration_id to the VO b/c it would link Customer Information to their login information in the app code.
                    results.Add(new CustomerVO(dataReader.GetInt32(0), -1, dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetDateTime(8).ToString()));
                }

                if(results.Count > 1)
                {
                    // Referential Integrity violation.  Application side constraint that we can't have multiple records refer to the same RegistrationID.
                    results.Clear();
                    results = null;
                    throw new Exception("System Error - Referential Integrity Violation");
                }
                else if(results.Count < 1)
                {
                    // Forces the LoginForm to try something else... say check the Employee table or something.  And then check if that employee is a manager or something.
                    results.Clear();
                    results = null;
                }
            }
            catch (Exception e)
            {
                if (OnFormError != null)
                {
                    OnFormError(this, new FormErrorArg("Error getting information from database: " + e.Message, e));
                }
                results = null;
            }

            if (results != null)
                return results[0];
            else
                return null;
        }

        public EmployeeVO GetEmployeeInformationFromRegistrationId(int id)
        {
            List<EmployeeVO> results = new List<EmployeeVO>();
            try
            {
                command = new OleDbCommand("SELECT E.employee_id, E.registration_id, E.first_name, E.last_name, E.address, E.status, E.type, E.hourly_rate, E.hire_date, E.building_number, T.teller_id, B.branch_manager_id FROM Employee E LEFT JOIN Teller T ON E.employee_id = T.employee_id LEFT JOIN Branch_Manager B ON E.employee_id = B.employee_id WHERE registration_id = '" + id + "'", connection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Note: I'm not adding the registration_id to the VO b/c it would link Customer Information to their login information in the app code.
                    int temp = getNullablePositiveIntFromDataReader(10);
                    bool isTeller = (temp != -1) ? true : false;
                    temp = getNullablePositiveIntFromDataReader(11);
                    bool isBranchManager = (temp != -1) ? true : false;
                    results.Add(new EmployeeVO(dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetInt32(7), dataReader.GetDateTime(8).ToString(), dataReader.GetInt32(9), isTeller, isBranchManager));
                }

                if (results.Count > 1)
                {
                    // Referential Integrity violation.  Application side constraint that we can't have multiple records refer to the same RegistrationID.
                    results.Clear();
                    results = null;
                    throw new Exception("System Error - Referential Integrity Violation");
                }
                else if (results.Count < 1)
                {
                    // Forces the LoginForm to try something else... say check the Employee table or something.  And then check if that employee is a manager or something.
                    results.Clear();
                    results = null;
                }
            }
            catch (Exception e)
            {
                if (OnFormError != null)
                {
                    OnFormError(this, new FormErrorArg("Error getting information from database: " + e.Message, e));
                }
                results = null;
            }

            if (results != null)
                return results[0];
            else
                return null;
        }

        public void AddNewAccount(int customerID, string accountName, string accountType)
        {
            try
            {
                command = new OleDbCommand("INSERT INTO Accounts VALUES ('" + accountType + "','" + customerID + "','" + accountName + "')", connection);
                int queryResult = command.ExecuteNonQuery();

                command = new OleDbCommand("SELECT account_id FROM Accounts WHERE customer_id = '" + customerID + "' AND account_name = '" + accountName + "'", connection);
                dataReader = command.ExecuteReader();

                int new_account_id = -1;
                while(dataReader.Read())
                {
                    new_account_id = dataReader.GetInt32(0);
                }

                if(OnFormInfo != null && GlobalVariables.DEBUG)
                {
                    OnFormInfo(this, new FormInfoArg("Number of Rows Inserted: " + queryResult));
                }
                if (OnFormInfo != null)
                {
                    OnFormInfo(this, new FormInfoArg("Successfully created account!  You account number is " + new_account_id + ".  Please do not lose this number, as you will need it to access your account."));
                }
            }
            catch (Exception e)
            {
                if (OnFormError != null)
                {
                    OnFormError(this, new FormErrorArg("Error getting information from database: " + e.Message, e));
                }
            }
        }

        public void AddAccountTransaction(int accountID, double amount)
        {
            try
            {
                command = new OleDbCommand("INSERT INTO Account_Transaction VALUES ('" + accountID + "', null,'" + amount + "', CURRENT_TIMESTAMP)", connection);
                int queryResult = command.ExecuteNonQuery();

                if (OnFormInfo != null && GlobalVariables.DEBUG)
                {
                    OnFormInfo(this, new FormInfoArg("Number of Rows Inserted: " + queryResult));
                }
                if (OnFormInfo != null)
                {
                    OnFormInfo(this, new FormInfoArg("Account #" + accountID + ": Successfully added $" + amount + " to your account."));
                }
            }
            catch (Exception e)
            {
                if (OnFormError != null)
                {
                    OnFormError(this, new FormErrorArg("Error getting information from database: " + e.Message, e));
                }
            }
        }

        public List<AccountTransactionVO> GetAccountTransactionsForAccountID(int accountID)
        {
            List<AccountTransactionVO> results = new List<AccountTransactionVO>();
            try
            {
                command = new OleDbCommand("SELECT line_id, teller_id, amount_transacted, created_timestamp FROM Account_Transaction WHERE account_id = '" + accountID + "'", connection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    string status = (getNullablePositiveIntFromDataReader(1) != -1) ? "Approved" : "Pending";
                    results.Add(new AccountTransactionVO((double)dataReader.GetDecimal(2), status, dataReader.GetDateTime(3).ToString()));
                }
            }
            catch (Exception e)
            {
                if (OnFormError != null)
                {
                    OnFormError(this, new FormErrorArg("Error getting information from database: " + e.Message, e));
                }
            }
            return results;
        }

        public void AddLoanApplication(LoanApplicationVO valueObject)
        {
            try
            {
                command = new OleDbCommand("INSERT INTO Loan VALUES ('" + valueObject.AccountId + "', null,'" + valueObject.PrincipalAmount + "','" + valueObject.LoanType + "','" + valueObject.Interest + "','" + valueObject.SocialSecurity + "','" + valueObject.CreditScore + "', CURRENT_TIMESTAMP)", connection);
                int queryResult = command.ExecuteNonQuery();

                if (OnFormInfo != null && GlobalVariables.DEBUG)
                {
                    OnFormInfo(this, new FormInfoArg("Number of Rows Inserted: " + queryResult));
                }
                if (OnFormInfo != null)
                {
                    OnFormInfo(this, new FormInfoArg("Loan application successfully created"));
                }
            }
            catch (Exception e)
            {
                if (OnFormError != null)
                {
                    OnFormError(this, new FormErrorArg("Error getting information from database: " + e.Message, e));
                }
            }
        }

        public void UpdateLoan(int branchManagerId, int loanId)
        {
            try
            {
                command = new OleDbCommand("UPDATE Loan SET branch_manager_id = '" + branchManagerId + "' WHERE load_id = '" + loanId + "'", connection);
                int queryResult = command.ExecuteNonQuery();

                if (OnFormInfo != null && GlobalVariables.DEBUG)
                {
                    OnFormInfo(this, new FormInfoArg("Number of Rows Updated: " + queryResult));
                }
                if (OnFormInfo != null)
                {
                    OnFormInfo(this, new FormInfoArg("Loan successfully updated"));
                }
            }
            catch (Exception e)
            {
                if (OnFormError != null)
                {
                    OnFormError(this, new FormErrorArg("Error getting information from database: " + e.Message, e));
                }
            }
        }

        public void AddLoanTransaction(LoanPaymentVO valueObject)
        {
            try
            {
                command = new OleDbCommand("INSERT INTO Loan_Payment VALUES ('" + valueObject.Loan_id + "','" + valueObject.Payment_amount + "', CURRENT_TIMESTAMP)", connection);
                int queryResult = command.ExecuteNonQuery();

                if (OnFormInfo != null && GlobalVariables.DEBUG)
                {
                    OnFormInfo(this, new FormInfoArg("Number of Rows Inserted: " + queryResult));
                }
                if (OnFormInfo != null)
                {
                    OnFormInfo(this, new FormInfoArg("Payment successfully registered"));
                }
            }
            catch (Exception e)
            {
                if (OnFormError != null)
                {
                    OnFormError(this, new FormErrorArg("Error getting information from database: " + e.Message, e));
                }
            }
        }

        public List<LoanApplicationVO> GetLoanInformation(int accountId)
        {
            List<LoanApplicationVO> results = new List<LoanApplicationVO>();
            try
            {
                command = new OleDbCommand("SELECT loan_id, account_id, branch_manager_id, principal, loan_type, interest, social_security, credit_score, created_date FROM Loan WHERE account_id = '" + accountId + "'", connection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    results.Add(new LoanApplicationVO(dataReader.GetInt32(0), dataReader.GetInt32(1), getNullablePositiveIntFromDataReader(2), (double)dataReader.GetDecimal(3), dataReader.GetString(4), (double)dataReader.GetDecimal(5), dataReader.GetString(6), Convert.ToInt32(dataReader.GetString(7)), dataReader.GetDateTime(8).ToString()));
                }
            }
            catch (Exception e)
            {
                if (OnFormError != null)
                {
                    OnFormError(this, new FormErrorArg("Error getting information from database: " + e.Message, e));
                }
            }
            return results;
        }

        public List<LoanPaymentVO> GetLoanPayments(int loanId)
        {
            List<LoanPaymentVO> results = new List<LoanPaymentVO>();
            try
            {
                command = new OleDbCommand("SELECT loan_id, payment_amount FROM Loan_Payment WHERE loan_id = '" + loanId + "'", connection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    results.Add(new LoanPaymentVO(-1, dataReader.GetInt32(0), (double)dataReader.GetDecimal(1)));
                }
            }
            catch (Exception e)
            {
                if (OnFormError != null)
                {
                    OnFormError(this, new FormErrorArg("Error getting information from database: " + e.Message, e));
                }
            }
            return results;
        }
    }
}
