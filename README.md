# H5D-Delivery

For the application to run you need Docker: https://www.docker.com/products/docker-desktop/

For the SQL Docker Server you must run the "docker-compose.yml" file using powershell with the command:
"docker-compose up -d"

To install the MQTT Broker Image use following command:
"docker pull eclipse-mosquitto:1.6.15"
Afterwards you can run the image from the Docker GUI (set Port to 1883 and give the container a name)

Both mqtt and sql server must run for the application to boot. Make sure that the connection strings are set correctly depending on release and debug build.

When starting with an empty SQL Server Instance, Click through all Gui pages top down to ensure that all tables are created (Customer -> Product -> Stock -> Order -> RobotDashboard)

## Class Diagram
![image](https://user-images.githubusercontent.com/75679578/227969633-53258193-5338-42ba-bc51-ece41f58b4ef.png)
