using System;
using System.Collections.Generic;
using System.Text;
using TransforMe.Interface;

namespace TransforMe.BusinessLogic.Models
{
    public class Activity : IActivity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
