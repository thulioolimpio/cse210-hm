using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime date;
        private int minutes;

        protected Activity(DateTime date, int minutes)
        {
            this.date = date;
            this.minutes = minutes;
        }

        public DateTime Date => date;
        public int Minutes => minutes;

        public abstract double GetDistance(); // in miles or km
        public abstract double GetSpeed();    // in mph or kph
        public abstract double GetPace();     // in min per mile or min per km

        public virtual string GetSummary()
        {
            return $"{Date.ToString("dd MMM yyyy")} {GetType().Name} ({Minutes} min) - " +
                   $"Distance: {GetDistance():F1} miles, " +
                   $"Speed: {GetSpeed():F1} mph, " +
                   $"Pace: {GetPace():F1} min per mile";
        }
    }
}