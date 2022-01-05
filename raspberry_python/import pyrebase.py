import pyrebase
from time import sleep
import time
import serial

received_data = 0
int_val = 0

config = {
  "apiKey": "..............",
  "authDomain": ".................",
  "databaseURL": "......................",
  "storageBucket": "......................"
}

firebase = pyrebase.initialize_app(config)

auth = firebase.auth()

db = firebase.database()

#Mod1
mod1 = db.child("SelectedMod1&2").child("Mod1 & Mod2").child("Mod1").get()
mod_1 = mod1.val() 

#Mod2
mod2 = db.child("SelectedMod1&2").child("Mod1 & Mod2").child("Mod2").get()
mod_2 = mod2.val()

#Mod3
mod3b = db.child("SelectedMod3").child("Mod3").child("Mod3Blue").get()
mod_3b = mod3b.val()

mod3g = db.child("SelectedMod3").child("Mod3").child("Mod3Green").get()
mod_3g = mod3g.val()

mod3r = db.child("SelectedMod3").child("Mod3").child("Mod3Red").get()
mod_3r = mod3r.val()

#Mod4
mod4 = db.child("SelectedMod4").child("Mod4").child("Mod4tick").get()
mod_4 = mod4.val()

#uart
ser = serial.Serial ("/dev/ttyS0", 115200)    #Open port with baud rate

#mod1
if mod_1 != 0 :
    print(mod_1)
    ser.write(mod_1.to_bytes(1,'big'))
   

#mod2
if mod_2 != 0 : 
    print(mod_2)
    ser.write(mod_2.to_bytes(1,'big'))
    

#mod3
if mod_3b != 175 :
    print(mod_3b)
    ser.write(mod_3b.to_bytes(1,'big'))
    

if mod_3g != 93 :
    print(mod_3g)
    ser.write(mod_3g.to_bytes(1,'big'))
    

if mod_3r != 11 :
    print(mod_3r)
    ser.write(mod_3r.to_bytes(1,'big'))
    

#mod4tick
if mod_4 != 0 :
    print(mod_4)
    ser.write(mod_4.to_bytes(1,'big'))
   

#mod4activity
received_data = ser.read()              #read serial port
sleep(0.03)
data_left = ser.inWaiting()             #check for remaining byte
received_data += ser.read(data_left)

if received_data == 0 :
      
	int_val = int.from_bytes(received_data, "big")
	data = {"Activity":int_val}  
	db.child("SelectedMod4").child("Mod4Activity").update(data)
