using System;

namespace testHepsiBurada
{
    class Program
    {
        static void Main(string[] args)
        {
            RoverInput ri = new RoverInput(args);

            var maxPosition = ri.inputLines[0];

            var roversCount = (ri.inputLines.Length - 1) / 2;

            for (int i = 1; i <= roversCount; i++)
            {
                var _roverPosition = ri.inputLines[(int)(Math.Pow(2, i)) - 1];
                var _roverRoute = ri.inputLines[(int)(Math.Pow(2, i))];

                Rover rv = new Rover(_roverPosition);
                rv.Move(_roverRoute);

                Console.WriteLine(rv.Position.ToString());
            }
        }
    }
}
