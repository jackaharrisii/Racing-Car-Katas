using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {

        public AlarmTest()
        {
            ISensor stubSensor = new StubSensor();
        }
        
        [Fact]
        public void Alarm_IsOff_ByDefault()
        {
            //Arrange
            //Act
            Alarm alarm = new Alarm(new Sensor());
            //Assert
            Assert.False(alarm.AlarmOn);
        }

        [Fact]
        public void Alarm_GoesOn_WhenPressureValue_LessThanLowPressureThreshold()
        {
            //Arrange
            Alarm alarm = new Alarm(new StubSensor{NextPressurePsiValue = Alarm.LowPressureThreshold - 1});
            //Act
            alarm.Check();
            //Assert
            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Alarm_GoesOn_WhenPressureValue_HigherThanHighPressureThreshold()
        {
            //Arrange
            Alarm alarm = new Alarm(new StubSensor{NextPressurePsiValue = Alarm.HighPressureThreshold + 1});
            //Act
            alarm.Check();
            //Assert
            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Alarm_StaysOff_WhenPressureValue_BetweenPressureThresholds()
        {
            //Arrange
            Alarm alarm = new Alarm(new StubSensor{NextPressurePsiValue = Alarm.HighPressureThreshold - 1});
            //Act
            alarm.Check();
            //Assert
            Assert.False(alarm.AlarmOn);
        }
    }

    public class StubSensor : ISensor
    {
        
        public double PopNextPressurePsiValue()
        {
            return NextPressurePsiValue;
        }

        public double NextPressurePsiValue { get; set; }
    }
}