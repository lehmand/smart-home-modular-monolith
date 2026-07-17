# smart-home-monolith
Smart home implementation in C#



# Setup for mosquitto:

### login interactively into the mqtt container
sudo docker exec -it mosquitto sh

### Create new password file and add user and it will prompt for password
mosquitto_passwd -c /mosquitto/config/pwfile dev_user

### Add additional users (remove the -c option) and it will prompt for password
mosquitto_passwd /mosquitto/config/pwfile user2

### delete user command format
mosquitto_passwd -D /mosquitto/config/pwfile <user-name-to-delete>

### type 'exit' to exit out of docker container prompt
