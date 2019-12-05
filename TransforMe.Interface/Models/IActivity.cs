using System;
using System.Collections.Generic;
using System.Text;

namespace TransforMe.Interface
{
    public interface IActivity
    {
        int Id { get; set; }
        string Description { get; set; }
        DateTime Date { get; set; }
        int UserId { get; set; }
    }
}
