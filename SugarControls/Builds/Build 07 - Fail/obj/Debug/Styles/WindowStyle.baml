   M S B A M L   `   `   `  ����H  DSugarControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SugarControls.SrcSugarControls.Src  5      &     SugarControls.Styles.WindowStyle\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   WindowTemplate �� 
TargetType �Name J� Opacity ��Name � Cursor � RowDefinitions ��Name	 � Icon
 ��Name  ImageButtonStyle F�Name  VSCloseIcon  VSMaximizeIcon  VSMinimizeIcon ��Name � Title � 	Resources �� Triggers  WindowStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value   5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      'srcclr-namespace:SugarControls.Src  5        5      �� 5
   
   $6 0/SugarControls;component/Themes/Icons/Icons.xaml?�6   �� 5   
   $; 5/SugarControls;component/Styles/ImageButtonStyle.xaml?�6   %o
  &	        7  7  7  7  7  7  &	 �	    7   �� 5      " �6-   .R�5   
   � $ 
ResizeGrid��6   
�������$ 0Q�5   "   .+�5      �� $ LeftResizer��6   $��5��5      $��	0,10,0,10q�5      $
��Left=�5      
������ $ SizeWE��5      �� 5!      $ LeftTopResizer��6   $��10��5"      $��10��5#      $
��Left=�5$      $	��Top=�5%      
������ $ SizeNWSE��5'      �� 5)      $ 
TopResizer��6   $��5��5*      $��	10,0,10,0q�5+      $	��Top=�5,      
������ $ SizeNS��5.      �� 50      $ RightTopResizer��6   $��10��51      $��10��52      $��Right=�53      $	��Top=�54      
������ $ SizeNESW��56      �� 58      $ RightResizer��6   $��5��59      $��	0,10,0,10q�5:      $��Right=�5;      
������ $ SizeWE��5=      �� 5?      $ RightBottomResizer��6   $��10��5@      $��10��5A      $��Right=�5B      $��Bottom=�5C      
������ $ SizeNWSE��5E      �� 5G      $ BottomResizer��6   $��5��5H      $��	10,0,10,0q�5I      $��Bottom=�5J      
������ $ SizeNS��5L      �� 5N      $ LeftBottomResizer��6   $��10��5O      $��10��5P      $
��Left=�5Q      $��Bottom=�5R      
������ $ SizeNESW��5T      �� 5X      $ 
MainBorder��6   #��z��5Y   	   #��z��5Z   	   #��z��5[   	   $��5,5,5,5q�5\   	   ._�5^      � $ MainGrid��6    5_      �� 5`      $��22 �6(   �� 5a      .+�5g      �� $ PART_TITLEBAR��6   -   5        
������ ._�5k      ]� .+�5m      �� $ 	PART_ICON��6/   $��5,0,0,0q�5n      #��z	 5o      �� 5q      $
 
PART_CLOSE��6%   -   5        $��30��5r   	   $��Right=�5s   	   $��Center=�5t   	   $��Center=�5u   	   8��  .��5x   "   F� $ 	ClosePath��6'   8�� 5y   	   5z      �� 5|      $
 PART_MAXIMIZE��6%   -   5        $��30��5}   	   $��Right=�5~   	   $��Center=�5   	   $��Center=�5�   	   8�� .��5�   "   F� $ MaximizePath��6'   8�� 5�   	   5�      �� 5�      $
 PART_MINIMIZE��6%   -   5        $��30��5�   	   $��Right=�5�   	   $��Center=�5�   	   $��Center=�5�   	   8�� .��5�   "   F� $ MinimizePath��6'   8�� 5�   	   5�      �� 5�      $ Title��6(   #��z 5�   	   ���	#FF879999$��Center=�5�   	   $��10,0,0,0q�5�   	   5�      5�      �� 5�      $��1��6'   #��z��64   5�      5�      5�       5�   
   ��5�       5�   
   5�      �� 5�      " �6    .�5�   
   ��  � ��8   6%    5�   
   P� 5�       �@�IsActive .  . �5�      ��  � ��
 ���� 60   5�      5�      5�      