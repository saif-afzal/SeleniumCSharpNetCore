using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using Selenium2.Meridian;
using NUnit.Framework;
using Selenium2;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class UsersUtil
    {
        private readonly IWebDriver driverobj;
       // public static IWebDriver driverobj;
        public TrainingHomes TrainingHomeobj;
        public My_Responsibilities MyResponsibilitiesobj;
        public AdministrationConsoles AdminstrationConsoleobj;
        public ManageUsers ManageUsersobj;
        public CreateNewAccount CreateNewAccountobj;


        public UsersUtil(IWebDriver driver)
        {
            driverobj = driver;
            driverobj = driver;
            AdminstrationConsoleobj = new AdministrationConsoles(driverobj);
            TrainingHomeobj = new TrainingHomes(driverobj);
            ManageUsersobj = new ManageUsers(driverobj);
            CreateNewAccountobj = new CreateNewAccount(driverobj);
            MyResponsibilitiesobj = new My_Responsibilities(driverobj);
        }

        public bool CreateNewUserAccount(string browserstr)
        {
            bool _actualresult = false;
            try
            {
               
                driverobj.UserLogin("admin1",browserstr);
                TrainingHomeobj.isTrainingHome();
                TrainingHomeobj.MyResponsiblities_click();
                MyResponsibilitiesobj.Click_People();
                ManageUsersobj.Click_CreateNewUserLink();
                CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr, ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr, ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
                CreateNewAccountobj.Click_SelectOrganization("");
                CreateNewAccountobj.Click_CreateAccount();
                ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_newuser["Firstname"]+browserstr, ExtractDataExcel.MasterDic_newuser["Lastname"]+browserstr);
                ManageUsersobj.Click_SearchUser();
                driverobj.tempUserLogin("user", ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, ManageUsersobj.passwordcreationnewuser(), browserstr);//it is for user for reguser createaccount.tempUserLogin("userforregression", "", passwd);
                _actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                //Assert.Fail(ex.Message);
               
            }
            return _actualresult;
            //string username = driverobj.GetElement(By.XPath("/html/body/form/div[6]/div/div/div/div[2]/div/div/ul/li/a/span")).Text;
            
        }
        public void CreateRegAccount(string browserstr)
        {

            try
            {
               
                driverobj.UserLogin("admin1",browserstr);
                //TrainingHomeobj.isTrainingHome();
                //   TrainingHomeobj.MyResponsiblities_click();
                //  MyResponsibilitiesobj.Click_People();
                driverobj.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/admin/manageusers/usersimplesearch.aspx']"));
                ManageUsersobj.Click_CreateNewUserLink();
                CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_userforreg["Id"] + browserstr, ExtractDataExcel.MasterDic_userforreg["Firstname"] + browserstr, ExtractDataExcel.MasterDic_userforreg["Lastname"] + browserstr, ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
                
                CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
                CreateNewAccountobj.Click_CreateAccount();
                MyResponsibilitiesobj.Click_People();
                ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforreg["Firstname"]+browserstr, ExtractDataExcel.MasterDic_userforreg["Lastname"]+browserstr);
                ManageUsersobj.Click_SearchUser();
                driverobj.tempUserLogin("newuser", ExtractDataExcel.MasterDic_userforreg["Id"] + browserstr, ManageUsersobj.passwordcreationnewuser(), browserstr);//it is for user for reguser createaccount.tempUserLogin("userforregression", "", passwd);
                //driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                //driverobj.UserLogin("userforregression");
               //driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
               
                //Assert.Fail(ex.Message);
            }

            //string username = driverobj.GetElement(By.XPath("/html/body/form/div[6]/div/div/div/div[2]/div/div/ul/li/a/span")).Text;
            
        }

        public string UserLogin(string type,string browserstr)
        {
            try
            {

                if (type == "admin")
                {
                    //ExtractDataExcel.admin();
                    //  driverobj.WaitForElement(By.Id(WebElementRepository.login_id));
                    driverobj.GetElement(ObjectRepository.login_id).SendKeys(ExtractDataExcel.MasterDic_admin["Id"]);
                    driverobj.GetElement(ObjectRepository.login_password).SendKeys(ExtractDataExcel.MasterDic_admin["Password"]);

                }

                else if (type == "userforregression")
                {
                   // ExtractDataExcel.userforregression();
                    //  driverobj.WaitForElement(By.Id(WebElementRepository.login_id));
                    driverobj.GetElement(ObjectRepository.login_id).SendKeys(ExtractDataExcel.MasterDic_userforreg["Id"]+browserstr);
                    driverobj.GetElement(ObjectRepository.login_password).SendKeys(ExtractDataExcel.MasterDic_userforreg["Password"]);

                }
                else
                {
                    //driverobj.WaitForElement(By.Id(WebElementRepository.login_id));
                    driverobj.GetElement(ObjectRepository.login_id).SendKeys(ExtractDataExcel.MasterDic_newuser["Id"]+browserstr + Common.token);
                    driverobj.GetElement(ObjectRepository.login_password).SendKeys(ExtractDataExcel.MasterDic_newuser["Password"]);

                }



                driverobj.GetElement(ObjectRepository.signin_button).Click();

                if (type == "userforregression" && driverobj.Title!="Home")
                {
                   // ExtractDataExcel.userforregression();
                    string usernotfound = "The login ID entered was not found in the system's records. Ensure that Caps Lock is not turned on and re-enter the login ID. Click Contact Administrator for help.";
                    if (usernotfound == driverobj.GetElement(By.Id("MainContent_UC5_cvIsLoginExists")).Text)
                    {
                        CreateRegAccount(browserstr);
                        
                    
                    } 

                }

            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                //Assert.Fail(ex.Message);
            }
            return driverobj.GetElement(ObjectRepository.login_name).Text;
        }

        public string LogoutUser()
        {
            try
            {
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driverobj.WaitForElement(ObjectRepository.label);
                string var = driverobj.Title;
                
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                //Assert.Fail(ex.Message);

            }
            
            return driverobj.Title;
        }
      
    }
}
