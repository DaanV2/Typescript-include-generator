using System;
using System.Collections.Generic;

namespace Typescript_include_generator {
    ///DOLATER <summary>add description for class: ProjectTree</summary>
    public sealed partial class ProjectTree {
        /// <summary>Creates a new instance of <see cref="ProjectTree"/></summary>
        public ProjectTree(String Directory) {
            this.Folders = new List<Folder>();

            var Item = Folder.Create(Directory);

            if (Item != null) {
                this.Folders.Add(Item);
            }
        }
    }
}
