   M S B A M L   `   `   `  ���� a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  G CFile_Renamer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:File_RenamerFile_Renamer    File_Renamer.App   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ]ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     ,localclr-namespace:File_Renamer       �� 	Resources     HeaderButtonPathStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding �� RelativeSource �� AncestorLevel �� AncestorType	 �� Value  	IconStyle  ButtonFocusVisual
 J� SnapsToDevicePixels �� StrokeDashArray  ButtonNormalBackground �� EndPoint �� 
StartPoint � Color � Offset  ButtonNormalBorder �� Color  HeaderButtonStyle �� 
TargetType �� Triggers P� Property P� Value  ButtonStyle ��Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value � UseLayoutRounding  Brush_90_90_90  Brush_70_70_70 	 Brush_45_45_45 
 TextBoxHintStyle  File_Renamer.TextBoxHint �� CornerRadius �� Padding  ��Name! �� 
TargetName  CheckBoxStroke  CheckRadioFocusVisual  HighLightedBlue  Brush_170_170_170  RadioButtonStyle" �Name# R� KeyTime$ R� Value% ��Name  ToggleButtonStyle  IconStrokeEnabled  InvisibleWhite  Brush_130_130_130  Brush_255_255_255_40  VerticalScrollBarStyle& � RowDefinitions' �� LineUpCommand( J� IsMouseOver  VerticalRepeatButtonStyle+   %Microsoft.Windows.Themes.ScrollChrome)   ScrollGlyph* ]�Name+ ]� DecreaseRepeatButton, �� PageUpCommand # VerticalMiddleRepeatButtonStyle- ]� IncreaseRepeatButton. �� PageDownCommand/ ]� Thumb  VerticalScrollBarThumb0 �� LineDownCommand1 J� RenderTransformOrigin2 �� ScaleY3 �� ScaleX4 �� AngleY5 �� AngleX6 �� Angle7 � ColumnDefinitions8 �� LineLeftCommand  ScrollBarButton9 �� PageLeftCommand ! HorizontalScrollBarPageButton: �� PageRightCommand  ScrollBarThumb; �� LineRightCommand  Brush_110_110_110  HorizontalRepeatButtonStyle<  6System.Windows.Media.Animation.EasingThicknessKeyFrame< p� KeyTime= p� Value> F�Name? �� Stretch % !HorizontalMiddleRepeatButtonStyle  HorizontalScrollBarStyle   VerticalScrollBarPageButton ! HorizontalScrollBarThumb@ J� OpacityMaskA  NameB   RenderMouseOverC   RenderPressedD n� 
IsDraggingE �� 
ResourceIdF �� TypeInTargetAssembly&   System.Windows.Controls.DataGridG �NameH J� OpacityI � Points " DataGridStyleJ   SelectAllCommand7	  1System.Windows.Controls.DataGridHeadersVisibility
K 	  AllL �� ConverterParameter!M   HeadersVisibilityConverterN �� 	ConverterG
  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenterO 
 NameP 	  ColumnQ ��NameR �� CanContentScrollS ��NameT �� ScrollableHeightU � MaximumV �� Orientation*W �� #ComputedVerticalScrollBarVisibilityX �� ViewportHeightY �� ViewportSizeZ � Value[ �� Mode\ ]� 
Conditions] �� Property^ �� Value # DataGridCellStyle*  $System.Windows.Controls.DataGridCell_   FocusBorderBrushKey $ ColumnHeaderGripperStyle % DataGridColumnHeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader3   -Microsoft.Windows.Themes.DataGridHeaderBorder`   CanUserSorta   IsClickableb   	IsPressedc   	IsHoveredd   SortDirectione   SortDirectionf   SeparatorBrushg   SeparatorBrushh   SeparatorVisibilityi   SeparatorVisibilityj n�Name & Brush_200_200_200 ' CheckBoxDGStyle ( SeparatorStyle��%>8  &	        &	 �     &	     &	 f    &	 �    &	     7  7  7  &	 �    7  7  7  &	 6    &	 K    &		 `    &	
 u    &	 )    &	 <    &	 �    &	 �    &	 �    7  7  7  &	 0    7  7  7  &	 n    &	 �    &	 �    &	 �    &	 �    7  7  7  7  7  &	 �    &	 �    7  7  &	 �    7  7 	 &	 �    &	 ~    7  7   7   7  7  &	! -    7  7  &	 !    7  7  7 	 &	 $    &	  �$    &	 p%    &	 &    &	 �&    (�� e'    $"E DataGridSelectAllButtonStyle��"F  )&	" �(    (�� .    *DataGrid.FocusBorderBrushKey+)&	# .    &	$ �/    &	% j0    7 $ 7 $ &	& �1    &	' �1    &	( �4    �� " F�.���  � �� �	#FFAAAAAA ��  �� *IsMouseOver+ �� $ 1��" ��	 True.a���  � �� �	#FFFFFFFF�� " F�.���  �@J�Opacity$	 .15Q� ��  �� *	IsEnabled+ �� $ 1��" ��	 True.a���  �@J�Opacity$ 1Q��� .���  � �� �� .R��� $��2q�
 . #��� ��$��1��$	 1 2R��� $	 0,1&�$	 0,0&�.��� $ #F3F3F3��$ 0Q�� $ #EBEBEB��$	 0.5Q�� $ #DDDDDD��$	 0.5Q�� $ #CDCDCD��$ 1Q��� $ 	#FF707070���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��$ 1q���  � ��# � ����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R�� ���	#00000000.+��� #��z��$��3q���. #
 z
 #��z�� P�  �@J�IsKeyboardFocused . P�  �@d�	IsChecked$
 trueY�P�  � {� .  . ���  � �� �#ADADAD�� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��$ 1q���  � ��# � ����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border�����	#00000000   CommonStates��.   
Normal��  	MouseOver��. �� .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$ border��.g�  $ 0��$ 	#33FFFFFF��  Pressed��  Disabled��._��� #��z��$��0q���. #
 z
 #��z�� .  P�  �@J�IsKeyboardFocused . P�  �@d�	IsChecked$
 trueY�P�  � {� .  . ���  � �� �#ADADAD�� $ 	#FF5A5A5A���� $ 	#FF464646���� $ 	#FF2D2D2D���� "  .���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�FocusVisualStyle Z� ��  �@J�	AllowDrop . ��  � �� �� " ��.R��� $��Border��$ 0��$ 2q�#���  ���	#FF3C3C3C$��1q�._��� $  PART_ContentHost��$��0q� P�  � {� .  . ��� $! Border�� � �� �#EEEEEE�� $! Border�� � �� �#EEEEEE��  � �� �#888888�� $ #8E8F8F���� .���  � �� �� .R��� $��14,0,0,0q�
 . #��� ��$��1��$	 1 2R��� $ 	#FF6C88AA���� $ 	#FFAAAAAA���� " 	�.���  � ��# � ����  � �� �#F4F4F4��  � ��8   ��  � ��$ 1q���  � �� �� " 	�.R�� $
" grid��$��0q����	#00000000   CommonStates��.   
Normal��  	MouseOver��. �� .���� $* $(Shape.Fill).(SolidColorBrush.Color)�$ PART_MOUSEOVER��.g�  $ 0��$ 	#33FFFFFF��  Pressed��  Disabled��  CheckStates��.   Checked��. �� .��T� $ (Shape.Fill)�$ 
PART_CHECK��..�i� $# 0��8$    	Unchecked��  Indeterminate��.+��� $% 
PART_CHECK��$
��Left=�$��40��$	��Top=�$��40�����	#0070B1FF��Z� �� $% PART_MOUSEOVER�����	#00000000$
��Left=�$��40��$	��Top=�$��40����Z� �� #��z��$��0q���. #��z�� P�  � �� . . ��� 8   �@�FocusVisualStyle��  � ��$ 4,0,0,0q�P�  � {� .  . ��� # � �� � ���� " d�.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��$ 1q���  � ��# � ����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " d�.R�� $
" grid��$��0q����	#00000000   CommonStates��.   
Normal��  	MouseOver��. �� .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$
 grid��.g�  $ 0��$ Transparent���� $* $(Shape.Fill).(SolidColorBrush.Color)�$ PART_MOUSEOVER��.g�  $ 0��$ 	#33FFFFFF��  Pressed��  Disabled��  CheckStates��.   Checked��. �� .��T� $ (Shape.Fill)�$ 
PART_CHECK��..�i� $# 0��#$ �    	Unchecked��  Indeterminate��.+��� $% 
PART_CHECK�����	#0070B1FF$
��Left=�$��40��$	��Top=�$��40����Z� �� $% PART_MOUSEOVER�����	#00000000$
��Left=�$��40��$	��Top=�$��40����Z� �� #��z��$��0q���. #
 z
 #��z�� P�  �@J�IsKeyboardFocused . P�  �@d�	IsChecked$
 trueY�P�  � {� .  . ���  � �� �#ADADAD�� $ 	#CCFFFFFF���� �� $ 	#FF828282���� $ 	#66FFFFFF���� " ��.���  �@��IsPressAndHoldEnabled .  ��  �@��IsFlicksEnabled .  ��  � ��# � ����  � ��# � r���  � ��# � r���  � �� �� " ��.R�� $" Bg��
 . $��0q�$��13��$��Stretch=�& �� #��� q�$��13 ��� �� #��� q�$
��Auto �.+��� #��Z' #{�z( #���  $) UpArrow=�]� $* 
PART_Track����. #{�z( $��1��+ �� #��Z, #���  - �� #��Z. #���  / n� #���  $) VerticalGripper=��� #��Z0 #{�z( $��2��#���  $) 	DownArrow=�$1 0.5,0.5&�z�V� .~��� $2 -1Q�$3 1Q��� $4 0Q�$5 0Q��� $6 0Q�T�  P�  �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 0����  � ��# � ����  � ��# � ����  � �� �� " ��.R�� $" Bg��#��z��
 . 7 �� #��� ���� $��0.00001* ��� #��� ��.+��� #��Z8 #{�z( 8��  $) 	LeftArrow=�]� $* 
PART_Track��$��1��#{�z( + �� #��Z9 8�� - �� #��Z: 8�� / n� 8�� $) HorizontalGripper=��� $��2��#��Z; #{�z( 8�� $) 
RightArrow=��� $ 	#FF6E6E6E���� " n�.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � �� �� " n�.R�� $��Stretch=�$
��Auto��$��Stretch=�$
��Auto��   CommonStates��.   
Normal��  	MouseOver��. �� .��T� $ (Shape.Fill)�$ 	rectangle��..�i� $# 0��8$     Pressed��. �� .��T� $ (Shape.Fill)�$ 	rectangle��..�i� $# 0��8$    Disabled��.+��� $% 	rectangle��$��Stretch=�$
��Auto��$��Stretch=�$
��Auto��$��0q�#���  �� " ��.���  �@�OverridesDefaultStyle . ��  � |� .  ��  � �� .  ��  � �� �� " ��.R�� $��Stretch=�$
��Auto��$��Stretch=�$
��Auto��7 ��    CommonStates��.   
Normal��  	MouseOver��. �� .��T� $ (Shape.Fill)�$
 path��..�i� $# 0��8$     Pressed��. �� .��r� $ (FrameworkElement.Margin)�$
 path��.	�  $< 0��$= 0q�T� $ (Shape.Fill)�$
 path��..�i� $# 0��8$    Disabled��.+��� $��Stretch=�$
��Auto��$��Stretch=�$
��Auto��$��0��$��1��#���  F� $
> path��'���p��[ .|�  x�� �  � �     � 	#���  $��Center=�$��6.062��$
? Fill=�$��Center=�$��7.554��$��0,0,2,0q�$��1��$1 0.5,0.5&�z�V� .~��� �� �� $	6 -90Q�T� �� " ��.���  �@�OverridesDefaultStyle . ��  � ��
 ���� ��  � |� .  ��  � �� .  ��  � �� �� " ��.R��� #��z��#��z��#���  �� " ��.���  �@��IsPressAndHoldEnabled .  ��  �@��IsFlicksEnabled .  ��  � ��# � ����  � ��# � r���  � ��# � r���  � �� �� " ��.R�� $" Bg��#��z��$��13��
 . & �� #��� q��� $��0.00001* ��� #��� q�.+��� #��Z' #{�z( 8��  $) UpArrow=�]� $* 
PART_Track����. #{�z( $��1��+ �� #��Z, 8�� - �� #��Z. 8�� / n� 8�� $) VerticalGripper=��� #��Z0 #{�z( $��2��8�� $) 	DownArrow=� P�  �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 0����  � ��$ 13����  � ��$ 13����  � �� �� " ��.R�� $" Bg��#��z��
 . $��0q�$��Stretch=�$��11��7 �� #��� ��$��13 ��� $	��11* ��� #��� ��$��13 �.+��� #��Z8 #{�z( #���  $) 	LeftArrow=�]� $* 
PART_Track��$��1��#{�z( $��0q�+ �� #��Z9 #���  $��0q�$
��Auto��- �� #��Z: #���  / n� #��� ! $) HorizontalGripper=�$1 0.5,0.5&�$
��Auto��$��Stretch=�$��Stretch=�$��0q�z�V� .~��� �� �� $6 0Q�T� �� $��2��#��Z; #{�z( #���  $) 
RightArrow=�$1 0.5,0.5&�z�V� .~��� $2 1Q�$3 -1Q��� $4 0Q�$5 0Q��� $6 0Q�T� �� " n�.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � �� �� " n�.R�� $��Stretch=�$��13��$��Stretch=�$
��Auto��   CommonStates��.   
Normal��  	MouseOver��. �� .��T� $ (Shape.Fill)�$ 	rectangle��..�i� $# 0��8$     Pressed��. �� .��T� $ (Shape.Fill)�$ 	rectangle��..�i� $# 0��8$    Disabled��.+��� $% 	rectangle��$��Stretch=�$
��Auto��$��Stretch=�$
��Auto��$��0q�#���  �� " ��.���  �@�OverridesDefaultStyle . ��  � |� .  ��  � �� .  ��  � �� �� " ��.R�� $��Stretch=�$��13��$��Stretch=�$
��Auto��7 ��    CommonStates��.   
Normal��  	MouseOver��. �� .��T� $ (Shape.Fill)�$
 path��..�i� $# 0��8$   T� $ (UIElement.OpacityMask)�$
 path��..�i� $# 0��8$    Pressed��. �� .��T� $ (Shape.Fill)�$
 path��..�i� $# 0��8$    Disabled��.+��� $��Stretch=�$
��Auto��$��Stretch=�$
��Auto��$��0��$��1��#���  F� $
> path��'���p��[ .|�  x�� �  � �     � 	#���  $��Center=�$��6.062��$
? Fill=�$��Center=�$��7.554��$��0,0,2,2q�$��1��$1 0.5,0.5&�#@ �  z�V� .~��� �� �� T� �� " ��.���  �@�OverridesDefaultStyle . ��  � |� .  ��  � �� .  ��  � �� �� " ��.R�  $A Chrome��#B z( #C z��
 . #) z) �� " ��.���  �@�OverridesDefaultStyle . ��  � ��
 ���� ��  � |� .  ��  � �� .  ��  � �� �� " ��.R��� #��z��#��z��#��z���� " n�.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � �� �� " n�.R�  $A Chrome��#B z( #C zD 
 . #) z) �� " ��.���  �@�OverridesDefaultStyle . ��  � ��
 ���� ��  � |� .  ��  � �� .  ��  � �� �� " ��.R��� #��z��#��z��#���  �� " ��.���  �@�OverridesDefaultStyle . ��  � ��
 ���� ��  � |� .  ��  � �� .  ��  � �� �� " ��.R��� #��z��#��z��#��z���� " ��.���  � �� �� " ��.R�� .+��� $% Border��#��� ��
 . � $G Arrow��
���   �$��Right=�$��8,8,3,3q�$
H 0.15Q�I �   ��� ��� ��� ��� $? Uniform=�$��Bottom=� P�  �@J�IsMouseOver . . ��� $! Border��# � �� � ��P�  � �� . . ��� $! Border��# � �� � ��P�  � {� .  . ��� $! Arrow�� � y�$ 	Collapsed=��� "  .���  � ��# � ����  � ��# � ����  � �� �	#FF688CAF��  � ��$ 1q���   �@ RowDetailsVisibilityMode$ VisibleWhenSelected=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � �� �� "  .R��� #��z��#��z��#��z��# z��
 . ._��� $  DG_ScrollViewer��|�.  $��Center=�$��Center=����� " ��.R�� 7 �� $
��Auto ��� $��* ��� $
��Auto �& �� $
��Auto ��� $��* ��� $
��Auto �.+��� 
���   �$��0,1,1,1q�$��3��$��Stretch=�$
��Auto��$��1��$��Stretch=�$
��Auto��$��0q�#���  �� #��ZJ |�.  ��C� *�� $"E DataGridSelectAllButtonStyle��"F  +y��� *HeadersVisibility+#L ZK #N ZM  �� "  ���� *CellsPanelHorizontalOffset+ �� "  
  $!O PART_ColumnHeadersPresenter��$��1��y��� *HeadersVisibility+#L ZP #N ZM  �� "  �� $!Q PART_ScrollContentPresenter��#R z��$��2��$��1���� $S PART_VerticalScrollBar��$��2��#U zT $V Vertical=�$��1��#y�zW #Y zX #���  $��13��$��13��Z �� *VerticalOffset+$[ OneWay=� �� *TemplatedParent+.���� #
 z
  ]� \ �� ] �@��
IsGrouping^ . �� "] �@%�IsVirtualizingWhenGrouping^ .  ./���  � �� .  �� $ 	#FF000000���� "  .���  � ��# �  ��  � ��
 ���� ��  � ��$ 1q���  � �� �� "  .R��� #��z��#��z��
 . ._��� #
 z
  P�  �@ 
IsSelected . . ���  � ��# � ����  � ��# � ����  � ��# �  P�  �@J�IsKeyboardFocusWithin . . ���  � ��# � _ ]� \ �� ] �@ 
IsSelected^ . �� ] �@��IsSelectionActive^ .  ./���  � ��# �  P�  � {� .  . ���  � ��# � ���� " n�.���  � ��$ 8����  � ��
 ���� ��  �@�Cursor$ SizeWE����  � �� �� " n�.R��� #��z��# z���� "  .���  � ��$ Center=���  � �� �� "  .R�� .+�  #a z` #b z��#c z( # z��#e zd #g zf #i zh 
���   �$��0,1,1,1q�#���  ._��� #��z����. #
 z
 #��z��$��7,0,0,0q�n� $j PART_LeftHeaderGripper��$
��Left=�8��  n� $j PART_RightHeaderGripper��$��Right=�8�� �� $ 	#FFC8C8C8���� " ��.���  � �� �� " ��.R�� $��13��$��13����Z�    CommonStates��.   
Normal��  	MouseOver��. �� .���� $* $(Shape.Fill).(SolidColorBrush.Color)�$ 
PART_MOUSE��.g�  $ 0��$ 	#33FFFFFF��  Pressed��. �� .���� $* $(Shape.Fill).(SolidColorBrush.Color)�$ 
PART_MOUSE��.g�  $ 0��$ 	#33000000��  CheckStates��.   Checked��. �� .���� $* $(Shape.Fill).(SolidColorBrush.Color)�$ 
PART_CHECK��.g�  $ 0��$ 	#FF6C88AA��  	Unchecked��.+��� #��� 	 #���  $��2q�$
��Left=�$��13��$	��Top=�$��13���� $% 
PART_CHECK��#���  $��Stretch=�$
��Auto��$��Stretch=�$
��Auto��$��4q���Z� �� $% 
PART_MOUSE��#���  $��Stretch=�$
��Auto��$��Stretch=�$
��Auto��$��2q���Z� �� " ��.���  � �� �� " ��.R�� $��0,6,0,4q�
 .  .  .+��� ���	#FF191919$
��Auto��$��2,-2,2,0q��� ���	#FF414141$
��Auto��$��2,0,2,-1q�$1 0.5,0.5&�z�V� .~��� $2 -1Q��� �� T� 