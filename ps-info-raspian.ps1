
param ([string]$ip, [string]$destination, [string]$username)

& plink.exe -v -ssh ${username}@${ip} ls ${destination}/Nadine

& plink.exe -v -ssh ${username}@${ip} echo $ASPNETCORE_URLS