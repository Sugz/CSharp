   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5       File_Renamer   File_Renamer.DataGridMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ]ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     5      -   5          �Name$  PopupDG��5      $��
MousePoint=�5
   *    � UseLayoutRounding .  J� SnapsToDevicePixels .  � 	Resources 5         MenuItemSelectionFill �� EndPoint �� 
StartPoint � Color � Offset  	Checkmark �� 
TargetType	 �� 
ResourceId
 �� TypeInTargetAssembly ��Name �� RadiusY �� RadiusX �� Triggers P� Value P� Property �� 
TargetName �� Property �� Value  MenuItemPressedFill  SubMenuBackgroundBrush �� Color  UpArrow  MenuScrollButton �� 
TargetType �� BasedOn ��Name $  MenuScrollingVisibilityConverter  	DownArrow � ColumnDefinitions � RowDefinitions �� CanContentScroll �� LineUpCommand �� RelativeSource `� ConverterParameter `� 	Converter �� FallbackValue  �� Path! �� LineDownCommand" F�Name# � AllowsTransparency$ � HorizontalOffset% � VerticalOffset5   /Microsoft.Windows.Themes.SystemDropShadowChrome&  Name'   Color( ��Name) ��Name* �� ClearTypeHint+ �� ElementName, ��Name-  'System.Windows.Input.KeyboardNavigation-   DirectionalNavigation. � IsSharedSizeScope/   TabNavigation0 P� 
SourceName  
RightArrow1 z� SharedSizeGroup2 �� CornerRadius3 m� InputGestureText 	 MenuItemStyle4 �� AncestorType5 �� Triggers��%\6  &	        &	 �     (�� �     5      $	 SubmenuItemTemplateKey��"
 m�)&	     &	 �    &	 �    &	 +    &	 �    &	     (�� >    5G   
   $	 MenuScrollViewer��"
 �)7  7  7  7  7  7  (�� k    5t      $	 TopLevelHeaderTemplateKey��"
 m�)7  7  7  7  7  (�� �    5�      $	 TopLevelItemTemplateKey��"
 m�)7  7  &	 �!    (�� 
"    5�      $	 SubmenuHeaderTemplateKey��"
 m�)7  7  7  7  7   &		 k0    �� 5      $	 0,1&�66   $	 0,0&�6E   .��5      � $ 	#34C5EBFF��6   $ 0Q�6$   � 5      $ 	#3481D8FF��6   $ 1Q�6$   5      �5      <8M 0,5.1 L 1.7,5.2 L 3.4,7.1 L 8,0.4 L 9.2,0 L 3.3,10.8 Z�6Y   �� 5      " m�6}   .R�5      �  . .+�5      �� $ InnerBorder��6   $��1q�6%   $ 2��60   $ 2��6<   � 5      .+�5      �� $��2��6   $��Header��6(   #��z��6?   ��. # z 6}   5      5       5      P� 5       6   Z�  �@m�IconP� 5       �@m�	IsChecked . 6#   P� 5       �@m�IsHighlighted . . �5      �� $ InnerBorder��6     � �� �	#40FFFFFF69   5      P� 5       � {� .  . �5      ��  � �� �	#FF9A9A9A6$   5       5"      �� 5#      $	 0,1&�64   $	 0,0&�6C   .��5$      � $ 	#28717070��6   $ 0Q�6$   � 5%      $ 	#50717070��6   $
 0.75Q�6$   � 5&      $ 	#90717070��6   $ 1Q�6$   5'      �� 5(      $ 	#FFF5F5F5��63   �5)      M 0,4 L 3.5,0 L 7,4 Z�64   �� 5*      " ��66    6#   Z� .�5+      ��  �@��	ClickMode$ Hover=�6!   �� 5,       � ��$ 0��6    �� 5-       � ��$ 0��6!   �� 5.       � �� 5/      �� 50      " ��6   .R�51      ]� 
