using DiagnosticBillManagementApp.DAL;
using DiagnosticBillManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.BLL
{
    
    public class TestTypeManager
    {
        TestTypeGateWay testTypeGateway = new TestTypeGateWay();
        
        public bool Save(TestType testType)
        {
            bool isSaved = testTypeGateway.Save(testType) > 0;

            return isSaved;
        }

        public bool TypeNameAlereadyExist(string typeName)
        {
            TestType testType = testTypeGateway.GetTypeName(typeName);
            if(testType == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<TestType> GetTypeNameList()
        {
            List<TestType> tests = testTypeGateway.GetTypeNameList();
            return tests;
        }
    }
}