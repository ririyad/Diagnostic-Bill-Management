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
        TestTypeManager testTypeManager = new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestType testType = new TestType();

            testType.TypeName = typeNameTextBox.Text;

            if(testType.TypeName == "test")
            {
                warningMesageLabel.Text = "Please enter the name type!";
            }

            else
            {
                // check if the name is already exist in the database.
                bool isAlreadyExist = testTypeManager.TypeNameAlereadyExist(testType.ToString());
                if(isAlreadyExist)
                {
                    warningMesageLabel.Text = "This type already exist in the database!";
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
                        warningMesageLabel.Text = "Name is failed to save!";
                    }
                }
                
            }


        }

        public void LoadTypeNameGridView()
        {
            List<TestType> types = testTypeManager.GetTypeNameList();
            showTypeNameGridView.DataSource = types;
            showTypeNameGridView.DataBind();
        }
    }
}