import utime
from time import sleep
import dht
from machine import Pin
import network
import ntptime
import ujson
from umqtt.simple import MQTTClient

class Config():
    def __init__(self):
        self.dictionary = {}
        
    def __getitem__(self, key):
        return self.dictionary[key]

    def save(self,path):
        config_json = ujson.dumps(dictionary)
        
        try:
            f = open(path,'w')
            f.write(config_json)
            f.close()
            print('Saved:', config_json)
            return True
        except:
            return False
        
    def load(self,path):
        try:
            f = open(path,'r')
            config_string=f.read()
            f.close()
            print('Loaded:', config_string)
            
            self.dictionary = ujson.loads(config_string)
        except:
            print('Settings file load failed')

def connect_to_wifi():
    print('Trying to connect')
    ssid = conf['wifi_ssid']
    password =  conf['wifi_password']
  
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
    ufc_offset = conf['timezone'] * 60 * 60
    current_time = utime.time()
    time_tuple = utime.localtime(current_time + ufc_offset)

    year = "{:04d}".format(time_tuple[0])
    month = "{:02d}".format(time_tuple[1])
    day = "{:02d}".format(time_tuple[2])
    hour = "{:02d}".format(time_tuple[3])
    minute = "{:02d}".format(time_tuple[4])
    second = "{:02d}".format(time_tuple[5])

    return "{}-{}-{}T{}:{}:{}Z".format(year, month, day, hour, minute, second)

conf = Config()
conf.load('config.json')
connect_to_wifi()
sync_time()