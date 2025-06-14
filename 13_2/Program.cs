namespace _13_2
{
    public delegate void MyDelegate(string time, string device, string status);
    internal class Program
    {
        static void Main()
        {
            SmartHomeSystem myHome = new SmartHomeSystem();

            myHome.MyDelegate += (string time, string device, string status) =>
            {
                Console.WriteLine($"{time} {device} {status}");
            };

            try { myHome.SetTemperature(35); }
            catch (Exception ex) { Console.WriteLine($"Выявлена ошибка: {ex.Message}\n"); }
            myHome.LockDoor();
            myHome.TurnOnLight();

            myHome.TurnOffLight();
            myHome.UnlockDoor();
            myHome.LockDoor();
            try { myHome.SetTemperature(-300); }
            catch (Exception ex) { Console.WriteLine($"Выявлена ошибка: {ex.Message}\n"); }
            try { myHome.SetTemperature(23); }
            catch (Exception ex) { Console.WriteLine($"Выявлена ошибка: {ex.Message}\n"); }
            //Console.WriteLine($"{myHome.sd1.ToString()}");
            //Console.WriteLine($"{myHome.sd2.ToString()}");
            //Console.WriteLine($"{myHome.sd3.ToString()}");

            Console.WriteLine("Press any key...");
            Console.ReadKey();

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
    public class SmartHomeSystem
    {
        public event MyDelegate MyDelegate;
        public SmartDevice sd1 = new SmartDevice("Дверь");
        public void LockDoor()
        {
            sd1.deviceStatus = "Закрыта";
            MyDelegate?.Invoke(DateTime.Now.ToString("HH:mm:ss"), sd1.deviceName, sd1.deviceStatus);
        }
        public void UnlockDoor()
        {
            sd1.deviceStatus = "Открыта";
            MyDelegate?.Invoke(DateTime.Now.ToString("HH:mm:ss"), sd1.deviceName, sd1.deviceStatus);
        }

        public SmartDevice sd2 = new SmartDevice("Термостат");
        public void SetTemperature(int temp)
        {
            if (temp < -273)
            {
                throw new Exception("Какая-то сказочная температура");
            }
            if (temp > 9000)
            {
                throw new Exception("Какая-то сказочная температура");
            }

            sd2.deviceStatus = $"Установлен на {temp} градусов";
            MyDelegate?.Invoke(DateTime.Now.ToString("HH:mm:ss"), sd2.deviceName, sd2.deviceStatus);
        }

        public SmartDevice sd3 = new SmartDevice("Свет");
        public void TurnOnLight()
        {
            sd3.deviceStatus = "Включен";
            MyDelegate?.Invoke(DateTime.Now.ToString("HH:mm:ss"), sd3.deviceName, sd3.deviceStatus);
        }
        public void TurnOffLight()
        {
            sd3.deviceStatus = "Выключен";
            MyDelegate?.Invoke(DateTime.Now.ToString("HH:mm:ss"), sd3.deviceName, sd3.deviceStatus);
        }

    }

}
