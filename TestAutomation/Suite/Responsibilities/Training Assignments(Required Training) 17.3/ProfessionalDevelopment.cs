using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    class ProfessionalDevelopment
    {

        [Test, Order(1)]
        public void User_Edit_a_Job_title_31501()
        {
            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            CommonSection.Manage.ProfessionalDevelopment();
            ProfessionalDevelopmentPage.ClickJobTitleTab();
            ProfessionalDevelopmentPage.SearchJobtitle("Reg_Jobtittle").ClickSearchlink();
            Assert.IsTrue(ProfessionalDevelopmentPage.JobTittle("Reg_Jobtittle"));
            ProfessionalDevelopmentPage.ClickJobtittle("Reg_Jobtittle");
            ManageJobTittlePage.ClickJobDetailsTab();
            ManageJobTittlePage.JobDetailsTab.AddDescription("Reg_Description");
            ManageJobTittlePage.ClickSavebutton();
            StringAssert.AreEqualIgnoringCase("The Changes were Saved"), ManageJobTittlePage.GetSuccessMessage(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("Reg_Description"), ManageJobTittlePage.GetDescriptionLink(), "Description value does not match");
            ManageJobTittlePage.JobDetailsTab.AddKeywords("Reg_Keywords");
            ManageJobTittlePage.ClickSavebutton();
            StringAssert.AreEqualIgnoringCase("The Changes were Saved", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("Reg_Keywords"), ManageCompetencyPage.GetDescriptionLink(), "Keywords value does not match");
            ManageJobTittlePage.JobDetailsTab.JobCodeLink("Reg_JOBCODE");
            ManageJobTittlePage.ClickSavebutton();
            StringAssert.AreEqualIgnoringCase("The Changes were Saved", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("Reg_JOBCODE"), ManageCompetencyPage.GetDescriptionLink(), "JobCode Value does not match");

        }

        [Test, Order(2)]
        public void User_Remove_Competency_from_existing_Job_title_31504()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            ProfessionalDevelopmentPage.ClickJobTitleTab();
            ProfessionalDevelopmentPage.SearchJobtitle("Reg_Jobtittle").ClickSearchlink();
            Assert.IsTrue(ProfessionalDevelopmentPage.JobTittle("Reg_Jobtittle"));
            ProfessionalDevelopmentPage.ClickJobtittle("Reg_Jobtittle");
            ManageJobTittlePage.CareerTrackTab.ClickAssignCompetency();
            ManageJobTittlePage.Frame.AssignCompetency.SearchCompetency("A Competency for Testing").ClickSearchlink();
            ManageJobTittlePage.Frame.AssignCompetency.SelectItem("A Competency for Testing").ClickAssignButton();
            ManageJobTittlePage.CareerTrackSection.SelectCompetency("A Competency for Testing").ClickRemoveButton();
            ManageJobTittlePage.ConfirmationWindow.ClickRemovebutton();
            StringAssert.AreEqualIgnoringCase("The selected items were removed.", ManageJobTittlePage.GetSuccessMessage(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("There are no assigned competencies."), ManageJobTittlePage.NameColumn(), "Value does not match");
        }

        [Test, Order(3)]
        public void User_Remove_Competency_while_Creating_New_Job_title_31506()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            ProfessionalDevelopmentPage.ClickJobTitleTab();
            ProfessionalDevelopmentPage.ClickJobTitleButton.ClickUnnamedJobtitlelink("Reg_Jobtittle").Clickokbutton();
            StringAssert.AreEqualIgnoringCase("The Job Title was created.", ManageJobTittlePage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ProfessionalDevelopmentPage.JobTittle("Reg_Jobtittle"));
            ManageJobTittlePage.CareerTrackTab.ClickAssignCompetency();
            ManageJobTittlePage.Frame.AssignCompetency.SearchCompetency("A Competency for Testing").ClickSearchlink();
            ManageJobTittlePage.Frame.AssignCompetency.SelectItem("A Competency for Testing").ClickAssignButton();
            StringAssert.AreEqualIgnoringCase(" The selected competencies were assigned to the job title.", ManageJobTittlePage.GetSuccessMessage(), "Error message is different");
            ManageJobTittlePage.CareerTrackSection.SelectCompetency("A Competency for Testing").ClickRemoveButton();
            ManageJobTittlePage.ConfirmationWindow.ClickRemovebutton();
            StringAssert.AreEqualIgnoringCase("The selected items were removed.", ManageJobTittlePage.GetSuccessMessage(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("There are no assigned competencies."), ManageJobTittlePage.NameColumn(), "Value does not match");
        }

        [Test, Order(4)]
        public void User_adds_supplemental_training_to_a_new_competency_31561)
        
            {  // //Pre-req: Login with admin and create a document/Gen. Course that will be added as supplemetanl training  
            CommonSection.Manage.ProfessionalDevelopment();
            ProfessionalDevelopmentPage.ClickCompetencyTab();
            ProfessionalDevelopmentPage.CompetencyTab.ClickCreateCompetency();
            CreateCompetencyPage.EditCompetencyName("CompetencyTitle_Reg");
            CreateCompetencyPage.SaveCompetencyName();
            StringAssert.AreEqualIgnoringCase("The Competency was created", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.AssociatedContentTab.click();
            ManageCompetencyPage.SupplementalTab.Click();
            StringAssert.AreEqualIgnoringCase("There is no supplemental content.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
           ManageCompetencyPage.AssociateContent.Click();
           ManageCompetencyPage.Frame.SearchText("Document that created as Pre req");
           ManageCompetencyPage.Frame.SelectRecord.ClickAddbutton();
           StringAssert.AreEqualIgnoringCase("The selected items were added.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
         Assert.ManageCompetencyPage.AssociateContent.VerifyAddedRecord("dv_test");//Added record should appear that we created as pre req
         }

    [Test, Order(5)]
    public void User_adds_supplemental_training_to_an_existing_competency_31562()
        {
            // //Pre-req: Login with admin and create a document/Gen. Course that will be added as supplemetanl training  
            CommonSection.Manage.ProfessionalDevelopment();
            ProfessionalDevelopmentPage.ClickCompetencyTab();
            ProfessionalDevelopmentPage.CompetencyTab.SearchRecord("DV_Competency").Clickname;
          ManageCompetencyPage.ClickAssociatedContentTab.click();
            ManageCompetencyPage.SupplementalTab.click();
             ManageCompetencyPage.AssociateContent.Click();
           ManageCompetencyPage.Frame.SearchText("Document that created as Pre req");
           ManageCompetencyPage.Frame.SelectRecord.ClickAddbutton();
           StringAssert.AreEqualIgnoringCase("The selected items were added.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
         Assert.ManageCompetencyPage.AssociateContent.VerifyAddedRecord("dv_test");//Added record should appear that we created as pre req
         }
public void (Edit_Competency_Details_31458(2)
        
        {
            CommonSection.Manage.ProfessionalDevelopment();
            ProfessionalDevelopmentPage.ClickCompetencyTab();
            ProfessionalDevelopmentPage.CompetencyTab.ClickCompetency();
            ManageCompetencyPage.ClickCompetencyDetailsTab();
            ManageCompetencyPage.CompetencyDetailsTab.AddDescription("EditDescription");
            ManageCompetencyPage.ClickSavebutton();
            StringAssert.AreEqualIgnoringCase("The Changes were Saved", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.CompetencyDetailsTab.AddKeywords("EditKeywords");
            ManageCompetencyPage.ClickSavebutton();
            StringAssert.AreEqualIgnoringCase("The Changes were Saved", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckEditDescription);
            Assert.IsTrue(ManageCompetencyPage.CheckEditKeyword);
        }
    }

}
