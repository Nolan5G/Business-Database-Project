using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace app_HogBank.Services
{
    class ConnectionStringService
    {
        private string username;
        private string password;
        private string database;
        private string server;

        public ConnectionStringService()
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = Environment.CurrentDirectory + "\\Resources\\Configurations\\DatabaseConnection.config";
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            if(config.HasFile)
            {
                string[] csList = config.AppSettings.Settings["item1"].Value.Split(';');
                username = csList[0];
                password = csList[1];
                database = csList[2];
                server = csList[3];
            }
            else
            {
                throw new Exception("Could not read the connection string from Resources/Configurations/DatabaseConnection.config");
            }        
        }

        public string buildConnectionString()
        {
            return "Provider=SQLNCLI11;Server=" + server + ";Database=" + database + ";UID=" + username + ";PWD=" + password + ";";
        }
    }
}
