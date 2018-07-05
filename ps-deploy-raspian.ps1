
param ([string]$ip, [string]$destination, [string]$username)

& ".\ps-publish-raspian.ps1"

& pscp.exe -r .\bin\Debug\netcoreapp2.1\linux-arm\publish\* ${username}@${ip}:${destination}

& plink.exe -v -ssh ${username}@${ip} chmod u+x,o+x ${destination}/Nadine



