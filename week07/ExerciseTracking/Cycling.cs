using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double speed; // in mph

        public Cycling(DateTime date, int minutes, double speed)
            : base(date, minutes)
        {
            this.speed = speed;
        }

        public override double GetDistance()
        {
            return (speed * Minutes) / 60;
        }

        public override double GetSpeed()
        {
            return speed;
        }

        public override double GetPace()
        {
            return 60 / speed;
        }

        public override string GetSummary()
        {
            return $"{Date.ToString("dd MMM yyyy")} Cycling ({Minutes} min) - " +
                   $"Distance: {GetDistance():F1} miles, " +
                   $"Speed: {GetSpeed():F1} mph, " +
                   $"Pace: {GetPace():F1} min per mile";
        }
    }
}