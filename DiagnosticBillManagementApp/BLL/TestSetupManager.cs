using DiagnosticBillManagementApp.DAL;
using DiagnosticBillManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.BLL
{
    public class TestSetupManager
    {
        TestSetupGateway testSetupGateWay = new TestSetupGateway();
        public bool Save(Tests test)
        {
            bool isSaved = testSetupGateWay.Save(test) > 0;

            return isSaved;
        }
    }
}