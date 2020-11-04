using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using LinqToExcel;
using System.IO;
using relativepath;
using Utility;
// using TestAutomation.Data;

namespace Selenium2.Meridian
{
    public class ExtractDataExcel
    {

        public static string token = string.Empty;
        public static string token_for_reg = string.Empty;

        public static Dictionary<string, string> MasterDic_newuser = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_smokeuser = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_admin = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_admin1 = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_child1admin = new Dictionary<string, string>();

        public static Dictionary<string, string> MasterDic_document = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_scrom = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_genralcourse = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_classrommcourse = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_ojt = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_userforreg = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_userforhr = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_userforhelpdesk = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_product = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_discount = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_approver = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_announcement = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_certification = new Dictionary<string, string>();

        public static Dictionary<string, string> MasterDic_ELType = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_EL = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_curriculam = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_sforg = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_sfvendor = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_aicc = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_CSpace = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_FAQ = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_Survey = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_TrainingProfile = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_CourseProvider = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_AccountCode = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_AccountCodeType = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_DiscountCode = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_CreditTypes = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_JobTitle = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_EducationLevel = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_GoToMeeting = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_GoToTraining = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_Adobe = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_Assignment = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_idpadmin = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_ProficencyScale = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_instructor = new Dictionary<string, string>();
        public static Dictionary<string, string> MasterDic_Webex = new Dictionary<string, string>();
        public static void fillalldic()
        {
            token = Class_utility.token();
            token_for_reg = Class_utility.token();
            NewUser();
            SmokeUser();
            admin();
            admin1();
            idpadmin();
            userforregression();
            userforhr();
            userforhelpdesk();
            announcementforregression();
            Product();
            Discount();
            Approver();
            Scrom12();
            document();
            GeneralCourse();
            ClassroomCourse();
            Certifications();
            EL();
            ELType();
            sforg();
            sfvendor();
            Curriculam();
            OnlineJobTraining();
            Aicc();
            CSpace();
            faqforregression();
            surveyforregression();
            TrainingProfile();
            CourseProvider();
            AccountCode();
            AccountCodeType();
            DiscountCode();
            CreditTypes();
            JobTitle();
            GoToMeeting();
            Assignment();
            GoToTraining();
            Adobe();
            Webex();
            ProficencyScale();
            Instructor();
            child1admin();
            EducationLevel();
        }