������  . .+�52   	   �� $ R1��6   $��Right=�6   
������ $��1��6I   �� 53   	   $ B1��6   $��Bottom=�6   
������ $��1��6J   �� 54   	   $ L1��6   $
��Left=�6   
������ $��1��6H   �� 55   	   $ T1��6   $	��Top=�6   
������ $��1��6G   �� 56   	   $ ContentContainer��6   $��Center=�64   $��2,2,2,2q�6Q   $��Center=�6b   57   	    58      P� 59   	    � �� . . �5:   
   �� $ R1��6!   # � ��61    � ���� 5;   
   $ B1��6!   # � ��61    � ���� 5<   
   $ L1��6!   # � ��61    � ���� 5=   
   $ T1��6!   # � ��61    � ���� 5>   
   $ ContentContainer��6#    � ��$ 3,3,1,1q�6A   5?   
   5A      5C      5D      l� 5E      6%   �5F      M 0,0 L 3.5,4 L 7,0 Z�66   �� 5G      " ��6�    6u   Z� .�5H      ��  � ��$ Hidden=�65   �� 5I       � ��$
 Auto=�63   �� 5J       � �� 5K      �� 5L      " ��6   .R�5M      �  .  5N   	   �� 5O   
   $��* �6    5Q   	   �� 5R   
   $
��Auto �6   �� 5S   
   $��* �6   �� 5T   
   $
