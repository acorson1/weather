using System;
using System.IO;

namespace weather_system
{
    class Program
    {
        public class Data
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public double Maxtemp { get; set; }
            public double Mintemp { get; set; }
            public int Airfrost { get; set; }
            public double Rain { get; set; }
            public double Sun { get; set; }

         }
        public static void Report(int type)
        {
            Console.WriteLine("Please select the desired weather station");
            string path = ("C:\\c#-data-files\\" + Console.ReadLine() + ".txt");

            Console.WriteLine("what is the year you want to start from?");
            int fyear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("what is the laster year you want information on?");
            int lyear = Convert.ToInt32(Console.ReadLine());
            


                int fmonth = 2;
            int lmonth = 1;

            if (type == 1)
            {
                fmonth = 1;
                lmonth = 12;
            }

            if (type == 2)
            {
                Console.WriteLine("what is the month of the year you want to start from?");
                fmonth = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("what is the last month you want information on?");
                lmonth = Convert.ToInt32(Console.ReadLine());
            }

            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    line = sr.ReadLine();
                    int year  = Convert.ToInt32(line.Split("\t")[1]);
                    int month = 0;
                
                    if (type == '1')
                    {
                    month = 1;
                }
                else if (type == '2')
                {
                    month = Convert.ToInt32(line.Split("\t")[2]);
                }
                if (year >= fyear && lyear >= year)
                {
                    if (month >= fmonth && lmonth >= month)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
}
        public static void sortingby(int type)
        {
            if (type != 1 && type != 2)
            {
                Console.WriteLine("you have note enterd a valid input");
            }
            else if (type == '1' || type == '2')
            {
                Console.WriteLine("Please select the desired weather station");
                string location = ("C:\\c#-data-files\\" + Console.ReadLine() + ".txt");

                Console.WriteLine("when do you want to start from? (MM/YYYY)");
                string fdate = Console.ReadLine();
                int fmonth = Convert.ToInt32(fdate.Split('/')[0]);
                int fyear = Convert.ToInt32(fdate.Split('/')[1]);

                Console.WriteLine("when do you want the search to end? (MM/YYYY)");
                string ldate = Console.ReadLine();
                int lmonth = Convert.ToInt32(ldate.Split('/')[0]);
                int lyear = Convert.ToInt32(ldate.Split('/')[1]);
                int tvalue = 0;

                Console.WriteLine("what data do you want it sorted by?");
                string value = Console.ReadLine();

                if (value == "max temp")
                {
                   tvalue = 2;
                }
                else if (value == "min temp")
                {
                    tvalue = 3;
                }
                else if (value == "af")
                {
                    tvalue = 4;
                }
                else if (value == "rain")
                {
                    tvalue = 5;
                }
                else if (value == "sun")
                {
                    tvalue = 6;
                }
                Console.WriteLine(tvalue);
            }
        }

        public static void stat(int type)
        {

        }

        public static void dataentry(int type)
        {

        }

        static void Main(string[] args)
        {
            int answer = 6;
            Console.WriteLine("Root Menu");
            Console.WriteLine("Please select the desired the function next.");
            Console.WriteLine("1. weather reports");
            Console.WriteLine("2. sorting");
            Console.WriteLine("3. statistics");
            Console.WriteLine("4. data entry");

            answer = Convert.ToInt32(Console.ReadLine());

            if (0 < answer && answer < 6)
            {
                if (answer == 1)
                {
                    Console.WriteLine("weather report menu" +
                    "1. Annual reports" +
                    "2. report month range");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    Report(menu);
                }
                if (answer == 2)
                {
                    Console.WriteLine("sorting menu");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    sortingby(menu);
                }
                if (answer == 3)
                {
                    Console.WriteLine("statistical menu");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    stat(menu);
                }
                if (answer == 4)
                {
                    Console.WriteLine("data entry menu");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    dataentry(menu);
                }
                if (answer == 0)
                {

                }
                else
                {
                    Console.WriteLine("you have not entered a correct value.");
                }
            }
        }
    }
}
