def connect_to_rabbit(client_name, broker_host, keep_alive):
    try:
        print('Connect to Rabbit.')

        mqttc = MQTTClient(client_name, broker_host, keepalive=keep_alive)
        mqttc.connect()
        
        print('Connected to Rabbit.')
        return mqttc
    except OSError as e:
        print('Failed to connect.')
        return None
    
def defy_sensor_pin(pin):
    return dht.DHT22(Pin(pin))

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
    
room_id = conf['room_id']
sensor_delay = conf['sensor_delay']

sensor_pin = conf['sensor_pin']
sensor = defy_sensor_pin(sensor_pin)

client_name = conf['mqtt_client']
broker_host = conf['mqtt_host']
keep_alive = conf['keep_alive']
mqttc = connect_to_rabbit(client_name, broker_host, keep_alive)

while True:
    status, tmp, hum = temperature()
    if status:
        now = get_time()
        json = '{ "roomId": %i, "temperature": %.2f, "humidity": %.2f, "measurmentTime": "%s" }' % (room_id, tmp, hum, str(get_time()))
        mqttc.publish('climate-measured-event', json)
        print(json)
        sleep(sensor_delay)