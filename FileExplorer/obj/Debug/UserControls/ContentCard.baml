   M S B A M L   `   `   `  ����G  CFileExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FileExplorer.UserControlsFileExplorer.UserControls  5      +    %FileExplorer.UserControls.ContentCard   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:FileExplorer.UserControls     5      -   5        $��FE_ContentCard��5      $	��150��5      $	��300��6/   ��5	      �� 5
   
     �� 
TargetType"  >�6    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5      ��  �� Property � �� �� Value
 �����63   5      5      .��5      � $��10q�6    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ #212121��6      ShadowDepth$ 2Q�6/   	   
BlurRadius$	 4Q�6?   
   	Direction$	
 336Q�6N      Opacity$	 0.4Q�6^    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ contentImage��5      $��0��6&   �� 5   
   $	��Top=�5      $��Center=�5      $��Center=�6/   $��1��5       ��5      ��  �� Path$ ContentName� �� ElementName$ FE_ContentCard�� � 	Resources 5!      ��%`   '��       �� 5"      "  ��6   .�5#      ��  � ��$ WrapWithOverflow=�65   5$      5%      5&      5'      5(      