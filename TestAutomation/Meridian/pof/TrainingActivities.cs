using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using System.Threading;

namespace Selenium2.Meridian
{
    class TrainingActivities
    {

        private readonly IWebDriver driverobj;

         public TrainingActivities(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool AddTrainingActivities_Click()
        {
            try
            {
                driverobj.WaitForElement(TrainingActivities_AddTrainingActivities_Button);
                driverobj.ClickEleJs(TrainingActivities_AddTrainingActivities_Button);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool Click_AddCurriculamBlock()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(btn_addcurriculamblock);
                driverobj.ClickEleJs(btn_addcurriculamblock);
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(5000);
                driverobj.WaitForElement(rb_unordered);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
           
            }
            return result;
        }

        public bool Click_SaveandAddAnotherCurriculamBlock(string prefix, string browserstr)
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(rb_unordered);
               // driverobj.GetElement(rb_unordered).ClickWithSpace();
                driverobj.ClickEleJs(rb_unordered);
                driverobj.GetElement(txt_titleofblock).Clear();
                driverobj.GetElement(txt_titleofblock).SendKeysWithSpace(Variables.curriculumblockTitle+browserstr+prefix);
                driverobj.GetElement(btn_saveaddanotherblock).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                driverobj.WaitForElement(rb_unordered);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }


        public bool Click_SaveandExitCurriculamBlock(string prefix,string browserstr)
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(rb_ordered);
               // driverobj.GetElement(rb_ordered).ClickWithSpace();
                driverobj.ClickEleJs(rb_ordered);
                driverobj.GetElement(txt_titleofblock).Clear();
                driverobj.GetElement(txt_titleofblock).SendKeysWithSpace(Variables.curriculumblockTitle+browserstr+prefix);
                driverobj.GetElement(btn_saveandexit).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.WaitForElement(lbl_success);
              //  driverobj.WaitForElement(TrainingActivities_AddTrainingActivities_Button);
             //   driverobj.GetElement(btn_return).ClickWithSpace();
                


                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }

        public bool Click_Backbutton()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(btn_back);
                driverobj.ClickEleJs(btn_back);
                
                //  driverobj.WaitForElement(TrainingActivities_AddTrainingActivities_Button);
                //   driverobj.GetElement(btn_return).ClickWithSpace();



                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;

        }
        public bool Click_SaveCreditCurriculamBlock(string browserstr)
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(rb_credit);
              //  driverobj.GetElement(rb_credit).ClickWithSpace();
                driverobj.ClickEleJs(rb_credit);
                driverobj.GetElement(txt_titleofblock).Clear();
                driverobj.GetElement(txt_titleofblock).SendKeysWithSpace(Variables.curriculumblockTitle+browserstr + "_credit");
                driverobj.GetElement(btn_saveandexit).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                driverobj.WaitForElement(cmb_credittype);
                driverobj.GetElement(btn_return).ClickWithSpace();
               



                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }
        public bool Check_AutoSave()
        {
            bool result = false;
            try
            {
                IList<IWebElement> txkbox = driverobj.FindElements(By.XPath("//input[contains(@name,'txtBlockTitle')]"));
                int i = 0;
                foreach (var itr in txkbox)
                {
                    if (i == 0)
                    {
                        itr.Click();
                    }
                    else
                    {
                        itr.Click();
                        driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                        break;

                    }

                }
                //input[contains(@name,'txtBlockTitle')
                    result = true;
                
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }
        public bool Click_TrainingActivityCurriBlock1()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_MLinkButton1"));
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_MLinkButton1"));
               
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }
        public bool Click_TrainingActivityCurriBlock2()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(btn_trainingactivities_curriblock2);
                driverobj.GetElement(btn_trainingactivities_curriblock2).ClickWithSpace();

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }

        public bool Click_TrainingActivityCurriBlockCredit()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(btn_trainingactivities_curriblock_credit);
                driverobj.GetElement(btn_trainingactivities_curriblock_credit).ClickWithSpace();

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }


        private By TrainingActivities_AddTrainingActivities_Button = By.XPath("//a[contains(.,'Add Training Activities')]");
        private By btn_addcurriculamblock = By.Id("MainContent_MainContent_UC1_MLinkButton1");
        private By rb_unordered = By.Id("MainContent_UC1_BLOCK_TYPE_0");
        private By rb_ordered = By.Id("MainContent_UC1_BLOCK_TYPE_1");
        private By rb_credit = By.Id("MainContent_UC1_BLOCK_TYPE_2");
        private By txt_titleofblock = By.Id("MainContent_UC1_BLOCK_NAME");
        private By btn_saveaddanotherblock = By.Id("MainContent_UC1_AddAnotherBlock");
        private By lbl_success = By.XPath("//div[@class='alert alert-success']");
        private By btn_saveandexit = By.Id("MainContent_UC1_Save");
        private By btn_return = By.Id("MainContent_MainContent_UC1_btnCancel");
        private By txt_curriculamblock1 = By.XPath("//td[2]/div/div/div/div/div/input");
        private By txt_curriculamblock2 = By.XPath("//div[2]/table/tbody/tr[2]/td[2]/div/div/div/div/div/input");
        private By txt_curriculamblock_credit = By.XPath("/div[@id='MainContent_MainContent_UC1_pnlCurriculumBlock']/div/div[3]/table/tbody/tr[2]/td[2]/div/div/h2/input");
        private By btn_trainingactivities_curriblock1 = By.XPath("//div[2]/div/div[2]/div/a");
        private By btn_trainingactivities_curriblock2 = By.XPath("//div[2]/table/tbody/tr[2]/td[2]/div/div/div[2]/div/div[2]/div/a");
        private By btn_trainingactivities_curriblock_credit = By.XPath("//div[3]/div/a");
        private By cmb_credittype = By.XPath("//select[contains(@id,'ddlCreditTypes')]");
        private By btn_back = By.Id("MainContent_MainContent_UC1_btnCancel");

        internal void Click_SaveandExitCurriculamBlock()
        {
            throw new NotImplementedException();
        }
    }
}
