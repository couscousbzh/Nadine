# Nadine project using Asp.net Core 2.1 with SignalR, GPIO and Raspberry pi 3

This is a personal project. I wanted to discover Asp.net Core 2.1 and SignalR. 

I use a Raspberr pi 3 with an external board so I can easily plug cables and play with leds and buttons on GPIOs.

Here is the goal : count on an input (Gpio 17) linked to a photo-electric cell the number of passage of a fake fabric bottle line, simulated here by one propal of an old usb fan. The signal is read on Gpio17 by the raspberry pi and sent via SignalR to a web client (which is also host on the same raspberry pi server, with asp.net core razor pages.)

So I can read the counter on my web page in real time (almost). 

Youtube Demo here : https://youtu.be/c3wAWcoAf0M

---

## How it works

In Asp.net Core you can manage WebHost as usual (your web site) but you can add other host that can act like a service. 

This is what i've done. I create two services, webhost and a timehostedservice. If my english is not so bad, I understood that host and webhost services will be "Generic Host" in the future. I notice some diffences when creating it. With webhost service you can configure it in one line (CreateDefaultBuilder) but there is no such things for host. 

Anyway, all of this is coded in program.cs and startup.cs (this one is basically only used for webhost)


---

## WEB

Basic project made with a "dotnet new webapp" cli command. 

Then I follow the microsoft guide line : https://docs.microsoft.com/fr-fr/aspnet/core/signalr/introduction?view=aspnetcore-2.1

this give me a little chat room exemple using SignalR.

Then, I add a Counter Page. The goal of this is to simulate a counter (like a bottle counter sensor) and upload the value directly in client web page, using SignalR. 

Template Gentelella : https://github.com/puikinsh/gentelella

npm init -y
npm install @aspnet/signalr
npm install gentelella --save

dotnet build


---

## GPIOs

Thansk to Jeremy Lindsay, I could use the GPIOs as I wanted. Here is some usefull links :

>https://jeremylindsayni.wordpress.com/2017/05/01/controlling-gpio-pins-using-a-net-core-2-webapi-on-a-raspberry-pi-using-windows-10-or-ubuntu/

>https://jeremylindsayni.wordpress.com/2017/04/05/turning-gpio-pins-high-and-low-on-a-raspberry-pi-3-using-net-core-2-and-ubuntu/

>https://jeremylindsayni.wordpress.com/2017/04/18/write-net-core-2-once-run-anywhere-hardware-access-on-raspberry-pi-3-with-ubuntu-and-windows-10-iot-core/

I copy some classes into /GpioManager folder. 

And my code is basically located into the worker class (/HostedServices/Worker.cs)

---

Deploy Asp.net Core 2.1

https://github.com/dotnet/core/blob/master/samples/RaspberryPiInstructions.md#linux

On dev environnement :

dotnet publish -c Release -r linux-arm
copy publish folder content to RapsberryPi

For Raspbian Debian 9 Jessie you need to do the following (only once):

sudo apt-get update
sudo apt-get install curl libunwind8 gettext apt-transport-https

chmod 755 ./MyWebApp

export ASPNETCORE_URLS="http://*:5000"
export ASPNETCORE_URLS="http://192.168.8.123:5000"
echo $ASPNETCORE_URLS

./MyWebApp

-----------------------


wiringPi

gpio readall
gpio mode 0 in (0 match GPIO 17)
gpio mode 2 in (2 match GPIO 27)
gpio mode 5 out (5 match GPIO 24)



--------------------------

.\ps-deploy-raspian.ps1 -ip 192.168.8.123 -destination "/home/pi/Dotnet/Nadine" -username pi 

.\ps-info-raspian.ps1 -ip 192.168.8.123 -destination "/home/pi/Dotnet/Nadine" -username pi


sudo E /home/Dotnet/Nadine/Nadine





