# Nadine, Asp.net Core 2.1 with SignalR


Basic project made with a "dotnet new webapp" cli command. 

Then I follow the microsoft guide line : https://docs.microsoft.com/fr-fr/aspnet/core/signalr/introduction?view=aspnetcore-2.1

this give me a little chat room exemple using SignalR.

Then, I add a Counter Page. The goal of this is to simulate a counter (like a bottle counter sensor) and upload the value directly in client web page, using SignalR. 



Template Gentelella : https://github.com/puikinsh/gentelella

npm init -y
npm install @aspnet/signalr
npm install gentelella --save

dotnet build


-------------------------------------------------



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





