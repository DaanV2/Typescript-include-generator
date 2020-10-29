using System;
using System.Collections.Generic;

namespace Typescript_include_generator {
    public sealed partial class Folder {
        /// <summary>
        /// 
        /// </summary>
        public String Path { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Folder> SubFolders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<String> Files { get; set; }
    }
}
