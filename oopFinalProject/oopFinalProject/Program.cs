using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = ReadFile("values.csv");
            List<Instrument> instruments = new List<Instrument>();

            instruments = GetInstruments(file);
            PrintInstruments(instruments);
            Console.ReadKey();
        }

        /// <summary>
        /// Read from file and return lines
        /// </summary>
        /// <param name="filename">Path to file</param>
        /// <returns>String array of file lines</returns>
        static string[] ReadFile(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            return lines;
        }

        /// <summary>
        /// Get instruments from file
        /// </summary>
        /// <param name="file">File Lines</param>
        /// <returns>List of instruments</returns>
        static List<Instrument> GetInstruments(string[] file)
        {
            Dictionary<int, List<string>> file_items = new Dictionary<int, List<string>>();
            List<Instrument> instruments = new List<Instrument>();

            // Get items from file
            for (int i = 0; i < file.Length; i++) file_items.Add(i, GetItems(file[i]));

            // Create instrument object
            for (int i = 1; i < file.Length; i++)
            {
                Instrument p;
                string companyname = "", instrumentname = "", instrumenttype = "", countrybuild = "";
                int builddate = 0;

                for (int j = 0; j < file_items[0].Count(); j++)
                {
                    // Check what value we are on
                    switch (file_items[0][j].ToLower())
                    {
                        case "companyname":
                            companyname = file_items[i][j];
                            break;
                        case "instrumentname":
                            instrumentname = file_items[i][j];
                            break;
                        case "instrumenttype":
                            instrumenttype = file_items[i][j];
                            break;
                        case "countrybuild":
                            countrybuild = file_items[i][j];
                            break;
                        case "builddate":
                            builddate = int.Parse(file_items[i][j]);
                            break;
                        default:
                            //Console.WriteLine($"Header '{file_items[0][j]}' is not a valid header");
                            break;
                    }
                }

                p = new Instrument(companyname, instrumentname, instrumenttype, countrybuild, builddate);
                instruments.Add(p);

            }

            // return new instance of instruments
            return new List<Instrument>(instruments);
        }

        /// <summary>
        /// Get items from line
        /// </summary>
        /// <param name="line">Line</param>
        /// <returns>List of items</returns>
        static List<string> GetItems(string line)
        {
            string current_word = "";
            List<string> items = new List<string>();


            // split line
            foreach (char c in line)
            {
                if (c == ',')
                {
                    if (current_word != "")
                    {
                        items.Add(current_word);
                        current_word = "";
                    }

                }
                else
                {
                    current_word += c.ToString();
                }
            }


            // add left over item if it exists
            if (current_word != "") items.Add(current_word);

            // return new instance of items list
            return new List<string>(items);
        }

        /// <summary>
        /// Print information about every instrument
        /// </summary>
        /// <param name="instruments">list of instruments</param>
        static void PrintInstruments(List<Instrument> instruments)
        {
            foreach (Instrument p in instruments)
            {
                Console.WriteLine($"I own a {p.CompanyName} {p.InstrumentName} which is a {p.InstrumentType} that was designed and build in {p.CountryBuild} in {p.BuildDate.ToString()}.");
            }

        }
    }
}
