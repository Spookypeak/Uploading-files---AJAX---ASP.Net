using System;

namespace UploadingFiles_AJAX_ASP.Net
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public string Extension { get; set; }
        public DateTime Date { get; set; }
    }
}