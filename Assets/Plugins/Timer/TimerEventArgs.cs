namespace EnotoButebrodo
{
    public class TimerEventArgs
    {
        public float CurrentTime { get; private set; }
        public float MaxTime { get; private set; }

        public float Percent => CurrentTime / MaxTime;

        public TimerEventArgs(float currentTime, float maxTime)
        {
            CurrentTime = currentTime;
            MaxTime = maxTime;
        }
    }
}