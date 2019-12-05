using System;
using System.Collections.Generic;
using System.Text;
using TransforMe.Interface;

namespace TransforMe.DataAccess.Models
{
    public class DtoProgression : IProgression
    {
        public int Id { get; set; }
        public byte[] ProgressPicture { get; set; }
        public decimal Bodyweight { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
