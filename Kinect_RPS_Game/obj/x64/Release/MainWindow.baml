   M S B A M L   `   `   `  ���� I  ECCT.NUI.Visual, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:CCT.NUI.Visual;assembly=CCT.NUI.VisualCCT.NUI.Visual   
RPS_Kinect#   CCT.NUI.WPFSamples.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Cuc4clr-namespace:CCT.NUI.Visual;assembly=CCT.NUI.Visual     -     � Title$'  !Rock Paper Scissors - Kinect Game��$	��720��$	��960�� � Icon$ ./Images/Kinect.ico�� J� IsManipulationEnabled . .���  � RowDefinitions �� $
��937* ��� $	��57* ��� $��0* �.+��� $��3q�
���   �$��3,1,533,224q�}�. ._��� -   $��
imgGesture��$
��Fill=�$
��Left=�$	��Top=�$��0,3,0,0q�$	��410��$	��408�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     RenderingBias$ Quality=��� -   $��versus��$��Uniform=�$��./Images/VS.png��$��Center=�$	��118��$��97��$��416,186,418,367q��� -   $	��cpu��$��Uniform=�$
��Left=�$	��129��$��146,428,0,110q��� -   $	��man��$��Uniform=�$��Right=�$	��129��$��0,428,146,110q��� -   $
��imag��$
��Fill=�$��./Images/Logo_Unifi.png��$
��Left=�$	��180��$��90��$��	0,554,0,0q�$   CCT.NUI.Visual.WpfVideoControl  -   $��videoControl��   Stretch$
 None=�$	��413��$	��417��$��Right=�$	��Top=�}�. 
���   �$��3q�$��0,1,3,0q�   $ Quality=��� -   $��txtInfo��$��42��$
��Left=�$	��Top=�$	��960�� �� 
IsReadOnly . $��16(� J� RenderTransformOrigin$ 0.5,0.5&�$��1��$��	0,0,-28,0q�$��2q�$*��$/Font/RobotoMedium.ttf#Roboto Medium)�$��Expanded&�	 �� TextAlignment$	 Center=�$��2����Z� .��z�V� .~��� �� �� 
 �� Angle$
 -0.147Q�T�  T� X$ 	-0.629122Q� T� Y$ 1.04589Q�.���� -	   $��textBox1��$��Center=�$��81��$��235,567,205,0q� �� TextWrapping$
 Wrap=�$��
Ready��$	��Top=�$	��550��$	 Center=�$��22(�$��0q� . $*��$/Font/RobotoMedium.ttf#Roboto Medium)���Z� �� -
   $	��btn��
������ 
������ $��0q�$��863,552,5,5q�$��-4q�$ -0.456,0.343&�.���� $��./Images/NOTICE_3.png��$��94��$	��143��$��Right=�$��Bottom=�$ 0.365,0.505&�� -    �Name$ popup�� � 	StaysOpen .  $��Bottom=�$��Right=�$	��Top=�$	��500��$	��503�� � PlacementTarget ��  �� ElementName$	 btn��.���� 
���   �$��2q�
������ $	��500��$	��503��$��0,0,0,0q�._��� -    ��Name$ txtBox�� . $����
INSTRUCTIONS
_________________________________________________________________________

Ever thought about playing Rock-Paper-Scissors with your PC? 
Now you can do this by using Kinect RPS.
The rule are rock breaks scissors, scissors cut paper 
and paper wraps rock.
Kinect RPS can recognize your hand gesture and immediately
show you its hand-sign randomly chooses. 
In according to the game rule, the system can decide the winner
between human and computer.

(unless it recognizes wrongly..Sometimes it does)


NOTICE
_________________________________________________________________________

- Separate your fingers when showing your gesture.
-  It'll be able to detect the fingers between 500- 800mm
-  Perfect distance for the tracking is around 650mm
- Position your hand flat to the viewing angle of the kinect��$��16(�$��3��$	 Center=�$
��Bold"�$	��500��$��Bottom=�$��0,0,0,0q