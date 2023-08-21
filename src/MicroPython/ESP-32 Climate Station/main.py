from umqtt.simple import MQTTClient
from time import sleep
import dht
from machine import Pin
import time

print("Connect to Rabbit")

CLIENT_NAME = 'guest'
BROKER_ADDR = '192.168.0.102'
sensor = dht.DHT22(Pin(14))
mqttc = MQTTClient(CLIENT_NAME, BROKER_ADDR, keepalive=10)
mqttc.connect()

print("Connected to Rabbit")

def temperature():
    try:
        sensor.measure()
        temp = sensor.temperature()
        hum = sensor.humidity()
        if (isinstance(temp, float) and isinstance(hum, float)) or (isinstance(temp, int) and isinstance(hum, int)):
          return True, temp, hum
        else:
          print('Invalid sensor readings.')
          return False, 0, 0
    except OSError as e:
        print('Failed to read sensor.')
        return False, 0, 0
    
while True:
	status, tmp, hum = temperature()
	if status:
         now = getTime()
         json = '{ "temperature": %.2f, "humidity": %.2f, "time": %s }' % (tmp, hum, now)
         mqttc.publish("temp_mqtt", json )
         print(json)
         sleep(10)

