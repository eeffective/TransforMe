using System;
using System.Collections.Generic;
using System.Text;

namespace TransforMe.Interface
{
    public interface IProgression
    {
        int Id { get; set; }
        byte[] ProgressPicture { get; set; }
        decimal Bodyweight { get; set; }
        DateTime Date { get; set; }
        int UserId { get; set; }
    }
}
