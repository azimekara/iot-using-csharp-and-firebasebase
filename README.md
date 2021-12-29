# iot-using-csharp-and-firebasebase

![image](https://user-images.githubusercontent.com/77415599/147707713-cf2e3b35-2372-4476-a7bd-9aa8adf237b9.png)

In summary:
Mode selection is made from the UI created with C#. The selection is processed to firebase. This data is received from the firebase with Raspberry Pi and transmitted to MSP430G2553 with UART. According to the selected mode, the strip led lights up.

### C# Working Principle
The user clicks on the button of the mode they want to select. This action disables other modes and prevents two modes from being selected at the same time. After selecting the mode and the desired option, the "Send" button is clicked to send the data (index of the selected + 2) to firebase. If the user wants to select a new mode, he must press the "Reset" button.(This operation is valid for the first 3 modes and the button on the hardware must be pressed in order for "Mode4" to be active.)

- UI Prepared with C#

![image](https://user-images.githubusercontent.com/77415599/147702129-0ec2d7ad-d673-451f-883a-b9897e8fb7a2.png)

- Default Firbase  

![image](https://user-images.githubusercontent.com/77415599/147705856-19e001ec-7ce4-488e-a209-c23d5fc61497.png)

- Selected Mod1 with Index Number One

![askjdh](https://user-images.githubusercontent.com/77415599/147707071-41ac64da-36b4-4aaf-a1bf-afbe5d416605.png)

