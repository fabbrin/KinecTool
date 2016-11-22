<img src="https://github.com/fabbrin/KinecTool/blob/master/images/fine.png" width="225" height="225">
# KinecTool
A repository of open kinect projects


A repository of open kinect projects. **KinecTool** is the result of my work for the Human Computer Interaction course (University of Florence - Prof. A. D. Bagdanov)


*Hand gesture based Human-Computer-Interaction (HCI) is one of the most natural and intuitive ways to communicate between people and machines. Compared to the entire human body, the hand is a smaller object with more complex articulations and more easily affected by segmentation errors. It is thus a very challenging problem to recognize hand gestures. In this project, i use Candescent NUI libraries for hands and fingers tracking and i use Kinect SDK for hand gestures. In conclusion propose two demos: one for the game rock paper scissors (RPS) to demonstrate the performance of Candescent NUI libraries in a real life application and other for the control of PowerPoint or PDF program using Kinect SDK.*

Link to the Final Report

Link to the Demo Video

### Prerequisities

- A [Microsoft Kinect Controller](http://www.xbox.com/en-US/xbox-360/accessories/kinect) - all projects are based on this device
- [Candescent NUI](http://candescentnui.codeplex.com/) Library - hand and fingers tracking library
- [Microsoft Visual Studio](https://www.microsoft.com/it-it/download/details.aspx?id=30682) - development environment (IDE) from Microsoft
- [Kinect SDK](https://www.microsoft.com/en-us/download/details.aspx?id=40278) - Microsoft skeleton tracking library
- [OpenNI](http://openni.ru/openni-sdk/) - SDK used for the development of 3D sensing middleware libraries and applications 

### Project structure

bin: contains binaries and instruction
UsabilityTest: contains the little website used for the timed test and the usability questionnaire
ClickGestureTrainer: sources of the training set recorder for the click gesture (left and right)
Controller: sources of the main application (AirMouse)
MergeTrainingSet sources of the training sets merger
StaticGesturesTrainer: sources of the training set recorder for the hand poses

### Authors

Student: **Niccolò Fabbri**

Supervisor: **Andrew David Bagdanov**

### License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/fabbrin/KinecTool/blob/master/LICENSE) file for details
