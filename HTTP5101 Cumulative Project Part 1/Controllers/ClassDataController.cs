using HTTP5101_Cumulative_Project_Part_1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101_Cumulative_Project_Part_1.Controllers
{
    public class ClassDataController : ApiController
    {
        private SchoolDbContext DbCon = new SchoolDbContext();

        //This Controller Will access the Class table of our school database.
        /// <summary>
        /// Returns a list of Class in the system
        /// </summary>
        /// <example>GET api/ClassData/ListClass</example>
        /// <returns>
        /// A list of Class (first names and last names)
        /// </returns>
        [HttpGet]
        public IEnumerable<Class> ListClass()
        {
            //Create an instance of a connection
            MySqlConnection Conn = DbCon.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes where lower(classcode) like lower(@key) ";
            
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Authors
            List<Class> ClassList = new List<Class> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                DateTime StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                DateTime FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);
                string ClassName = ResultSet["classname"].ToString();

                Class NewClass = new Class();
                NewClass.ClassId = ClassId;

                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;

                ClassList.Add(NewClass);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of Class names
            return ClassList;
        }


        /// <summary>
        /// Finds given Class in the system given an ID
        /// </summary>
        /// <param name="id">The Class primary key</param>
        /// <returns>A Class object</returns>
        [HttpGet]
        public Class FindClass(int id)
        {
            Class NewClass = new Class();

            //Create an instance of a connection
            MySqlConnection Conn = DbCon.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes where classid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index


                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                DateTime StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                DateTime FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);
                string ClassName = ResultSet["classname"].ToString();


                NewClass.ClassId = ClassId;

                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;


            }


            return NewClass;
        }

    }
}
