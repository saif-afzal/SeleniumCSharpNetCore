using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium2.Meridian
{
     public static class Meridian_Common
        {
            public static string MeridianTestSite { get; set; }
        public static string MeridianFileDownload { get; set; }
        public static string MeridianTestbrowser { get; set; }
        public static string SmokeTestSite { get; set; }
        public static string globalnum = string.Format("{0:ddhhssmmss}", DateTime.Now);
        public static bool islog = false;
        public static bool checklocal = false;
        public static string CurrentTestName = string.Empty;
        public static string parentwdw = string.Empty;
        public static string childwdw1 = string.Empty;
        public static string childwdw2 = string.Empty;
        public static string childwdw3 = string.Empty;
        public static string UserId = string.Empty;
        public static string NewUserId = string.Empty;
            public static bool issmoketest = false;
        public static bool isadminlogin = false;
        public static string text12;
        public static string text23;
        public static string RecentContentText;
        public static string SearchResultTitle;
        public static string Runreportpage_SectionActivity = string.Empty;
        public static string Runreportpage_Organization;
        public static string Runreportpage_Layout;
        public static string waitlist;
        public static string cancelwaitlist;
        public static string ContentPageCourse;
        public static string CertificateCourseTitle;
        public static string CourseComplitionDate;
        public static string CandidateName;
        public static string CompletionCode;
        public static string Runreportpage_DateFrom;
        public static string Runreportpage_DateTo;
        public static string Runreportpage_CapacityOperator;
        public static string Runreportpage_CapacityValue;
        public static string Runreportpage_EnrollmentOperator;
        public static string Runreportpage_EnrollmentValue;
        public static string UserTimeZone=string.Empty;
        public static string resultpath;
        public static string Emailid= string.Empty;
    }

}

