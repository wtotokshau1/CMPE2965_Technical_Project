#!/usr/bin/env python3
import RPi.GPIO as GPIO # import GPIO
import pyodbc

from hx711 import HX711 # import the class HX711
from gpiozero import LED
from gpiozero import MotionSensor
from datetime import datetime
from time import sleep
GPIO.setmode(GPIO.BCM)
import time

# Pyodbc.connect looks for the DSN(Data source name in /etc/odbc.ini
# ini file contains address, port, driver name, database for connection
# Driver may need to be set up properly by editing the /etc/odbcinst.ini file
server = 'PetActivityTracker' 
username = 'wtotokshau_SQLLogin_1' 
password = 'xfr2k1v5yz'

   

green_led = LED(27)
pir = MotionSensor(4)
green_led.off()
ledpin = 27                                                
pushpin = 17                                        
GPIO.setup(ledpin, GPIO.OUT)          
GPIO.setup(pushpin, GPIO.IN, pull_up_down = GPIO.PUD_UP) # using the internal Pull up resistor
GPIO.setup(27, GPIO.OUT, initial = GPIO.LOW) 


try:  
	# set GPIO pin mode to BCM numbering
    GPIO.setmode(GPIO.BCM)
    
    # Create an object hx which represents your real hx711 chip
    # Required input parameters are only 'dout_pin' and 'pd_sck_pin'
    hx = HX711(dout_pin=5, pd_sck_pin=6)
    
    # Set scale ratio for the hx711    
    hx.set_scale_ratio(-482)
    
    # Uses switch state to determine whether food or water is being tracked
    activityType = "Food"
    

    while True:
        print("Waiting for motion...")
        pir.wait_for_motion()
        
        print("Motion Sensed...")
        green_led.on()
        initWeight = round(hx.get_weight_mean(20)-25.75,2)
        startTime = time.strftime("%Y%m%d %I:%M:%S %p", time.localtime())
        
        pir.wait_for_no_motion()
        green_led.off()
        
        finWeight = round(hx.get_weight_mean(20)-25.75,2)
        endTime = time.strftime("%Y%m%d %I:%M:%S %p", time.localtime())
        
        weight_consumed = initWeight - finWeight
        
        if(weight_consumed > 1.0):
            if(not GPIO.input(pushpin)):
                activityType  = "Water"            
            else:
                activityType = "Food"
            
            cnxn = pyodbc.connect(f'DSN={server};UID={username};PWD={password};')
            cursor = cnxn.cursor()            
            cursor.execute(f"INSERT INTO PetActivity VALUES('5', '{activityType}', '{startTime}', '{endTime}', '{round(weight_consumed,2)}');")
            print(f"Insert Statement: INSERT INTO PetActivity VALUES('5', '{activityType}', '{startTime}', '{endTime}', '{weight_consumed}');" )
            cnxn.commit()
            cursor.close()
            cnxn.close()
        else:
            print(f"wight consumed: {round(weight_consumed,2)} is too low to be sent to database.")

except (KeyboardInterrupt, SystemExit):
    print('Bye :)')

finally:
    GPIO.cleanup()
