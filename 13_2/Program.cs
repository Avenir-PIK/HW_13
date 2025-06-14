using System.Globalization;
using System.Security.AccessControl;

namespace _13_2
{
    internal class Program
    {
        static void Main()
        {

        }
    }


    public class SmartDevice
    {
        public string deviceName { get; }
        public string deviceStatus { get; set; } = "Статус не инициализирован";
        public SmartDevice(string deviceName)
        {
            this.deviceName = deviceName;
        }
        public override string ToString()
        {
            return (deviceName + " : " + deviceStatus);
        }
    }
    internal class SmartHome
    {

        SmartDevice sd1 = new SmartDevice("Дверь");
        void LockDoor() { sd1.deviceStatus = "Закрыта"; }
        void UnlockDoor() { sd1.deviceStatus = "Открыта"; }

        SmartDevice sd2 = new SmartDevice("Термостат");
        void SetTemperature(int temperature) { sd2.deviceStatus = $"Установлено {temperature} градусов"; }

        SmartDevice sd3 = new SmartDevice("Свет");
        void TurnOnLight() { sd3.deviceStatus = "Включен"; }
        void TurnOffLight() { sd3.deviceStatus = "Выключен"; }

    }

}
