   M S B A M L   `   `   `  ����C  ?TestMode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TestModeTestMode  5          TestMode.Page1   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:TestMode     5        N� Title$  Page1��5       � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $@ :/PublicResources;component/styles/MainTabControlStyle.xaml?�6%   %    5      .��5      � -   5         �Name$
 grid��5      ���	#FF333333 � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $��1* �6   �� 5      $	��20* �6   .+�5   
   �� -   5         ��Name$ MainLeftTabControl��5      $��0��61    �� TabStripPlacement$
 Left=�6A   ���	#FF00D1E5$��0q�6r   .@�5      �� -   5         ��Name$ iteamControlBoard��5         LCB-0001#���   61   $��80��6V   $��80��6a   $��Stretch=�6m   $��Stretch=�6�   $��0,0,-3,0q�6�   $
��Bold"�6�     TabItemStyle#���  6�   &   System.Windows.Media.TextOptions	   TextFormattingMode$	 Display=�6  ��5      �� 5      
 �� ImageSource$<
 6/PublicResources;component/images/lockcontrolboard.png��6!   .��5      �� $��5q�6   .+�5      �� -   5          LCB-0002#���  5      
�������$��0,6,0,6q�6T   $��Center=�6f   6�   �� 5      ._�5      �� $0��*/PublicResources;component/images/line.png��6    5      �� 5       -   5          LCB-0003#���  5       
�������$��0,6,0,6q�6T   $��Center=�6f   6�   �� 5!      ._�5"      �� $0��*/PublicResources;component/images/line.png��6    5#      5$      5%      �� 5&      -   5        $ iteamIDCard��5&        IDC-0001#���  6,   $��80��6P   $��0,0,-3,0q�6\   $��80��6n   $
��Bold"�6y   #���  6�   $	 Display=�6�   ��5'      �� 5(      $2
 ,/PublicResources;component/images/idcard.png��6!   .��5*      �� $��5q�6   .+�5+      �� -   5          IDC-0002#���  5+      
�������$��0,6,0,6q�6T   $��Center=�6f   6�   �� 5,      ._�5-      �� $0��*/PublicResources;component/images/line.png��6    5.      �� 5/      -   5          IDC-0003#���  5/      
�������$��0,6,0,6q�6T   $��Center=�6f   6�   �� 50      ._�51      �� $0��*/PublicResources;component/images/line.png��6    52      53      54      �� 55      -	   5        $ iteamDigitalVein��55        DGV-0001#���  62   $��80��6V   $��0,0,-3,0q�6b   $��80��6t   $
��Bold"�6   #���  6�   $	 Display=�6�   ��56      �� 57      $2
 ,/PublicResources;component/images/finger.png��6!   .��59      �� $��5q�6   .+�5:      �� -
   5          DGV-0002#���  5:      
�������$��0,6,0,6q�6T   $��Center=�6f   6�   �� 5;      ._�5<      �� $0��*/PublicResources;component/images/line.png��6    5=      5>      5?      �� 5@      -   5        $ iteamQRCode��5@       	 QRC-0001#��� 	 6,   $��80��6P   $��0,0,-3,0q�6\   $��80��6n   $
��Bold"�6y   #���  6�   $	 Display=�6�   ��5A      �� 5B      $2
 ,/PublicResources;component/images/qrcode.png��6!   .��5D      �� $��5q�6   .+�5E      �� -   5         
 QRC-0002#��� 
 5E      
�������$��0,6,0,6q�6T   $��Center=�6f   6�   �� 5F      ._�5G      �� $0��*/PublicResources;component/images/line.png��6    5H      5I      5J      �� 5K      -   5        $ iteamCamera��5K        CMR-0001#���  6-   $��80��6Q   $��0,0,-3,0q�6]   $��80��6o   $
��Bold"�6z   #���  6�   $	 Display=�6�   ��5L      �� 5M      $2
 ,/PublicResources;component/images/camera.png��6!   .��5O      �� $��5q�6   .+�5P      �� -   5          CMR-0002#���  5P      
�������$��0,6,0,6q�6T   $��Center=�6f   6�   �� 5Q      ._�5R      �� $0��*/PublicResources;component/images/line.png��6    5S      �� 5T      -   5          CMR-0003#���  5T      
�������$��0,6,0,6q�6T   $��Center=�6f   6�   �� 5U      ._�5V      �� $0��*/PublicResources;component/images/line.png��6    5W      5X      5Y      �� 5Z      -   5        $ iteamUHF_RFID��5Z        UHF-0001#���  6.   $��80��6R   $��0,0,-3,0q�6^   $��80��6p   $
��Bold"�6{   #���  6�   $	 Display=�6�   ��5[      �� 5\      $0
 */PublicResources;component/images/rfid.png��6!   .��5^      �� $��5q�6   .+�5_      �� -   5          UHF-0002#���  5_      
�������$��0,6,0,6q�6T   $��Center=�6g   6�   �� 5`      ._�5a      �� $0��*/PublicResources;component/images/line.png��6    5b      �� 5c      -   5          UHF-0003#���  5c      
�������$��0,6,0,6q�6T   $��Center=�6g   6�   �� 5d      ._�5e      �� $0��*/PublicResources;component/images/line.png��6    5f      5g      5h      5i      � 5j   
   $��1��6   $��2��6   
�������.+�5k      �� -   5         ��Name$ spliter��5k      $��32��6(   $��64��63   $��-8,0,0,0q�6?    � Cursor$
 Hand��6Q   $
��Left=�6_   ��5l      �� 5m      $7
 1/PublicResources;component/images/panelexpand.png��6!    j� Stretch$ UniformToFill=�6a   5o      5p       � 5q   
   -   5          �Name$ pageContainer��5q      $��2��6(   ��.   � NavigationUIVisibility$ Hidden=�6]   5r      5s      