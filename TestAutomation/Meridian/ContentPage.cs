using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class ContentPage
    {
        public static ContentTabCommand ContentTab
        {
            get { return new ContentTabCommand(); }
        }

        public static bool? isTestDisplayed()
        {
            throw new NotImplementedException();
        }

        public static bool? SectionContentPageopened()
        {
            return Driver.existsElement(By.XPath("//div[@id='no-content']/div/div/a"));
        }

        public static void ClickAddContent(string v)
        {
            //Driver.waitforframe();
            Driver.clickEleJs(By.XPath("(//a[contains(text(),'Add Content')])[2]"));
            Driver.waitforframe();

            Driver.GetElement(By.XPath("//input[@id='SearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@id='btn-search-content']//span[@class='fa fa-search']"));
            Driver.clickEleJs(By.XPath("//input[@id='btSelectItem_5BEBDBA5C3254ADDBA2E7FBF9A371047']"));
            Driver.clickEleJs(By.XPath("//button[@id='btn-add']"));

        }

        public static void ClickViewAslearner()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }

        public static void ClickSectionDetailsTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkSectionDetails']"));
        }
    }

}

public class ContentTabCommand
{
    public bool? filesIsDisplayed;
    public bool? notesIsDisplayed;
    public bool? assignmentIsDisplayed;

    public editGradingOptionsModalCommand EditGradingOptionsModal
    {
        get { return new editGradingOptionsModalCommand(); }
    }

    public EditAssignmentModalCommand EditAssignmentModal { get { return new EditAssignmentModalCommand(); } }

    public bool? AddNoteModalIsClosed { get { return Driver.existsElement(By.XPath("//div[@id='addNote']/div/div/div/h4")); } }

    public AddNoteModalCommand AddNoteModal { get { return new AddNoteModalCommand(); } }

    public bool? isNoteModalOpened { get; internal set; }

    public bool? onlineIsDisplayed(string v)
    {
        throw new NotImplementedException();
    }

    public void clickGradingCompletionForGeneralCourse()
    {
        throw new NotImplementedException();
    }

    public bool GetGradingCompletionColumnForGeneralCourse()
    {
        throw new NotImplementedException();
    }

    public bool GetGradingCompletionColumnForGeneralCourse(string v1, string v2)
    {
        throw new NotImplementedException();
    }

    public void ClickGradeBookTab()
    {
        throw new NotImplementedException();
    }

    public void ClickGradingCompletionColumnForAssignment()
    {
        Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[5]/a"));
        Driver.clickEleJs(By.XPath("//table[@id='table-material']/tbody/tr/td[5]/a"));

    }

    public string GradingCompletionColumnValue()
    {
        return Driver.GetElement(By.XPath("//table[@id='table-material']/tbody/tr/td[5]/a")).Text;
    }

    public bool? GradingCompletionColumnUpdated(string gradingCompletionColumnvalue)
    {
        Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[5]/a"));
        if (!(Driver.GetElement(By.XPath("//table[@id='table-material']/tbody/tr/td[5]/a")).Text == gradingCompletionColumnvalue))
        {
            return true;
        }
        else
            return false;
    }

    public bool? ListFirstNotesdisplay()
    {
        return Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[2]/a"));
        Thread.Sleep(10000);
    }

    public bool? AddNoteModaldisplay()
    {
        Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        return Driver.existsElement(By.XPath("//div[@id='addNote']/div/div/div/h4"));
    }

    public string NotesTitleText()
    {
        return Driver.GetElement(By.XPath("//table[@id='table-material']/tbody/tr/td[2]/a")).Text;
    }

    public void ClickNotesTitle()
    {
        Driver.clickEleJs(By.XPath("//table[@id='table-material']/tbody/tr/td[2]/a"));
    }

    public bool? NotesTitleUpdated(string v)
    {
        Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[2]/a"));

        if (Driver.GetElement(By.XPath("//table[@id='table-material']/tbody/tr/td[2]/a")).Text != v)
        {
            return true;
        }
        else
            return false;
    }

    public void SelectAddAssignmentAddContentdropdown(string v)
    {
        Driver.clickEleJs(By.XPath("//div[@id='no-content']/div/div/a[2]"));
        Driver.clickEleJs(By.XPath("//div[@id='no-content']/div/div/ul/li/a"));
    }

    public void AddAssignmentAs(string v)
    {
        Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        //Driver.existsElement(By.XPath("//div[@id='edit-assignment-modal']/div/h4"));
        Driver.GetElement(By.Id("title")).Clear();
        Driver.GetElement(By.Id("title")).SendKeys(v);
        Driver.clickEleJs(By.XPath("//div[@id='edit-assignment-modal']/div[3]/button[2]"));
        Driver.existsElement(By.XPath("//div[@id='edit-assignment-modal']/div[3]/button[2]"));
        Driver.clickEleJs(By.XPath("//div[@id='edit-assignment-modal']/div[3]/button[2]"));
    }
    public void UpdateAssignmentAs(string v)
    {
        Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        //Driver.existsElement(By.XPath("//div[@id='edit-assignment-modal']/div/h4"));
        Driver.GetElement(By.Id("title")).Clear();
        Driver.GetElement(By.Id("title")).SendKeys(v);
        Driver.clickEleJs(By.XPath("//div[@id='edit-assignment-modal']/div[3]/button[2]"));

    }


