using System;
using System.Collections.Generic;
using System.Text;
using TransforMe.Interface;

namespace TransforMe.DataAccess.Models
{
    public class DtoActivity : IActivity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
