using System;
using System.Collections.Generic;
using System.Text;

namespace TransforMe.Interface
{
    public interface IMessage
    {
        int Id { get; set; }
        string Text { get; set; }
        DateTime PostedAt { get; set; }
        int UserId { get; set; }
    }
}
