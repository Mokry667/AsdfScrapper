using System;
using System.Collections.Generic;

namespace WebRequestTest
{
    public class Message
    {
        public string Html { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
        public string OriginalInbox { get; set; }
        public string Inbox { get; set; }
        public DateTime Received { get; set; }
        public string Body { get; set; }
        public string Id { get; set; }
        public List<From> From { get; set; }
    }
}
