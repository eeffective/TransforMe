using System;
using System.Collections.Generic;
using System.Text;
using TransforMe.Interface;

namespace TransforMe.BusinessLogic.Models
{
    public class Message : IMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PostedAt { get; set; }
        public int UserId { get; set; }
    }
}
