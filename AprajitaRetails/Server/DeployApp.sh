clear
cd  /home/amit/UserArea/GitHub/AprajitaRetails/AprajitaRetails/Server
dotnet publish --configuration Release
sudo systemctl stop  estore.service
sudo cp -r bin/Release/net7.0/publish/* /var/www/estore/
sudo systemctl start estore.service
sudo systemctl status estore.service

