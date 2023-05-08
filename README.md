# H5D-Delivery

For the application to run you need Docker: https://www.docker.com/products/docker-desktop/

For the SQL Docker Server you must run the "docker-compose.yml" file using powershell with the command:
"docker-compose-H5D-Db up -d"

To install the MQTT Broker Image use following command:
"docker pull eclipse-mosquitto:1.6.15"
Afterwards you can run the image from the Docker GUI (set Port to 1883 and give the container a name)

## Class Diagram
![image](https://user-images.githubusercontent.com/75679578/227969633-53258193-5338-42ba-bc51-ece41f58b4ef.png)
