   M S B A M L   `   `   `  ���� M  IConsumablesCabinet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ConsumablesCabinet.TestModeConsumablesCabinet.TestMode  '    !ConsumablesCabinet.TestMode.Page1   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;local)clr-namespace:ConsumablesCabinet.TestMode       N� Title$  Page1�� � 	Resources  �� MergedDictionaries �� Source��  �� $@ :/PublicResources;component/styles/MainTabControlStyle.xaml?�%    .��� -    �Name$
 grid�����	#FF333333 � ColumnDefinitions �� $��5* ��� $��1* ��� $	��20* �.+��� -    ��Name$ MainLeftTabControl��$��0�� �� TabStripPlacement$
 Left=����	#FF00D1E5$��0q�.@���    LCB-0001#���   $��80��$��80��$��Stretch=�$��Stretch=�$��0,0,-3,0q�$
��Bold"�  TabItemStyle#���  &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=����� 	 �� ImageSource$<	 6/PublicResources;component/images/lockcontrolboard.png��.���� $��5q�.+��� -     LCB-0002#���  
�������$��0,6,0,6q�$��Center=��� ._��� $0��*/PublicResources;component/images/line.png���� -     LCB-0003#���  
�������$��0,6,0,6q�$��Center=��� ._��� $0��*/PublicResources;component/images/line.png����   IDC-0001#���  $��80��$��0,0,-3,0q�$��80��$
��Bold"�#���  $ Display=����� $2	 ,/PublicResources;component/images/idcard.png��.���� $��5q�.+��� -     IDC-0002#���  
�������$��0,6,0,6q�$��Center=��� ._��� $0��*/PublicResources;component/images/line.png���� -     IDC-0003#���  
�������$��0,6,0,6q�$��Center=��� ._��� $0��*/PublicResources;component/images/line.png����   DGV-0001#���  $��80��$��0,0,-3,0q�$��80��$
��Bold"�#���  $ Display=����� $2	 ,/PublicResources;component/images/finger.png��.���� $��5q�.+��� -     DGV-0002#���  
�������$��0,6,0,6q�$��Center=��� ._��� $0��*/PublicResources;component/images/line.png����  	 QRC-0001#��� 	 $��80��$��0,0,-3,0q�$��80��$
��Bold"�#���  $ Display=����� $2	 ,/PublicResources;component/images/qrcode.png��.���� $��5q�.+��� -    
 QRC-0002#��� 
 
�������$��0,6,0,6q�$��Center=��� ._��� $0��*/PublicResources;component/images/line.png����   CMR-0001#���  $��80��$��0,0,-3,0q�$��80��$
��Bold"�#���  $ Display=����� $2	 ,/PublicResources;component/images/camera.png��.���� $��5q�.+��� -	     CMR-0002#���  
�������$��0,6,0,6q�$��Center=��� ._��� $0��*/PublicResources;component/images/line.png���� -
     CMR-0003#���  
�������$��0,6,0,6q�$��Center=��� ._��� $0��*/PublicResources;component/images/line.png����   UHF-0001#���  $��80��$��0,0,-3,0q�$��80��$
��Bold"�#���  $ Display=����� $0	 */PublicResources;component/images/rfid.png��.���� $��5q�.+��� -     UHF-0002#���  
�������$��0,6,0,6q�$��Center=��� ._��� $0��*/PublicResources;component/images/line.png���� -     UHF-0003#���  
�������$��0,6,0,6q�$��Center=��� ._��� $0��*/PublicResources;component/images/line.png��� $��1��$��2��
�������.+��� -   
 ��Name$
 spliter��$��32��$��64��$��-8,0,0,0q� � Cursor$
 Hand��$
��Left=����� $7	 1/PublicResources;component/images/panelexpand.png�� j� Stretch$ UniformToFill=� � -     �Name$ pageContainer��$��2����.   � NavigationUIVisibility$ Hidden=