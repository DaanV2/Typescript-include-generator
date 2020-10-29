using System;
using System.Collections.Generic;
using System.IO;

namespace Typescript_include_generator {
    ///DOLATER <summary>add description for class: Folder</summary>
    public sealed partial class Folder {
        /// <summary>Creates a new instance of <see cref="Folder"/></summary>
        public Folder(String Folder) {
            this.Path = Folder;
            this.SubFolders = new List<Folder>();
            this.Files = new List<String>(Directory.GetFiles(Folder, "*.ts"));
        }
    }
}
