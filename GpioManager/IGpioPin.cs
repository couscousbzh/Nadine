using GpioManager.Devices.Gpio.Core;
using System;

namespace GpioManager.Devices.Gpio.Abstractions
{
    public interface IGpioPin : IDisposable
    {
        void Write(GpioPinValue pinValue);

        GpioPinValue Read();

        void SetDriveMode(GpioPinDriveMode driveMode);
    }
}