   M S B A M L   `   `   `  ����
  Quiz47    Quiz47.TestWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
TestWindow��5   	   $	��300��6   $	��465��6)    +� FocusedElement 5   	   ��  �� ElementName$ 	firstName��.��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5	      $
��auto �6   �� 5
      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��_First Name:��5       �� Target 5      �� $ 	firstName��5      �� 5   
   -   5         ��Name$ 	firstName��5      $��1��5      �� 5   
   $��1��6   $��_Last Name:��5       5      �� $ lastName���� 5   
   -   5        $ lastName��5      $��1��5      $��1��5      �� 5   
   $��2��6   $��Se_x:��5       5      �� $
 male��� 5    
   $��2��6   $��1��5!      $��Center=�5"      .+�5#      	� -   5         	�Name$
 male��5#       	� 	GroupName$	 sex��5$      $
��Male��5%      $��3q�5&      	� 5'      $	 sex��6   $��Female��5(      $��3q�5)      5*      �� 5+   
   $��3��6   $��_Education:��5,       5-      �� $ 
highSchool��� 5.   
   $��3��6   $��1��5/      .+�50      �� -   5        	 ��Name$	 
highSchool��50      $��High School��51      $��2q�52      �� 53      $��
Bachelor's��6   $��2q�54      �� 55      $��Master's��6   $��2q�56      �� 57      $��	Doctorate��6   $��2q�58      �� 59      �� 5:      
����  �$��MainWindow.xaml?�5;      .�6   
Go to Main5=      5>      5?      �� 5@   
   $��4��6   $��Additional _Notes:��5A       5B      �� $ additionalNotes���� 5D   
   -   5        $ additionalNotes��5D      $��4��5E      $��1��5F      
 �� AcceptsReturn
 .  �� 
AcceptsTab .  �� TextWrapping$
 Wrap=�5I      $��Stretch=�5J       �� 	IsEnabled . 5K      �� 5L   
   -   5        $��5��5L      $��1��5M      $��Right=�5N      .��5P      �� .��6   _Save6    5Q      5R      5S      