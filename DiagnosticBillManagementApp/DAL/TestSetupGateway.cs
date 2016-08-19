using DiagnosticBillManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.DAL
{
    public class TestSetupGateway
    {
        string connectionString = "Server=DESKTOP-N3N0UFQ;Database=DiagnosticCenterBillManagementDB;Integrated Security=true";

        public int Save(Tests tests)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_tests(TestName,Fee,TypeNameId)VALUES('" + tests.TestName + "','" + tests.Fee + "','" + tests.TypeNameId + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rawAffected = command.ExecuteNonQuery();
            connection.Close();

            return rawAffected;
        }
    }
}