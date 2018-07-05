using System.Collections.Generic;

namespace GpioManager.Devices.Gpio.Abstractions
{
    public interface IGpioController
    {
        IGpioPin OpenPin(int pinNumber);

        void ClosePin(int pinNumber);

        IDictionary<string, string> Pins { get; }
    }
}