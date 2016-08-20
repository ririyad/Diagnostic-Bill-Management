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
    public partial class TestTypeSetup : System.Web.UI.Page
    {
        TestManager testTypeManager = new TestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTypeNameGridView();
        }

        protected void saveButton_Click1(object sender, EventArgs e)
        {
            TestType testType = new TestType();

            testType.TypeName = typeNameTextBox.Text;

            if (testType.TypeName == "")
            {
                warningMessageLabel.Text = "Please enter the name type!";
                return;
            }

            else
            {
                // check if the name is already exist in the database.
                bool isAlreadyExist = testTypeManager.TypeNameAlereadyExist(testType.ToString());
                if (isAlreadyExist)
                {
                    warningMessageLabel.Text = "This type already exist in the database!";
                    return;
                }
                else
                {
                    //saving name in the database
                    bool isSaved = testTypeManager.Save(testType);

                    if (isSaved)
                    {
                        messgaeLabel.Text = "Name has been saved successfully";
                    }

                    else
                    {
                        warningMessageLabel.Text = "Name is failed to save!";
                    }
                }

            }

            LoadTypeNameGridView();

        }

        public void LoadTypeNameGridView()
        {
            List<TestType> types = testTypeManager.GetTypeNameList();
            showTypeNameGridView.DataSource = types;
            showTypeNameGridView.DataBind();
        }


    }
}