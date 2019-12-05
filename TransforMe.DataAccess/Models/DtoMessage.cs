using System;
using System.Collections.Generic;
using System.Text;
using TransforMe.Interface;

namespace TransforMe.DataAccess.Models
{
    public class DtoMessage : IMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PostedAt { get; set; }
        public int UserId { get; set; }
    }
}
