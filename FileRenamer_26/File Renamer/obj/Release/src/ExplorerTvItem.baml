   M S B A M L   `   `   `  ����   File_Renamer!    File_Renamer.ExplorerTvItem   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     Q�Name$  TV��$
��Test��   ExplorerTvItemStyle#���   ���	#FFE6E6E6 � 	Resources   TreeViewItemFocusVisual �� Property �� Value . *TreeViewItem.TreeArrow.Static.Checked.Fill �� Color 0 ,TreeViewItem.TreeArrow.Static.Checked.Stroke + 'TreeViewItem.TreeArrow.MouseOver.Stroke ) %TreeViewItem.TreeArrow.MouseOver.Fill 3 /TreeViewItem.TreeArrow.MouseOver.Checked.Stroke 1 -TreeViewItem.TreeArrow.MouseOver.Checked.Fill  	TreeArrow &	 "TreeViewItem.TreeArrow.Static.Fill (
 $TreeViewItem.TreeArrow.Static.Stroke  ExpandCollapseToggleStyle �� 
TargetType �� 
TargetType �� Padding F�Name  Brush_170_170_170	 �� Angle
 �� CenterY �� CenterX �� Triggers P� Property P� Value �� 
TargetName  HighLightedBlue ]� 
Conditions �� Property �� Value �� RelativeSource �� AncestorType �Name � ColumnDefinitions � RowDefinitions ��Name d�Name �� 	ClickMode d� 	IsChecked ��Name � UseLayoutRounding J� SnapsToDevicePixels �� Left
  �� Top! �� Stretch  Brush_255_255_255_40" ��Name# ��Name$ �� Triggers��%�  &	       &	 &     &	 ;     &	 P     &	 e     &	 |     &	 �     &	 �     &		 �     &	
 �     &	 �     7  &	  �    7  7  �� .���  � �� �� .R��� �� $ 	#FF595959���� $ 	#FF262626���� $ 	#FF1BBBFA���� $ Transparent���� $ 	#FF262626���� $ 	#FF595959��B� $��M0,0 L0,6 L6,0 zC��� $ Transparent���� $ 	#FF989898���� " d�.���  � |� .  ��  � ��$ 16����  � ��$ 16����  � �� �� " d�.R��� 
������ $��16��$ 5,5,5,5q�$��16��._�F� $ 
ExpandPath��8��  #���  #���  z��� $		 135Q�$
 3Q�$ 3Q� P�  �@d�	IsChecked$
 TrueY�. ��� $ 
ExpandPath�� � z� �� $		 180Q�$
 3Q�$ 3Q��� $ 
ExpandPath��# �   � ���� $ 
ExpandPath��# �   � ��P�  �@J�IsMouseOver . . ��� $ 
ExpandPath��# �   � ���� $ 
ExpandPath��# �   � ��]�  ��  �@J�IsMouseOver . ��  �@d�	IsChecked$
 TrueY�./��� $ 
ExpandPath��# �   � ���� $ 
ExpandPath��# �   � ���� " Q�.���  � ��
 ���� ��  � �� �� *HorizontalContentAlignment+ �� " ����  � �� �� *VerticalContentAlignment+ �� " ����  � ��$ 1,0,0,0q���  � ��# � ����  �@�FocusVisualStyle8   ��  � �� �� " Q�.R�� $
 grid����Z�  �� $��19��$
��Auto ��� $
��Auto ��� $��* � �� $��25 ��� .+��� $ PART_SEL��$��2�����	#006C88AA$��Stretch=�$��20��$	��Top=�$
��Auto��$��1��$��0q���Z� d� $ Expander��$ Press=�8�� #���  #���  $
��Left=�$	��Top=�$��0,2,0,0q� �� *
IsExpanded+ �� *TemplatedParent+� $ grid1��$��1�����	#006C88AA.+��� $ 
Icons_16px��$
��Left=�$��16�� . $	��Top=�$��16�� . $��5,2,0,0q�.+��� $	 Hdd��$��15��$	 0.5��$	  0.5��$��15��.+�F� e����ȅ  � ��$ P� ��% �L
 ��(  � �v,  � рv�  � Ӡ/�  � 8X� �L
 H�� P� шg�  � ���	#66FFFFFF$��12.086��$ -0.493�����	#CCFFFFFF$
  -0.5��$��15.985��F� �������� �= ���� �FA ��  �D H��  �D Ѹ.  �D �P  �D  � �FA  � �= � � �. � � h  P  � �.  � �H��  � Ӱ�  � ��� h  ��� �. 	$��5�����	#CCFFFFFF$  10.75��$��16�� .  F� t����� � �� 0� �; � �0�     0� � �    �; 0� � � � Ӱ; � � �; � � ���	#CCFFFFFF$��1.708��$ 11.104��$  12.813��$��1.708�� .  F� ������  �. �� � �Pk � ��G � Ӏ`$ �  � �  �  �. � � �<D �`$ P�U ��G P�U ӨPk P�U � �<D �  �. 	$��6.118��$ 2.791�����	#CCFFFFFF$  2.604��$��9.417���� $ Computer��$
��13.5��$ 0��$	  1.5��$��16��.+�F� "�������    ��5� P�� ��5�     ���	#66FFFFFF$��8.978��$ 0.896��$	  0.5��$��14.105��F� �������� �l� ���� P� P#� �y� �q� �y� �H�
 �y� Ӱ 	 �y�  � P�  � �l� � � `�
 � � �� � 	 � H�
 � Ѹq� � �P#� � ��� �� ��� `�
 	$��12��$ 0�����	#CCFEFEFE$  -0.667��$��16�� .  F� +���� $� @B �    @B �        � $�     ���	#CCFFFFFF$��1��$ 1��$  9��$��14.105�� .  $
