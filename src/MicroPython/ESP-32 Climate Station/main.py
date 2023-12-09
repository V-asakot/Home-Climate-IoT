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
    
device_guid = conf['device_guid']
sensor_delay = conf['sensor_delay']

sensor_pin = conf['sensor_pin']
sensor = defy_sensor_pin(sensor_pin)

client_name = conf['mqtt_client']
broker_host = conf['mqtt_host']
keep_alive = conf['keep_alive']
mqttc = connect_to_rabbit(client_name, broker_host, keep_alive)

device_name = conf['device_name']
room_guid = conf['room_guid']
device_type = conf['device_type']

init_json = '{"deviceName":"%s", "deviceGuid":"%s", "roomGuid":"%s", "deviceType":%i}' % (device_name, device_guid, room_guid, device_type)
print(init_json)
mqttc.publish('device-initialized-event', init_json)

while True:
    status, tmp, hum = temperature()
    if status:
        now = get_time()
        measurment_json = '{ "deviceGuid": "%s", "temperature": %.2f, "humidity": %.2f, "measurmentTime": "%s" }' % (device_guid, tmp, hum, str(get_time()))
        mqttc.publish('climate-measured-event', measurment_json)
        print(measurment_json)
        sleep(sensor_delay)