using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using relativepath;
using Selenium2.Meridian;

namespace Utility
{

    class Class_utility
    {
        public static String[] Logincredential()
        {
            string tok;
            string token = string.Format("{0:ddhhmmss}", DateTime.Now);
            string[] name = new string[4];
            tok = token;
            //name[0] = "Autotester";
            //name[1] = "Tpg";
            //name[2] = "bred_"+tok;
            //name[3] = "password";
            //name[4] = tok;

            //log("User values as : Fname: " + name[0] + " Lname: " + name[1] + " Login:  bred_" + tok + " Password: password");
            return name;
        }

        public string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }

        public static string token()
        {
            string token = Meridian_Common.globalnum;
            return token;
        }

     

        public static void log(string text)
        {
            DateTime time = DateTime.Now;
            string format = "Mdhmmyy";//"M d h:mm yy" Use this format
            RelativeDirectory rd = new RelativeDirectory();

            TextWriter tw = new StreamWriter(rd.Up(2) + "\\log\\log" + time.ToString(format) + ".txt", true);
            //tw.WriteLine("Execution start at ----" + DateTime.Now + "---------------");
            tw.WriteLine(" ");
            tw.WriteLine("[" + DateTime.Now + "]" + " " + text);
            tw.Close();

        }


        public string Login_loc(string loc_key)
        {
            string loc = string.Empty;
            //Create Dictionary with two key value pairs.
            var dict = new Dictionary<string, string>()
              {
                    {"login_link","lnkCreateAccount"}, //id 
                    {"user_name","MainContent_UC1_USR_LOGIN_ID"}, //id
                    {"user_pass","MainContent_UC1_USR_PASSWORD"},//id
                    {"conf_pass","MainContent_UC1_ConfirmPassword"},//id
                    {"first_name","MainContent_UC1_USR_FIRST_NAME"},//id
                    {"last_name","MainContent_UC1_USR_LAST_NAME"},//id
                    {"e-mail","MainContent_UC1_USR_EMAIL_ADDRESS"},//id
                    {"org","MainContent_UC1_lnkSelectOrg"},//id
                    {"org_srch_btn","MainContent_UC1_btnSearch"},//id
                    {"org_rdo_btn","ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect"},//id
                    {"org_save_btn","MainContent_UC1_Save"},//id
                    {"user_crt_btn","MainContent_UC1_Create"},//id
                    {"logout","Logout"},
               };

            loc = dict[loc_key];
            log("element used to perform action with key as:" + loc + "value in app : " + dict[loc_key]);
            return loc;
        }

        public string Admin_loc(string loc_key)
        {
            string loc = string.Empty;

            //Create Dictionary with two key value pairs.
            var dict = new Dictionary<string, string>()
              {
                    {"admin_tab","//*[@id='NavigationStrip1_lnkAdminConsole']"},
                    {"adminconsole","Administration Console"},
                    //course links
                    {"document_link","//a[contains(text(),'Documents')]"},
                    {"scrom12_link","//a[contains(text(),'SCORM 1.2')]"},
                    {"generalcourse_link","//a[contains(text(),'General Course')]"},
                    //Home link
                    {"Home_link","//a[contains(text(),'Home')]"},
                    
               };

            loc = dict[loc_key];
            log("element used to perform action with key as:" + loc + "value in app : " + dict[loc_key]);
            return loc;
        }

        public string Scrom12_loc(string loc_key)
        {
            string loc = string.Empty;

            //Create Dictionary with two key value pairs.
            var dict = new Dictionary<string, string>()
              {
                    {"scrom12_fileupload","TabMenu_ML_BASE_TAB_UploadContent_UploadFile"},
                    {"createScrom_BTN","ML.BASE.BTN.Create"},
                    {"scromTitle","TabMenu_ML_BASE_TAB_EditMetadata_CRSW_COURSE_TITLE"},
                    //{"scromSave","ML.BASE.BTN.Save"}
                    {"scromSave",".//*[@id='ML.BASE.BTN.Save']"},
                    {"msg_text","ReturnFeedback"}
              };
            loc = dict[loc_key];
            log("element used to perform action with key as:" + loc + "value in app : " + dict[loc_key]);
            return loc;
        }

