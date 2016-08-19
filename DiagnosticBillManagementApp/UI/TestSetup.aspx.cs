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
        TestManager testManager = new TestManager();
        TestSetupManager testSetupmanager = new TestSetupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadTestsWithTypes();
                LoadTypeNameDropDown();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Tests tests = new Tests();
            tests.TestName = testNameTextBox.Text;
            tests.Fee = Convert.ToInt32(feeTextBox.Text);
            tests.TypeNameId = Convert.ToInt32(testTypeDropDown.SelectedValue);

            bool isSaved = testSetupmanager.Save(tests);
        }

        public List<TestType> GetTypeNameList()
        {
            return testManager.GetTypeNameList();
        }

        private void LoadTypeNameDropDown()
        {
            List<TestType> testTypes = GetTypeNameList();
            testTypeDropDown.DataSource = testTypes;
            testTypeDropDown.DataValueField = "Id";
            testTypeDropDown.DataTextField = "TypeName";
            testTypeDropDown.DataBind();

        }

        private void LoadTestsWithTypes()
        {
            List<ViewTestsWithTypes> testsWithTypes = testManager.GetAllTestsWithTypes();
            showTestInfoGridView.DataSource = testsWithTypes;
            showTestInfoGridView.DataBind();
        }
    }
}