﻿using System.Data;
using System.Data.SqlClient;

namespace LMS
{
    public class Student : User
    {
        public Student(int id, string name, string family, string email, string pass, string pn) : base(id, name, family, email, pass, pn)
        {

        }
        public static Student GetStd(string email, string password)
        {
            SqlParameter[] sqlParameters = {
                new SqlParameter("@Email", SqlDbType.VarChar) { Value = email },
                new SqlParameter("@Password", SqlDbType.VarChar) { Value = password }
            };
            string query = "SELECT sId, Name, Family, Email, Password, Phonenumber FROM Student WHERE Email = @Email AND Password = @Password";
            DataRow res = DBHelper.ExecuteQuery(query, sqlParameters).Rows[0];
            return new Student(int.Parse(res["sId"].ToString()), res["Name"].ToString(), res["Family"].ToString(), res["Email"].ToString(), res["Password"].ToString(), res["Phonenumber"].ToString());
        }
        public static int RegisterInCourse(int cId, int sId)
        {
            string query;
            SqlParameter[] sqlParameters;
            query = "INSERT INTO Registration_Request (sId, cId) VALUES (@sId, @cId);";
            sqlParameters = new SqlParameter[] {
                    new SqlParameter("@sId", SqlDbType.Int) {Value = sId},
                    new SqlParameter("@cId", SqlDbType.Int) {Value = cId},
            };
            int res = DBHelper.ExecuteNonQuery(query, sqlParameters);
            if (res == 0)
                return -1;
            else
                return 1;
        }

        public static DataTable ViewFiles(int cId)
        {
            string query;
            SqlParameter[] sqlParameters;
            query = "SELECT FROM Files WHERE cId = @cId;";
            sqlParameters = new SqlParameter[] {
                    new SqlParameter("@cId", SqlDbType.Int) {Value = cId},
            };
            return DBHelper.ExecuteQuery(query, sqlParameters);
        }

        public static DataTable getCoursesForStd(int sId)
        {
            string query = "SELECT c.cId as cId, c.Title as Title, c.Semester as Semester, c.Department as Department, c.pId as pId FROM Course as c JOIN Registration as r ON c.cId = r.cId WHERE r.sId = @sId";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@sId", SqlDbType.Int) { Value = sId }
            };
            return DBHelper.ExecuteQuery(query, sqlParameters);
        }
    }
}
