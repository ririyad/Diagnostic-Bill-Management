using DiagnosticBillManagementApp.DAL;
using DiagnosticBillManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.BLL
{
    
    public class TestManager
    {
        TestGateWay testGateway = new TestGateWay();
        
        public bool Save(TestType testType)
        {
            bool isSaved = testGateway.Save(testType) > 0;

            return isSaved;
        }

        public bool TypeNameAlereadyExist(string typeName)
        {
            TestType testType = GetTypeName(typeName);
            if(testType == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public TestType GetTypeName(string type)
        {
            return testGateway.GetTypeName(type);
        }

        public List<TestType> GetTypeNameList()
        {
            List<TestType> tests = testGateway.GetTypeNameList();
            return tests;
        }

        public List<ViewTestsWithTypes> GetAllTestsWithTypes()
        {
            return testGateway.GetAllTestsWithTypes();
        }
    }
}