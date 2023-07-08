using System;

namespace Twileloop.SessionGuard.Models
{
    public class VirtualFile
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public long Size { get; set; }
        public byte[] Content { get; set; }
        public VirtualDirectory ParentDirectory { get; set; }
    }
}
