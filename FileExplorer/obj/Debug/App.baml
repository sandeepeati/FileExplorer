   M S B A M L   `   `   `  ����G  CFileExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FileExplorerFileExplorer  5          FileExplorer.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ,localclr-namespace:FileExplorer     5        �� 	Resources  5         FE_Button_Style �� 
TargetType �� Property �� Value  FE_Header_Button_Style3  -System.Windows.Media.Effects.DropShadowEffect   Opacity   	Direction   ShadowDepth   
BlurRadius  FE_Button_CT �� 
TargetType	 ��Name
 J� SnapsToDevicePixels ��Name �� ContentStringFormat �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �    �� 5   
   " ��6(   .�5	      ��  � ��
 �����6+   �� 5
       � ��
 �����6,   �� 5       � ��$ 10q�6(   �� 5       � ��$	 5 2q�6'   5      �� 5   
   " ��6/   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��
 �   �6+   �� 5       � ��$
 Left=�64   �� 5       � ��$	 250��6)   �� 5       � ��$	 200��6)   �� 5       � ��$ 10q�6(   �� 5       � ��$	 5 2q�6'   �� 5       �@J�Effect 5        5      $	 0.5Q�6'   $	 315Q�65   $ 2Q�6E   $ 4Q�6U   5      5      �� 5!   
   " ��6/   .R�5"      �� $	 border��6   #��z��6%   #��z��6Q   #��z��6�   
 . ._�5#      �� $ contentPresenter��6#   #��z��6=   #��z��6q   # z 6�   |�.  #��z��6�   #��z��6&  ��. #
 z
 6d  #��z��6�  5$       5%      P� 5&       �@��IsDefaulted . . �5'      �� $ border��64   # � ��6H    � ��5(      P� 5)       �@J�IsMouseOver . . �5*      �� $ border��63    � ��
 �����6G   �� 5+      $ border��64    � ��
 �����6H   5,      P� 5-       � �� . . �5.      �� $ border��63    � ��
 �����6G   �� 5/      $ border��64    � ��
 �����6H   50      P� 51       �@d�	IsChecked$
 TrueY�6<   . �52      �� $ border��63    � �� �	#FFBCDDEE6G   �� 53      $ border��64    � �� �	#FF245A836H   54      P� 55       � {� .  . �56      �� $ border��63    � �� �	#FFF4F4F46G   �� 57      $ border��64    � �� �	#FFADB2B56H   �� 58       � �� �	#FF83838363   59      5;      5<      5=      