    public string AssignmentTitleText()
    {
        return Driver.GetElement(By.XPath("//table[@id='table-material']/tbody/tr/td[2]/a")).Text;
    }

    public void ClickAssignmentTitle()
    {
        Driver.clickEleJs(By.XPath("//table[@id='table-material']/tbody/tr/td[2]/a"));
    }

    public bool? AvailabletoLearneris(string v)
    {
        
      Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/a"));
        return Driver.GetElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/a")).Text == v;
        //Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr[3]/td[2]/a"));
    }

    public void clickGradingCompletionForScormCourse()
    {
        throw new NotImplementedException();
    }

    public bool? GetGradingCompletionColumnForScormCourse(string v)
    {
        throw new NotImplementedException();
    }

    public bool? isTestDisplayed(string v)
    {
        throw new NotImplementedException();
    }

    public void DeleteContent()
    {
        Driver.clickEleJs(By.XPath("//table[@id='table-material']/tbody/tr/td/input"));
        Driver.clickEleJs(By.XPath("//div[@id='utilityToolbar']/div/div/button/span"));

    }

    public void ClickFile()
    {
        throw new NotImplementedException();
    }

    public bool? isFileOpened()
    {
        throw new NotImplementedException();
    }

    public bool? isGeneralCourseDisplayed(string v)
    {
        throw new NotImplementedException();
    }

    public bool? isScormCourse2004tDisplayed(string v)
    {
        return Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[2]"));
    }

    public void AvailabletoLearner(string v)
    {
        Driver.clickEleJs(By.XPath("//tr[@data-index='0']//a[@class='xeditable xeditable-click'][contains(text(),'')]"));
        Driver.select(By.XPath("//select[@class='form-control input-sm']"), v);

    }

    public void AddContent()
    {
        throw new NotImplementedException();
    }

    public void ClickAddContent()
    {
        Driver.existsElement(By.XPath("//a[contains(text(),'Add Content')]"));
        Driver.clickEleJs(By.XPath("//a[contains(text(),'Add Content')]"));
    }
}


    public class AddNoteModalCommand
    {
        public AddNoteModalCommand()
        {
        }

        public void AddNoteswith(string v)
        {

            Driver.GetElement(By.Id("note_description")).Clear();
            Driver.GetElement(By.Id("note_description")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//div[@id='addNote']/div/div/div[3]/button[2]"));
            Thread.Sleep(3000);
        }

        public bool? isTestDisplayed()
        {
            throw new NotImplementedException();
        }

        public bool? isTestDisplayed(string v)
        {
            throw new NotImplementedException();
        }

        public void DeleteContent()
        {
            throw new NotImplementedException();
        }

        public bool? isGeneralCourseDisplayed(string v)
        {
            throw new NotImplementedException();
        }

        public bool? isScormCourse2004tDisplayed(string v)
        {
            throw new NotImplementedException();
        }

        public void ClickNote()
        {
            throw new NotImplementedException();
        }

        public void ClickFile()
        {
            throw new NotImplementedException();
        }

        public bool? isFileOpened()
        {
            throw new NotImplementedException();
        }

        public void clickGradingCompletionForScormCourse()
        {
            throw new NotImplementedException();
        }

        public bool? GetGradingCompletionColumnForScormCourse(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class EditAssignmentModalCommand
    {
        public bool? IsClosed { get { return Driver.existsElement(By.XPath("//div[@id='edit-assignment-modal']/div/h4")); } }

        public EditAssignmentModalCommand()
        {
        }

        public bool? ItemWeightdisplay()
        {
            return Driver.existsElement(By.Id("weight"));
        }

        public bool? GradingScaledisplay()
        {
            return Driver.existsElement(By.Id("grading-scale"));
        }

        public bool? DueDatedisplay()
        {
            return Driver.existsElement(By.Id("fromDate"));
        }

        public void ItemWeightEditAs(string v)
        {
            Driver.GetElement(By.Id("weight")).SendKeysWithSpace(v);
        }

        public void GradingScaleEditAs(string v)
        {
            Driver.clickEleJs(By.XPath("//div[@id='pnlAssignmentSummary']/div/div[2]/div/select"));
            Driver.Instance.select(By.XPath("//div[@id='pnlAssignmentSummary']/div/div[2]/div/select"), v);
            
        }

        public void DueDateEditAs(string v)
        {
            Driver.GetElement(By.Id("fromDate")).SendKeysWithSpace(v);
        }

        public void ClickSaveButton()
        {
            Driver.clickEleJs(By.XPath("//div[2]/div/div/div[3]/button[2]"));
        }
    }

    public class editGradingOptionsModalCommand
    {
        public editGradingOptionsModalCommand()
        {
        }

        public void setItemWeightandDueDate(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
