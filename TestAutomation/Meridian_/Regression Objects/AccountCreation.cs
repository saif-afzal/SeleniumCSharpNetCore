using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;
using relativepath;
using System.Diagnostics;
using LinqToExcel;
using Utility;
using System.Reflection;


namespace Selenium2.Meridian
{
    class AccountCreation
    {
        private readonly IWebDriver createaccount;
        public bool tocreateaccount = false;
        public static string learnerfirstname = string.Empty;
        public static string learneruserid = string.Empty;
        public static string learnerpassword = string.Empty;
        public static string managerfirstname = string.Empty;
        public static string manageruserid = string.Empty;
        public static string managerpassword = string.Empty;
        public static string trainingpocfirstname = string.Empty;
        public static string trainingpocuserid = string.Empty;
        public static string trainingpocpassword = string.Empty;
        public static string ifmispocfirstname = string.Empty;
        public static string ifmispocuserid = string.Empty;
        public static string ifmispocpassword = string.Empty;
        public static string financepocfirstname = string.Empty;
        public static string financepocuserid = string.Empty;
        public static string financepocpassword = string.Empty;
        
        public AccountCreation(IWebDriver driver)
        {
            createaccount = driver;
        }
        public static string token_for_reg = Class_utility.token();
        public  Dictionary<string, string> MasterDic_sfuser = new Dictionary<string, string>();
        public  void NewUserforsf(string dataid)
        {

            string data;
            MasterDic_sfuser.Clear();
            // Initialize the linq to excel provider
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "\\Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("Login")
                        where p["DataID"].ToString() == dataid
                        select p;

            MasterDic_sfuser = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() + token_for_reg }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() + token_for_reg }, { "Lastname", query.First().ItemArray[4].ToString() + token_for_reg }, { "Email", query.First().ItemArray[5].ToString() } };
            // MasterDic = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString()}, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString()}, { "Lastname", query.First().ItemArray[4].ToString() }, { "Email", query.First().ItemArray[5].ToString() } };
            setusersfirstname(dataid);
        }

        public void setusersfirstname(string dataid)
        {


            switch (dataid)
            {
                case "learnerforsf":
                    {
                        learnerfirstname = MasterDic_sfuser["Firstname"];
                        learneruserid = MasterDic_sfuser["Id"];
                        learnerpassword = MasterDic_sfuser["Password"];
                        break;
                    }
                case "managerforsf":
                    {
                        managerfirstname = MasterDic_sfuser["Firstname"];
                        manageruserid = MasterDic_sfuser["Id"];
                        managerpassword = MasterDic_sfuser["Password"];
                        break;
                    }

                case "traininguserforsf":
                    {
                        trainingpocfirstname = MasterDic_sfuser["Firstname"];
                        trainingpocuserid = MasterDic_sfuser["Id"];
                        trainingpocpassword = MasterDic_sfuser["Password"];
                        break;
                    }
                case "ifmisuserforsf":
                    {
                        ifmispocfirstname = MasterDic_sfuser["Firstname"];
                        ifmispocuserid = MasterDic_sfuser["Id"];
                        ifmispocpassword = MasterDic_sfuser["Password"];
                        break;
                    }
                case "financeuserforsf":
                    {
                        financepocfirstname = MasterDic_sfuser["Firstname"];
                        financepocuserid = MasterDic_sfuser["Id"];
                        financepocpassword = MasterDic_sfuser["Password"];
                        break;
                    }

            }
        }
        public void linkcreateaccntclick()
        {

            try
            {
                createaccount.WaitForElement(By.XPath("//span[contains(.,'People')]"));
                createaccount.GetElement(By.XPath("//span[contains(.,'People')]")).ClickWithSpace();
                createaccount.WaitForElement(By.Id("MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser"));
                createaccount.GetElement(By.Id("MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser")).ClickWithSpace();


                // createaccount.WaitForElement(ObjectRepository.create_account_link);
                //createaccount.GetElement(ObjectRepository.create_account_link).ClickWithSpace();
                //createaccount.WaitForElement(ObjectRepository.org_create_btn);
                tocreateaccount = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "linkcreateaccountclickfailed");
                tocreateaccount = false;
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on People or Create Account Link", createaccount);

            }
            // return createaccount.GetElement(By.Id(Object.login_name)).Text

        }
        public void populatecreateaccountform(string browserstr)
        {
            //if (tocreateaccount == false)
            //{
            //    return;
            //}
            try
            {
                createaccount.WaitForElement(ObjectRepository.loginid_text);
                createaccount.GetElement(ObjectRepository.loginid_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Id"]+browserstr);
                ObjectRepository.newuserloginid = ExtractDataExcel.MasterDic_newuser["Id"]+browserstr.ToString();
                //createaccount.GetElement(ObjectRepository.passwd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                //createaccount.GetElement(ObjectRepository.confirmpasswd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                createaccount.GetElement(ObjectRepository.fname_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Firstname"]+browserstr);
                createaccount.GetElement(ObjectRepository.lname_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Lastname"]+browserstr);
                createaccount.GetElement(ObjectRepository.email_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Id"]+browserstr + "@xyz.com");
                createaccount.GetElement(ObjectRepository.org_select_link).ClickWithSpace();
                Thread.Sleep(5000);
                //createaccount.SelectFrame();
                createaccount.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                Thread.Sleep(5000);
                createaccount.WaitForElement(ObjectRepository.org_search_text);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populatecreateaccountform failed");
                tocreateaccount = false;
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Populate Create Account Form", createaccount);
                
            }

        }
        public void populatecreateaccountformforregression(string browserstr)
        {
            //if (tocreateaccount == false)
            //{
            //    return;
            //}
            try
            {
                createaccount.WaitForElement(ObjectRepository.loginid_text);
               
                createaccount.GetElement(ObjectRepository.loginid_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Id"]+browserstr);
                //createaccount.GetElement(ObjectRepository.passwd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                //createaccount.GetElement(ObjectRepository.confirmpasswd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                createaccount.GetElement(ObjectRepository.fname_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Firstname"]+browserstr);
                createaccount.GetElement(ObjectRepository.lname_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Lastname"]+browserstr);
                createaccount.GetElement(ObjectRepository.email_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Id"]+browserstr + "@xyz.com");

                if (createaccount.existsElement(By.XPath("//input[contains(@id,'MainContent_UC1_USRX_')]")))
                {
                    createaccount.GetElement(By.XPath("//input[contains(@id,'MainContent_UC1_USRX_')]")).SendKeysWithSpace("testing");

                }
                Thread.Sleep(5000);
                createaccount.ScrollToCoordinated("500", "500");
                createaccount.GetElement(ObjectRepository.org_select_link).ClickWithSpace();
                //createaccount.SelectFrame();
                createaccount.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                Thread.Sleep(5000);
                createaccount.WaitForElement(ObjectRepository.org_search_text);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populatecreateaccountform failed");
                tocreateaccount = false;
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Populate Create Account Form", createaccount);
               
            }

        }
        public void populatecreateaccountformforregressioncustomized(string id,string fname,string lname,string email )
        {
            //if (tocreateaccount == false)
            //{
            //    return;
            //}
            try
            {
                createaccount.WaitForElement(ObjectRepository.loginid_text);
                createaccount.GetElement(ObjectRepository.loginid_text).ClickWithSpace();
                createaccount.GetElement(ObjectRepository.loginid_text).SendKeysWithSpace(id);
                //createaccount.GetElement(ObjectRepository.passwd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                //createaccount.GetElement(ObjectRepository.confirmpasswd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                createaccount.GetElement(ObjectRepository.fname_text).SendKeysWithSpace(fname);
                createaccount.GetElement(ObjectRepository.lname_text).SendKeysWithSpace(lname);
                createaccount.GetElement(ObjectRepository.email_text).SendKeysWithSpace(email);
                if (createaccount.existsElement(By.XPath("//input[contains(@id,'MainContent_UC1_USRX_')]")))
                {
                    createaccount.GetElement(By.XPath("//input[contains(@id,'MainContent_UC1_USRX_')]")).SendKeysWithSpace("testing");

                }
                createaccount.ScrollToCoordinated("500", "500");
                createaccount.GetElement(ObjectRepository.org_select_link).ClickWithSpace();
                Thread.Sleep(5000);
                //createaccount.SelectFrame();
                createaccount.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                Thread.Sleep(5000);
                createaccount.WaitForElement(ObjectRepository.org_search_text);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populatecreateaccountform failed");
                tocreateaccount = false;
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Populate Create Account Form", createaccount);
                
            }

        }
        public void populatecreateaccountformforsf()
        {
            //if (tocreateaccount == false)
            //{
            //    return;
            //}
            try
            {
                createaccount.WaitForElement(ObjectRepository.loginid_text);
                createaccount.GetElement(ObjectRepository.loginid_text).SendKeysWithSpace(MasterDic_sfuser["Id"] + Common.token);
                //createaccount.GetElement(ObjectRepository.passwd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                //createaccount.GetElement(ObjectRepository.confirmpasswd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                createaccount.GetElement(ObjectRepository.fname_text).SendKeysWithSpace(MasterDic_sfuser["Firstname"]);
                createaccount.GetElement(ObjectRepository.lname_text).SendKeysWithSpace(MasterDic_sfuser["Lastname"]);
                createaccount.GetElement(ObjectRepository.email_text).SendKeysWithSpace(MasterDic_sfuser["Id"] + "@xyz.com");
                createaccount.GetElement(ObjectRepository.org_select_link).ClickWithSpace();
                Thread.Sleep(5000);
                //createaccount.SelectFrame();
                createaccount.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                Thread.Sleep(5000);
                createaccount.WaitForElement(ObjectRepository.org_search_text);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populatecreateaccountform failed");
                tocreateaccount = false;
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Populate Create Account form foe SF-182 User", createaccount);
               
            }

        }

        public void populateaccountsearchform(string browserstr)
        {
          
            try
            {

                //createaccount.GetElement(ObjectRepository.passwd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                //createaccount.GetElement(ObjectRepository.confirmpasswd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                createaccount.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtFirstName']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Firstname"]+browserstr);
                createaccount.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtLastName']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Lastname"]+browserstr);
                createaccount.FindSelectElementnew(By.Id("MainContent_ucUserSimpleSearch_ddlUserSearchStd"), "All Domains");
                //createaccount.GetElement(ObjectRepository.email_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Id"]+browserstr + "@xyz.com");
                //createaccount.GetElement(ObjectRepository.org_select_link).ClickWithSpace();
                //Thread.Sleep(5000);
                //createaccount.SelectFrame();
                //Thread.Sleep(5000);
                //createaccount.WaitForElement(ObjectRepository.org_search_text);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populatecreateaccountform failed");
                tocreateaccount = false;
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Serach User in People", createaccount);
               
            }

        }

        public void populateaccountsearchformforregression(string browserstr)
        {
            //if (tocreateaccount == false)
            //{
            //    return;
            //}
            try
            {

                //createaccount.GetElement(ObjectRepository.passwd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                //createaccount.GetElement(ObjectRepository.confirmpasswd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                createaccount.WaitForElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtFirstName']"));
                createaccount.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtFirstName']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Firstname"]+browserstr);
                createaccount.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtLastName']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Lastname"]+browserstr);
                createaccount.FindSelectElementnew(By.Id("MainContent_ucUserSimpleSearch_ddlUserSearchStd"), "All Domains");
                //createaccount.GetElement(ObjectRepository.email_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Id"]+browserstr + "@xyz.com");
                //createaccount.GetElement(ObjectRepository.org_select_link).ClickWithSpace();
                //Thread.Sleep(5000);
                //createaccount.SelectFrame();
                //Thread.Sleep(5000);
                //createaccount.WaitForElement(ObjectRepository.org_search_text);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populatecreateaccountform failed");
                tocreateaccount = false;
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Serach User in People", createaccount);
               
            }

        }
        public void populateaccountsearchformforregressioncustomized(string fname,string lname)
        {
            //if (tocreateaccount == false)
            //{
            //    return;
            //}
            try
            {

                //createaccount.GetElement(ObjectRepository.passwd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                //createaccount.GetElement(ObjectRepository.confirmpasswd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                createaccount.GetElement(By.XPath("//input[@id='SEARCH_FOR']")).SendKeysWithSpace(fname);
//createaccount.GetElement(By.XPath("//input[@id='USR_LAST_NAME']")).SendKeysWithSpace(lname);
                //createaccount.GetElement(ObjectRepository.email_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Id"]+browserstr + "@xyz.com");
                //createaccount.GetElement(ObjectRepository.org_select_link).ClickWithSpace();
                //Thread.Sleep(5000);
                //createaccount.SelectFrame();
                //Thread.Sleep(5000);
                //createaccount.WaitForElement(ObjectRepository.org_search_text);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populatecreateaccountform failed");
                tocreateaccount = false;
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Serach User in People", createaccount);
            
            }

        }

        public void populateaccountsearchformforsf()
        {
            //if (tocreateaccount == false)
            //{
            //    return;
            //}
            try
            {

                //createaccount.GetElement(ObjectRepository.passwd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                //createaccount.GetElement(ObjectRepository.confirmpasswd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                createaccount.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtFirstName']")).SendKeysWithSpace(MasterDic_sfuser["Firstname"]);
                createaccount.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtLastName']")).SendKeysWithSpace(MasterDic_sfuser["Lastname"]);
                //createaccount.GetElement(ObjectRepository.email_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Id"]+browserstr + "@xyz.com");
                //createaccount.GetElement(ObjectRepository.org_select_link).ClickWithSpace();
                //Thread.Sleep(5000);
                //createaccount.SelectFrame();
                //Thread.Sleep(5000);
                //createaccount.WaitForElement(ObjectRepository.org_search_text);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populatecreateaccountform failed");
                tocreateaccount = false;
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Populate User for Search in People", createaccount);
               
            }

        }
        public string buttonsearchclick()
        {
            //if (tocreateaccount == false)
            //{
            //    return "";
            //}
            try
            {
                createaccount.WaitForElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_btnSearch']"));
                createaccount.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_btnSearch']")).ClickWithSpace();
                //createaccount.findandacceptalert();
                createaccount.WaitForElement(By.XPath("//input[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_MUsrImgIcon']"));
                // createaccount.WaitForElement(ObjectRepository.sucessmessage);
           //     createaccount.GetElement(By.XPath("//input[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl02_ctl01_chkHdTempUsr']")).ClickWithSpace();

                // string actualresult = createaccount.GetElement(ObjectRepository.sucessmessage).Text;
                return "true";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populateselectorganizationform failed");
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Serach User in People", createaccount);
             

                return "the search failed";

            }

            // return createaccount.GetElement(By.Id(Object.login_name)).Text

        }
        public string buttonsearchclick1()
        {
            //if (tocreateaccount == false)
            //{
            //    return "";
            //}
            try
            {
                createaccount.WaitForElement(By.XPath("//button[@class='btn btn-primary']"));
                createaccount.GetElement(By.XPath("//button[@class='btn btn-primary']")).ClickWithSpace();
                //createaccount.findandacceptalert();
                createaccount.WaitForElement(By.Id("ddlUsrAction_0"));
                // createaccount.WaitForElement(ObjectRepository.sucessmessage);
               // createaccount.GetElement(By.XPath("//input[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl02_ctl01_chkHdTempUsr']")).ClickWithSpace();

                // string actualresult = createaccount.GetElement(ObjectRepository.sucessmessage).Text;
                return "true";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populateselectorganizationform failed");
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Serach User in People", createaccount);
              

                return "the search failed";

            }

            // return createaccount.GetElement(By.Id(Object.login_name)).Text

        }
        public string passwordcreation(string browserstr)
        {
            //if (tocreateaccount == false)
            //{
            //    return "";
            //}
            try
            {
                createaccount.WaitForElement(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"));
                createaccount.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Login Assistance");
                createaccount.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
                //createaccount.SelectFrame();
                createaccount.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                createaccount.WaitForElement(By.Id("MainContent_UC1_Save"));
                createaccount.GetElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();
                createaccount.WaitForElement(By.XPath("//div[@class='forms-msg-success']"));
                string result = createaccount.GetElement(By.XPath("//div[@class='forms-msg-success']")).Text;
                var elements = result.Split(' ');
                string passwd = elements[5];
                passwd = passwd.Replace(".", "");
                //  var words = elements[4].Split(' ');
                //foreach (var word in elements)
                //{
                //    return elements[5];
                //  //  Console.WriteLine(string.Concat(elements[0], ",", elements[1], ",", elements[2], ",", elements[3], ",", word));
                //}

                // string actualresult = createaccount.GetElement(ObjectRepository.sucessmessage).Text;
                createaccount.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                createaccount.tempUserLogin("sfuser", MasterDic_sfuser["Id"] + Common.token, passwd, browserstr);
                return result; 

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populateselectorganizationform failed");
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Genrate Password for Users", createaccount);
               

                return "";

            }

            // return createaccount.GetElement(By.Id(Object.login_name)).Text

        }
        public string passwordcreationnewuser(string browserstr)
        {
            //if (tocreateaccount == false)
            //{
            //    return "";
            //}
            try
            {
                createaccount.WaitForElement(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"));
                createaccount.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Login Assistance");
                createaccount.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
                //createaccount.SelectFrame();
                createaccount.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                createaccount.WaitForElement(By.Id("MainContent_UC1_Save"));
                createaccount.GetElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();
                Thread.Sleep(3000);
                createaccount.WaitForElement(By.XPath("//div[@class='forms-msg-success']"));
                string result = createaccount.GetElement(By.XPath("//div[@class='forms-msg-success']")).Text;
                var elements = result.Split(' ');
                string passwd = elements[5];
                passwd = passwd.Replace(".", "");
                //  var words = elements[4].Split(' ');
                //foreach (var word in elements)
                //{
                //    return elements[5];
                //  //  Console.WriteLine(string.Concat(elements[0], ",", elements[1], ",", elements[2], ",", elements[3], ",", word));
                //}

                // string actualresult = createaccount.GetElement(ObjectRepository.sucessmessage).Text;
                createaccount.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
               // Thread.Sleep(5000);
                createaccount.tempUserLogin("user", "", passwd, browserstr);
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populateselectorganizationform failed");
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Genrate Password for Users", createaccount);
                

                return "";

            }

            // return createaccount.GetElement(By.Id(Object.login_name)).Text

        }
        public string passwordcreationforregression(string browserstr)
        {
            //if (tocreateaccount == false)
            //{
            //    return "";
            //}
            try
            {
                createaccount.WaitForElement(By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction"));
                createaccount.select(By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction"), "Login Assistance");
                createaccount.GetElement(By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo")).ClickWithSpace();
                //createaccount.SelectFrame();
                createaccount.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                createaccount.WaitForElement(By.Id("MainContent_UC1_Save"));
                createaccount.GetElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();
                Thread.Sleep(3000);
                createaccount.WaitForElement(By.XPath("//div[@class='forms-msg-success']"));
                string result = createaccount.GetElement(By.XPath("//div[@class='forms-msg-success']")).Text;
                Thread.Sleep(5000);
                var elements = result.Split(' ');
                string passwd = elements[5];
                passwd = passwd.Replace(".", "");
                //  var words = elements[4].Split(' ');
                //foreach (var word in elements)
                //{
                //    return elements[5];
                //  //  Console.WriteLine(string.Concat(elements[0], ",", elements[1], ",", elements[2], ",", elements[3], ",", word));
                //}

                // string actualresult = createaccount.GetElement(ObjectRepository.sucessmessage).Text;

                createaccount.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

                //Thread.Sleep(5000);
                createaccount.tempUserLogin("userforregression", "", passwd, browserstr);
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populateselectorganizationform failed");
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Genrate Password for Users", createaccount);
               

                return "";

            }

            // return createaccount.GetElement(By.Id(Object.login_name)).Text

        }
        //public string passwordcreationforregressioncustomize(string type)
        //{
        //    //if (tocreateaccount == false)
        //    //{
        //    //    return "";
        //    //}
        //    try
        //    {
        //        createaccount.WaitForElement(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"));
        //        createaccount.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Login Assistance");
        //        createaccount.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
        //        Thread.Sleep(3000);
        //        createaccount.SelectFrame();
        //        createaccount.WaitForElement(By.Id("MainContent_UC1_Save"));
        //        Thread.Sleep(3000);
        //        createaccount.GetElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();
        //        Thread.Sleep(5000);
        //        createaccount.WaitForElement(By.XPath("//div[@class='forms-msg-success']"));
        //        string result = createaccount.GetElement(By.XPath("//div[@class='forms-msg-success']")).Text;
        //        Thread.Sleep(3000);
        //        var elements = result.Split(' ');
        //        string passwd = elements[5];
        //        passwd = passwd.Replace(".", "");
        //        //  var words = elements[4].Split(' ');
        //        //foreach (var word in elements)
        //        //{
        //        //    return elements[5];
        //        //  //  Console.WriteLine(string.Concat(elements[0], ",", elements[1], ",", elements[2], ",", elements[3], ",", word));
        //        //}

        //        // string actualresult = createaccount.GetElement(ObjectRepository.sucessmessage).Text;

        //        createaccount.LogoutUser(ObjectRepository.LogoutHoverLink);


        //        createaccount.tempUserLogin1(type, "", passwd);
        //        return result;

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message + "populateselectorganizationform failed");
        //        ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Genrate Password for Users", createaccount);
                

        //        return "";

        //    }

        //    // return createaccount.GetElement(By.Id(Object.login_name)).Text

        //}
        public string passwordcreationforprxylogin(string browserstr)
        {
           
            try
            {
                createaccount.WaitForElement(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"));
                createaccount.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Login Assistance");
                createaccount.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
                createaccount.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                createaccount.WaitForElement(By.Id("MainContent_UC1_Save"));
                createaccount.GetElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();
                createaccount.WaitForElement(By.XPath("//div[@class='forms-msg-success']"));
                string result = createaccount.GetElement(By.XPath("//div[@class='forms-msg-success']")).Text;
                var elements = result.Split(' ');
                string passwd = elements[5];
                passwd = passwd.Replace(".", "");
                //  var words = elements[4].Split(' ');
                //foreach (var word in elements)
                //{
                //    return elements[5];
                //  //  Console.WriteLine(string.Concat(elements[0], ",", elements[1], ",", elements[2], ",", elements[3], ",", word));
                //}

                // string actualresult = createaccount.GetElement(ObjectRepository.sucessmessage).Text;
                createaccount.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                createaccount.tempUserLogin("userforregression1", "", passwd, browserstr);
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populateselectorganizationform failed");
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Genrate Password for Users", createaccount);
                

                return "";

            }

            // return createaccount.GetElement(By.Id(Object.login_name)).Text

        }
        public void populateselectorganizationform(string browserstr)
        {
            //if (tocreateaccount == false)
            //{
            //    return;
            //}

            try
            {
               createaccount.GetElement(ObjectRepository.org_search_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_sforg["Title"]+browserstr);

                Thread.Sleep(5000);
                createaccount.GetElement(ObjectRepository.org_search_btn).ClickWithSpace();
                //  createaccount.WaitForElement(By.Id(Object.org_search_btn));
                Thread.Sleep(5000);
                createaccount.GetElement(ObjectRepository.org_radio_btn).ClickWithSpace();
                Thread.Sleep(5000);
                createaccount.GetElement(ObjectRepository.org_save_btn).ClickWithSpace();
                createaccount.WaitForElement(ObjectRepository.org_create_btn);

                //createaccount.GetElement(By.Id(Object.org_create_btn)).ClickWithSpace();
                //// createaccount.WaitForElement(By.Id(Object.login_name));
                //createaccount.WaitForElement(By.XPath("/html/body/form/div[6]/div/div[2]/div/div/ul/li/a/span"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populateselectorganizationform failed");
                tocreateaccount = false;
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Select Organization for Creating New User", createaccount);
              
            }
            // return createaccount.GetElement(By.Id(Object.login_name)).Text

        }
        public void populateselectorganizationformforregression()
        {
            //if (tocreateaccount == false)
            //{
            //    return;
            //}

            try
            {
                createaccount.WaitForElement(By.Id("MainContent_UC1_txtSearch"));
                createaccount.GetElement(By.Id("MainContent_UC1_txtSearch")).SendKeysWithSpace("Sample Organization");

                Thread.Sleep(3000);
                createaccount.GetElement(ObjectRepository.org_search_btn).ClickWithSpace();
                //  createaccount.WaitForElement(By.Id(Object.org_search_btn));
                Thread.Sleep(5000);
                createaccount.GetElement(ObjectRepository.org_radio_btn).ClickWithSpace();
                Thread.Sleep(5000);
                createaccount.GetElement(By.Id("MainContent_UC1_FormView1_Save")).ClickWithSpace();
                createaccount.WaitForElement(ObjectRepository.org_create_btn);

                //createaccount.GetElement(By.Id(Object.org_create_btn)).ClickWithSpace();
                //// createaccount.WaitForElement(By.Id(Object.login_name));
                //createaccount.WaitForElement(By.XPath("/html/body/form/div[6]/div/div[2]/div/div/ul/li/a/span"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populateselectorganizationform failed");
                tocreateaccount = false;
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Select Organization for Creating New User", createaccount);
               
            }
            // return createaccount.GetElement(By.Id(Object.login_name)).Text

        }
        public string buttoncreateclick()
        {
            //if (tocreateaccount == false)
            //{
            //    return "";
            //}
            try
            {
                // createaccount.GetElement(ObjectRepository.passwd_text).Clear();
                //  createaccount.GetElement(ObjectRepository.passwd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                //createaccount.GetElement(ObjectRepository.passwd_text).Clear();
                //   createaccount.GetElement(ObjectRepository.confirmpasswd_text).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"]);
                createaccount.WaitForElement(ObjectRepository.org_create_btn);
                createaccount.GetElement(ObjectRepository.org_create_btn).ClickWithSpace();
                //createaccount.findandacceptalert();
                createaccount.WaitForElement(ObjectRepository.sucessmessage);
                //  createaccount.WaitForElement(ObjectRepository.TrainingHome);
                //string actualresult=createaccount.GetElement(ObjectRepository.TrainingHome).Text; //commented for 14.1

                string actualresult = createaccount.GetElement(ObjectRepository.sucessmessage).Text;
                return actualresult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "populateselectorganizationform failed");
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Search for Adding Organization to new user being Created", createaccount);
               

                return "";

            }

            // return createaccount.GetElement(By.Id(Object.login_name)).Text

        }

       

    }
}
