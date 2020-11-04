using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;



namespace Selenium2.Meridian.Suite.MyResponsibilities.d_ApprovalRequest
{
    [TestFixture("ffbs")]
    [TestFixture("chbs")]
    [TestFixture("iebs")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ApprovalRequestsold : TestBase
    {
        string browserstr = string.Empty;
        public ApprovalRequestsold(string browser)
            : base(browser)
        {
            browserstr = browser;
        }
        public bool sectioncreation = false;

        //   private string user;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin",browserstr);
        }
        [TearDown]
        public void stoptest()
        {

            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
            driver.Quit();
        }
        [SetUp]
        public void starttest()
        {

int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin", browserstr);
        }
            Meridian_Common.islog = false;
        }
        string result = string.Empty; // checks the request is approved
        [Test]
        public void a_View_Pending_My_Approval_tab()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.click_systemOptions();
            TrainingHomeobj.click_systemOptionsAccordian("Training Management");
            TrainingHomeobj.click_systemOptionsLink("Access Approval Paths");

           // TrainingHomeobj.Click_AdminConsoleLink();
        //    AdminstrationConsoleobj.Click_OpenItemLink("Approval Paths");
            ApprovalPathobj.Click_CreateNewGoTo();
            ApprovalPathobj.Populate_AdministrativeApproval(ExtractDataExcel.MasterDic_approver["Title"] + "a_View_Pending_My_Approval_tab");
            ApprovalPathobj.Select_Administrators(0);
            driver.Navigate_to_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Approvalrequestobject approvalrequest = new Approvalrequestobject(driver);
            string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"] + 1;

            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform1(ExtractDataExcel.MasterDic_classrommcourse["Title"], ExtractDataExcel.MasterDic_classrommcourse["Desc"], 1);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1(browserstr);
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            classroomcourse.buttonsaveandexitclick();
            classroomcourse.linkcoursesectionclick();
            approvalrequest.buttonaccessapprovaleditclick();
            approvalrequest.populatemanageaccessapprovalframe(ExtractDataExcel.MasterDic_approver["Title"] + "a_View_Pending_My_Approval_tab", "Exact phrase");
            approvalrequest.buttonaccessapprovalsearchclick();
            approvalrequest.radioaccessapprovalresultclick();
            approvalrequest.buttonaccessapprovalsaveclick();
            approvalrequest.linkmyownlearningclick();
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] + 1, "Exact phrase");
            driver.clicktableresult("");
            approvalrequest.buttonrequestaccessapprovalclick();
            approvalrequest.buttonrequestaccessapprovalframeclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            approvalrequest.linkapprovalrequestclick();
            approvalrequest.populatefindrequest(ExtractDataExcel.MasterDic_classrommcourse["Title"] + 1);
            string actualresult = approvalrequest.buttonaccessapprovalfiltersearch();
            approvalrequest.buttonraccessapprovalclick();
            approvalrequest.buttonraccessapprovalframeclick();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            result = driver.GetElement(ObjectRepository.sucessmessage).Text;
            //    driver.LogoutUser(ObjectRepository.LogoutHoverLink,ObjectRepository.HoverMainLink);
            //     driver.deleteclassroom(ExtractDataExcel.MasterDic_classrommcourse["Title"] + 0, "Exact phrase");
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);

          //  driver.deleteclassroom(ExtractDataExcel.MasterDic_classrommcourse["Title"] + 0, "Exact phrase");
            //       driver.LogoutUser(ObjectRepository.LogoutHoverLink,ObjectRepository.HoverMainLink);

        }
        [Test]
        public void b_View_Awaiting_Approval_from_Others_tab()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.click_systemOptions();
            TrainingHomeobj.click_systemOptionsAccordian("Training Management");
            TrainingHomeobj.click_systemOptionsLink("Access Approval Paths");

            // TrainingHomeobj.Click_AdminConsoleLink();
            //    AdminstrationConsoleobj.Click_OpenItemLink("Approval Paths");
            ApprovalPathobj.Click_CreateNewGoTo();
            ApprovalPathobj.Populate_AdministrativeApproval(ExtractDataExcel.MasterDic_approver["Title"] +"a_View_Awaiting_Approval_tab");
            ApprovalPathobj.Select_Administrators(1);
            driver.Navigate_to_TrainingHome();
            TrainingHomeobj.isTrainingHome();


            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Approvalrequestobject approvalrequest = new Approvalrequestobject(driver);
            string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"] + "awaiting_othertab";
          //  driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+"awaiting_othertab", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1(browserstr);
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            classroomcourse.buttonsaveandexitclick();
            classroomcourse.linkcoursesectionclick();
            approvalrequest.buttonaccessapprovaleditclick();
            approvalrequest.populatemanageaccessapprovalframe(ExtractDataExcel.MasterDic_approver["Title"] + "a_View_Awaiting_Approval_tab", "Exact phrase");
            approvalrequest.buttonaccessapprovalsearchclick();
            approvalrequest.radioaccessapprovalresultclick();
            approvalrequest.buttonaccessapprovalsaveclick();
            approvalrequest.linkmyownlearningclick();
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "awaiting_othertab", "Exact phrase");
            driver.clicktableresult("");
            approvalrequest.buttonrequestaccessapprovalclick();
            approvalrequest.buttonrequestaccessapprovalframeclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            approvalrequest.linkapprovalrequestclick();
            approvalrequest.tabraccesapprovalawaitingapprovalfromothersclick();
            approvalrequest.populatefindrequest(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "awaiting_othertab");
            string actualresult = approvalrequest.buttonaccessapprovalfiltersearch();
          //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.deleteclassroom(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "awaiting_othertab", "Exact phrase");
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            // approvalrequest.buttonraccessapprovaldenyclick();
            //approvalrequest.buttonraccessapprovaldenyframeclick();


                  //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void c_View_Finalized_Requests_tab()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Approvalrequestobject approvalrequest = new Approvalrequestobject(driver);
            string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"] + "finalize";
           // driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+"finalize", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1(browserstr);
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            classroomcourse.buttonsaveandexitclick();
            classroomcourse.linkcoursesectionclick();
            approvalrequest.buttonaccessapprovaleditclick();
            approvalrequest.populatemanageaccessapprovalframe(ExtractDataExcel.MasterDic_approver["Title"] + "a_View_Pending_My_Approval_tab", "Exact phrase");
            approvalrequest.buttonaccessapprovalsearchclick();
            approvalrequest.radioaccessapprovalresultclick();
            approvalrequest.buttonaccessapprovalsaveclick();
            approvalrequest.linkmyownlearningclick();
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] +"finalize", "Exact phrase");
            driver.clicktableresult("");
            approvalrequest.buttonrequestaccessapprovalclick();
            approvalrequest.buttonrequestaccessapprovalframeclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            approvalrequest.linkapprovalrequestclick();
            approvalrequest.populatefindrequest(ExtractDataExcel.MasterDic_classrommcourse["Title"]  +"finalize");

            approvalrequest.buttonaccessapprovalfiltersearch();
            approvalrequest.buttonraccessapprovaldenyclick();
            approvalrequest.buttonraccessapprovaldenyframeclick();
            approvalrequest.tabraccesapprovalfinalizedapprovalclick();
            approvalrequest.populatefindrequest(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "finalize");

            StringAssert.AreEqualIgnoringCase(expectedresult, approvalrequest.buttonaccessapprovalfiltersearch());
         //   driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.deleteclassroom(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "finalize", "Exact phrase");
                 //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void d_View_Manage_Requests_tab()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Approvalrequestobject approvalrequest = new Approvalrequestobject(driver);
            string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"] + "ManageRequestTab";
        //    driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+"ManageRequestTab", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1(browserstr);
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            classroomcourse.buttonsaveandexitclick();
            classroomcourse.linkcoursesectionclick();
            approvalrequest.buttonaccessapprovaleditclick();
            approvalrequest.populatemanageaccessapprovalframe(ExtractDataExcel.MasterDic_approver["Title"] + "a_View_Pending_My_Approval_tab", "Exact phrase");
            approvalrequest.buttonaccessapprovalsearchclick();
            approvalrequest.radioaccessapprovalresultclick();
            approvalrequest.buttonaccessapprovalsaveclick();
            approvalrequest.linkmyownlearningclick();
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "ManageRequestTab", "Exact phrase");
            driver.clicktableresult("");
            approvalrequest.buttonrequestaccessapprovalclick();
            approvalrequest.buttonrequestaccessapprovalframeclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            approvalrequest.linkapprovalrequestclick();
            approvalrequest.populatefindrequest(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "ManageRequestTab");

            approvalrequest.buttonaccessapprovalfiltersearch();
            approvalrequest.buttonraccessapprovaldenyclick();
            approvalrequest.buttonraccessapprovaldenyframeclick();
            approvalrequest.tabraccesapprovalmanageapprovalclick();
            approvalrequest.populatefindrequest(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "ManageRequestTab");

            StringAssert.AreEqualIgnoringCase(expectedresult, approvalrequest.buttonaccessapprovalfiltersearch());
           // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.deleteclassroom(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "ManageRequestTab", "Exact phrase");
             //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void e_Filter_the_requests_using_the_search_facets()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Approvalrequestobject approvalrequest = new Approvalrequestobject(driver);
            string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"];
