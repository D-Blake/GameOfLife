   M S B A M L   `   `   `  ����L  HGameOfLifeProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GameOfLifeProjectGameOfLifeProject  5   	   K*clr-namespace:GameOfLifeProject.ConvertersGameOfLifeProject.Converters  5   	   "    GameOfLifeProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:GameOfLifeProject     5   	   ;conv*clr-namespace:GameOfLifeProject.Converters     5   	   
���   �  � 
ResizeMode$  NoResize=�5
   	    � Title$ GameOfLifeWindow��5   	   $	��350��6"   $	��525��6/   .��5      � .+�5-   
   � $y�Visible=�6    � ColumnDefinitions 5.      �� 5/      $��2* �6#   �� 50      $��* �6#    � RowDefinitions 53      .+�56      �� $��1��6   
�������$��5q�69   ._�57      �� $��Bottom=�6   $��10q�68   .+�5:      � -   5         �Name$ throttleGrid��5:       5;      �� 5<      �� 5=      .+�5?      �� $��Throttle��6    
�������63   �� 5@      
�������$��1��63   ��6C   ��  �� Path$ Throttle�5A      �� 5B      -   5         ��Name$ throttleSlider��5B       � Minimum$ 0Q�65    � Maximum$
 1000Q�6A   	 � SmallChange$		 100Q�6P   
 � Value
 6b   �� $ Throttle� �� Mode$ TwoWay=� � ToolTip 5C      _� 5D      ��6&   �� $ Throttle�5F      � 5I      -   5        $ XGrid��5I       5J      �� 5K      �� 5L      .+�5N      �� $��X Slider��6    
�������63   �� 5O      
�������$��1��63   ��6C   �� $ GridX�5P      �� 5Q      -   5        $ xSlider��5Q      $ 10Q�6.   $	 100Q�6;   $	 1Q�6I   
 6Y   �� $ GridX�$ TwoWay=� 5R      _� 5S      ��6&   �� $ GridX�5U      � 5X      -   5        $ YGrid��5X       5Y      �� 5Z      �� 5[      .+�5]      �� $��Y Slider��6    
�������63   �� 5^      
�������$��1��63   ��6C   �� $ GridY�5_      �� 5`      -   5        $ ySlider��5`      $ 10Q�6.   $	 100Q�6;   $	 1Q�6I   $��
0, 0, 0, 5q�6Y   
 6m   �� $ GridY�$ TwoWay=� 5a      _� 5b      ��6&   �� $ GridX�5d      �� 5g      -   5         ��Name$ NewGridButton��5g   5   
����iA�$��5q�6L   $��New Grid��6X   $��Bottom=�6k   $��70��6�   $��20��6�   6�   �� 5h      -   5        $ OneStepButton��5h   4   
����iA�$��5q�6K   $��One Step��6W   $��Bottom=�6j   $��70��6�   $��20��6�   6�   �� 5i      -	   5        $ 
PlayButton��5i   4   
����iA�$��5q�6H   $
��Play��6T   $��Bottom=�6c   $��70��6~   $��20��6�   6�   �� 5j      -
   5        $ PauseButton��5j   4   
����iA�$��5q�6I   $��Pause��6U   $��Bottom=�6e   $��70��6�   $��20��6�   6�   �� 5k      -   5        $ RandomButton��5k   4   
����iA�$��5q�6J   $��Random��6V   $��Bottom=�6g   $��70��6�   $��20��6�   6�   5m      5n      A� 5q      -   5         A�Name$ playGrid��5q      $��0��6,   5r      5t      5u      5v      