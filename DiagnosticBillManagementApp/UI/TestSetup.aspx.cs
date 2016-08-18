using DiagnosticBillManagementApp.BLL;
using DiagnosticBillManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagnosticBillManagementApp.UI
{
    public partial class TestSetup : System.Web.UI.Page
    {
        TestTypeManager testTypemanager = new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDepartmentDropDown();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Tests tests = new Tests();
            tests.TestName = testNameTextBox.Text;
            tests.Fee = Convert.ToInt32(feeTextBox.Text);
        }

        public List<TestType> GetTypeNameList()
        {
            return testTypemanager.GetTypeNameList();
        }

        private void LoadDepartmentDropDown()
        {
            List<TestType> testTypes = GetTypeNameList();
            testTypeDropDown.DataSource = testTypes;
            testTypeDropDown.DataValueField = "Id";
            testTypeDropDown.DataTextField = "TypeName";
            testTypeDropDown.DataBind();

        }
    }
}