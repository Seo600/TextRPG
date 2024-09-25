using System;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Net;

namespace TextRPG
{
    internal class Program
    {
        public static Character character = new Character();
        public static Village village = new Village();
        static void Main(string[] args)
        {
            FirstScreen screen = new();
            screen.InputName();

        }

    }

}

