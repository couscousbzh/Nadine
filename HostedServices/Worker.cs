using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using GpioManager.Devices.Gpio.Core;
using GpioManager.Devices.Gpio.Abstractions;
using GpioManager.Devices.Gpio;

using Microsoft.AspNetCore.SignalR.Client;

namespace Nadine
{
    public class GpioWorker
    {
        private IGpioController gpioController;
        private bool DeviceReady = false;
        private IGpioPin pin17, pin22;

        private int antiRebond = 20;//ms
        private  DateTime dt1;
        private int stateChange;
        private string oldStatusPin17;

        HubConnection connection;
        //bool connectionStarted = false;

        int counter = 0;

        public GpioWorker()
        {   
            Init();            
        }

        public async void Init()
        {
            InitGpio();

            await Task.Delay(10000); //Wait 10 s that the server starts

            await InitHub();       
        }

        public void InitGpio()
        {
            try
            {
                gpioController = GpioController.Instance;

                //Set Direction of pins (Input or Output)
                
                pin17 = gpioController.OpenPin(17);            
                pin17.SetDriveMode(GpioPinDriveMode.Input);

                pin22 = gpioController.OpenPin(22);          
                pin22.SetDriveMode(GpioPinDriveMode.Input);

                //Init value
                dt1 = DateTime.Now;
                stateChange = 0;
                oldStatusPin17 = "";

                DeviceReady = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Init Gpio Error : " + ex.Message);
                DeviceReady = false;
            }  
        }

        public async Task<bool> InitHub()
        {
            try
            {
                connection = new HubConnectionBuilder()
                    .WithUrl("http://192.168.8.123:5000/counterhub")
                    .Build();

                await connection.StartAsync();
                
                Console.WriteLine("Hub connection started");              

                return true;
            }
            catch (Exception ex)
            {               
                Console.WriteLine("Error : " + ex.Message);
                return false;
            }
        }

        public async void ReadGPIO()
        {
            try
            {
                if(DeviceReady)
                {                    
                    GpioPinValue pin17Status = pin17.Read();

                    if (pin17Status.ToString() != oldStatusPin17)
                    {     
                        stateChange++;

                        if(stateChange == 1)
                        {
                            dt1 = DateTime.Now; //Nouveau front
                            //Console.WriteLine("dt1 : " + dt1.ToString());
                        }
                        oldStatusPin17 = pin17Status.ToString();
                        //Console.WriteLine("GPIO 17 state change : " + pin17Status.ToString());

                        if(stateChange == 2) //on a eu un retour d'état donc un Low High Low (ou High Low High)
                        {
                            DateTime dt2 = DateTime.Now;
                            //Console.WriteLine("dt2 : " + dt2.ToString());

                            TimeSpan spanElapsed = dt2.Subtract (dt1);
                            
                            //Console.WriteLine("Time elapsed between states : " + spanElapsed.TotalMilliseconds.ToString());  
                            
                            if(spanElapsed.TotalMilliseconds > antiRebond)
                            {
                                Console.WriteLine("GPIO 17 counter +1. signal duration : " + spanElapsed.TotalMilliseconds.ToString() + "ms");        
                                counter++;
                                await connection.InvokeAsync("CounterUpdate", counter.ToString());
                            }
                            else
                            {
                                Console.WriteLine("GPIO 17 bounce detected " + spanElapsed.TotalMilliseconds.ToString() + "ms < " +  antiRebond.ToString() + "ms");     
                            }

                            stateChange = 0; //init
                            dt1 = DateTime.Now; //init
                        }                        
                    }  

                }      
                else
                    Console.WriteLine("Device is not ready");    
            }
            catch(Exception ex)
            {
                Console.WriteLine("ReadGPIO Error : " + ex.Message);              
            }  
            // finally
            // {
            //     if(pin17 != null)
            //         pin17.Dispose();    

            //     if(pin22 != null)
            //         pin22.Dispose();   
            // }

        }


    }

}