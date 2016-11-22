# Kinect PPT/PDF Control
Niccolò Fabbri - Copyright © 2016

# Requirements
- Microsoft Kinect Xbox 360 device
- Kinect for Windows SDK v1.8
- Optional: Microsoft Office PowerPoint or Adobe PDF Reader

# Usage
- Compile [Kinect_PPT_PDF_Control](https://github.com/fabbrin/KinecTool/blob/master/Kinect_PPT_PDF_Control/Kinect_PPT_PDF_Control.sln) solution or run the application (bin/release/Kinect_PPT_PDF.exe)
- Point the Kinect device at you and stand at least 1 meter away  
- You can see yourself in the application window and the **three circles** will track your **head** and **hands** 
- Move, as described inside system instructions, your arms to activate the gesture
  - These gestures will send an arrow or control key to the foreground application
- Run your **PowerPoint** or **PDF** presentation so is the foreground application.

The **ellipses** grow and **change color** when your hand exceeds the threshold. The gestures will only activate once as your hand exceeds the threshold, and only one of the gestures can be active at once. You must bring your hand back closer to your body to activate the gesture a second time.

# Limitations
There is currently no way to activate embedded videos.

# License
The source code is made available under the [MIT](https://github.com/fabbrin/KinecTool/blob/master/LICENSE) License. 
