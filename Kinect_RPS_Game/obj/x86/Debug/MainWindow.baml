   M S B A M L   `   `   `  ����I  ECCT.NUI.Visual, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:CCT.NUI.Visual;assembly=CCT.NUI.VisualCCT.NUI.Visual  5   	    
RPS_Kinect#   CCT.NUI.WPFSamples.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Cuc4clr-namespace:CCT.NUI.Visual;assembly=CCT.NUI.Visual     5   	   -   5          � Title$'  !Rock Paper Scissors - Kinect Game��5   	   $	��720��63   $	��960��6@    � Icon$ ./Image/Kinect.ico��6L    J� IsManipulationEnabled . .��5      �  � RowDefinitions 5   
   �� 5      $
��937* �6   �� 5	      $	��57* �6   �� 5
      $��0* �6   .+�5   
   �� $��3q�6   
���   �$��1,1,533,224q�5   	   }�. ._�5      �� -   5        $��
imgGesture��5      $
��Fill=�6&   $��/Image/None.png��65   $
��Left=�6N   $	��Top=�6i   $��	7,0,-3,-3q�6�   $	��414��6�   $	��408��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         RenderingBias$ Quality=�6#   5      5      �� 5   
   -   5        $��versus��5      $��Uniform=�6   $��/Image/versus.png��60   $��Center=�6K   $	��118��6h   $��97��6t   $��414,186,420,367q�6�   �� 5   
   -   5        $	��cpu��5      $��Uniform=�6   $��/Image/CPU.png��6-   $
��Left=�6E   $	��129��6`   $��146,428,0,110q�6l   �� 5   
   -   5        $	��man��5      $��Uniform=�6   $��/Image/man.png��6-   $��Right=�6E   $	��129��6a   $��0,428,146,110q�6m   �� 5   
   -   5        $
��imag��5      $
��Fill=�6   $��/Image/Logo_Unifi.png��6+   $
��Left=�6J   $	��180��6e   $��90��6q   $��	0,554,0,0q�6}   $   CCT.NUI.Visual.WpfVideoControl  5   
   -   5        $��videoControl��5         Stretch$
 None=�61   $	��413��6@   $	��417��6L   $��Right=�6Y   $	��Top=�6u   }�. 
���   �$��3q�6�   $��0,1,1,0q�6�    5        5       $ Quality=�6#   5"      �� 5#   
   -   5        $��txtInfo��5#   :   $��42��6   $
��Left=�6   $	��Top=�6I   $	��960��6a    �� 
IsReadOnly . $��16(�6    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��1��6�   $��
0,0,-28,-2q�6�   $��2q�6  $��Calibri)�6  $��Expanded&�6/  	 �� TextAlignment$	 Center=�6F  $��2��6]  ��6�   Z� .��6o  z�5$      V� 5%      .~�5&      �� �� 5'      �� 5(      
 �� Angle$
 -0.147Q�6&   T� 5)       T� X$ 	-0.629122Q�6)    T� Y$ 1.04589Q�67   5*      .��5+   '   5,      �� 5-   
   -	   5        $��textBox1��5-      $��Center=�6"   $��81��6?   $��326,569,326,0q�6K    �� TextWrapping$
 Wrap=�6b   $��
Ready��6v   $	��Top=�6�   $	��300��6�   $	 Center=�6�   $��22(�6�   $��0q�6  ��6�   Z� 6  5.      5/      