   M S B A M L   `   `   `  ����I  ECCT.NUI.Visual, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:CCT.NUI.Visual;assembly=CCT.NUI.VisualCCT.NUI.Visual  5   	    
RPS_Kinect#   CCT.NUI.WPFSamples.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Cuc4clr-namespace:CCT.NUI.Visual;assembly=CCT.NUI.Visual     5   	   -   5          � Title$'  !Rock Paper Scissors - Kinect Game��5   	   $	��720��63   $	��960��6@    � Icon$ ./Images/Kinect.ico��6L    J� IsManipulationEnabled . .��5      �  � RowDefinitions 5   
   �� 5      $
��937* �6   �� 5	      $	��57* �6   �� 5
      $��0* �6   .+�5   
   �� $��3q�6   
���   �$��3,1,533,224q�5   	   }�. ._�5      �� -   5        $��
imgGesture��5      $
��Fill=�6&   $
��Left=�65   $	��Top=�6P   $��0,3,0,0q�6h   $	��410��6y   $	��408��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         RenderingBias$ Quality=�6'   5      5      �� 5   
   -   5        $��versus��5      $��Uniform=�6   $��./Images/VS.png��60   $��Center=�6I   $	��118��6f   $��97��6r   $��416,186,418,367q�6~   �� 5   
   -   5        $	��cpu��5      $��Uniform=�6   $
��Left=�6-   $	��129��6H   $��146,428,0,110q�6T   �� 5   
   -   5        $	��man��5      $��Uniform=�6   $��Right=�6-   $	��129��6I   $��0,428,146,110q�6U   �� 5   
   -   5        $
��imag��5      $
��Fill=�6   $��./Images/Logo_Unifi.png��6+   $
��Left=�6L   $	��180��6g   $��90��6s   $��	0,554,0,0q�6   $   CCT.NUI.Visual.WpfVideoControl  5   
   -   5        $��videoControl��5         Stretch$
 None=�61   $	��413��6@   $	��417��6L   $��Right=�6Y   $	��Top=�6u   }�. 
���   �$��3q�6�   $��0,1,3,0q�6�    5        5      $ Quality=�6#   5       �� 5"   
   -   5        $��txtInfo��5"   :   $��42��6   $
��Left=�6   $	��Top=�6I   $	��960��6a    �� 
IsReadOnly . $��16(�6    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��1��6�   $��	0,0,-28,0q�6�   $��2q�6  $*��$/Font/RobotoMedium.ttf#Roboto Medium)�6  $��Expanded&�6K  	 �� TextAlignment$	 Center=�6b  $��2��6y  ��6�   Z� .��6�  z�5#      V� 5$      .~�5%      �� �� 5&      �� 5'      
 �� Angle$
 -0.147Q�6&   T� 5(       T� X$ 	-0.629122Q�6)    T� Y$ 1.04589Q�67   5)      .��5*   '   5+      �� 5-   
   -	   5        $��textBox1��5-      $��Center=�6"   $��81��6?   $��235,567,205,0q�6K    �� TextWrapping$
 Wrap=�6b   $��
Ready��6v   $	��Top=�6�   $	��550��6�   $	 Center=�6�   $��22(�6�   $��0q�6  $*��$/Font/RobotoMedium.ttf#Roboto Medium)�6"  ��6�   Z� 6"  �� 5.   
   -
   5        $	��btn��5.      
������ 
������ $��0q�52   	   $��863,552,5,5q�53   	   $��-4q�54   	   $ -0.456,0.343&�6   .��55      �� $��./Images/NOTICE_3.png��6   $��94��63   $	��143��6?   $��Right=�6K   $��Bottom=�6g   $ 0.365,0.505&�6�   56      � 58   
   -   5         �Name$ popup��58       � 	StaysOpen .  $��Bottom=�6]   $��Right=�6p   $	��Top=�6�   $	��500��6�   $	��503��6�    � PlacementTarget 61   ��  �� ElementName$	 btn��.��59      �� 
���   �$��2q�6)   
������ $	��500��6V   $	��503��6c   $��0,0,0,0q�6o   ._�5:      �� -   5         ��Name$ txtBox��5:      $����
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
- Position your hand flat to the viewing angle of the kinect��6*   $��16(�6�  $��3��6�  $	 Center=�6  $
��Bold"�6-  $	��500��6?  $��Bottom=�6L  $��0,0,0,0q�6g  5;      5<      5?      5@      