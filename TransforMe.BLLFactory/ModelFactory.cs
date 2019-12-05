using System;
using System.Collections.Generic;
using System.Text;
using TransforMe.BusinessLogic.Models;
using TransforMe.Interface;

namespace TransforMe.BLLFactory
{
    public static class ModelFactory
    {
        public static IUser CreateUser() => new User();
        public static IMessage CreateMessage() => new Message();
        public static IProgression CreateProgression() => new Progression();
        public static IActivity CreateActivity() => new Activity();
    }
}
