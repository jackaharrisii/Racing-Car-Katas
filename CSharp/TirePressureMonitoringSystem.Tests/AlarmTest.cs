using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {

        public AlarmTest()
        {
            ISensor fakeSensor = new FakeSensor();
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
            Alarm alarm = new Alarm(new FakeSensor{NextPressurePsiValue = Alarm.LowPressureThreshold - 1});
            //Act
            alarm.CheckAndSetAlarm();
            //Assert
            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Alarm_GoesOn_WhenPressureValue_HigherThanHighPressureThreshold()
        {
            //Arrange
            Alarm alarm = new Alarm(new FakeSensor{NextPressurePsiValue = Alarm.HighPressureThreshold + 1});
            //Act
            alarm.CheckAndSetAlarm();
            //Assert
            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Alarm_StaysOff_WhenPressureValue_BetweenPressureThresholds()
        {
            //Arrange
            Alarm alarm = new Alarm(new FakeSensor{NextPressurePsiValue = Alarm.HighPressureThreshold - 1});
            //Act
            alarm.CheckAndSetAlarm();
            //Assert
            Assert.False(alarm.AlarmOn);
        }
        
        [Fact]
        public void AlarmNotSet_WhenFlagFalse_ForLowPressure()
        {
            //Arrange
            Alarm alarm = new Alarm(new FakeSensor{NextPressurePsiValue = Alarm.LowPressureThreshold - 1});
            //Act
            alarm.CheckWithNoAlarm();
            //Assert
            Assert.False(alarm.AlarmOn);
        }
        
        [Fact]
        public void AlarmSet_WhenFlagTrue_ForLowPressure()
        {
            //Arrange
            Alarm alarm = new Alarm(new FakeSensor{NextPressurePsiValue = Alarm.LowPressureThreshold - 1});
            //Act
            alarm.CheckAndSetAlarm();
            //Assert
            Assert.True(alarm.AlarmOn);
        }
        
        [Fact]
        public void AlarmNotSet_WhenFlagTrue_ForGoodPressure()
        {
            //Arrange
            Alarm alarm = new Alarm(new FakeSensor{NextPressurePsiValue = Alarm.LowPressureThreshold + 1});
            //Act
            alarm.CheckAndSetAlarm();
            //Assert
            Assert.False(alarm.AlarmOn);
        }
        
    }

    public class FakeSensor : ISensor
    {
        
        public double PopNextPressurePsiValue()
        {
            return NextPressurePsiValue;
        }

        public double NextPressurePsiValue { get; set; }
    }
}