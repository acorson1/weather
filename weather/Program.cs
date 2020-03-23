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
                    if (fyear == year && month >= fmonth)
                    {
                        Console.WriteLine(line);
                    }
                    else if (year > fyear && lyear > year)
                    {
                        if (month == fmonth)
                        {
                        Console.WriteLine(line);
                        }
                    }
                    else if (year == lyear && month <= lmonth)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }

        public static void Sortingby(int type)
        {
            int tvalue = 0;
            if (type != 1 && type != 2)
            {
                Console.WriteLine("you have note enterd a valid input");
            }
            else if (type == '1' || type == '2')
            {
                Console.WriteLine("Please select the desired weather station");
                string path = ("C:\\c#-data-files\\" + Console.ReadLine() + ".txt");

                Console.WriteLine("when do you want to start from? (MM/YYYY)");
                string fdate = Console.ReadLine();
                int fmonth = Convert.ToInt32(fdate.Split('/')[0]);
                int fyear = Convert.ToInt32(fdate.Split('/')[1]);

                Console.WriteLine("when do you want the search to end? (MM/YYYY)");
                string ldate = Console.ReadLine();
                int lmonth = Convert.ToInt32(ldate.Split('/')[0]);
                int lyear = Convert.ToInt32(ldate.Split('/')[1]);
                

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
                int i = 0;
                using (StreamReader sr = new StreamReader(path))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        i++;
                        line = sr.ReadLine();
                        int year = Convert.ToInt32(line.Split("\t")[1]);
                        int month = Convert.ToInt32(line.Split("\t")[2]);
                    }
                }
            }
        }

        public static void Stat(int type)
        {
            int tvalue = 0;
            if (type != 1 && type != 2)
            {
                Console.WriteLine("you have note enterd a valid input");
            }
            else if (type == '1' || type == '2')
            {
                Console.WriteLine("Please select the desired weather station");
                string path = ("C:\\c#-data-files\\" + Console.ReadLine() + ".txt");

                Console.WriteLine("when do you want to start from? (MM/YYYY)");
                string fdate = Console.ReadLine();
                int fmonth = Convert.ToInt32(fdate.Split('/')[0]);
                int fyear = Convert.ToInt32(fdate.Split('/')[1]);

                Console.WriteLine("when do you want the search to end? (MM/YYYY)");
                string ldate = Console.ReadLine();
                int lmonth = Convert.ToInt32(ldate.Split('/')[0]);
                int lyear = Convert.ToInt32(ldate.Split('/')[1]);
                

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
                int i = 0;
                int total = 0;
                int current = 0;
                int wrong = 0;
                using (StreamReader sr = new StreamReader(path))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        i++;
                        line = sr.ReadLine();
                        int year = Convert.ToInt32(line.Split("\t")[1]);
                        int month = Convert.ToInt32(line.Split("\t")[2]);
                        if (line.Split("\t")[tvalue] != "--" )
                        {
                            current = Convert.ToInt32(line.Split("\t")[tvalue]);
                        }
                        else
                        {
                            current = 0;
                            wrong++;
                        }
                        if (fyear == year && month >= fmonth)
                        {
                            total = current + total;
                        }
                        else if (year > fyear && lyear > year)
                        {
                            if (month == fmonth)
                            {
                                total = current + total;
                            }
                        }
                        else if (year == lyear && month <= lmonth)
                        {
                            total = current + total;
                        }
                        if (type == 1)
                        {
                            int average = total / (i - wrong);
                            Console.WriteLine("the average " + value + " between" + fmonth + " and " + lmonth + " is " + average);
                        }

                        else if (type == 2)
                        {
                            Console.WriteLine("the total " + value + " between" + fmonth + " and " + lmonth + " is " + total);
                        }
                    }
                }

            }
        }

        public static void Dataentry()
        {
            char answer = 'y';
            while (answer == 'y')
            {
                //1.station
                Console.WriteLine("what station do you want to enter the data for?");
                string path = ("C:\\c#-data-files\\" + Console.ReadLine() + ".txt");

                string year = "2020";
                string month = "01";
                string maxtemp = "100.0";
                string mintemp = "0.1";
                string AF = "50";
                string sun = "1";

                //2.information
                while (Convert.ToInt32(year) >= 1800 && Convert.ToInt32(year) <= 2025)
                {
                    Console.WriteLine("year");
                    year = Console.ReadLine();
                }

                while (Convert.ToInt32(month) >= 1 && Convert.ToInt32(month) <= 12)
                {
                    Console.WriteLine("month");
                    month = Console.ReadLine();
                }

                while (Convert.ToDouble(maxtemp) >= -1000 && Convert.ToDouble(maxtemp) <= 1000 || maxtemp == "--")
                {
                    Console.WriteLine("max temp");
                    maxtemp = Console.ReadLine();
                }

                while (Convert.ToDouble(mintemp) >= -1000 && Convert.ToDouble(mintemp) <= Convert.ToDouble(maxtemp) || mintemp == "--")
                {
                    Console.WriteLine("min temp");
                    mintemp = Console.ReadLine();
                }

                while (Convert.ToDouble(AF) >= 0 && Convert.ToDouble(AF) <= 31 || AF == "--")
                {
                    Console.WriteLine("AF");
                    AF = Console.ReadLine();
                }
                

                while (Convert.ToInt32(sun) >= 0 && Convert.ToInt32(sun) <= 31 || sun == "--")
                {
                    Console.WriteLine("sun");
                    sun = Console.ReadLine();
                }
                

                //verify

                using (StreamWriter sw = File.AppendText(path))
				{
                    sw.WriteLine(year + "\t" + month + "\t" + maxtemp + "\t" + mintemp + "\t" + AF + "\t" + sun);
				}
                //append data file
                Console.WriteLine("is that all? (y/n)");
                answer = Convert.ToChar(Console.ReadLine());

            }
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
                    Console.WriteLine("weather report menu");
                    Console.WriteLine("1. Annual reports");
                    Console.WriteLine("2. report month range");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    Report(menu);
                }
                if (answer == 2)
                {
                    Console.WriteLine("sorting menu");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    Sortingby(menu);
                }
                if (answer == 3)
                {
                    Console.WriteLine("statistical menu");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    Stat(menu);
                }
                if (answer == 4)
                {
                    Console.WriteLine("data entry menu");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    Dataentry();
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