//start

            driver.UserLogin("admin", browserstr);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1(browserstr);
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            classroomcourse.buttonsaveandexitclick();
            classroomcourse.linkcoursesectionclick();
            approvalrequest.buttonaccessapprovaleditclick();
            approvalrequest.populatemanageaccessapprovalframe("Administrative Approval", "Exact phrase");
            approvalrequest.buttonaccessapprovalsearchclick();
            approvalrequest.radioaccessapprovalresultclick();
            approvalrequest.buttonaccessapprovalsaveclick();
            approvalrequest.linkmyownlearningclick();
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] + 0, "Exact phrase");
            driver.clicktableresult("");
            approvalrequest.buttonrequestaccessapprovalclick();
            approvalrequest.buttonrequestaccessapprovalframeclick();
//break

            classroomcourse.linkmyresponsibilitiesclick(driver);
            approvalrequest.linkapprovalrequestclick();
            approvalrequest.tabraccesapprovalmanageapprovalclick();
           string text1= driver.GetElement(ObjectRepository.contentsearchItemscountlbl).Text;
            int cnt = driver.getintegerfromstring(text1);
            driver.GetElement(By.Id("Classroom Section")).ClickWithSpace();

            string text2 = driver.GetElement(ObjectRepository.contentsearchItemscountlbl).Text;
            int cnt1 = driver.getintegerfromstring(text2);
            Assert.GreaterOrEqual(cnt, cnt1);
            driver.GetElement(By.Id("Last 30 Days")).ClickWithSpace();
            int cntfa = driver.FindElements(By.ClassName("fa")).Count;
            //string text3 = driver.GetElement(ObjectRepository.contentsearchItemscountlbl).Text;
            //int cnt2 = driver.getintegerfromstring(text3);

            Assert.GreaterOrEqual(cnt1, cntfa);

          //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


        }
        [Test]
        public void f_Approve_a_user_request_to_a_content_item()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Approvalrequestobject approvalrequest = new Approvalrequestobject(driver);
            string expectedresult = "The request was approved.";
          //  driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+"Approve_userrequest", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1(browserstr);
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            classroomcourse.buttonsaveandexitclick();
            classroomcourse.linkcoursesectionclick();
            approvalrequest.buttonaccessapprovaleditclick();
            approvalrequest.populatemanageaccessapprovalframe(ExtractDataExcel.MasterDic_approver["Title"] + "a_View_Pending_My_Approval_tab", "Exact phrase");
            approvalrequest.buttonaccessapprovalsearchclick();
            approvalrequest.radioaccessapprovalresultclick();
            approvalrequest.buttonaccessapprovalsaveclick();
            approvalrequest.linkmyownlearningclick();
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Approve_userrequest", "Exact phrase");
            driver.clicktableresult("");
            approvalrequest.buttonrequestaccessapprovalclick();
            approvalrequest.buttonrequestaccessapprovalframeclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            approvalrequest.linkapprovalrequestclick();
            approvalrequest.populatefindrequest(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Approve_userrequest");

            approvalrequest.buttonaccessapprovalfiltersearch();
            approvalrequest.buttonraccessapprovalclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, approvalrequest.buttonraccessapprovalframeclick());
         //   driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.deleteclassroom(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Approve_userrequest", "Exact phrase");
            // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void g_Deny_a_user_request_to_a_content_item()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Approvalrequestobject approvalrequest = new Approvalrequestobject(driver);
            string expectedresult = "The request was denied.";
           // driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+"Deny_Request", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1(browserstr);
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            classroomcourse.buttonsaveandexitclick();
            classroomcourse.linkcoursesectionclick();
            approvalrequest.buttonaccessapprovaleditclick();
            approvalrequest.populatemanageaccessapprovalframe(ExtractDataExcel.MasterDic_approver["Title"] + "a_View_Pending_My_Approval_tab", "Exact phrase");
            approvalrequest.buttonaccessapprovalsearchclick();
            approvalrequest.radioaccessapprovalresultclick();
            approvalrequest.buttonaccessapprovalsaveclick();
            approvalrequest.linkmyownlearningclick();
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Deny_Request", "Exact phrase");
            driver.clicktableresult("");
            approvalrequest.buttonrequestaccessapprovalclick();
            approvalrequest.buttonrequestaccessapprovalframeclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            approvalrequest.linkapprovalrequestclick();
            approvalrequest.populatefindrequest(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Deny_Request");

            approvalrequest.buttonaccessapprovalfiltersearch();
            approvalrequest.buttonraccessapprovaldenyclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, approvalrequest.buttonraccessapprovaldenyframeclick());
           // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.deleteclassroom(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Deny_Request", "Exact phrase");
       //       driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void h_Rescind_a_user_request_to_a_content_item()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Approvalrequestobject approvalrequest = new Approvalrequestobject(driver);
            string expectedresult = "The request was rescinded.";
            //driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+"Rescind_Request", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1(browserstr);
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            classroomcourse.buttonsaveandexitclick();
            classroomcourse.linkcoursesectionclick();
            approvalrequest.buttonaccessapprovaleditclick();
            approvalrequest.populatemanageaccessapprovalframe(ExtractDataExcel.MasterDic_approver["Title"] + "a_View_Pending_My_Approval_tab", "Exact phrase");
            approvalrequest.buttonaccessapprovalsearchclick();
            approvalrequest.radioaccessapprovalresultclick();
            approvalrequest.buttonaccessapprovalsaveclick();
            approvalrequest.linkmyownlearningclick();
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Rescind_Request", "Exact phrase");
            driver.clicktableresult("");
            approvalrequest.buttonrequestaccessapprovalclick();
            approvalrequest.buttonrequestaccessapprovalframeclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            approvalrequest.linkapprovalrequestclick();
            approvalrequest.populatefindrequest(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Rescind_Request");

            approvalrequest.buttonaccessapprovalfiltersearch();
            approvalrequest.buttonraccessapprovaldenyclick();
            approvalrequest.buttonraccessapprovaldenyframeclick();
            approvalrequest.tabraccesapprovalfinalizedapprovalclick();
            approvalrequest.populatefindrequest(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Rescind_Request");

            approvalrequest.buttonaccessapprovalfiltersearch();
            approvalrequest.buttonraccessapprovalrescindclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, approvalrequest.buttonraccessapprovalrescindframeclick());
        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.deleteclassroom(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Rescind_Request", "Exact phrase");
        //      driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void i_View_the_request_history_for_a_content_item()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Approvalrequestobject approvalrequest = new Approvalrequestobject(driver);
            string expectedresult = "Below is information about all access approval requests the user has submitted for this content.";
            string actualresult = string.Empty;
          //  driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+"Request_History", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1(browserstr);
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            classroomcourse.buttonsaveandexitclick();
            classroomcourse.linkcoursesectionclick();
            approvalrequest.buttonaccessapprovaleditclick();
            approvalrequest.populatemanageaccessapprovalframe(ExtractDataExcel.MasterDic_approver["Title"] + "a_View_Pending_My_Approval_tab", "Exact phrase");
            approvalrequest.buttonaccessapprovalsearchclick();
            approvalrequest.radioaccessapprovalresultclick();
            approvalrequest.buttonaccessapprovalsaveclick();
            approvalrequest.linkmyownlearningclick();
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Request_History", "Exact phrase");
            driver.clicktableresult("");
            approvalrequest.buttonrequestaccessapprovalclick();
            approvalrequest.buttonrequestaccessapprovalframeclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            approvalrequest.linkapprovalrequestclick();
            approvalrequest.populatefindrequest(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Request_History");

            approvalrequest.buttonaccessapprovalfiltersearch();
            approvalrequest.imageviewrequestclick();
            actualresult = approvalrequest.linkviewrequestclick();
            StringAssert.Contains(expectedresult, actualresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
           // driver.deleteclassroom(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Request_History", "Exact phrase");
      //         driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
      
    }
}

