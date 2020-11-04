using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Selenium2.Meridian;
using System.Threading;
using NUnit.Framework;
using System.Text.RegularExpressions;
using Utility;
using System.Collections.ObjectModel;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class ShoppingCartUtil
    {
         private readonly IWebDriver driverobj;
         private TrainingHomes TrainingHomeobj;
         private AdminstrationConsole AdminstrationConsoleobj;
         public ShoppingCartUtil(IWebDriver driver)
        {
            driverobj = driver;
            TrainingHomeobj = new TrainingHomes(driver);
            AdminstrationConsoleobj = new AdminstrationConsole(driver);
        }

        public string CourseTitleForShopping = string.Empty;
        public void linkmyresponsibilitiesclick()
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.myResponsibilities);
                driverobj.GetElement(ObjectRepository.myResponsibilities).ClickAnchor();
                driverobj.WaitForElement(ObjectRepository.searchHome);
                

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

        }
        public void linkgeneralcourseclick()
        {
           

            try
            {
                driverobj.WaitForElement(ObjectRepository.classroomCoursesLink);
                driverobj.ClickEleJs(ObjectRepository.classroomCoursesLink);
                driverobj.WaitForElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public void buttongoclick()
        {
            try
            {
                driverobj.FindSelectElementnew(ObjectRepository.selectcoursetype, "General Course");
                driverobj.GetElement(ObjectRepository.goCreategeneralcoursebtn).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.generalcourseTitle);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public void populatesummarygeneralCourse(int i)
        {

            try
            {
                
                driverobj.GetElement(ObjectRepository.generalcourseTitle).SendKeysWithSpace(CourseTitleForShopping + i);
                driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(ObjectRepository.generalcourseKeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Desc"]);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}
        }
        public void populateCourseFilesform()
        {

            try
            {
                // generalCourse.GetElement(ObjectRepository.generalcourseboostindex).SendKeys("2");
                driverobj.GetElement(ObjectRepository.generalcourseurlradio).Click();
                driverobj.GetElement(ObjectRepository.generalcourseurl_txtfld).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Url"]);


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}
        }
        public void buttoncreateclick()
        {

            try
            {

                driverobj.WaitForElement(ObjectRepository.generalcoursenext_btn);
                driverobj.GetElement(ObjectRepository.generalcoursenext_btn).ClickWithSpace();

                driverobj.WaitForElement(ObjectRepository.CheckinNew);
               

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }

        public void applysalestax()
        {

            driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_ddlTaxItemCategories"));
            driverobj.FindSelectElementnew(By.Id("MainContent_MainContent_UC1_ddlTaxItemCategories"), "test_taxcategory_" + ExtractDataExcel.token_for_reg);
        }

        public void buttoneditcostclick()
        {

            try
            {

               // driverobj.ScrollToCoordinated("0", "250");
                driverobj.ClickEleJs(ObjectRepository.generalcourseeditcostbutton);
                driverobj.WaitForElement(ObjectRepository.generalcourseeditcosttxt);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }

        public string buttonsetcostclick()
        {

            try
            {

                driverobj.GetElement(ObjectRepository.generalcourseeditcosttxt).Clear();
                driverobj.GetElement(ObjectRepository.generalcourseeditcosttxt).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["cost"]);
                driverobj.GetElement(ObjectRepository.generalcoursesavedefaultcost).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.sucessmessage);
                return driverobj.GetElement(ObjectRepository.sucessmessage).Text;
               

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);return "";

            }

        }
         public void buttonbackclick()
        {

            try
            {

               driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_btnCancel"));
                driverobj.GetElement(By.Id("MainContent_MainContent_UC1_btnCancel")).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.CheckinNew);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        
        public void buttoncheckinclick()
        {

            try
            {

               
                driverobj.ClickEleJs(ObjectRepository.CheckinNew);
                driverobj.WaitForElement(ObjectRepository.myResponsibilities);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public string CreateGeneralCourseforcart(int noofcourse, string postfix, string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
                CourseTitleForShopping = string.Empty;
                CourseTitleForShopping = ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "_" + postfix;
                MyPurchases.purchaseitem = CourseTitleForShopping;
                //ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "_shoppingcart"
                for (int i = 1; i <= noofcourse; i++)
                {
                   //linkmyresponsibilitiesclick();
                    TrainingHomeobj.MyResponsiblities_click();
                    linkgeneralcourseclick();
                    buttongoclick();
                    populatesummarygeneralCourse(i);
                    populateCourseFilesform();
                    buttoncreateclick();
                    buttoneditcostclick();
                   // applysalestax();
                    actualresult = buttonsetcostclick();
                    buttonbackclick();
                    buttoncheckinclick();
                    //driverobj.GetElement(ObjectRepository.generalcourseeditcostbutton).Click();
                    //driverobj.WaitForElement(ObjectRepository.generalcourseeditcosttxt);
                    //driverobj.GetElement(ObjectRepository.generalcourseeditcosttxt).Clear();
                    //driverobj.GetElement(ObjectRepository.generalcourseeditcosttxt).SendKeys(ExtractDataExcel.MasterDic_genralcourse["cost"]);
                    //driverobj.GetElement(ObjectRepository.generalcoursesavedefaultcost).Click();
                    
                }
                
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }


        public string additemtocartforgenral( int noofcourse, int startpoint)
        {
            string actualresult = string.Empty;
            try
            {
                
                   // ExtractDataExcel.GeneralCourse();
               


                for (int i = startpoint; i <= noofcourse; i++)
                {
                    driverobj.WaitForElement(By.Id("txtGlobalSearch"));
                    driverobj.ClickEleJs(By.Id("txtGlobalSearch"));
                    driverobj.WaitForElement(By.Id("txtGlobalSearch"));
                    driverobj.GetElement(By.Id("txtGlobalSearch")).Clear();
                   // driverobj.FindSelectElementnew(ObjectRepository.trainingcatalogtextsearchtype, ObjectRepository.filterdropdowntext);
                    driverobj.GetElement(By.Id("txtGlobalSearch")).SendKeysWithSpace(CourseTitleForShopping + i);
                    driverobj.GetElement(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']")).ClickWithSpace();
                    driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + CourseTitleForShopping + i + "')]"));
                    driverobj.ClickEleJs(By.XPath("//a[contains(text(),'" + CourseTitleForShopping + i + "')]"));
                    driverobj.WaitForElement(By.Id("MainContent_ucContentECommerce_FormView1_AddToCartButtonFlag"));
                    driverobj.GetElement(By.Id("MainContent_ucContentECommerce_FormView1_AddToCartButtonFlag")).ClickWithSpace();
               
                    driverobj.WaitForElement(ObjectRepository.sucessmessage);
                    actualresult = driverobj.GetElement(ObjectRepository.sucessmessage).Text;
                }

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink); 
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public string additemtocartforproduct(int noofcourse, int startpoint, string type, string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
             
                    //ExtractDataExcel.Product();
               


                for (int i = startpoint; i <= noofcourse; i++)
                {
                    driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                    driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                    driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).Clear();
                    //driverobj.FindSelectElementnew(ObjectRepository.trainingcatalogtextsearchtype, ObjectRepository.filterdropdowntext);
                    driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["Title"] + browserstr + i + type);
                    driverobj.GetElement(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']")).ClickWithSpace();
                    driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_product["Title"]+browserstr + i+type+ "')]"));
                    driverobj.ClickEleJs(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_product["Title"]+browserstr + i + type + "')]"));
                    driverobj.WaitForElement(By.Id("MainContent_ucContentECommerce_FormView1_AddToCartButtonProductFlag"));
                    driverobj.ClickEleJs(By.Id("MainContent_ucContentECommerce_FormView1_AddToCartButtonProductFlag"));
                   

                    // driverobj.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_AddToCartButtonFlag")).Click();
                    //driverobj.doubleClick(By.Id("MainContent_ucPrimaryActions_FormView1_AddToCartButtonFlag"));
                    driverobj.WaitForElement(ObjectRepository.sucessmessage);
                    actualresult = driverobj.GetElement(ObjectRepository.sucessmessage).Text;
                }

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink); ;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool CheckIteminCart( int startpoint,int noofcourse)
        {
            bool actualresult = false;
            try
            {
                driverobj.ClickEleJs(By.XPath("//a[@href='/ECommerce/ShoppingCart.aspx']"));
               // ExtractDataExcel.GeneralCourse();
                //Thread.Sleep(5000);
                //driverobj.WaitForElement(ObjectRepository.ShoppingCartLink);
                //driverobj.GetElement(ObjectRepository.ShoppingCartLink).ClickWithSpace();
                
                // driverobj.isPresentAndClick(By.XPath("NavigationStrip1_qucShoppingCart_lnkIcon"));
               // Thread.Sleep(5000);
                for (int i = startpoint; i <= noofcourse; i++)
                {

                    driverobj.GetElement(By.XPath("//a[contains(text(),'" + CourseTitleForShopping + i + "')]"));
                    
                }

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public string RemoveItemfromCart()
        {
            string actualresult = string.Empty;
            try
            {
                //ExtractDataExcel.GeneralCourse();
                driverobj.WaitForElement(By.XPath("//a[@href='/ECommerce/ShoppingCart.aspx']"));
                driverobj.ClickEleJs(By.XPath("//a[@href='/ECommerce/ShoppingCart.aspx']"));
                driverobj.WaitForElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_MRadGrid_Digital_ctl00__0']/td[2]/a"));
                driverobj.ClickEleJs(By.XPath(".//*[@id='ctl00_MainContent_UC1_MRadGrid_Digital_ctl00__0']/td[2]/a"));
                driverobj.findandacceptalert();
                Thread.Sleep(3000);
                driverobj.WaitForElement(ObjectRepository.ShoppingCartDigitalSubTotal);
                actualresult = driverobj.GetElement(By.XPath(".//*[@id='content']/div/div/div[2]/div[1]/p[5]")).Text;

                 //actualresult = driverobj.GetElement(By.XPath("//td[@class='cart-subtotal']")).Text;
               // actualresult = driverobj.GetElement(By.XPath("/html/body/form/div[6]/div/div[6]/div[2]/div/div[2]/div/table/tfoot/tr/td")).Text;
                actualresult = Regex.Replace(actualresult, "[^.0-9]", "");

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool RemoveAllfromCart()
        {
            bool actualresult = false;
            try
            {
               // ExtractDataExcel.GeneralCourse();

                driverobj.GetElement(ObjectRepository.ShoppingCartLink).ClickWithSpace();
                Thread.Sleep(5000);

                while (driverobj.ElementNotPresent(ObjectRepository.ShoppingCartDeleteFirstItem)==false)
                {
                    driverobj.GetElement(ObjectRepository.ShoppingCartDeleteFirstItem).ClickWithSpace();
                    driverobj.findandacceptalert();
                    
                }

                actualresult = true;
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink); 
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                actualresult = false;
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                //Assert.Fail(ex.Message);
                
            }
            return actualresult;
           
        }

        public string UpdateQuantityinCart()
        {
            string actualresult = string.Empty;
            try
            {
                //ExtractDataExcel.Product();
                driverobj.WaitForElement(By.XPath("//span[@class='fa fa-shopping-cart fa-lg']"));
                driverobj.GetElement(By.XPath("//span[@class='fa fa-shopping-cart fa-lg']")).ClickWithSpace();
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_MRadGrid_Digital_ctl00_ctl04_SHOPPINGCART_CONTENT_QTY"));
                driverobj.GetElement(By.Id("ctl00_MainContent_UC1_MRadGrid_Digital_ctl00_ctl04_SHOPPINGCART_CONTENT_QTY")).Clear();
                driverobj.GetElement(By.Id("ctl00_MainContent_UC1_MRadGrid_Digital_ctl00_ctl04_SHOPPINGCART_CONTENT_QTY")).SendKeysWithSpace("2");
                driverobj.ClickEleJs(By.Id("ctl00_MainContent_UC1_MRadGrid_Digital_ctl00_ctl04_DigitalUpdateItemQuantity"));
                Thread.Sleep(4000);
                driverobj.WaitForElement(ObjectRepository.ShoppingCartSubTotal);
                //actualresult = driverobj.GetElement(By.XPath("//td[@class='cart-subtotal']")).Text;
                // Thread.Sleep(5000);
                actualresult = driverobj.GetElement(By.XPath(".//*[@id='content']/div/div/div[2]/div[1]/p[1]")).Text;
                //actualresult = driverobj.GetElement(By.XPath("/html/body/form/div[6]/div/div[6]/div[2]/div/div[2]/div[3]/table/tfoot/tr/td")).Text;
                actualresult = Regex.Replace(actualresult, "[^.0-9]", "");

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }


        public string adddiscount(string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
            //ExtractDataExcel.Discount();
                TrainingHomeobj.isTrainingHome();
                //TrainingHomeobj.lnk_SystemOptions_click();
                TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Ecommerce')]"));
                TrainingHomeobj.lnk_PricingandCodes_click();
                AdminstrationConsoleobj.Click_OpenItemLink("Discount Codes");
                driverobj.WaitForElement(ObjectRepository.DiscountGoBtn);
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.TAB.DiscountCode.SimpleSearch"), "Create Order Discount Code");
            driverobj.GetElement(ObjectRepository.DiscountGoBtn).ClickWithSpace();
            driverobj.GetElement(ObjectRepository.DiscountTitle).Clear();
            driverobj.GetElement(ObjectRepository.DiscountTitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_discount["Name"]+browserstr);
            driverobj.GetElement(ObjectRepository.DiscountDesc).Clear();
            driverobj.GetElement(ObjectRepository.DiscountDesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_discount["Desc"]);
            driverobj.GetElement(ObjectRepository.DiscountKeyword).Clear();
            driverobj.GetElement(ObjectRepository.DiscountKeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_discount["Desc"]);
            driverobj.GetElement(ObjectRepository.DiscountCode).Clear();
            driverobj.GetElement(ObjectRepository.DiscountCode).SendKeysWithSpace(ExtractDataExcel.MasterDic_discount["code"]+browserstr);
            driverobj.GetElement(ObjectRepository.DiscountValue).Clear();
            driverobj.GetElement(ObjectRepository.DiscountValue).SendKeysWithSpace(ExtractDataExcel.MasterDic_discount["discount"]);
            driverobj.GetElement(ObjectRepository.createbutton).ClickWithSpace();
            driverobj.WaitForElement(ObjectRepository.DiscountUserGoBtn);
            driverobj.GetElement(ObjectRepository.DiscountUserGoBtn).ClickWithSpace();
            driverobj.GetElement(ObjectRepository.DiscountUserSearch).Clear();
            driverobj.GetElement(ObjectRepository.DiscountUserSearch).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Firstname"]+browserstr + " " + ExtractDataExcel.MasterDic_userforreg["Lastname"]+browserstr);
            driverobj.FindSelectElementnew(ObjectRepository.DiscountSearchType, ObjectRepository.filterdropdowntext);
            driverobj.GetElement(ObjectRepository.DiscountSearchGroupBtn).ClickWithSpace();
            driverobj.WaitForElement(ObjectRepository.DiscountSelectUserGroupFromList);
            driverobj.GetElement(ObjectRepository.DiscountSelectUserGroupFromList).ClickWithSpace();
            driverobj.WaitForElement(ObjectRepository.DiscountAssignUserGroupBtn);
            driverobj.GetElement(ObjectRepository.DiscountAssignUserGroupBtn).ClickWithSpace();
            driverobj.GetElement(ObjectRepository.DiscountEditActivit).ClickWithSpace();
            driverobj.GetElement(ObjectRepository.DiscountSaveBtn).ClickWithSpace();
            driverobj.WaitForElement(ObjectRepository.generalcourseReturnFeedback);
            actualresult = driverobj.GetElement(ObjectRepository.generalcourseReturnFeedback).Text.ToString();

                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
           

        }

        public string deletediscount(string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
               // ExtractDataExcel.Discount();
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElement(ObjectRepository.admindiscountlink).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.searchtext);
                driverobj.GetElement(ObjectRepository.searchtext).Clear();
                driverobj.GetElement(ObjectRepository.searchtext).SendKeysWithSpace(ExtractDataExcel.MasterDic_discount["Name"]+browserstr);
                driverobj.FindSelectElementnew(ObjectRepository.searchtype, ObjectRepository.filterdropdowntext);
                driverobj.GetElement(ObjectRepository.searchbutton).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.DiscountSelectToDelete);
                driverobj.GetElement(ObjectRepository.DiscountSelectToDelete).ClickWithSpace();
                driverobj.GetElement(ObjectRepository.DiscountDeleteBtn).ClickWithSpace();
                
                driverobj.findandacceptalert();
                
                actualresult = driverobj.GetElement(ObjectRepository.generalcourseReturnFeedback).Text.ToString();

                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;


        }

        public bool ApplyDiscount(string browserstr)
        {
            bool actualresult = false;
            try
            {
                //ExtractDataExcel.Discount();
                driverobj.WaitForElement(ObjectRepository.ShoppingCartLink);
                driverobj.GetElement(ObjectRepository.ShoppingCartLink).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.DiscountCodeApplytxt);
                driverobj.GetElement(ObjectRepository.DiscountCodeApplytxt).Clear();
                driverobj.GetElement(ObjectRepository.DiscountCodeApplytxt).SendKeysWithSpace(ExtractDataExcel.MasterDic_discount["code"]+browserstr);
                driverobj.GetElement(ObjectRepository.DiscountApplyBtn).ClickWithSpace();
              actualresult= driverobj.existsElement(By.XPath("//strong[contains(.,'$140.00')]"));
               
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
             
            }
            return actualresult;
        }

        public string SetMultipleCurrency()
        {
            string actualresult = string.Empty;
            try
            {
                //ExtractDataExcel.Discount();
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElement(ObjectRepository.adminconfigconsole).ClickAnchor();
                driverobj.GetElement(ObjectRepository.adminMultipleCurrency).ClickWithSpace();
                driverobj.GetElement(ObjectRepository.MultipleCurrencyCheck).ClickWithSpace();
                driverobj.GetElement(ObjectRepository.MultipleCurrencySaveBtn).ClickWithSpace();

                actualresult = driverobj.GetElement(ObjectRepository.generalcourseReturnFeedback).Text.ToString();

                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;


        }

        //public bool SwitchCurrency(IWebDriver iSelenium)
        //{
        //    bool actualresult = false;
        //    try
        //    {
        //        ExtractDataExcel.Discount();

        //        driverobj.isPresentAndClick(By.Id("NavigationStrip1_qucShoppingCart_lnkIcon"));
        //        Thread.Sleep(5000);
        //        driverobj.GetElement(By.Id("MainContent_UC1_SwitchCurrency")).Click();
        //        driverobj.SelectFrame();
        //        driverobj.FindSelectElementnew(By.Id("MainContent_UC1_USR_CURRENCY_ID"), "British Pound");
        //        driverobj.GetElement(By.CssSelector("option[value=\"GBP\"]")).Click();
        //        Thread.Sleep(3000);
        //       string exchangedrate = driverobj.GetElement(By.Id("MainContent_UC1_pnlExchangeRate")).Text;
        //       exchangedrate = exchangedrate.Remove(0, exchangedrate.IndexOf('=')+1).Trim();
        //       exchangedrate = exchangedrate.Remove(exchangedrate.IndexOf(' '), exchangedrate.Length - exchangedrate.IndexOf(' '));
        //       //exchangedrate = Regex.Replace(exchangedrate, "[^.0-9]", "");
        //       //string exchangedrate = driverobj.GetElement(By.Id("MainContent_UC1_pnlExchangeRate")).GetAttribute("value");
        //        driverobj.GetElement(By.Id("MainContent_UC1_Save")).Click();
        //        Thread.Sleep(5000);
                
        //        driverobj.SwitchTo().DefaultContent();

        //        string matchexchanged = driverobj.GetElement(By.XPath("/html/body/form/div[6]/div/div[6]/div[2]/div/div[2]/div[6]/div[11]/span")).Text;

        //        //actualresult = driverobj.GetElement(By.XPath("/html/body/form/div[6]/div/div[6]/div[2]/div/div[2]/div[3]/table/tfoot/tr/td")).Text;
        //       matchexchanged = Regex.Replace(matchexchanged, "[^.0-9]", "");

        //       string dollarrate = driverobj.GetElement(By.XPath("/html/body/form/div[6]/div/div[6]/div[2]/div/div[2]/div[6]/div[12]/div[3]/span")).Text;
        //       dollarrate = Regex.Replace(dollarrate, "[^.0-9]", "");
        //       double converttoswitchedcurrency = Convert.ToDouble(dollarrate) * Convert.ToDouble(exchangedrate);
        //       if (converttoswitchedcurrency == Convert.ToDouble(matchexchanged))
        //       {
        //           actualresult = true;
        //       }
        //        driverobj.OpenToolbarItems("Logout");

        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.TakeScreenShot();
        //        //Assert.Fail(ex.Message);
        //    }
        //    return actualresult;
        //}

        public bool SwitchCurrency( string currency, string cssval)
        {
            bool actualresult = false;
            try
            {
                //ExtractDataExcel.Discount();
                driverobj.WaitForElement(By.XPath("//span[@class='fa fa-shopping-cart fa-lg']"));
                driverobj.ClickEleJs(By.XPath("//span[@class='fa fa-shopping-cart fa-lg']"));

                driverobj.WaitForElement(ObjectRepository.SwitchCurrencyBtn);
                //driverobj.ScrollToCoordinated("0", "250");
                driverobj.GetElement(ObjectRepository.SwitchCurrencyBtn).ClickWithSpace();
                //driverobj.SelectFrame(ObjectRepository.SwitchCurrencySelectCurrency);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.FindSelectElementnew(ObjectRepository.SwitchCurrencySelectCurrency, currency);
                driverobj.GetElement(By.CssSelector("option[value=\"" + cssval + "\"]")).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.SwitchCurrencySaveBtn);
                string exchangedrate = string.Empty;
                if (cssval != "USD")
                {
                    
                    exchangedrate = driverobj.GetElement(ObjectRepository.SwitchCurrencyExchangeRate).Text;
                    exchangedrate = exchangedrate.Remove(0, exchangedrate.IndexOf('=') + 1).Trim();
                    exchangedrate = exchangedrate.Remove(exchangedrate.IndexOf(' '), exchangedrate.Length - exchangedrate.IndexOf(' '));
                    //exchangedrate = Regex.Replace(exchangedrate, "[^.0-9]", "");
                    //string exchangedrate = driverobj.GetElement(By.Id("MainContent_UC1_pnlExchangeRate")).GetAttribute("value");

                    driverobj.GetElement(ObjectRepository.SwitchCurrencySaveBtn).ClickWithSpace();
                    Thread.Sleep(5000);

                    driverobj.SwitchTo().DefaultContent();

                    string matchexchanged = driverobj.GetElement(By.XPath("/html/body/form/div[7]/div/div/div[2]/div[2]/div[3]/div[2]/div[4]/div[2]")).Text;


                     matchexchanged = Regex.Replace(matchexchanged, "[^.0-9]", "");

                     string dollarrate = driverobj.GetElement(By.XPath("/html/body/form/div[7]/div/div/div[2]/div[2]/div[3]/div[2]/div[5]/div/div[2]")).Text;
                    dollarrate = Regex.Replace(dollarrate, "[^.0-9]", "");
                    double converttoswitchedcurrency = Convert.ToDouble(dollarrate) * Convert.ToDouble(exchangedrate);
                    if (converttoswitchedcurrency == Convert.ToDouble(matchexchanged))
                    {
                        actualresult = true;
                    }
                }
                else
                {
                    driverobj.GetElement(ObjectRepository.SwitchCurrencySaveBtn).ClickWithSpace();
                    Thread.Sleep(5000);

                    driverobj.SwitchTo().DefaultContent();
                    actualresult = true;
                }
               
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public string checkoutitems()
        {
            string actualresult = string.Empty;
            try
            {
               // ExtractDataExcel.GeneralCourse();
                driverobj.WaitForElement(ObjectRepository.ShoppingCartLink);
                driverobj.GetElement(ObjectRepository.ShoppingCartLink).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.ShoppingCartCheckoutPageBtn);
                driverobj.GetElement(ObjectRepository.ShoppingCartCheckoutPageBtn).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.ShippingStreet);
                driverobj.GetElement(ObjectRepository.ShippingStreet).Clear();
                driverobj.GetElement(ObjectRepository.ShippingStreet).SendKeysWithSpace("test1");
                driverobj.GetElement(ObjectRepository.ShippingCity).Clear();
                driverobj.GetElement(ObjectRepository.ShippingCity).SendKeysWithSpace("testcity");
                driverobj.FindSelectElementnew(ObjectRepository.ShippingState, "Alabama");
                driverobj.FindSelectElementnew(ObjectRepository.ShippingCountry, "UNITED STATES");
                driverobj.GetElement(ObjectRepository.ShippingZipCode).Clear();
                driverobj.GetElement(ObjectRepository.ShippingZipCode).SendKeysWithSpace("824201");
                driverobj.GetElement(ObjectRepository.ShippingPhoneNo).Clear();
                driverobj.GetElement(ObjectRepository.ShippingPhoneNo).SendKeysWithSpace("3232323232");
                driverobj.GetElement(ObjectRepository.ShippingContinueToCheckout).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.ShoppingCartCheckOut);
              
                actualresult=driverobj.Title;


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }
        public void checkoutnexttime()
        {
          
            try
            {
                // ExtractDataExcel.GeneralCourse();
                driverobj.WaitForElement(ObjectRepository.ShoppingCartLink);
                driverobj.GetElement(ObjectRepository.ShoppingCartLink).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.ShoppingCartCheckoutPageBtn);
                driverobj.GetElement(ObjectRepository.ShoppingCartCheckoutPageBtn).ClickWithSpace();
                 driverobj.WaitForElement(ObjectRepository.ShoppingCartCheckOut);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                //Assert.Fail(ex.Message);
            }
           
        }
        public  void setbillingaddress()
        {
            try
            {
             //   driverobj.WaitForElement(ObjectRepository.ShoppingCartLink);
            //    driverobj.GetElement(ObjectRepository.ShoppingCartLink).ClickWithSpace();
                //driverobj.SelectFrame(ObjectRepository.BillingStreet);
                //driverobj.SelectFrame();
              //  driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                if (!driverobj.existsElement(By.Id("cbAgreeToTerms")))
                {
                    driverobj.GetElement(By.Name("ctl00$MainContent$UC1$ctl01")).ClickWithSpace();
                    driverobj.WaitForElement(By.Id("PI_BILL_TO_TAX_STREET"));
                    driverobj.GetElement(By.Id("PI_BILL_TO_TAX_STREET")).Clear();
                    driverobj.GetElement(By.Id("PI_BILL_TO_TAX_STREET")).SendKeysWithSpace("Test Street");
                    driverobj.GetElement(By.Id("PI_BILL_TO_TAX_CITY")).Clear();
                    driverobj.GetElement(By.Id("PI_BILL_TO_TAX_CITY")).SendKeysWithSpace("Test City");
                    driverobj.FindSelectElementnew(By.Id("PI_BILL_TO_TAX_COUNTRY_ID"), "UNITED STATES");
                    Thread.Sleep(4000);
                    driverobj.FindSelectElementnew(By.Id("PI_BILL_TO_TAX_STATE_ID"), "Alabama");


                    //due to loading problem occurs
                    Thread.Sleep(5000);
                    driverobj.GetElement(By.Id("PI_BILL_TO_TAX_ZIP")).Clear();
                    driverobj.GetElement(By.Id("PI_BILL_TO_TAX_ZIP")).SendKeysWithSpace("824201");
                    // driverobj.GetElement(By.Id("PI_BILL_TO_TAX_STREET")).Clear();
                    //  driverobj.GetElement(By.Id("PI_BILL_TO_TAX_STREET")).SendKeysWithSpace("123456789");
                    driverobj.GetElement(By.Id("MButton1")).ClickWithSpace();

                    Thread.Sleep(3000);
                    // driverobj.SwitchTo().Window("");
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
               // driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

        }

        public void managetaxrate()
        {
            try
            {

                //driverobj.GetElement(ObjectRepository.adminconsoleopenlink).Click();
                //driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.WaitForElement(ObjectRepository.ManageTaxRateLink);
                driverobj.GetElement(ObjectRepository.ManageTaxRateLink).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.AddNewTaxTableBtn);
                driverobj.GetElement(ObjectRepository.AddNewTaxTableBtn).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.TaxTableTitle);
                driverobj.GetElement(ObjectRepository.TaxTableTitle).SendKeysWithSpace("test_taxtable_" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(ObjectRepository.AddTaxTableBtn).ClickWithSpace();
                driverobj.SwitchTo().DefaultContent();
                driverobj.SwitchTo().Frame(0);
                ReadOnlyCollection<IWebElement> managebtns = driverobj.FindElements(ObjectRepository.alltaxtable);// -1;
               // if (driverobj.FindElements(ObjectRepository.alltaxtable).Count==1)
               // {
               //     taxtablecount = 0;
               // }
               //// driverobj.SelectFrame();
               // //driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_rgTaxTables_ctl00_ctl20_btnManageTaxRateTable"));
               // driverobj.WaitForElement(By.XPath("//tr[@id = '" + ObjectRepository.ManageTaxTableBtn + taxtablecount.ToString() + "']/td[2]/a[0]"));
               // driverobj.GetElement(By.XPath("//tr[@id = '" + ObjectRepository.ManageTaxTableBtn + taxtablecount.ToString() + "']/td[2]/a[0]")).Click();
                managebtns[managebtns.Count-1].Click();
                //driverobj.GetElement(By.XPath("//a[@href='EditSalesTaxRates.aspx?tid=" + taxtablecount + "']")).Click();
                //driverobj.SwitchTo().Frame(0);
                driverobj.WaitForElement(ObjectRepository.ManageTaxRateState);
                driverobj.FindSelectElementnew(ObjectRepository.ManageTaxRateState, "Alabama");
                driverobj.WaitForElement(ObjectRepository.taxratetxt);
                driverobj.GetElement(ObjectRepository.taxratetxt).SendKeysWithSpace("5");
                driverobj.GetElement(ObjectRepository.checkshippingtax).ClickWithSpace();
                driverobj.GetElement(ObjectRepository.shippingtaxratetxt).SendKeysWithSpace("0");
                driverobj.GetElement(ObjectRepository.addshippinforstatebtn).ClickWithSpace();
                //driverobj.WaitForElement(sucessmessage);
               // driverobj.WaitForElement(ObjectRepository.Returntoadminbtn);
                Thread.Sleep(3000);
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Administration Console')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Administration Console')]")).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.ManageTaxRateLink);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }

        public void Createtaxitemcategory()
        {
            try
            {
                //driverobj.GetElement(ObjectRepository.adminconsoleopenlink).Click();
                //driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.WaitForElement(ObjectRepository.TaxItemCatagoryLink);
                driverobj.GetElement(ObjectRepository.TaxItemCatagoryLink).ClickWithSpace();
                driverobj.SwitchTo().Frame(0);
                driverobj.WaitForElement(ObjectRepository.AddNewTaxItemCatageroyBtn);
                driverobj.GetElement(ObjectRepository.AddNewTaxItemCatageroyBtn).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.TaxCategoryTxt);
                driverobj.GetElement(ObjectRepository.TaxCategoryTxt).SendKeysWithSpace("test_taxcategory_" + ExtractDataExcel.token_for_reg);
                driverobj.FindSelectElementnew(ObjectRepository.selectTaxTable, "test_taxtable_" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(ObjectRepository.AddTaxItenCatageryBtn).ClickWithSpace();
                driverobj.SwitchTo().DefaultContent();
                driverobj.SwitchTo().Frame(0);
                driverobj.WaitForElement(ObjectRepository.AddNewTaxItemCatageroyBtn);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
                  
            
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
               // driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

        }

        public void Enable_SalesTax()
        {
            try
            { 
            driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
            driverobj.selectWindow(ObjectRepository.adminwindowtitle);
            driverobj.WaitForElement(By.LinkText("Configuration Console (Home)"));
            driverobj.GetElement(By.LinkText("Configuration Console (Home)")).ClickWithSpace();
            driverobj.WaitForElement(By.LinkText("Sales Tax"));
            driverobj.GetElement(By.LinkText("Sales Tax")).ClickWithSpace();
            driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_SalesTax_SALESTAX_SUPPORT_0"));
            driverobj.GetElement(By.Id("TabMenu_ML_BASE_SalesTax_SALESTAX_SUPPORT_0")).ClickWithSpace();
            driverobj.GetElement(By.Id("TabMenu_ML_BASE_SalesTax_SalesTax_ShowTaxRate_0")).ClickWithSpace();
            driverobj.GetElement(By.Id("TabMenu_ML_BASE_SalesTax_EnableManualSalesTax_0")).ClickWithSpace();
            driverobj.GetElement(By.Id("ML.BASE.BTN.Save")).ClickWithSpace();
            driverobj.WaitForElement(By.Id("ReturnFeedback"));
            
            driverobj.WaitForElement(By.XPath("//a[contains(.,'Administration Console')]"));
            driverobj.GetElement(By.XPath("//a[contains(.,'Administration Console')]")).ClickWithSpace();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                // driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

        
        }

        public bool Purchaseusingaccountcode()
        {
            try
            {
                driverobj.WaitForElement(rb_accountcode);
                driverobj.GetElement(rb_accountcode).ClickWithSpace();
                driverobj.GetElement(ObjectRepository.ShoppingCartCheckOut).ClickWithSpace();
               return driverobj.existsElement(chk_agree);
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }


        }

       public bool Purchaseusingcybersource()
        {
            try
            {
                driverobj.WaitForElement(rb_cybersource);
                driverobj.GetElement(rb_cybersource).ClickWithSpace();
                driverobj.GetElement(ObjectRepository.ShoppingCartCheckOut).ClickWithSpace();
                Thread.Sleep(5000);
                
                //if (driverobj.Title.Contains("cybersource"))
                //{

                //    return true;
                //}
                //else

                //{
                //    return false;
                //}
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }


        

        }
       public bool Complete_Purchase()
       {
           try
           {
             
               driverobj.WaitForElement(chk_agree);
               driverobj.GetElement(chk_agree).ClickWithSpace();
               driverobj.GetElement(btn_Buy).ClickWithSpace();
              return driverobj.existsElement(sucessmessage);
             
           }
           catch (Exception ex)
           {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
               return false;
           }




       }
        private By sucessmessage = By.XPath("//div[@class='alert alert-success']");
        private By desc_htmleditor = By.XPath("//div[@id='Editor']/div[2]/div/p");
        private By desc_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        private By rb_accountcode = By.Id("MainContent_UC1_fvPaymentInfo_PMTACCOUNTCODE_0");
        private By rb_cybersource = By.Id("MainContent_UC1_fvPaymentInfo_PMTCYBERSOURCE");
        private By btn_Buy = By.Id("MainContent_UC1_Checkout");
        private By chk_agree = By.Id("cbAgreeToTerms");
      

    }
}
