   M S B A M L   `   `   `  ����G  CSugzControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:SugzControls;assembly=SugzControlsSugzControls  5   	   d `PresentationFramework.Classic, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35jMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.ClassicMicrosoft.Windows.Themes 5   	   C ?StyleApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:StyleAppStyleApp 5   	   A0clr-namespace:SugzControls;assembly=SugzControlsSugzControls  5	   	      StyleApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:SugzControls;assembly=SugzControls     5   	   `ThemesMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Classic     5   	   )local1clr-namespace:StyleApp     5   	   EControls0clr-namespace:SugzControls;assembly=SugzControls     5	   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5         ExpanderToggleButton �� 
TargetType ��Name F�Name �� Triggers P� Property P� Value �� 
TargetName	 �� Property
 �� Value  SugzExpanderStyle �� 
TargetType   SugzControls.SugzExpander � RowDefinitions ��Name � ColumnDefinitions �� Padding � OverridesDefaultStyle d� 	IsChecked �� Mode �� RelativeSource �� ElementName��%|  &	        &	 3    7   �� 5   
   " d�67   .R�5      �� $ Border��6   
������ ._�5      F� $ Arrow��6   ���	#FF969696$
��Left=�5      $��Center=�5      "����        �     z р�[  	= 	$��6,0,0,0q�5      5       5      P� 5       �@J�IsMouseOver . . �5      �� $ Arrow��6   	 � ��
 �	#FF0068FF6@   5      P� 5       �@d�	IsChecked$
 trueY�6/   . �5      �� $ Arrow��6   	 � ��"
 ��        � z     � 	= ��[ 	6@   �� 5      $ Arrow��6   	 � ��$
 5,0,0,0q�6B   5      5!      �� 5#   
   "  6*   .�5$      �� 	 � ��
 5%      �� 5&      " 9�6&   .R�5'      �  5(      �� 5)   "   $
��Auto �60   �� 5*   "   $ 
ContentRow��60   $��0 �6D   .+�5,      �� $ Border��6%   $��0��5-      #��z��5.      #��z��5/      #��z��50      #��z��51      ._�52   "   �  53   &   �� 54   *   $��* �6;   �� 55   *   $
��Auto �6;   �� 56   *   $
��Auto �6;   .+�59   &   �� $��0��60   
������ #��z��5;      #��z��5<      $��Center=�5=      $��0,-2,0,0q�5>      $ 20,0,0,0q�5?      d� 5@   &   $��0��63    . 8��   5A      �� *
IsExpanded+$ TwoWay=� �� *TemplatedParent+5C      5D   #   5E      �� 5F      $ Content��6%   $��1��5G      
������ ._�5I   "   �� 5J      5K       5L      P� 5M       �@9�
IsExpanded . . �5N   "   �� $ 
ContentRow��6)   
 5P      �� *DesiredHeight+$ Content��	 � ��5Q      P� 5R       � {� . . �5S   "   �� 	 � ��

 �   �6?   5T      5V      5X      5Y      5[      .��5_      � .+�5`   
     -   5          Name$ sugzExpander��5`       $��SugzExpander��66   $
��Left=�6L   $��
201,92,0,0q�6g   $	��Top=�6{   #���  6�   ���	#FF969696$	��158��6�   ���	#FF323232$��0q�6�   $��18��6  .��5a      � ���	#FFE5E5E56   5b      5f      5g      