﻿using System;

namespace Twileloop.SessionGuard.Models
{
    public class FileDetails<T>
    {
        public string FileName { get; set; }
        public string FileLocation { get; set; }
        public string Extension { get; set; }
        public long FileSizeBytes { get; set; }
        public T Data { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
