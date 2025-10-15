using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week08_Git_Multiple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LightBulb lightBulb = new LightBulb();
            lightBulb.TurnOn();
            lightBulb.TurnOff();
            Console.WriteLine(lightBulb.isOn);

            PortableFan fan = new PortableFan();
            fan.TurnOn();
            fan.TurnOn();
            fan.TurnOff();
            Console.WriteLine(fan.isOn);



            List<ISwitchControl> smarthome = new List<ISwitchControl>();

            // เพิ่ม AirConditioner และ lightBulb เข้าไปใน List (ใช้ Reference เป็น ISwitchControl)
            smarthome.Add(lightBulb);
            smarthome.Add(fan);

            Console.WriteLine("--- 1.  ISwitchControl (On/Off) ---");

            foreach (var device in smarthome)
            {
                // สามารถเรียกใช้ TurnOn ได้กับทุก Object ใน List
                device.TurnOn();
            }

            Console.WriteLine("\n--- Turn off all ---");
            foreach (var device in smarthome)
            {
                device.TurnOff();
            }

            Console.WriteLine("\n======================================================\n");
            Fridge fridge = new Fridge();
            fridge.SetTemperature(8);
            while (fridge.CurrentTemperature != fridge.TargetTemperature)
            {
                fridge.GetCurrentTemperature();
            }
            Airconditioner air = new Airconditioner(-5);
            air.TurnOn();
            //air.TurnOff();
            air.SetTemperature(20);
            while (air.CurrentTemperature != air.TargetTemperature)
            {
                air.GetCurrentTemperature();
            }
            smarthome.Add(air);
            Console.WriteLine("\n--- Turn off all ---");
            foreach (var device in smarthome)
            {
                device.TurnOff();
            }
            List<ITemperatureControl> temperatureControls = new List<ITemperatureControl>();
             
            air.SetTemperature(5);
            fridge.SetTemperature(1);
            temperatureControls.Add(air);
            temperatureControls.Add(fridge);
            foreach (var device in temperatureControls)

            {
                while(device.CurrentTemperature != device.TargetTemperature)
                {
                    device.GetCurrentTemperature();
                }
                   
            }
            ClothesDryer dryer = new ClothesDryer();
            smarthome.Add(dryer);

            WaterHeater waterHeater = new WaterHeater();
            waterHeater.SetTemperature(75);
            while (waterHeater.CurrentTemperature != waterHeater.TargetTemperature)
            {
                waterHeater.GetCurrentTemperature();
            }
            Console.WriteLine("Water Heater reached target temperature.");

            temperatureControls.Add(dryer);


        }
    }
}