! Fill=�F� +������� @B �    @B �        р��     ���	#CCFFFFFF$��1��$ 3��$
  12.5��$��10���� $ Folder��$��12��$��14��$��0q�$ 1��$  1��.+�F� w���Ѐ�h � % Q�K �W ��?SҏJ �䎊AX�?�E �aο��?rLC �aο��?��c  � �P	  �  � 0�  � � � � �. 	$��5��$ -0.917�����	#CCFFFFFF$��8.001�� . $  0.126��$
! Fill=���Z� F� ������c �y� �`Q� �y� ��� �y� �@� ��� �@� �� Ѡ@� @B Ӡ@� �� p��  � ���  � ����  � d6 2 d6 2 ��� 2 2 �h 2 R� � � @�� � � ��� P	 �y� �c �y� 	$��11��$ -1�����	#CCFFFFFF$��15�� . $  3��#���  $
! Fill=��� $ 
OpenFolder��$��12��$��16��$��0q�$  1��.+�F� �����N�� WK �`�� ��- �`�� xg* �� �%& �t� �%& јm �%& ��sk �%& x�i �@& h�h x% ј�N �o
 ӈ�M `7	 ��I  � �$H  � ѠD  � Ӱ 	  �  � x�  � ��
 � � @]� 	$
��13.5�����	#CCFFFFFF$��14�� .  F� ������  � р*-  � �xg*  � ' P�	 �k& �< �Xn �� Ӏ� (ϊ @f	 `�� �2 `�� ���� `�� ���� `�� �:� � �� �!� ���� P{ ӈg� @� ���  � ��  � 	$��9��$ 0.024�����	#CCFFFFFF$  5.125��$��16�����	#66FFFFFF$
! Fill=� .  �� $" PART_Header��$��Header��#��z��# z $��28,2,-1.001,0q��� $# 	ItemsHost��$��2��$��1��$��1�� P�  �@Q�
IsExpanded .  . ��� $ 	ItemsHost�� � y�$ 	Collapsed=�P�  �@��HasItems .  . ��� $ Expander�� � y�$ Hidden=�P�  �@Q�
IsSelected . . ��� $ PART_SEL��# �   � ��]�  ��  �@Q�
IsSelected . ��  �@Q�IsSelectionActive .  ./��� $ PART_SEL�� � �� �	#FF828282P�  � {� .  . ��� # � �� � ��$ P�  �@%�IsVirtualizing . . ���  � �� �� .R�$� 