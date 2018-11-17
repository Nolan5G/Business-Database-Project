using app_HogBank.Models;
using app_HogBank.Models.Arguments;
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

        public delegate void FormErrorHandler(object sender, FormErrorArg args);
        public event FormErrorHandler OnFormError;

        public delegate void FormInfoHandler(object sender, FormInfoArg args);
        public event FormInfoHandler OnFormInfo;

        //------------------------------------------------------------------------
        //  Constructors and Initializers
        //------------------------------------------------------------------------
        public DatabaseService()
        {
            connection = new OleDbConnection();
            connectionStringService = new ConnectionStringService();
            connection.ConnectionString = connectionStringService.buildConnectionString();
            connection.Open();
        }

        public void cleanup()
        {
            connection.Close();
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
    }
}
