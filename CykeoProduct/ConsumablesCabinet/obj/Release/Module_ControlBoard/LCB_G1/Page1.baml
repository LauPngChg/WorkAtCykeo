   M S B A M L   `   `   `  ���� M  IConsumablesCabinet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullm;clr-namespace:ConsumablesCabinet.Module_ControlBoard.LCB_G1-ConsumablesCabinet.Module_ControlBoard.LCB_G1  9    3ConsumablesCabinet.Module_ControlBoard.LCB_G1.Page1   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Mlocal;clr-namespace:ConsumablesCabinet.Module_ControlBoard.LCB_G1       N� Title$  Page1�� � 	Resources  �� MergedDictionaries �� Source��  �� $@ :/PublicResources;component/styles/BreathLightCheckBox.xaml?��� $? 9/PublicResources;component/styles/LockSwitchCheckBox.xaml?�%    .���  � ShowGridLines .  � RowDefinitions �� $��1* ��� $��7* ��� $��3* �.+�� $��1�� .  � ColumnDefinitions �� $��3* ��� $��1* �.+��� $��0��   LCB-0004#���   $��Center=�$��Center=�$��50(����	#50000000� $��1�� .  �� $��1* ��� $��2* ��� $��1* �.+�� $��0�� �� $��1* ��� $��1* � �� $��4* ��� $��1* �.+��� -    ��Name$ checkboxLock1��  
LockSwitch#��[ $
��Left=�$��Bottom=�$��0��$��0��$��	20,20,0,0q��� -   $ checkboxLock2��#��[ $
��Left=�$��Bottom=�$��0��$��1��$��	20,20,0,0q���   LCB-0005#���  $��0��$��1��$	��Top=�$
��Left=�$��20,0,0,0q���   LCB-0006#���  $��1��$��1��$	��Top=�$
��Left=�$��20,0,0,0q�� $��1�� �� $��1* ��� $��1* � �� $��4* ��� $��1* ��� $��4* ��� $��1* �.+��� -   $ checkboxLED1��  BreathLight#��[ $
��Left=�$��Center=�$��	20,25,0,0q�$��0��$��0���� -   $ checkboxLED2��#��[ $
��Left=�$��Center=�$��	20,25,0,0q�$��0��$��1���� -   $ checkboxLED3��#��[ $
��Left=�$��Center=�$��	20,25,0,0q�$��2��$��0���� -   $ checkboxLED4��#��[ $
��Left=�$��Center=�$��	20,25,0,0q�$��2��$��1����   LCB-0007#���  $��0��$��1��$	��Top=�$
��Left=�$��20,0,0,0q���   LCB-0008#���  $��1��$��1��$	��Top=�$
��Left=�$��20,0,0,0q���   LCB-0009#���  $��0��$��3��$	��Top=�$
��Left=�$��20,0,0,0q���   LCB-0010#���  $��1��$��3��$	��Top=�$
��Left=�$��20,0,0,0q�� $��2�� �� $��1* ��� $��1* ��� $��1* � �� $��2* ��� $��3* �.+��� -    ��Name$ comBoxDeviceAddress��$��1��$��0��$��	0,10,20,0q��� -   $ comBoxTagAddress��$��1��$��1��$��	0,10,20,0q���  	 LCB-0011#��� 	 $��0��$��0��$��Right=�$��Bottom=���  
 LCB-0012#��� 
 $��0��$��1��$��Right=�$��Bottom=��� -	   	 ��Name$	 buttonSetAddress��  LCB-0013#���  $��0��$��2��$��2��$��	10,5,20,5q�� $��2��$��0,0,0,30q� �� $��3* ��� $��1* �.+��� -
   
 ��Name$
 
textboxLog��$��20 0 0 0q�� $��1�� �� $��1* ��� $��1* ��� $��1* �.+��� -   $	 buttonGetLockStaus��  LCB-0014#���  $��1��$��0��$��
10,10,20,0q��� -   $	 buttonGetDeviceVersion��  LCB-0015#���  $��1��$��1��$��
10,10,20,0q��� -   $	 buttonClear��  LCB-0016#���  $��1��$��2��$��
10,10,20,0q