# Kinect PPT/PDF Control
Niccolò Fabbri - Copyright © 2016

# Requirements
- Microsoft Kinect Xbox 360 device
- Kinect for Windows SDK v1.8
- Optional: Microsoft Office PowerPoint or Adobe PDF Reader

# Usage
- 1.	Compile [Kinect_PPT_PDF_Control](https://github.com/fabbrin/KinecTool/blob/master/Kinect_PPT_PDF_Control/Kinect_PPT_PDF_Control.sln) solution or run the [application] (bin/release/Kinect_PPT_PDF.exe) (https://github.com/fabbrin/KinecTool/blob/master/Kinect_PPT_PDF_Control/bin/Release/Kinect_PPT_PDF_Control.exe) 
- 2.	Point the Kinect at you and stand at least five feet away 
- 3.	You can see yourself in the application window and the three circles will track your head and hands. 
- 4.	Extend your right arm to activate the "right" or "forward" gesture. Extend your left arm to active the "left" or "back" gesture.    These gestures will send a right or left arrow key to the foreground application, respectively. 
- 5.	Run your PowerPoint show so PowerPoint is the foreground application, and the right and left gestures will go forward and back in your deck.

The ellipses grow and change color when your hand exceeds the threshold of 45 centimeters. The gestures will only activate once as your hand exceeds the threshold, and only one of the gestures can be active at once. You must bring your hand back closer to your body to activate the gesture a second time.

The gestures will also work for any other application. For example, open Notepad and type some text then use the gestures to move the cursor left or right one character at a time.


# Limitations
There is currently no way to activate embedded videos, so you should add a PowerPoint animation so the video starts when you push the right arrow key. 

# License
The source code is made available under the MIT License. 
