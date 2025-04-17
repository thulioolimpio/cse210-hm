namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int laps;
        private const double LapLengthMeters = 50;
        private const double MetersToMiles = 0.000621371;

        public Swimming(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            this.laps = laps;
        }

        public override double GetDistance() => laps * LapLengthMeters * MetersToMiles;
        public override double GetSpeed() => (GetDistance() / Minutes) * 60;
        public override double GetPace() => Minutes / GetDistance();

        public override string GetSummary()
        {
            return $"{Date.ToString("dd MMM yyyy")} {GetType().Name} ({Minutes} min) - " +
                   $"Distance: {GetDistance():F1} miles, " +
                   $"Speed: {GetSpeed():F1} mph, " +
                   $"Pace: {GetPace():F1} min per mile, " +
                   $"Laps: {laps}";
        }
    }
}