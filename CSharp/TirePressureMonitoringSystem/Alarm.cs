namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        public const double LowPressureThreshold = 17;
        public const double HighPressureThreshold = 21;

        ISensor _sensor;

        bool _alarmOn = false;
        private long _alarmCount = 0;

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        public void CheckAndSetAlarm()
        {
            Check(true);
        }

        public void CheckWithNoAlarm()
        {
            Check(false);
        }

        private void Check(bool setAlarm)
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                if (setAlarm){ _alarmOn = true;}
                _alarmCount += 1;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

    }
}
