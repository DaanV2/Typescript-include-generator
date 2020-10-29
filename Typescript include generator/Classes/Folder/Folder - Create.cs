using System;
using System.IO;

namespace Typescript_include_generator {
    ///DOLATER <summary>add description for class: Folder</summary>
    public sealed partial class Folder {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static Folder Create(String dir) {
            Console.WriteLine("checking:\t" + dir);
            if (Directory.Exists(dir)) {
                var Out = new Folder(dir);

                String[] Folders = Directory.GetDirectories(dir);

                foreach (String F in Folders) {
                    Folder Item = Create(F);

                    if (Item != null) {
                        Out.SubFolders.Add(Item);
                    }
                }

                if (Out.Files.Count > 0 || Out.SubFolders.Count > 0) {
                    return Out;
                }
            }

            return null;
        }
    }
}
