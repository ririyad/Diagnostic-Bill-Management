﻿using DiagnosticBillManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.DAL
{
    public class TestTypeGateWay
    {
        string connectionString = "Server=DESKTOP-N3N0UFQ;Database=DiagnosticCenterBillManagementDB;Integrated Security=true";

        public int Save(TestType testType)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_typeName(TypeName)VALUES('" + testType.TypeName + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rawAffected = command.ExecuteNonQuery();
            connection.Close();

            return rawAffected;
        }

        public TestType GetTypeName(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM tbl_typeName WHERE TypeName='" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            TestType testType = null;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                reader.Read();
                testType = new TestType();
                testType.TypeName = reader["TypeName"].ToString();
            }
            connection.Close();

            return testType;
        }

        public List<TestType>GetTypeNameList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_typeName";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<TestType> testTypes = new List<TestType>();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    TestType testType = new TestType();
                    testType.Id = int.Parse(reader["Id"].ToString());
                    testType.TypeName = reader["TypeName"].ToString();
                    testTypes.Add(testType);
                }
                reader.Close();
            }
            connection.Close();

            return testTypes;
        }
    }
}