        #region functions for regression
        public static void NewUser()
        {

            string data;
            // token_for_reg = token_for_reg + "1";
            // Initialize the linq to excel provider
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("Login")
                        where p["DataID"].ToString() == "newuser"
                        select p;

            MasterDic_newuser = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() + token }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() + token }, { "Lastname", query.First().ItemArray[4].ToString() + token }, { "Email", query.First().ItemArray[5].ToString() } };
            // MasterDic = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString()}, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString()}, { "Lastname", query.First().ItemArray[4].ToString() }, { "Email", query.First().ItemArray[5].ToString() } };

        }

        public static void SmokeUser()
        {
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("Login")
                        where p["DataID"].ToString() == "smokeuser"
                        select p;
            MasterDic_smokeuser = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() + token }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() + token }, { "Lastname", query.First().ItemArray[4].ToString() + token }, { "Email", query.First().ItemArray[5].ToString() } };
        }

        public static void admin()
        {


            // Initialize the linq to excel provider
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("login")
                        where p["DataID"].ToString() == "admin"
                        select p;

            MasterDic_admin = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() }, { "Lastname", query.First().ItemArray[4].ToString() } };

        }
        public static void admin1()
        {


            // Initialize the linq to excel provider
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("login")
                        where p["DataID"].ToString() == "admin1"
                        select p;

            MasterDic_admin1 = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() }, { "Lastname", query.First().ItemArray[4].ToString() } };

        }

        public static void child1admin()
        {


            // Initialize the linq to excel provider
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("login")
                        where p["DataID"].ToString() == "child1admin"
                        select p;

            MasterDic_child1admin = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() }, { "Lastname", query.First().ItemArray[4].ToString() } };

        }
        public static void idpadmin()
        {

            string data;
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("Login")
                        where p["DataID"].ToString() == "idpadmin"
                        select p;

            MasterDic_idpadmin = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() + token }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() + token }, { "Lastname", query.First().ItemArray[4].ToString() + token }, { "Email", query.First().ItemArray[5].ToString() } };
            // MasterDic = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString()}, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString()}, { "Lastname", query.First().ItemArray[4].ToString() }, { "Email", query.First().ItemArray[5].ToString() } };

        }
        public static void userforregression()
        {


            // Initialize the linq to excel provider
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("login")
                        where p["DataID"].ToString() == "userforregression"
                        select p;

            MasterDic_userforreg = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() + token }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() + token }, { "Lastname", query.First().ItemArray[4].ToString() + token }, { "Email", query.First().ItemArray[5].ToString() }, { "Org", query.First().ItemArray[9].ToString() } };
           // MasterDic_userforreg = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() }, { "Lastname", query.First().ItemArray[4].ToString() } };

        }

        public static void Instructor()
        {


            // Initialize the linq to excel provider
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("Login")
                        where p["DataID"].ToString() == "instructor"
                        select p;

            //MasterDic_userforreg = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() + token }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() + token }, { "Lastname", query.First().ItemArray[4].ToString() + token } };
            MasterDic_instructor = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() + token }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() + token }, { "Lastname", query.First().ItemArray[4].ToString() + token }, { "Email", query.First().ItemArray[5].ToString() + token } };

        }

        //public static void userforregression()
        //{


        //    // Initialize the linq to excel provider
        //    RelativeDirectory rd = new RelativeDirectory();
        //    LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

        //    // Query the worksheet to get detail of new user from Excel Sheet
        //    var query = from p in provider.GetWorkSheet("login")
        //                where p["DataID"].ToString() == "userforregression"
        //                select p;

        //    MasterDic_userforreg = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString()}, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() + token }, { "Lastname", query.First().ItemArray[4].ToString() + token } };

        //}

        public static void userforhelpdesk()
        {


            // Initialize the linq to excel provider
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("login")
                        where p["DataID"].ToString() == "helpdeskuser"
                        select p;

            MasterDic_userforhelpdesk = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() + token }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() + token }, { "Lastname", query.First().ItemArray[4].ToString() + token }, { "Email", query.First().ItemArray[5].ToString() } };

        }
        public static void userforhr()
        {


            // Initialize the linq to excel provider
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("login")
                        where p["DataID"].ToString() == "hruser"
                        select p;

            MasterDic_userforhr = new Dictionary<string, string>() { { "Id", query.First().ItemArray[1].ToString() + token }, { "Password", query.First().ItemArray[2].ToString() }, { "Firstname", query.First().ItemArray[3].ToString() + token }, { "Lastname", query.First().ItemArray[4].ToString() + token }, { "Email", query.First().ItemArray[5].ToString() + token } };

        }
        public static void announcementforregression()
        {


            // Initialize the linq to excel provider
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("Announcement")
                        where p["DataID"].ToString() == "Announcement"
                        select p;

            MasterDic_announcement = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Announcement", query.First().ItemArray[2].ToString() }, { "Url", query.First().ItemArray[3].ToString() } };

        }

        public static string GeneralCourse()
        {
            string data = string.Empty;
            try
            {


                RelativeDirectory rd = new RelativeDirectory();
                LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

                var query = from p in provider.GetWorkSheet("General_course")
                            where p["DataID"].ToString() == "gereralcourseforregression"
                            select p;

                MasterDic_genralcourse = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() }, { "Url", query.First().ItemArray[7].ToString() }, { "cost", query.First().ItemArray[3].ToString() } };


            }
            catch (Exception ex)
            {

            }
            return data;

        }

        public static string Product()
        {
            string data = string.Empty;
            try
            {


                RelativeDirectory rd = new RelativeDirectory();
                LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

                var query = from p in provider.GetWorkSheet("Product")
                            where p["DataID"].ToString() == "productforregression"
                            select p;

                MasterDic_product = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() }, { "cost", query.First().ItemArray[3].ToString() }, { "shipping", query.First().ItemArray[4].ToString() }, { "handling", query.First().ItemArray[5].ToString() }, { "stock", query.First().ItemArray[6].ToString() } };


            }
            catch (Exception ex)
            {

            }
            return data;

        }


        public static string Discount()
        {
            string data = string.Empty;
            try
            {


                RelativeDirectory rd = new RelativeDirectory();
                LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

                var query = from p in provider.GetWorkSheet("Discount")
                            where p["DataID"].ToString() == "discountforregression"
                            select p;

                MasterDic_discount = new Dictionary<string, string>() { { "Name", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() }, { "code", query.First().ItemArray[3].ToString() + token }, { "discount", query.First().ItemArray[4].ToString() }, { "user", query.First().ItemArray[5].ToString() } };


            }
            catch (Exception ex)
            {

            }
            return data;

        }

        public static string Approver()
        {
            string data = string.Empty;
            try
            {


                RelativeDirectory rd = new RelativeDirectory();
                LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

                var query = from p in provider.GetWorkSheet("Approver")
                            where p["DataID"].ToString() == "RegressionApprover"
                            select p;

                MasterDic_approver = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() } };


            }
            catch (Exception ex)
            {

            }
            return data;

        }

        public static void ClassroomCourse()
        {

            try
            {

                String[] ClassroomCoursedata = new String[9];
                //string data = string.Empty;
                RelativeDirectory rd = new RelativeDirectory();
                LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

                var query = from p in provider.GetWorkSheet("Classroom_course")
                            where p["DataID"].ToString() == "classroomcourse1"
                            select p;
                MasterDic_classrommcourse = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() }, { "Url", query.First().ItemArray[7].ToString() } };
            }//end method
            catch (Exception ex)
            {

            }


        }

        public static void document()
        {


            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


            var query = from p in provider.GetWorkSheet("Document")
                        where p["DataID"].ToString() == "document1"
                        select p;

            MasterDic_document = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() }, { "Url", query.First().ItemArray[3].ToString() } };
        }
        public static void Scrom12()
        {


            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


            var query = from p in provider.GetWorkSheet("Scrom12")
                        where p["DataID"].ToString() == "scrom1"
                        select p;


            MasterDic_scrom = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() }, { "Url", query.First().ItemArray[7].ToString() } };
        }
        public static void Aicc()
        {


            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


            var query = from p in provider.GetWorkSheet("AICC")
                        where p["DataID"].ToString() == "aicc1"
                        select p;


            MasterDic_aicc = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() }, { "Url", query.First().ItemArray[7].ToString() } };
        }

        public static void Certifications()
        {


            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


            var query = from p in provider.GetWorkSheet("Certification")
                        where p["DataID"].ToString() == "RegressionCertification"
                        select p;


            MasterDic_certification = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() }, { "Type", query.First().ItemArray[3].ToString() } };
        }


        public static void ELType()
        {


            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


            var query = from p in provider.GetWorkSheet("External_Learning")
                        where p["DataID"].ToString() == "External_Learning_Type"
                        select p;


            MasterDic_ELType = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() } };
        }

        public static void EL()
        {


            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


            var query = from p in provider.GetWorkSheet("External_Learning")
                        where p["DataID"].ToString() == "External_Learning"
                        select p;


            MasterDic_EL = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() } };
        }

        public static void sforg()
        {


            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


            var query = from p in provider.GetWorkSheet("sf182_org")
                        where p["DataID"].ToString() == "organization"
                        select p;


            MasterDic_sforg = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() }, { "Code", query.First().ItemArray[3].ToString() + token_for_reg }, { "Parent", query.First().ItemArray[4].ToString() } };
        }

        public static void sfvendor()
        {


            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


            var query = from p in provider.GetWorkSheet("sf182_vendor")
                        where p["DataID"].ToString() == "Vendor"
                        select p;


            MasterDic_sfvendor = new Dictionary<string, string>() { { "Name", query.First().ItemArray[1].ToString() + token }, { "Phone", query.First().ItemArray[2].ToString() }, { "Email", query.First().ItemArray[3].ToString() }, { "TaxId", query.First().ItemArray[4].ToString() }, { "Address", query.First().ItemArray[5].ToString() } };
        }

        public static void Curriculam()
        {


            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


            var query = from p in provider.GetWorkSheet("Curriculam")
                        where p["DataID"].ToString() == "RegressionCurriculam"
                        select p;


            MasterDic_curriculam = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() } };
        }

        public static void OnlineJobTraining()
        {

            try
            {

                String[] OJTdata = new String[9];
                //string data = string.Empty;
                RelativeDirectory rd = new RelativeDirectory();
                LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

                var query = from p in provider.GetWorkSheet("Online_Job_Training")
                            where p["DataID"].ToString() == "ojt1"
                            select p;
                MasterDic_ojt = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() }, { "Url", query.First().ItemArray[7].ToString() } };
            }//end method
            catch (Exception ex)
            {

            }


        }
        public static void CSpace()
        {


            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


            var query = from p in provider.GetWorkSheet("CSpace")
                        where p["DataID"].ToString() == "RegressionCSpace"
                        select p;


            MasterDic_CSpace = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Type", query.First().ItemArray[2].ToString() }, { "HomeText", query.First().ItemArray[3].ToString() } };
        }


        public static void faqforregression()
        {


            // Initialize the linq to excel provider
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("faq")
                        where p["DataID"].ToString() == "FAQ"
                        select p;

            MasterDic_FAQ = new Dictionary<string, string>() { { "Question", query.First().ItemArray[1].ToString() + token }, { "Answer", query.First().ItemArray[2].ToString() }, { "Source", query.First().ItemArray[3].ToString() } };

        }

        public static void surveyforregression()
        {


            // Initialize the linq to excel provider
            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

            // Query the worksheet to get detail of new user from Excel Sheet
            var query = from p in provider.GetWorkSheet("Survey")
                        where p["DataID"].ToString() == "Survey"
                        select p;

            MasterDic_Survey = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() }, { "Type", query.First().ItemArray[3].ToString() }, { "Scale", query.First().ItemArray[4].ToString() + token } };

        }

          public static void TrainingProfile()
        {


            RelativeDirectory rd = new RelativeDirectory();
            LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


            var query = from p in provider.GetWorkSheet("TrainingProfile")
                        where p["DataID"].ToString() == "RegressionTP"
                        select p;


            MasterDic_TrainingProfile= new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() } };
        }

          public static void CourseProvider()
          {


              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


              var query = from p in provider.GetWorkSheet("CourseProvider")
                          where p["DataID"].ToString() == "RegressionCP"
                          select p;


              MasterDic_CourseProvider = new Dictionary<string, string>() { { "Name", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() } };
          }

          public static void AccountCode()
          {


              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


              var query = from p in provider.GetWorkSheet("AccountCode")
                          where p["DataID"].ToString() == "acccodeforregression"
                          select p;


              MasterDic_AccountCode = new Dictionary<string, string>() { { "Name", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() } };
          }

          public static void AccountCodeType()
          {


              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


              var query = from p in provider.GetWorkSheet("AccountCodeType")
                          where p["DataID"].ToString() == "acccodetypeforregression"
                          select p;


              MasterDic_AccountCodeType = new Dictionary<string, string>() { { "Name", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() } };
          }

          public static void DiscountCode()
          {


              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


              var query = from p in provider.GetWorkSheet("DiscountCode")
                          where p["DataID"].ToString() == "discodeforregression"
                          select p;


              MasterDic_DiscountCode = new Dictionary<string, string>() { { "Name", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() } };
          }
          public static void CreditTypes()
          {


              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


              var query = from p in provider.GetWorkSheet("CreditTypes")
                          where p["DataID"].ToString() == "credittypesforregression"
                          select p;


              MasterDic_CreditTypes = new Dictionary<string, string>() { { "Name", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() } };
          }
          public static void JobTitle()
          {


              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


              var query = from p in provider.GetWorkSheet("JobTitle")
                          where p["DataID"].ToString() == "JobTitleforregression"
                          select p;


              MasterDic_JobTitle = new Dictionary<string, string>() { { "Name", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() } };
          }

          public static void EducationLevel()
          {
              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

              var query = from p in provider.GetWorkSheet("EducationLevel")
                          where p["DataID"].ToString() == "EducationLevelforregression"
                          select p;
              MasterDic_EducationLevel = new Dictionary<string, string>() { { "Name", query.First().ItemArray[1].ToString() + token }, { "Desc", query.First().ItemArray[2].ToString() } };
          }

          public static void GoToMeeting()
          {
              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

              var query = from p in provider.GetWorkSheet("Connector")
                          where p["DataID"].ToString() == "ConnectorforGoToMeeting"
                          select p;
              MasterDic_GoToMeeting = new Dictionary<string, string>() { { "Name", query.First().ItemArray[1].ToString()}, { "Password", query.First().ItemArray[2].ToString() }, { "ClientId", query.First().ItemArray[3].ToString() } };
          }

          public static void GoToTraining()
          {
              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

              var query = from p in provider.GetWorkSheet("Connector")
                          where p["DataID"].ToString() == "ConnectorforGoToTraining"
                          select p;
              MasterDic_GoToTraining = new Dictionary<string, string>() { { "Name", query.First().ItemArray[1].ToString() }, { "Password", query.First().ItemArray[2].ToString() }, { "ClientId", query.First().ItemArray[3].ToString() } };
          }
          public static void Adobe()
          {
              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

              var query = from p in provider.GetWorkSheet("Connector")
                          where p["DataID"].ToString() == "ConnectorforAdobe"
                          select p;
              MasterDic_Adobe = new Dictionary<string, string>() { { "Name", query.First().ItemArray[1].ToString() }, { "Password", query.First().ItemArray[2].ToString() }, { "URL", query.First().ItemArray[3].ToString() } };
          }
          public static void Webex()
          {
              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

              var query = from p in provider.GetWorkSheet("Connector")
                          where p["DataID"].ToString() == "ConnectorforWebex"
                          select p;
              MasterDic_Webex = new Dictionary<string, string>() { { "URL", query.First().ItemArray[1].ToString() }, { "Username", query.First().ItemArray[2].ToString() },{ "Password", query.First().ItemArray[3].ToString() }, { "Siteid", query.First().ItemArray[4].ToString() }, { "Partnerid", query.First().ItemArray[5].ToString() } };
          }
          public static void Assignment()
          {
              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");

              var query = from p in provider.GetWorkSheet("Assignment")
                          where p["DataID"].ToString() == "AssignmentforRegression"
                          select p;
              MasterDic_Assignment = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() }, { "Desc", query.First().ItemArray[2].ToString() }, { "ItemWeight", query.First().ItemArray[3].ToString() } };
          }
          public static void ProficencyScale()
          {


              RelativeDirectory rd = new RelativeDirectory();
              LinqToExcelProvider provider = new LinqToExcelProvider(rd.Up(2) + "Data\\Regression2.xls");


              var query = from p in provider.GetWorkSheet("ProficencyScale")
                          where p["DataID"].ToString() == "RegressionProficencyScale"
                          select p;


              MasterDic_ProficencyScale = new Dictionary<string, string>() { { "Title", query.First().ItemArray[1].ToString() + token }, { "Label", query.First().ItemArray[2].ToString() }, { "DB", query.First().ItemArray[3].ToString() } };
          }

        #endregion
    }
}
