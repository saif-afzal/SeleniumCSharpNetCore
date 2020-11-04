using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class SpacesPage
    {
        public static string CheckTitle
        {
            get
            {
                Thread.Sleep(3000);
                return Driver.Instance.Title;
            }
        }
        public static SpaceTitlePageCommand SpaceTitlePage
        {
            get { return new SpaceTitlePageCommand(); }
        }
        public static TypePublicSpaceCommand TypePublicSpace
        {
            get { return new TypePublicSpaceCommand(); }
        }

        public static string GetSuccessMessage()
        {
            throw new NotImplementedException();
        }
    }

    public class TypePublicSpaceCommand
    {
        public TypePublicSpaceCommand()
        {
        }

        public void ClickSpaceTitle()
        {
            throw new NotImplementedException();
        }
    }

    public class SpaceTitlePageCommand
    {
        public void ClickJoinButton()
        {
            throw new NotImplementedException();
        }

        public void SelectAccessSpace()
        {
            throw new NotImplementedException();
        }
    }
}