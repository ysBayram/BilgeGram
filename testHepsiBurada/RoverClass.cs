using System;

namespace testHepsiBurada
{

    public enum RoverState
    {
        Moving,
        WaitOrders
    }

    public class RoverPosition
    {
        public RoverPosition(int initialXPosition, int initialYPosition, RoverCardinalCompassPoints initialFacingSide)
        {
            this.xPosition = initialXPosition;
            this.yPosition = initialYPosition;
            this.FacingSide = initialFacingSide;
        }
        public int xPosition { get; set; }
        public int yPosition { get; set; }
        public RoverCardinalCompassPoints FacingSide { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.xPosition.ToString(), this.yPosition.ToString(), this.FacingSide.ToString());
        }

    }

    public enum RoverCardinalCompassPoints
    {
        N,
        E,
        S,
        W
    }

    public enum RoverRoute
    {
        L = -1,
        M = 0,
        R = 1
    }

    public class Rover
    {
        public Rover() { }
        public Rover(string roverPosition)
        {
            this.Position = stringToRoverPosition(roverPosition);
        }

        public RoverState State { get; set; }
        public RoverPosition Position { get; set; }

        public void Move(string roverRoute)
        {
            this.State = RoverState.Moving;
            System.Console.WriteLine("Rover State is : {0}", this.State.ToString());

            foreach (var item in roverRoute.ToCharArray())
            {
                System.Console.WriteLine("Rover Position is : {0}", this.Position.ToString());
                var moveRoute = (RoverRoute)Enum.Parse(typeof(RoverRoute), item.ToString());

                switch (moveRoute)
                {
                    case RoverRoute.M:
                        int[] newPositionAdjust = { 0, 0 };
                        switch (this.Position.FacingSide)
                        {
                            case RoverCardinalCompassPoints.E:
                                newPositionAdjust[0] = 1;
                                break;
                            case RoverCardinalCompassPoints.W:
                                newPositionAdjust[0] = -1;
                                break;
                            case RoverCardinalCompassPoints.N:
                                newPositionAdjust[1] = 1;
                                break;
                            case RoverCardinalCompassPoints.S:
                                newPositionAdjust[1] = -1;
                                break;
                        }
                        this.Position.xPosition = this.Position.xPosition + newPositionAdjust[0];
                        this.Position.yPosition = this.Position.yPosition + newPositionAdjust[1];
                        break;
                    case RoverRoute.L:
                        var newSideLeft = this.Position.FacingSide;
                        switch (this.Position.FacingSide)
                        {
                            case RoverCardinalCompassPoints.E:
                                newSideLeft = RoverCardinalCompassPoints.N;
                                break;
                            case RoverCardinalCompassPoints.W:
                                newSideLeft = RoverCardinalCompassPoints.S;
                                break;
                            case RoverCardinalCompassPoints.N:
                                newSideLeft = RoverCardinalCompassPoints.W;
                                break;
                            case RoverCardinalCompassPoints.S:
                                newSideLeft = RoverCardinalCompassPoints.E;
                                break;
                        }
                        this.Position.FacingSide = newSideLeft;
                        break;
                    case RoverRoute.R:
                        var newSideRight = this.Position.FacingSide;
                        switch (this.Position.FacingSide)
                        {
                            case RoverCardinalCompassPoints.E:
                                newSideRight = RoverCardinalCompassPoints.S;
                                break;
                            case RoverCardinalCompassPoints.W:
                                newSideRight = RoverCardinalCompassPoints.N;
                                break;
                            case RoverCardinalCompassPoints.N:
                                newSideRight = RoverCardinalCompassPoints.E;
                                break;
                            case RoverCardinalCompassPoints.S:
                                newSideRight = RoverCardinalCompassPoints.W;
                                break;
                        }
                        this.Position.FacingSide = newSideRight;
                        break;
                }

                System.Console.WriteLine("Rover Position is : {0}", this.Position.ToString());
            }

            this.State = RoverState.WaitOrders;
            System.Console.WriteLine("Rover State is : {0}", this.State.ToString());

        }

        private RoverPosition stringToRoverPosition(string roverPosition)
        {
            var rvcoor = roverPosition.Split(" ");

            var rvInitialSide = (RoverCardinalCompassPoints)Enum.Parse(typeof(RoverCardinalCompassPoints), rvcoor[2]);

            var initialXPosition = Convert.ToInt32(rvcoor[0]);
            var initialYPosition = Convert.ToInt32(rvcoor[1]);
            return new RoverPosition(initialXPosition, initialYPosition, rvInitialSide);
        }        
    }
}