using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HTTP5101_Cumulative_Project_Part_1.Models
{
    
        public class SchoolDbContext
    { 
        private static string User { get { return "root"; } }
        private static string Password { get { return ""; } }
        private static string Database { get { return "schooldb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        protected static string ConnectionString
        {
            get
            {

                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password
                    + "; convert zero datetime = True";
            }
        }

        /// <summary>
        /// Returns a connection to the School database.
        /// </summary>
        /// <example>
        /// private DBContext DbCon = new DBContext();
        /// MySqlConnection Conn = DbCon.AccessDatabase();
        /// </example>
        /// <returns>A MySqlConnection Object</returns>
        public MySqlConnection AccessDatabase()
        {
            //We are instantiating the MySqlConnection Class to create an object
            //the object is a specific connection to our blog database on port 3307 of localhost
            return new MySqlConnection(ConnectionString);
        }
    }
}