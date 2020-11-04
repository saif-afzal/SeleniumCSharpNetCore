using OpenQA.Selenium;
using ParallelTesting_Solution2;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Miscellaneous;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace TestAutomation.helper
{
    public class ObjectInit
    {
        private IWebDriver objDriver;
        public ObjectInit(IWebDriver objDriver)
        {
            this.objDriver = objDriver;

        }
        public LoginPage loginPage1;
        public HelpPage helpPage1;
        public TrainingPage trainingPage1;
        public CommonSection commonSection1;
        public SearchResultsPage searchResultsPage1;
        public CreateCareerPathPage createCareerPathPage1;
        public CreateCompetencyPage createCompetencyPage1;
        public AccountPage accountPage1;
        public HomePage homePage1;
        public ReportsConsolePage reportConsolePage1;
        public DetailsPage detailsPage1;
        public RunReportPage runReportPage1;
        public MeridianGlobalReportingPage meridianGlobalReportingPage1;
        public MyTrainingProgressPDFPage myTrainingProgressPDFPage1;
        public ReportsPage reportsPage1;
        public ContentDetailsPage contentDetailsPage1;
        public CreatePage createPage1;
        public SummaryPage summaryPage1;
        public CourseLaunchModalPage courseLaunchModalPage1;
        public SystemCertificatePage systemCertificatePage1;
        public CertificatePage certificatePage1;


        public void InitializeBase(IWebDriver objDriver)
        {
            loginPage1 = new LoginPage(objDriver);
            helpPage1 = new HelpPage(objDriver);
            commonSection1 = new CommonSection(objDriver);
            trainingPage1 = new TrainingPage(objDriver);
            searchResultsPage1 = new SearchResultsPage(objDriver);
            createCareerPathPage1 = new CreateCareerPathPage(objDriver);
            createCompetencyPage1 = new CreateCompetencyPage(objDriver);
            accountPage1 = new AccountPage(objDriver);
            homePage1 = new HomePage(objDriver);
            reportConsolePage1 = new ReportsConsolePage(objDriver);
            detailsPage1 = new DetailsPage(objDriver);
            runReportPage1 = new RunReportPage(objDriver);
            meridianGlobalReportingPage1 = new MeridianGlobalReportingPage(objDriver);
            myTrainingProgressPDFPage1 = new MyTrainingProgressPDFPage(objDriver);
            reportsPage1 = new ReportsPage(objDriver);
            contentDetailsPage1 = new ContentDetailsPage(objDriver);
            summaryPage1 = new SummaryPage(objDriver);
            createPage1 = new CreatePage(objDriver);
            courseLaunchModalPage1 = new CourseLaunchModalPage(objDriver);
            systemCertificatePage1 = new SystemCertificatePage(objDriver);
            certificatePage1 = new CertificatePage(objDriver);
            //LoginPage = new MdnHomePage(driver);
            //LoginPage1 = new MdnLoginPage1(driver);
            //HomePage = new MdnHomePage(driver);
            //CommonPage = new MdnCommonPage(driver);

            //#region initialize old
            //driver = objDriver;
            //CheckOutobj = new CheckOut(driver);
            //takeScreenhsot = new ScreenShot(driver);
            //approvalrequest = new Approvalrequestobject(driver);
            //instructors = new Instructor(driver);
            //approvalrequest = new Approvalrequestobject(driver);
            //DomainConsoleobj = new DomainConsole(driver);
            //ManageGradebookobj = new ManageGradebook();
            //Instructorsobj = new Instructorspof();
            //MyResponsibilitiesobj = new My_Responsibilities(driver);
            //manageuserobj = new ManageUsers(driver);
            //objTrainingHome = new TrainingHomes(driver);
            //objCurriculum = new CreateCurriculum(driver);
            //classroomcourse = new ClassroomCourse(driver);
            //ContentSearchobj = new ContentSearch(driver);
            //objCreate = new Create(driver);
            //detailspage = new Details(driver);


            //TrainingHomeobj = new TrainingHomes(driver);
            //AdminstrationConsoleobj = new AdminstrationConsole(driver);
            //Testsobj = new Tests(driver);
            //Detailsobj = new Details(driver);
            //EditSummaryobj = new EditSummary(driver);
            //Scorm1_2obj = new Scorm1_2(driver);
            //EditQuestionobj = new EditQuestion(driver);
            //EditQuestionGroupobj = new EditQuestionGroup(driver);

            //AddUsrObj = new AddUsers(driver);

            //generalcourseobj = new GeneralCourse(driver);
            //myteachingscheduleobj = new MyTeachingSchedule();
            //professionaldevelopmentobj = new ProfessionalDevelopments(driver);
            //documentobj = new Document(driver);
            //CreateNewAccountobj = new CreateNewAccount(driver);
            //ManageUsersobj = new ManageUsers(driver);
            //Createobj = new Create(driver);
            //summaryobj = new Summary(driver);
            //reauiredtrainingconsoleobj = new RequiredTrainingConsoles(driver);
            //requiredtrainingobj = new RequiredTraining(driver);
            //Trainingobj = new Training(driver);
            //Loginobj = new Login(driver);
            //Contentobj = new Content(driver);
            //Creditsobj = new Credits(driver);
            //AddContentobj = new AddContent(driver);
            //Summaryobj = new Summary(driver);
            //ScheduleAndManageSectionobj = new ScheduleAndManageSection(driver);
            //SearchResultsobj = new SearchResults(driver);
            //CourseSectionobj = new CreateNewCourseSectionAndEventPage(driver);
            //Transcriptsobj = new Transcripts(driver);
            //Productsobj = new Products(driver);
            //BrowseTrainingCatalogobj = new BrowseTrainingCatalog(driver);
            //ShoppingCartsobj = new ShoppingCarts(driver);
            //ProfessionalDevelopmentsobj = new ProfessionalDevelopments(driver);
            //Createnewproficencyscaleobj = new Createnewproficencyscale(driver);
            //Createnewcompetencyobj = new Createnewcompetency(driver);
            //CreateNewSucessProfileobj = new CreateNewSucessProfile(driver);
            //SucessProfileobj = new SucessProfile(driver);
            //Searchobj = new Search(driver);
            //TrainingActivitiesobj = new TrainingActivities(driver);
            //ProfessionalDevelopments_learnerobj = new ProfessionalDevelopments_learner(driver);
            //Organizationobj = new Organization(driver);
            //DevelopmentPlansobj = new DevelopmentPlans(driver);
            //AddDevelopmentActivitiesobj = new AddDevelopmentActivities(driver);
            //MyAccountobj = new MyAccount(driver);
            //UsersUtilobj = new UsersUtil(driver);
            //MyCalendersobj = new MyCalenders(driver);
            //MyReportsobj = new MyReports(driver);
            //Config_Reportsobj = new Config_Reports(driver);
            //ConfigurationConsoleobj = new ConfigurationConsole(driver);
            //ApprovalPathobj = new ApprovalPath(driver);
            //MyMessageobj = new MyMessages(driver);
            //MessageUtilobj = new MessageUtil(driver);
            //MyRequestsobj = new MyRequests(driver);
            //Blogsobj = new Blogs(driver);
            //CollabarationSpacesobj = new CollabarationSpaces(driver);
            //Faqsobj = new Faqs(driver);
            //HomePageFeedobj = new HomePageFeed(driver);
            //ProductTypesobj = new ProductTypes(driver);
            //Surveysobj = new Surveys(driver);
            //SurveyScalesobj = new SurveyScales(driver);
            //AuditingConsolesobj = new AuditingConsoles(driver);
            //Categoryobj = new Category(driver);
            //Trainingsobj = new Trainings(driver);
            //VirtualMeetingsobj = new VirtualMeetings(driver);
            //CreditTypeobj = new CreditType(driver);
            //AssignedUserobj = new AssignedUser(driver);
            //AddUsersobj = new AddUsers(driver);
            //CustomFieldobj = new CustomField(driver);
            //CreateNewCustomFieldobj = new CreateNewCustomField(driver);
            //EditFieldobj = new EditField(driver);
            //EducationLevelobj = new EducationLevel(driver);
            //EditOrganizationobj = new EditOrganization(driver);
            //SelectManagerobj = new SelectManager(driver);
            //Roleobj = new Role(driver);
            //SelectTrainingPOCobj = new SelectTrainingPOC(driver);
            //Complexobj = new Complex(driver);
            //AccountCodesobj = new AccountCodes(driver);
            //AccountCodeTypesobj = new AccountCodeTypes(driver);
            //DiscountCodesobj = new DiscountCodes(driver);
            //ManageTaxRatesobj = new ManageTaxRates(driver);
            //TaxItemCategoriesobj = new TaxItemCategories(driver);
            //Certificatesobj = new Certificates(driver);
            //CourseProvidersobj = new CourseProviders(driver);
            //ExternalLearningsobj = new ExternalLearnings(driver);
            //ExternalLearningConsolesobj = new ExternalLearningConsoles(driver);
            //ExternalLearningtypesobj = new ExternalLearningtypes(driver);
            //RequiredTrainingConsolesobj = new RequiredTrainingConsoles(driver);
            //SelectProfileobj = new SelectProfile(driver);
            //TrainingProfilesobj = new TrainingProfiles(driver);
            //EditTrainingProfileobj = new EditTrainingProfile(driver);
            //MergeUsersobj = new MergeUsers(driver);
            //UserGroupobj = new UserGroup(driver);
            //SelectCertificateobj = new SelectCertificate(driver);
            //ManageProficencyScaleobj = new ManageProficencyScale(driver);
            //ArchivedProficencyScaleobj = new ArchivedProficencyScale(driver);
            //MappedContentobj = new MappedContent(driver);
            //MappedCompetencyobj = new MappedCompetency(driver);
            //ManageSuccessProfileobj = new ManageSuccessProfile(driver);
            //FAQ_lobj = new FAQ_l(driver);
            //Announcements_lobj = new Announcements_l(driver);
            //JobTitlesobj = new JobTitles(driver);
            //ManageJobTitleobj = new ManageJobTitle(driver);
            //ManagePricingScheduleobj = new ManagePricingSchedule(driver);
            //ExternalLearningSearchobj = new ExternalLearningSearch(driver);
            //urlobj = new url(driver);
            //skinobj = new skin(driver);
            //MyOwnLearningobj = new MyOwnLearningUtils(driver);
            //CurrentTrainingsobj = new CurrentTrainings(driver);
            //scormobj = new Scorm12(driver);
            //aicccourse = new AICC(driver);
            //ojtcourse = new OJT(driver);
            //TrainingCatalogobj = new TrainingCatalogUtil(driver);
            //accesskeys = new AccessKeys(driver);
            //#endregion
        }
    }
}