��Auto �6   .+�5V   	   �� $��0��6   $��1��6    ._�5W   
   �� # z��6!   #��z��6W   5X   
   �� 5Y   	   $��0��6   #��Z 6p   |�.  $��0��6�   8��  ��6&   ��  �� *TemplatedParent+y�5Z   
   `� 5[      $ 0��6   8  $ Visibility.Collapsed��6m   .1�5\      �� $)  #ComputedVerticalScrollBarVisibility�6    6?   �� *TemplatedParent+�� 5]      $  VerticalOffset�6    6*   �� *TemplatedParent+�� 5^      $  ExtentHeight�6    6(   �� *TemplatedParent+�� 5_      $  ViewportHeight�6    6*   �� *TemplatedParent+5`      .��5b   
   F� 8�� #��� ��6/   5c   
   �� 5d   	   $��0��6   #��Z! 6p   |�.  $��2��6�   8�� ��6&   ��  �� *TemplatedParent+y�5e   
   `� 5f      $	 100��6   8  $ Visibility.Collapsed��6o   .1�5g      �� $)  #ComputedVerticalScrollBarVisibility�6    6?   �� *TemplatedParent+�� 5h      $  VerticalOffset�6    6*   �� *TemplatedParent+�� 5i      $  ExtentHeight�6    6(   �� *TemplatedParent+�� 5j      $  ViewportHeight�6    6*   �� *TemplatedParent+5k      .��5m   
   F� 8�� #��� ��61   5n   
   5o   	   5p      5r      5s      �� 5t      " m�6�   .R�5u      �  . .+�5v      �� $ OuterBorder��6   $ 2��6%   $ 2��61   �� 5w      $ Bg��6   #��z��6   $��1q�6@   $ 1��6K   $ 1��6W   #��z��6c   $��1��6�   �� 5x      $ InnerBorder��6   $��2q�6%   ]� 5y      .+�5z      �� $
 Icon��6   $
��Icon��6&   $��4,0,6,0q�6;   # z 6L   $��Center=�6�   F� 5{      $" 
GlyphPanel��6   8��  #��z��6B   $��LeftToRight=�6f   $��7,0,0,0q�6�   $y�	Collapsed=�6�   $��Center=�6�   �� 5|      $��Header��6   #��z��6/   ��. # z 6m   5}      � 5~      $  
PART_Popup��6   # . |�.  $$ 1��6L   #��� -�6�   $��Bottom=�6  $% -1��6  ��6a   �� *IsSubmenuOpen+ �� *TemplatedParent+.��5        $
& Shdw��6%   $' Transparent��63   ._�5�      �� $( SubMenuBorder��6   ���	#FF959595$��1q�6>   8�� ._�5�   	   �� $) SubMenuScrollViewer��6   $	��1,0q�63   ��6@   C� *�� $	 MenuScrollViewer��"
 �+.��5�   
   � $* Enabled=�6   .+�5�      �� $
��Left=�6   $��0��6-   $	��Top=�68   $��0��6P   .+�5�      �� $ 
OpaqueRect��6   8�� ��6Y   �� *ActualHeight+$+ SubMenuBorder����6�   �� *ActualWidth+$+ SubMenuBorder��5�      �� 5�      ���#F1F1F1$
��Left=�6$   $	��1,2q�6?   $ 2��6L   $ 2��6X   $��28��6d   �� 5�      ���#E2E3E3$
��Left=�6$   $��29,2,0,2q�6?   $��1��6Q   �� 5�      
�������$
��Left=�6"   $��30,2,0,2q�6=   $��1��6O   �� 5�      $, ItemsPresenter��6   $- Cycle=�62   . . $��2q�6�   # z 6�   $/ Cycle=�6�   5�      5�   
   5�   	   5�      5�      5�       5�      P� 5�      " �@m�IsSuspendingPopupAnimation . . �5�      �� $ 
PART_Popup��6(    � ��$
 None=�6@   5�      P� 5�       6   Z�  �@m�Icon. �5�      �� $
 Icon��6$    � y�$ 	Collapsed=�66   5�      P� 5�       �@m�	IsChecked . . �5�      �� $ 
GlyphPanel��6$    � y�$ Visible=�6<   �� 5�      $
 Icon��6$    � y�$ 	Collapsed=�66   5�      P� 5�      $0 
PART_Popup��6'    �@�HasDropShadow . . �5�      �� $
 Shdw��6     � ��$ 0,0,5,5q�62   �� 5�      $
 Shdw��6    �@ Color$ 	#71000000��61   5�      P� 5�       �@m�IsHighlighted . . �5�      �� $ Bg��6     � �� �	#9071707060   �� 5�      $ OuterBorder��6     � �� �	#50FFFFFF69   �� 5�      $ InnerBorder��6     � �� �	#50FFFFFF69   5�      P� 5�       �@J�IsKeyboardFocused . . �5�      �� $ Bg��6     � �� �	#E071707060   �� 5�      $ Bg��6   8   � ��6.   �� 5�      $ InnerBorder��6     � �� �	#5074727269   5�      P� 5�       �@m�IsSubmenuOpen . . �5�      �� $ Bg��6     � �� �	#E071707060   �� 5�      $ Bg��6   8   � ��6.   �� 5�      $ InnerBorder��6     � �� �	#5074727269   5�      P� 5�       � {� .  . �5�      ��  � �� �	#FF9A9A9A6$   �� 5�      $ 
GlyphPanel��6    � �� �#84858966   5�      P� 5�      $0 SubMenuScrollViewer��67    � �� .  . �5�      �� $ 
OpaqueRect��6$    6<   �� *VerticalOffset+$+ SubMenuScrollViewer�� �@��Top�� 5�      $ 
OpaqueRect��6%    6=   �� *HorizontalOffset+$+ SubMenuScrollViewer�� �@��Left5�      5�      �� 5�      " m�6~   .R�5�      �  . .+�5�      �� $ OuterBorder��6   $ 2��6%   $ 2��61   �� 5�      $ Bg��6   #��z��6   $��1q�6@   $ 1��6K   $ 1��6W   #��z��6c   $��1��6�   �� 5�      $ InnerBorder��6   $��2q�6%   ]� 5�      .+�5�      �� $
 Icon��6   $
��Icon��6&   $��4,0,6,0q�6;   # z 6L   $��Center=�6�   F� 5�      $" 
GlyphPanel��6   8��  #��z��6B   $��LeftToRight=�6f   $��7,0,0,0q�6�   $y�	Collapsed=�6�   $��Center=�6�   �� 5�      $��Header��6   #��z��6/   ��. # z 6m   5�      5�       5�      P� 5�       6   Z�  �@m�Icon. �5�      �� $
 Icon��6$    � y�$ 	Collapsed=�66   5�      P� 5�       �@m�	IsChecked . . �5�      �� $ 
GlyphPanel��6$    � y�$ Visible=�6<   �� 5�      $
 Icon��6$    � y�$ 	Collapsed=�66   5�      P� 5�       �@m�IsHighlighted . . �5�      �� $ Bg��6     � �� �	#9071707060   �� 5�      $ OuterBorder��6     � �� �	#50FFFFFF69   �� 5�      $ InnerBorder��6     � �� �	#50FFFFFF69   5�      P� 5�       �@J�IsKeyboardFocused . . �5�      �� $ Bg��6     � �� �	#E071707060   �� 5�      $ Bg��6   8   � ��6.   �� 5�      $ InnerBorder��6     � �� �	#5074727269   5�      P� 5�       � {� .  . �5�      ��  � �� �	#FF9A9A9A6$   �� 5�      $ 
GlyphPanel��6    � �� �#84858966   5�      5�      �5�      M 0,0 L 4,3.5 L 0,7 Z�67   �� 5�      " m�6   .R�5�      �  . .+�5�      �� $ Bg��6   #��z��6   $ 2��6@   $ 2��6L   #��z��6X   $��1��6   �� 5�      $ InnerBorder��6   $��1q�6%   $ 2��60   $ 2��6<   
������ $��1��6]   � 5�       5�      �� 5�      $��24��6   $1 MenuItemIconColumnGroup��6'   $
��Auto �6Q   �� 5�      $��4 �6   �� 5�      $��* �6   �� 5�      $��37 �6   �� 5�      $1 MenuItemIGTColumnGroup��6   $
��Auto �6B   �� 5�      $��17 �6   .+�5�      �� $
 Icon��6   $
��Icon��6&   $��1q�6;   # z 6F   $��Center=�6�   �� 5�      $( 
GlyphPanel��6   ���#CDD3E6$��1q�68   ���#E6EFF4$2 3��6a   $��22��6r   $��1q�6~   $y�Hidden=�6�   $��22��6�   ._�5�      F� $" Glyph��6   8��  ���#0C12A1$��LeftToRight=�6M   $��11��6i   $��9��6u   5�      �� 5�      $��2��6   $��Header��6(   #��z��6?   ��. # z 6}   �� 5�      $��4��6   #��z��6!   #��z3 6D   $y�	Collapsed=�6n   F� 5�      $��5��6   8�� #��z��6?   $��4,0,0,0q�6c   $��Center=�6t   5�      � 5�      $  
PART_Popup��6   # . |�.  $$ -2��6L   #��� -�6�   $��Right=�6	  $% -3��6  ��6b   �� *IsSubmenuOpen+ �� *TemplatedParent+.��5�        $
& Shdw��6%   $' Transparent��63   ._�5�      �� $( SubMenuBorder��6   ���	#FF959595$��1q�6>   8�� ._�5�   	   �� $) SubMenuScrollViewer��6   $	��1,0q�63   ��6@   C� *�� $	 MenuScrollViewer��"
 �+.��5�   
   � $* Enabled=�6   .+�5�      �� $
��Left=�6   $��0��6-   $	��Top=�68   $��0��6P   .+�5�      �� $ 
OpaqueRect��6   8�� ��6Y   �� *ActualHeight+$+ SubMenuBorder����6�   �� *ActualWidth+$+ SubMenuBorder��5�      �� 5�      ���#F1F1F1$
��Left=�6$   $	��1,2q�6?   $ 2��6L   $ 2��6X   $��28��6d   �� 5�      ���#E2E3E3$
��Left=�6$   $��29,2,0,2q�6?   $��1��6Q   �� 5�      
�������$
��Left=�6"   $��30,2,0,2q�6=   $��1��6O   �� 5�      $, ItemsPresenter��6   $- Cycle=�62   . . $��2q�6�   # z 6�   $/ Cycle=�6�   5�      5�   
   5�   	   5      5     5      5     P� 5     " �@m�IsSuspendingPopupAnimation . . �5     �� $ 
PART_Popup��6(    � ��$
 None=�6@   5     P� 5      �@m�IsHighlighted . . �5     �� $ InnerBorder��6     � �� �	#D1DBF4FF69   5	     P� 5
      6   Z�  �@m�Icon. �5     �� $
 Icon��6$    � y�$ 	Collapsed=�66   5     P� 5      �@m�	IsChecked . . �5     �� $ 
GlyphPanel��6$    � y�$ Visible=�6<   �� 5     $
 Icon��6$    � y�$ 	Collapsed=�66   5     P� 5     $0 
PART_Popup��6'    �@�HasDropShadow . . �5     �� $
 Shdw��6     � ��$ 0,0,5,5q�62   �� 5     $
 Shdw��6    �@ Color$ 	#71000000��61   5     P� 5      �@m�IsHighlighted . . �5     �� $ Bg��6   8   � ��6.   �� 5     $ Bg��6     � �� �	#8571CBF160   5     P� 5      � {� .  . �5     ��  � �� �	#FF9A9A9A6$   �� 5     $ 
GlyphPanel��6$    � �� �#EEE9E96<   �� 5     $ 
GlyphPanel��6%    � �� �#DBD6D66=   �� 5     $ Glyph��6    � �� �#84858961   5     P� 5     $0 SubMenuScrollViewer��67    � �� .  . �5      �� $ 
OpaqueRect��6$    6<   �� *VerticalOffset+$+ SubMenuScrollViewer�� �@��Top�� 5!     $ 
OpaqueRect��6%    6=   �� *HorizontalOffset+$+ SubMenuScrollViewer�� �@��Left5"     5$     �� 5%     " m�6    .�5&     ��  � �� 62   �� *HorizontalContentAlignment+ �� "4 ���� 5'      � �� 60   �� *VerticalContentAlignment+ �� "4 ���� 5(      � ��
 ���� 6"   �� 5)      �@��PanningMode$
 Both=�60   �� 5*      �@��IsFlicksEnabled .  6.   �� 5+      � �� 6    C� *�� $	 SubmenuItemTemplateKey��"
 m�+5 5,     P� 5-      �@m�Role$ TopLevelHeader=�6   . �5.     ��  � ��$ 7,2,8,3q�6!   �� 5/      � �� 6"   C� *�� $	 TopLevelHeaderTemplateKey��"
 m�+50     P� 51      �@m�Role$ TopLevelItem=�6   . �52     ��  � ��$ 7,2,8,3q�6!   �� 53      � �� 6"   C� *�� $	 TopLevelItemTemplateKey��"
 m�+54     P� 55      �@m�Role$ SubmenuHeader=�6   . �56     ��  � ��$ 2,3,2,3q�6!   �� 57      � �� 6"   C� *�� $	 SubmenuHeaderTemplateKey��"
 m�+58     P� 59      �@m�Role$ SubmenuItem=�6   . �5:     ��  � ��$ 2,3,2,3q�6!   5;     5=     5>     .��5?     �� 
���   �$��1q�6   $
��Left=�62   $	��Top=�6M   $��0,0,-125,-40.75q�6e   $2 5��6~    
 Brush_45_45_45#��� 
 6�   $	��125��6�   $��40��6�   6 J� Effect6 5@     3  -System.Windows.Media.Effects.DropShadowEffect  5A     ._�5C     � $��0q�6	   .+�5D     m� -   5        $
��Open��5D     #��� 	 6   $��5,0,0,0q�6D   $	��Top=�6V     Brush_170_170_170#���  6n   6�   m� 5E     -   5        $��Show in Explorer��5E     #��� 	 6(   $��5,0,0,0q�6P   $��0,20,0,0q�6b   $	��Top=�6t   #���  6�   6�   5F     5G     5H     