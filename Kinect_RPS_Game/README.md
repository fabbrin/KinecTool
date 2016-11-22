# Kinect Rock Paper Scissors (RPS) The Game
Niccolò Fabbri - Copyright © 2016

*Ever thought about playing Rock-Paper-Scissors with your PC?*

*Now you can do this by using Kinect RPS. The rule are rock breaks scissors, scissors cut paper and paper wraps rock. Kinect RPS can recognize your hand gesture and immediately show you its hand-sign randomly chooses. In according to the game rule, the system can decide the winner between human and computer....(unless it recognizes wrongly..Sometimes it does)*

# Requirements
- Microsoft Kinect Xbox 360 device
- Kinect for Windows SDK v1.8
- Candescent NUI library
- OpenNI library

# Usage
- Compile [RPS_Kinect](https://github.com/fabbrin/KinecTool/blob/master/Kinect_RPS_Game/RPS_Kinect.sln) solution or run the application (bin/x64/Release/RPS_Kinect.exe)
- Point the Kinect device at you and stand   
- You can see yourself in the application window and the **three circles** will track your **head** and **hands** 
- Move, as described inside system instructions, your arms to activate the gesture
  - These gestures will send an arrow or control key to the foreground application
- Run your **PowerPoint** or **PDF** presentation, if you want you can run [Test_Slide](https://github.com/fabbrin/KinecTool/tree/master/Kinect_PPT_PDF_Control/Test_Slide) presentations

The **ellipses** grow and **change color** when your hand exceeds the threshold. The gestures will only activate once as your hand exceeds the threshold, and only one of the gestures can be active at once. You must bring your hand back closer to your body to activate the gesture a second time.

# Limitations
This is a beta version, so you can observe some lacks.

# License
The source code is made available under the [MIT](https://github.com/fabbrin/KinecTool/blob/master/LICENSE) License. 
