using System;
using System.Collections.Generic;
using System.Text;
using TransforMe.Interface;

namespace TransforMe.BusinessLogic.Models
{
    public class Progression : IProgression
    {
        public int Id { get; set; }
        public byte[] ProgressPicture { get; set; }
        public decimal Bodyweight { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
