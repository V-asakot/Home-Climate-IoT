def connect():
    import network
    print("Trying to connect")
    ssid = "TP-Link_A541"
    password =  "84325129"
  
    station = network.WLAN(network.STA_IF)
 
    if station.isconnected() == True:
        print("Already connected")
        return
 
    station.active(True)
    station.connect(ssid, password)
 
    while station.isconnected() == False:
        pass
 
    print("Connection successful")
    print(station.ifconfig())
    
def timeSync():
     import ntptime
     ntptime.settime()

UTC_OFFSET = 3 * 60 * 60

def getTime():
    now = time.localtime(time.time() + UTC_OFFSET)
    return '{}/{}/{} {}:{}'.format(now[1], now[2], now[0], now[3], now[4])
  
connect()
timeSync()

