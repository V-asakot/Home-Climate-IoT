import ujson
import network
import ntptime
from umqtt.simple import MQTTClient
from time import sleep
import dht
from machine import Pin
import time

class Config():
    def __init__(self, ssid,password,timezone,mqtt_client,mqtt_host,sensor_pin,sensor_delay):
        #wifi settings
        self.wifi_ssid = ssid
        self.wifi_password =  password
        #time
        self.timezone = timezone
        #mqtt
        self.mqtt_client = mqtt_client
        self.mqtt_host = mqtt_host
        #sensor
        self.sensor_pin = sensor_pin
        self.sensor_delay = sensor_delay
        
    @staticmethod
    def get_default():
        return Config('TP-Link_A541','84325129', 3,'guest','192.168.0.102',14,60)

    def save(self):
        settings_json = ujson.dumps(self.__dict__)
        print('Saving:', settings_json)
        try:
            f = open('config.json','w')
            f.write(settings_json)
            f.close()
            return True
        except:
            return False
        
    @staticmethod
    def load():
        try:
            f = open('config.json','r')
            config_string=f.read()
            f.close()
            print('Got settings:', config_string)
            config_dict = ujson.loads(config_string)
            result = Config.get_default()
            for setting in config_dict:
                print("Setting:", setting)
                setattr(result,setting, config_dict[setting])
            return result
        except:
            print('Settings file load failed')
            return Config.get_default()

def connect_to_wifi():
    print('Trying to connect')
    ssid = conf.wifi_ssid
    password =  conf.wifi_password
  
    station = network.WLAN(network.STA_IF)
 
    if station.isconnected() == True:
        print('Already connected')
        return
 
    station.active(True)
    station.connect(ssid, password)
 
    while station.isconnected() == False:
        pass
 
    print('Connection successful')
    print(station.ifconfig())
    
def sync_time():
     ntptime.settime()

def get_time():
    UTC_OFFSET = conf.timezone * 60 * 60
    now = time.localtime(time.time() + UTC_OFFSET)
    return '{}/{}/{} {}:{}'.format(now[1], now[2], now[0], now[3], now[4])

conf = Config.load()
connect_to_wifi()
sync_time()

