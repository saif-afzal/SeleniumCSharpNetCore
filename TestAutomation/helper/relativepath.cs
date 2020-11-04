using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;

namespace relativepath
{

    class RelativeDirectory
    {

        private DirectoryInfo dirInfo;


        public RelativeDirectory()
        {
            dirInfo = new DirectoryInfo(Environment.CurrentDirectory);
        }



        public string Up(int NumLevels)
        {
            //DirectoryInfo TempDir = null;

            //for (int i = 0; i < NumLevels; i++)
            //{
            //    TempDir = dirInfo.Parent;

            //    if (TempDir != null)
            //    {
            //        dirInfo = TempDir;
            //    }
            //}
           // string path = TempDir.FullName.ToString();
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); ;
            path = Path.GetFullPath(Path.Combine(path, @"..\..\"));
            return path;
           // return path;
        }

    }


}
