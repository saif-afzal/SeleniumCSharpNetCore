using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class ManageSurveyPage
    {
        public static StructureCommand Structure { get { return new StructureCommand(); } }

        public static AddaQuestionModalCommand AddaQuestionModal { get { return new AddaQuestionModalCommand(); }   }

        public static DropDownToggleCommand DropDownToggle { get { return new DropDownToggleCommand(); } }

        public static StructuretabCommand Structuretab { get { return new StructuretabCommand(); } }

        public static EvaluatorsTabCommand EvaluatorsTab { get { return new EvaluatorsTabCommand(); } }

        public static bool? IsAddaQuestionModalDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div/h4"));
        }

        public static bool? IsESignatureModalDisplayed()
        {
            return Driver.existsElement(By.XPath("//span[@id='KendoUIMGDialog_wnd_title']"));
        }

  

        public static void AtemptSurvey()
        {

            Driver.clickEleJs(By.XPath("//input[@id='sq_100i_0']"));
            Driver.clickEleJs(By.XPath("//body//input[3]"));
            Driver.clickEleJs(By.XPath("//a[@class='btn btn-default']"));
            Driver.Instance.SwitchtoDefaultContent();
        }

        public static bool? VerifyAddAQuestionModal()
        {
            return Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div/h4"));
        }

        public static bool? VerifyQuestionDisplayedInPreview(string question, string v)
        {
            //Driver.waitforframe();
            //Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_chk_ESIG_AGREEMENT']"));
            //Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_ESignatureAccept']"));
            //Driver.clickEleJs(By.XPath("//input[@value='Log In']"));
            bool result = false;
            try
            {
                Driver.Instance.selectWindow(v);
                result=Driver.existsElement(By.XPath("//span[contains(text(),'" + question + "')]"));
                Driver.Instance.SelectWindowClose();
                Driver.Instance.SwitchTo().DefaultContent();
            }
            catch { }
            return result;

        }

        public static string SuccessMessage()
        {
            return Driver.Instance.getSuccessMessage();
        }

        public static void AttemptPreviewSurvey()
        {
            Driver.clickEleJs(By.XPath("//input[@class='btn btn-primary']"));
            Driver.clickEleJs(By.XPath("//a[@class='btn btn-default']"));
            Driver.focusParentWindow();
                        
        }

        public static bool? VerifyEvaluationPassFail()
        {
            return Driver.existsElement(By.XPath("//b[@class='badge']"));
        }

        public static void SelectEvaluatorsTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='hlSurveyEvaluators']"));
        }

        public static void clickSurveyTab()
        {
            Driver.existsElement(By.XPath("//a[@id='MainContent_hlSurvey']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_hlSurvey']"));
        }

        public static void PublishEvaluation()
        {
            Driver.clickEleJs(By.XPath("//div[@id='contentDetailsHeader']/div[2]/div/button"));
            Driver.clickEleJs(By.LinkText("Publish"));
            //Driver.Instance.findandacceptalert();
             Driver.clickEleJs(By.XPath("//div[@class='bootbox modal fade bootbox-confirm in']//button[@class='btn btn-primary'][contains(text(),'OK')]"));
            Thread.Sleep(5000);
        }

        public static bool? VerifyPublishedEvaluation()
        {
            return Driver.GetElement(By.XPath("//div[@id='contentDetailsHeader']/div[2]/p")).Text.Equals("Published");
        }
    }

    public class EvaluatorsTabCommand
    {
        public void SelectCustomEvaluator()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Add Evaluators')]"));
            Driver.GetElement(By.XPath("//input[@id='SearchFor']")).SendKeysWithSpace("ak");
            Driver.clickEleJs(By.XPath("//button[@id='btn-search-evaluator']//span[@class='fa fa-search']"));
            Driver.clickEleJs(By.XPath("//table[@id='table-eval-user-add']/tbody/tr[1]/td/input"));
            Driver.clickEleJs(By.XPath("//button[@id='eval-modal-add']"));
        }

        public int VerifyEvaluatorIsAdded()
        {
            Driver.existsElement(By.XPath("//div[@id='has-users']//tr//td[1]//input[1]"));
            string totleCount = Driver.Instance.FindElements(By.XPath("//div[@id='has-users']//tr//td[1]//input[1]")).Count.ToString();
            return Driver.getIntegerFromString(totleCount);
        }

        public void SelectLearnermanager()
        {
            Driver.existsElement(By.XPath("//div[@id='surveys-evaluators']/div/div[2]/div/div/span[3]"));
            Driver.clickEleJs(By.XPath("//div[@id='surveys-evaluators']/div/div[2]/div/div/span[3]"));
        }

        public bool? VerifyLearnerManager()
        {
            return Driver.GetElement(By.XPath("//div[@id='surveys-evaluators']/div/div[2]/div/div/span[1]")).Text.Contains("Yes");
        }

        public void SelectCourseInstructor()
        {
            Driver.existsElement(By.XPath("//div[@id='surveys-evaluators']/div[2]/div[2]/div/div/span[3]"));
            Driver.clickEleJs(By.XPath("//div[@id='surveys-evaluators']/div[2]/div[2]/div/div/span[3]"));
        }

        public bool? VerifyCourseInstructor()
        {
            return Driver.GetElement(By.XPath("//div[@id='surveys-evaluators']/div[2]/div[2]/div/div/span[1]")).Text.Contains("Yes");
        }
    }

    public class StructuretabCommand
    {
        public StructuretabCommand()
        {
        }
    }

    public class DropDownToggleCommand
    {
        public void Click_Preview()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Preview')]"));
        }
    }

    public class AddaQuestionModalCommand
    {
        public bool? VerifyQuestionTypeDropdownIsDisplayed()
        {
            Driver.waitforframe();
            return Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[2]/div/div/div/div/button/span"));
        }

     

    

        public void SelectRadioButton()
        {
            Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[2]/div/div/div/div/button/span"));
        }

        public void SelectEvaluationQuestionType(string v)
        {
            Driver.waitforframe();
            Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[2]/div/div/div/div/button"));
            Driver.existsElement(By.XPath("//span[@class='text'][contains(text(),'" + v + "')]"));
            //Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[2]/div/div/div/div/button"));
            Driver.clickEleJs(By.XPath("//span[@class='text'][contains(text(),'" + v + "')]"));
            
        }

        public bool? VerifyQuestionOrTitleInputboxIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//textarea[@id='QUESTION_TITLE']"));
        }

        public bool? VerifyRequiredOptionSliderIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div/div/span[3]"))|| Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div/div/span[2]"));
        }

        public bool? VerifyQuestionToBeReusedSliderIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div[3]/div/div/span[3]"))|| Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div[3]/div/div/span[2]"));
        }

    

        public void SelectDropownList()
        {
            Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[2]/div/div/div/div/button"));
            Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[2]/div/div/div/div/div/ul/li[3]/a/span[2]"));
        }

        public void SelectDateField()
        {
            Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[2]/div/div/div/div/button"));
            Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[2]/div/div/div/div/div/ul/li[2]/a"));
        }

        public void SelectQuestionType(string v)
        {
            Driver.existsElement(By.XPath("//span[@class='text'][contains(text(),'" + v + "')]"));
            //Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[2]/div/div/div/div/button"));
            Driver.clickEleJs(By.XPath("//span[@class='text'][contains(text(),'"+ v + "')]"));


        }

        public void QuestionRequired(string v)
        {

            if (Driver.GetElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div/div/span")).Text==v)
            {
                Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div/div/span"));
            }
            else
            {
                Driver.clickEleJs(By.XPath("//span[@class='bootstrap-switch-handle-on bootstrap-switch-warning']"));
            }
            
        }

        public void AllowQuestionToBeReused(string v)
        {
            if (Driver.GetElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div[3]/div/div/span[3]")).Text == v)
            {
                Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div[3]/div/div/span[3]"));
            }
            else
            {
                Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div[3]/div/div/span[3]"));
            }
        }

        public bool? QuestionOrTitleInputboxDisplayed(string v)
        {
            Driver.GetElement(By.XPath("//textarea[@id='QUESTION_TITLE']")).SendKeysWithSpace(v);
            return Driver.existsElement(By.XPath("//textarea[@id='QUESTION_TITLE']"));
        }

        public string QuestionOrTitle()
        {
            return Driver.GetElement(By.XPath("//textarea[@id='QUESTION_TITLE']")).Text;
            
        }

        public void ClickCreate()
        {
            Driver.existsElement(By.XPath("//button[@id='btnCreateQuestion']"));
            Driver.clickEleJs(By.XPath("//button[@id='btnCreateQuestion']"));
            Thread.Sleep(10000);
        }

        public string QuestionType()
        {
            string con = Driver.GetElement(By.XPath("//div[@id='modal-question']/div/div/div[2]/div/div/div/div/button/span")).Text;
            //string[] conlist = Regex.Split(con, "\r");
            return con;
            
        }

      

        public bool? VerifyQuestionTypeIsInList(string v)
        {
            Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[2]/div/div/div/div/button"));
            return  Driver.existsElement(By.XPath("//span[@class='text'][contains(text(),'" + v + "')]"));
            //Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[2]/div/div/div/div/button"));
        }

        public int VerifyAnswerRadioSelections()
        {
            Driver.existsElement(By.XPath("//li/div/div/label"));
            string totleCount = Driver.Instance.FindElements(By.XPath("//li/div/div/label")).Count.ToString();
            return Driver.getIntegerFromString(totleCount);
        }

        public void EnterResponse(int s,int t)
        {
            for (int i=s; i <= t; i++)
            {
               
                if (Driver.Instance.FindElements(By.XPath("//li/div/div/label")).Count<= 2)
                {
                    for (int j = 1; j <= 2; j++)
                    {
                        Driver.GetElement(By.XPath("//input[@id='question-add-response-"+j+"']")).SendKeysWithSpace(+ j + ". Answer " + Meridian_Common.globalnum+ "-"+j);
                    }
                    Driver.clickEleJs(By.XPath("//a[@id='btnAddAnotherResponse']"));
                }
                else
                {
                    int k = i+1;
                    if (k <= t)
                    {
                        //Driver.clickEleJs(By.XPath("//a[@id='btnAddAnotherResponse']"));
                        Driver.GetElement(By.XPath("//input[@id='question-add-response-" + k + "']")).SendKeysWithSpace(+k + ". Answer " + Meridian_Common.globalnum + "-" + k);
                        Driver.clickEleJs(By.XPath("//a[@id='btnAddAnotherResponse']"));
                    }                  
                }
              
          
            }
            int l = t + 1;                         
            if (Driver.existsElement(By.XPath("//input[@id='question-add-response-" + l + "']")))
            {
                Driver.clickEleJs(By.XPath("//input[@id='question-add-response-" + l + "']/following::button[1]/span"));
            }
        }

        public bool? VerifySelectedQuestionType(string v)
        {
            return Driver.existsElement(By.XPath("//span[@class='filter-option pull-left'][contains(text(),'"+v+"')]"));
        }

        public bool? VerifyParagraphExample()
        {
            return Driver.existsElement(By.XPath("//div[@id='question-add-para']/div/div"));
        }

        public bool? VerifyCreateCustomAnswerIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//ul[@id='question-responses-list']/li/div/div/label"));
        }

        public bool? VerifyMinimumDropdownFieldIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='question-add-multiple']/div/div/div/div[2]/div[2]/div/div/div/button/span"));
        }

        public bool? VerifyMaximumDropdownFieldIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='question-add-multiple']/div/div/div/div[2]/div[2]/div[2]/div/div/button"));

        }

        //public void Select_MinimumValue_MaximumValue_RequiredOption_QuestionToBeReusedOption(string v1, string v2, string v3, string v4)
        //{
        //    Driver.clickEleJs(By.XPath("//div[@class='question-add-check-min-max']//div[1]//div[1]//div[1]//button[1]"));
        //    Driver.clickEleJs(By.XPath("//div[@class='btn-group bootstrap-select form-control open']//span[@class='text'][contains(text(),'" + v1 + "')]"));
        //    Driver.clickEleJs(By.XPath("//body[@class='canvas modal-open']//div[@id='content']//div[@class='row']//div[@class='row']//div[2]//div[1]//div[1]//button[1]"));
        //    Driver.clickEleJs(By.XPath("//div[@class='btn-group bootstrap-select form-control open']//span[@class='text'][contains(text(),'" + v2 + "')]"));

        //    if (Driver.existsElement(By.XPath("//span[@class='bootstrap-switch-handle-on bootstrap-switch-warning']")))
        //    {

        //        if (Driver.GetElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div/div/div/div/span[1]")).Text == v3)
        //        {
        //            Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div/div/div/div/span"));
        //        }
        //        else
        //        {
        //            Driver.clickEleJs(By.XPath("//span[@class='bootstrap-switch-handle-on bootstrap-switch-warning']"));
        //        }

        //    }
        //    else
        //    {
        //        if (Driver.GetElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div/div/div/div/span[3]")).Text == v3)
        //        {
        //            Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div/div/div/div/span"));
        //        }
        //        else
        //        {
        //            Driver.clickEleJs(By.XPath("//div[@class='bootstrap-switch bootstrap-switch-wrapper bootstrap-switch-id-QUESTION_IS_REQUIRED bootstrap-switch-off bootstrap-switch-animate']//span[@class='bootstrap-switch-handle-off bootstrap-switch-default'][contains(text(),'No')]"));
        //        }



        //    }

        //    if (Driver.GetElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div/div/div/div/span[1]")).Text == v3)
        //    {
        //        Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div/div/div/div/span"));
        //    }
        //    else
        //    {
        //        Driver.clickEleJs(By.XPath("//span[@class='bootstrap-switch-handle-on bootstrap-switch-warning']"));
        //    }
        //    if (Driver.GetElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div[2]/div/div/div/span[3]")).Text == v4)
        //    {
        //        Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div[2]/div/div/div/span[2]"));
        //    }
        //    else
        //    {
        //        Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div/div[2]/div/div/div/span[3]"));
        //    }
        //}

       

      

        public void Select_CheckboxMinimumValue(string v)
        {
            Driver.clickEleJs(By.XPath("//div[@class='question-add-check-min-max']//div[1]//div[1]//div[1]//button[1]"));
            Driver.clickEleJs(By.XPath("//div[@class='btn-group bootstrap-select form-control open']//span[@class='text'][contains(text(),'" + v + "')]"));

        }

        public bool? VerifyCheckboxQuestionRequired(string checkboxMinValue)
        {

            if (checkboxMinValue == "--")

               // if (Driver.GetElement(By.XPath("//div[@class='question-add-check-min-max']//div[1]//div[1]//div[1]//button[1]")).Text=="--")
            {
               return Driver.existsElement(By.XPath("//span[@class='bootstrap-switch-handle-off bootstrap-switch-default'][contains(text(),'No')]"));
            }
            else
            {
                return Driver.existsElement(By.XPath("//span[@class='bootstrap-switch-handle-on bootstrap-switch-warning']"));

            }
         
        }

        public string ChkbxMinValue()
        {
            string con = Driver.GetElement(By.XPath("//div[@class='question-add-check-min-max']//div[1]//div[1]//div[1]//button[1]")).Text;
            string[] conlist = Regex.Split(con, "\r");
            return conlist[0];
            //return Driver.GetElement(By.XPath("//div[@class='question-add-check-min-max']//div[1]//div[1]//div[1]//button[1]")).Text;
        }

        public void Select_MinimumValue_MaximumValue(string v1, string v2)
        {
            Driver.clickEleJs(By.XPath("//div[@class='question-add-check-min-max']//div[1]//div[1]//div[1]//button[1]"));
            Driver.clickEleJs(By.XPath("//div[@class='btn-group bootstrap-select form-control open']//span[@class='text'][contains(text(),'" + v1 + "')]"));
            Driver.clickEleJs(By.XPath("//body[@class='canvas modal-open']//div[@id='content']//div[@class='row']//div[@class='row']//div[2]//div[1]//div[1]//button[1]"));
            Driver.clickEleJs(By.XPath("//div[@class='btn-group bootstrap-select form-control open']//span[@class='text'][contains(text(),'" + v2 + "')]"));

        }

        public bool? VerifyErrorMessageIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//p[contains(text(),'The minimum number of choices cannot be greater th')]"));
        }

        public bool? VerifyMatrixExample()
        {
            return Driver.existsElement(By.XPath("//div[@id='matrixExample']"));
        }

        public int VerifyMatrixRows()
        {
            Driver.existsElement(By.XPath("//ul[@id='matrix-response-list']/li[1]/div/div/input"));
            string totalCount = Driver.Instance.FindElements(By.XPath("//ul[@id='matrix-response-list']/li[1]/div/div/input")).Count.ToString();
            return Driver.getIntegerFromString(totalCount);
        }

        public void EnterMatrixQueries(int s, int t)
        {
            for (int i = s; i <= t; i++)
            {

                if (Driver.Instance.FindElements(By.XPath("//div[@id='matrix']//li")).Count <= 1)
                {
                    for (int j = 1; j <= 1; j++)
                    {
                        Driver.GetElement(By.XPath("//input[@id='question-add-matrix-" + j + "']")).SendKeysWithSpace(j + "- Matrix Query " + Meridian_Common.globalnum + "-" + j);
                    }
                    Driver.clickEleJs(By.XPath("//a[@id='btnAddAnotherRow']"));
                }
                else
                {
                    int k = i;
                    //Driver.clickEleJs(By.XPath("//a[@id='btnAddAnotherResponse']"));
                    if (k <= t)
                    {
                        Driver.GetElement(By.XPath("//input[@id='question-add-matrix-" + k + "']")).SendKeysWithSpace(k + "- Matrix Query " + Meridian_Common.globalnum + "-" + k);
                        Driver.clickEleJs(By.XPath("//a[@id='btnAddAnotherRow']"));
                        if (Driver.existsElement(By.XPath("//p[@id='warningMessageMatrix']")))
                        {
                            break;
                        }
                    }
                    else if (k==t)
                    {
                        Driver.GetElement(By.XPath("//input[@id='question-add-matrix-" + k + "']")).SendKeysWithSpace(k + "- Matrix Query " + Meridian_Common.globalnum + "-" + k);
                    }
                    //Driver.GetElement(By.XPath("//input[@id='question-add-matrix-" + k + "']")).SendKeysWithSpace(+ k + ". Matrix Query " + Meridian_Common.globalnum + "-" + k);
                    //Driver.clickEleJs(By.XPath("//a[@id='btnAddAnotherRow']"));
                    //if (Driver.existsElement(By.XPath("//p[@id='warningMessage']")))
                    //{
                    //    break;
                    //} 
                }


            }
            //Delete needed to be worked out
            int l = t + 1;
            if (Driver.existsElement(By.XPath("//input[@id='question-add-matrix-" + l + "']")))
            {
                Driver.clickEleJs(By.XPath("//input[@id='question-add-matrix-" + l + "']/following::button[1]/span"));
            }
        }

        public bool? VerifyOptionalCommentfieldSliderIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div[2]/div/div/span[2]"))|| Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div[2]/div/div/span[3]"));
            
        }

        public void EnterMatrixResponse(int s, int t)
        {
            for (int i = s; i <=t; i++)
            {

                if (Driver.Instance.FindElements(By.XPath("//ul[@id='question-responses-list']/li/div/div/input")).Count <= 2)
                {
                    for (int j = 1; j <= 2; j++)
                    {
                        Driver.GetElement(By.XPath("//input[@id='question-add-response-" + j + "']")).SendKeysWithSpace("Answer " + j);
                    }
                    Driver.clickEleJs(By.XPath("//a[@id='btnAddAnotherResponse']"));
                }
                else
                {
                    int k = i+1;
                    if (k<=t)
                    {
                        Driver.GetElement(By.XPath("//input[@id='question-add-response-" + k + "']")).SendKeysWithSpace("Answer " + k);

                        Driver.clickEleJs(By.XPath("//a[@id='btnAddAnotherResponse']"));
                        if (Driver.existsElement(By.XPath("//p[@id='warningMessage']")))
                        {
                            break;
                        }

                    }
                    else if(k==t)
                    {
                        if (Driver.existsElement(By.XPath("//input[@id='question-add-response-" + k + "']")))
                        {
                            Driver.GetElement(By.XPath("//input[@id='question-add-response-" + k + "']")).SendKeysWithSpace("Answer " + k);
                        }
                        else
                        {
                            break;
                        }
                       
                    }
                    else
                    {
                        break;
                    }

                }


            }
            int l = t + 1;
            if (Driver.existsElement(By.XPath("//input[@id='question-add-response-" + l + "']")))
            {
                Driver.clickEleJs(By.XPath("//input[@id='question-add-response-" + l + "']/following::button[1]/span"));
            }
        }

        public bool? VerifyRatingScaleDropdownFieldIsDisplayed(string v)
        {
            return Driver.existsElement(By.XPath("//span[@class='filter-option pull-left'][contains(text(),'1 - 5')]"));
        }

        public bool? VerifyFirstItemLabelFieldIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//input[@id='question-rating-first']"));
        }

        public bool? VerifyLastItemLabelFieldIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//input[@id='question-rating-last']"));
        }

        public bool? VerifyResponseExampleIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[6]/div/div/label"));
        }

        public void SelectRatingScaleFromDropdown(string v)
        {
            Driver.clickEleJs(By.XPath("//div[@id='question-add-rating']/div/div/div/div/div/div/button"));
            Driver.clickEleJs(By.XPath("//span[@class='text'][contains(text(),'"+ v +"')]"));
        }

        public void EnterFirstValueLabel(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='question-rating-first']")).SendKeysWithSpace(v);
        }

        public void EnterLastValueLabel(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='question-rating-last']")).SendKeysWithSpace(v);
        }

        public void SelectOptionalCommentsFieldOption(string v)
        {
            if (Driver.GetElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div[2]/div/div/span[3]")).Text == v)
            {
                Driver.existsElement(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div[2]/div/div/span[3]"));
            }
            else
            {
                Driver.clickEleJs(By.XPath("//div[@id='modal-question']/div/div/div[4]/div/div/div[2]/div/div/span[3]"));
            }
        }

        public bool? VerifyShortAnswerExample()
        {
            return Driver.existsElement(By.XPath("//div[@id='question-add-short']/div/div"));
        }



        public bool? DeleteNumberofResponseto(int v, int s, int t)
        {
            for(int i=s; i<=t; i++)
            {
                Driver.clickEleJs(By.XPath("//ul[@id='question-responses-list']/li[" + i + "]/div/div/span/button/span"));
            }
           
            return Driver.Instance.FindElements(By.XPath("//li/div/div/label")).Count !=v;

        }

        public string VerifyLeastResponseWarningMessage()
        {
            //Driver.clickEleJs(By.XPath("//a[@id='btnAddAnotherResponse']"));
            Driver.existsElement(By.XPath("//p[@id='warningMessage']"));
            return Driver.GetElement(By.XPath("//p[@id='warningMessage']")).Text;
        }

        public bool? DeleteNumberofQueriesto(int v, int s, int t)
        {
            for (int i = s; i <= t; i++)
            {
                Driver.clickEleJs(By.XPath("//input[@id='question-add-matrix-" + s + "']/following::button[1]/span")); 
            }

            return Driver.Instance.FindElements(By.XPath("//div[@id='matrix']//li")).Count != v;
        }

        public string VerifyLeastQueryWarningMessage()
        {
            Driver.existsElement(By.XPath("//p[@id='warningMessageMatrix']"));
            return Driver.GetElement(By.XPath("//p[@id='warningMessageMatrix']")).Text;
        }

        public void BlankMatrixQuery(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='question-add-matrix-1']")).SendKeysWithSpace(v);
        }

        public bool? DeleteNumberofQueryto(int v, int s, int t)
        {
            for (int i = s; i <= t; i++)
            {
                Driver.clickEleJs(By.XPath("//input[@id='question-add-matrix-" + s + "']/following::button[1]/span"));
            }

            return Driver.Instance.FindElements(By.XPath("//div[@id='matrix']//li")).Count != v;
        }

        public bool? VerifyMinRangeFieldIsDisplayed(string v)
        {
            return Driver.existsElement(By.XPath("//input[@id='SQST_MIN_RANGE']"));

        }

        public bool? VerifyMaxRangeFieldIsDisplayed(string v)
        {
            return Driver.existsElement(By.XPath("//input[@id='SQST_MAX_RANGE']"));
        }

        public bool? VerifyStepIncrementFieldIsDisplayed(string v)
        {
            return Driver.existsElement(By.XPath("//input[@id='SQST_STEP_INCREMENT']"));
        }

        public bool? VerifyMinLabelFieldIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//input[@id='QUESTION_MIN_RATE_DESCRIPTION']"));
        }

        public bool? VerifyMaxLabelFieldIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//input[@id='QUESTION_MAX_RATE_DESCRIPTION']"));
        }

        public void Select_MinRange_MaxRange(string v1, string v2)
        {
            Driver.GetElement(By.XPath("//input[@id='SQST_MIN_RANGE']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='SQST_MIN_RANGE']")).SendKeysWithSpace(v1);
            Driver.GetElement(By.XPath("//input[@id='SQST_MAX_RANGE']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='SQST_MAX_RANGE']")).SendKeysWithSpace(v2);
        }

        public void Enter_StepIncrement(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='SQST_STEP_INCREMENT']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='SQST_STEP_INCREMENT']")).SendKeysWithSpace(v);
            Driver.GetElement(By.XPath("//input[@id='QUESTION_MIN_RATE_DESCRIPTION']")).SendKeysWithSpace(v);
            Thread.Sleep(2000);
        }

        public string VerifyMinRangeMessageIsDisplayed()
        {
            return Driver.GetElement(By.XPath("//small[@class='help-block']")).Text;
        }

        public string VerifyStepIncrementMessageIsDisplayed()
        {
            return Driver.GetElement(By.XPath("//div[@id='question-add-range']/div/div/div/div[2]/div/small")).Text;
        }

        public void Enter_MinLabel_Maxlabel(string v1, string v2)
        {
            Driver.GetElement(By.XPath("//input[@id='QUESTION_MIN_RATE_DESCRIPTION']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='QUESTION_MIN_RATE_DESCRIPTION']")).SendKeysWithSpace(v1);
            Driver.GetElement(By.XPath("//input[@id='QUESTION_MAX_RATE_DESCRIPTION']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='QUESTION_MAX_RATE_DESCRIPTION']")).SendKeysWithSpace(v2);
        }

        public bool? VerifySliderResponseExampleIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='question-add-range']/div/div/label"));
        }

        public void click_cancelbutton()
        {
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//button[contains(text(),'Cancel')]"));
            Thread.Sleep(8000);
        }

        public void CreateRadiobuttontype(string v1, string v2, string v3)
        {
            Driver.Instance.FindElement(By.Id("QUESTION_TITLE")).Click();
            Driver.Instance.FindElement(By.Id("QUESTION_TITLE")).Clear();
            Driver.Instance.FindElement(By.Id("QUESTION_TITLE")).SendKeys(v1);
            Driver.Instance.FindElement(By.Id("question-add-response-1")).Click();
            Driver.Instance.FindElement(By.Id("question-add-response-1")).Clear();
            Driver.Instance.FindElement(By.Id("question-add-response-1")).SendKeys(v2);
            Driver.Instance.FindElement(By.Id("question-add-response-2")).Click();
            Driver.Instance.FindElement(By.Id("question-add-response-2")).Clear();
            Driver.Instance.FindElement(By.Id("question-add-response-2")).SendKeys(v3);
            Driver.Instance.FindElement(By.Id("btnCreateQuestion")).Click();
        }
    }

    public class StructureCommand
    {
        public void Click_AddAQuestion()
        {
            Driver.clickEleJs(By.XPath("//div[@id='ViewManageContentStructure']/div/div/p/button"));
        }

        public string StructureQuestion(string questionType)
        {
            return Driver.GetElement(By.XPath("//a[contains(@href, '#modal-question')]")).Text;
           // return Driver.GetElement(By.XPath("//small[text()='" + questionType + "']/preceding::a[contains(text(),*)][1]")).Text;
        }

        public bool? VerifyQuestionType()
        {
            return Driver.existsElement(By.XPath("//div[@id='ViewManageContentStructure']/div/div/div[2]/ul/li[2]/div/div/small"));
        }

       

        public bool? VerifyQuestionType(string questionType)
        {
            string con = Driver.GetElement(By.XPath("//small[@class='text-muted']")).Text;

            string[] questionTypearray = Regex.Split(questionType, " ");
            string[] conlist = Regex.Split(con, " ");
            return questionTypearray[0].Equals("Drop-Down")||questionTypearray[0].Contains(con) || questionType.Contains(con) || conlist[0].Contains(questionType) || questionType.Contains(con);

            //return conlist[0].Equals(questionType);
            //return Driver.GetElement(By.XPath("//div[@id='ViewManageContentStructure']/div/div/div[2]/ul/li[2]/div/div/small")).Text.Equals(questionType);
            // return con.Equals(questionType)|| conlist[0].Equals(questionType); 
            //return questionType.Contains(con);
        }

        public bool? VerifyOptionalDisplayed(string questionOrTitle)
        {
            return Driver.existsElement(By.XPath("//a[contains(@href, '#modal-question')][contains(text(),'" + questionOrTitle + "')]/following::strong[1]"));
            //return Driver.existsElement(By.XPath([contains(@href, '#modal-question')]/following::strong[@class='badge bg-wrn ml-1']));
            //return Driver.existsElement(By.XPath("//a[contains(text(),'" + questionOrTitle + "')]"));
        }
        public bool? verifyingbranching()
        {
            return Driver.GetElement(By.XPath("//span[@class='fa fa-fw fa-code-fork fa-lg']")).Selected;
           
        }

        public bool? VerifybranchingLogicWhenSelected(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='ViewManageContentStructure']//small[text()='" + v + "']/following::a/span[1]")).Selected                                    ;
           
        }
    }
    
}
