using System;
using System.IO;

namespace testHepsiBurada
{
    public class RoverInput
    {
        public RoverInput(string[] args)
        {            
            var inputPath = args.Length > 0 ? args[0] : @"Input.txt";

            if (checkInputContent(inputPath))
            {
                this.inputLines = File.ReadAllLines(inputPath);
            }
        }

        public string[] inputLines { get; set; }
        
        private static bool checkInputContent(string inputPath)
        {
            var resultMsg = string.Empty;
            if (File.Exists(inputPath))
            {
                var inputLines = File.ReadAllLines(inputPath);
                if (inputLines.Length > 3)
                {
                    if ((inputLines.Length - 1) % 2 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        resultMsg = "Input file must have 2 line for each rover";
                    }
                }
                else
                {
                    resultMsg = "Input file must have minimum 3 lines";
                }
            }
            else
            {
                resultMsg = "Input file doesn't exist. Path : " + inputPath;
            }

            Console.WriteLine(resultMsg);
            throw new ArgumentException(resultMsg);;
        }
    }
}