        public string document_loc(string loc_key)
        {
            string loc = string.Empty;
            //Create Dictionary with two key value pairs.
            var dict = new Dictionary<string, string>()
              {
                    
                    {"doc_link","//a[contains(text(),'Documents')]"},
                    {"go_btn","TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu"},
                    {"doc_title","TabMenu_ML_BASE_TAB_EditMetadata_DOC_TITLE"},
                    {"doc_desc","TabMenu_ML_BASE_TAB_EditMetadata_DOC_DESCRIPTION"},
                    {"doc_keyword","TabMenu_ML_BASE_TAB_EditMetadata_DOC_KEYWORDS"},
                    {"nxt_btn","ML.BASE.BTN.Next"},
                    {"url_RB","TabMenu_ML_BASE_TAB_EditDocument_EXTERNALFILE_URL"},
                    {"url_ED","TabMenu_ML_BASE_TAB_EditDocument_DOCUMENT_URL"},
                    {"Create_BTN","ML.BASE.BTN.Create"},
                    {"doc_msg","The document was created. Click the workflow steps to enter more information."},
                    {"catogery_CK","//*[@id='TabMenuMLBASETABEditLocationContentLocation_2']/input"},
                    {"save_btn","ML.BASE.BTN.Save"},
                    {"catog_msg","The category information was saved."},
                    {"ChkIn","//*[@id='ML.BASE.WF.Checkin']/span"},
                    //end user locator
                    //Search course user login page
                   {"CourseName_Ed","MainContent_ucQuickSearch_txtSearch"},
                   {"CourseName_Typ","ddlSearchType"},
                   {"CourseSearch_Btn","btnSearch"},
                   {"open_itemBTN","MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst"}

               };

            loc = dict[loc_key];
            log("element used to perform action with key as:" + loc + "value in app : " + dict[loc_key]);
            return loc;
        }

        public string GeneralCourse_loc(string loc_key)
        {
            string loc = string.Empty;
            var dict = new Dictionary<string, string>()
     {
       {"gereralcourse_link","//a[contains(text(),'General Course')]"},
       {"genCourseTitle_ED","TabMenu_ML_BASE_TAB_EditMetadata_CRSW_COURSE_TITLE"},
       {"description","TabMenu_ML_BASE_TAB_EditMetadata_CRSW_DESCRIPTION"},
       {"keyword","TabMenu_ML_BASE_TAB_EditMetadata_CRSW_KEYWORDS"},
       {"course_cost","TabMenu_ML_BASE_TAB_EditMetadata_CRSW_COST"},
       {"duration","TabMenu_ML_BASE_TAB_EditMetadata_CRSW_DURATION"},
       {"course_num","TabMenu_ML_BASE_TAB_EditMetadata_CRSW_NUMBER"},
       {"credit_value","TabMenu_ML_BASE_TAB_EditMetadata_CRSW_CREDIT_VALUE"},
       {"next_btn","ML.BASE.BTN.Next"},
       {"rd_btn","TabMenu_ML_BASE_TAB_UploadFiles_EXTERNALFILE_URL"},
       {"url_txtfld","TabMenu_ML_BASE_TAB_UploadFiles_COURSE_URL"},
       {"create_btn","ML.BASE.BTN.Create"},
       {"enroll_btn","MainContent_ucPrimaryActions_FormView1_EnrollButton"},
       {"veiw_certificate","MainContent_ucPrimaryActions_FormView1_CertificateBlock"}
     };
            loc = dict[loc_key];
            return loc;
        }

        public string Common(string loc_key)
        {
            string loc = string.Empty;
            var dict = new Dictionary<string, string>()
            {
              //course search& create page
              {"go_btn","TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu"},
              {"search_ED","TabMenu_ML_BASE_TAB_Search_SearchFor"},
              {"search_typ","TabMenu_ML_BASE_TAB_Search_SearchType"},
              {"search_btn","TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"},
              {"Create_BTN","ML.BASE.BTN.Create"},
              {"save_btn","ML.BASE.BTN.Save"},
               //{"ChkIn","//*[@id='ML.BASE.WF.Checkin']/span"},
              {"ChkIn","ML.BASE.WF.Checkin"},
              {"Finish","ML.BASE.BTN.Finish"},
              {"Return","Return"},
              {"CheckTitle","CNT_TITLE"}
            };
            loc = dict[loc_key];
            return loc;

        }
    }
}
