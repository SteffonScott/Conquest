using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conquest.Worlds
{
    public static class Helper
    {
        public static int getRandom(double max, double min)
        {
            lock (syncLock)
            {
                // synchronize
                int myrandom = getrandom.Next((int)min, (int)max);
                return myrandom;
            }

            // System.Random RandNum = new System.Random();   
            // int randomreturn = RandNum.Next((int)min, (int)max);

            // return (int)randomreturn;
        }
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();

        public static int GetRandom(int max, int min)
        {
            lock (syncLock)
            {
                // synchronize
                int myrandom = getrandom.Next(min, max);
                return myrandom;
            }
        }
        public static T NumToEnum<T>(int number)
        {
            return (T)Enum.ToObject(typeof(T), number);
        }
    }
}