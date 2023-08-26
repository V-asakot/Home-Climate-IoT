def connect_to_rabbit():
    print('Connect to Rabbit')

    client_name = conf['mqtt_client']
    broker_host = conf['mqtt_host']
    keep_alive = conf['keep_alive']
    mqttc = MQTTClient(client_name, broker_host, keepalive=keep_alive)
    mqttc.connect()
    
    print('Connected to Rabbit')
    return mqttc
    
def defy_sensor_pin():
    return dht.DHT22(Pin(conf['sensor_pin']))

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
    
sensor = defy_sensor_pin()
mqttc = connect_to_rabbit()
while True:
	status, tmp, hum = temperature()
	if status:
         now = get_time()
         json = '{ "roomId": 1, "temperature": %.2f, "humidity": %.2f, "measurmentTime": "%s" }' % (tmp, hum, str(get_time()))
         mqttc.publish('climate-measured-event', json)
         print(json)
         sleep(conf['sensor_delay'])

