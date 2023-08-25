def connect_to_rabbit():
    print('Connect to Rabbit')

    CLIENT_NAME = conf.mqtt_client
    BROKER_ADDR = conf.mqtt_host
    sensor = dht.DHT22(Pin(conf.sensor_pin))
    mqttc = MQTTClient(CLIENT_NAME, BROKER_ADDR, keepalive=10)
    mqttc.connect()

    print('Connected to Rabbit')

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
    
connect_to_rabbit()
while True:
	status, tmp, hum = temperature()
	if status:
         now = getTime()
         json = '{ "roomId": 1,"temperature": %.2f,"humidity": %.2f,"measurmentTime": "2023-08-22T17:52:22.683Z"}' % (tmp, hum)
         mqttc.publish('climate-measured-event', json)
         print(json)
         sleep(conf.sensor_delay)

