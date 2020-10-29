using System;
using System.IO;

namespace Typescript_include_generator {
    internal class Program {
        /// <summary>The main point of entrance</summary>
        /// <param name="args"></param>
        private static void Main(String[] args) {
            //Get starting folder
            Console.WriteLine("Start folder?");
            String Folder = Console.ReadLine();

            //If folder exists get all nescarry folders and files
            if (Directory.Exists(Folder)) {
                var Data = new ProjectTree(Folder);
                Console.WriteLine("generating");
                //Process project data structure
                Process(Data);
            }

            //Done
            Console.WriteLine("done!");
            Console.ReadLine();
        }

        /// <summary>Processes the given project tree and generate the nesscary files</summary>
        /// <param name="Data"></param>
        private static void Process(ProjectTree Data) {
            foreach (Folder Folder in Data.Folders) {
                Process(Folder);
            }
        }

        /// <summary>Processes the given folder</summary>
        /// <param name="folder"></param>
        private static void Process(Folder folder) {
            //Start new include file, overwrite the old one
            var Writer = new StreamWriter(folder.Path + "/include.ts", false);

            //Write header
            Writer.WriteLine("/*\tAuto generated\t*/");

            //Write each include file first
            foreach (Folder sf in folder.SubFolders) {
                var DI = new DirectoryInfo(sf.Path);

                Writer.WriteLine($"export * as {DI.Name.Replace(' ', '_')} from './{DI.Name}/include'");
            }

            //include each file
            foreach (String F in folder.Files) {
                var FI = new FileInfo(F);

                if (FI.Name == "include.ts")
                    continue;

                Writer.WriteLine($"export * from './{FI.Name.Replace(FI.Extension, String.Empty)}'");
            }

            //done!
            Writer.Flush();
            Writer.Close();

            //Now generate the rest
            foreach (Folder sf in folder.SubFolders) {
                Process(sf);
            }
        }
    }
}
