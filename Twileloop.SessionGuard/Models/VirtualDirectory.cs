using System;
using System.Collections.Generic;

namespace Twileloop.SessionGuard.Models
{
    public class VirtualDirectory
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public List<VirtualFile> Files { get; set; }
        public List<VirtualDirectory> Directories { get; set; }
        public VirtualDirectory ParentDirectory { get; set; }
    }
}
