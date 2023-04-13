
using System.Collections.Generic;

namespace EtwLogin.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Attachments { get; internal set; }
    }
}
