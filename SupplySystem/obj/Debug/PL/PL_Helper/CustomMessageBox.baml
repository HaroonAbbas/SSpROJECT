   M S B A M L   `   `   `  ����G  CSupplySystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SupplySystem.PL.PL_HelperSupplySystem.PL.PL_Helper  5      0    *SupplySystem.PL.PL_Helper.CustomMessageBox   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v19.2, Version=19.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SupplySystem.PL.PL_Helper     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $��RightToLeft=�5	        � WindowStyle$
  None=�5
   	    � WindowStartupLocation$ CenterScreen=�5      
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	    � WindowState$ Normal=�6    � Title$ LogIn��5   	   $	��250��6   $	��500��6$   .��5      �� -   5         �� CornerRadius$ 25��5   	   
���  ��$��1q�6-   
�������._�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��AUTO �6    �� 5      $��20 �6    .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��Center=�6   $ 
Horizontal=�6:   .+�5      �� -   5        $��	lbl_Right��5   ,   $��Right��6   $��10 8 0 0q�6=   $��18(�6O   �� 5      -   5        $��lbl_HeaderOfMessage��5      $��Header of Message��5      $��18(�5      $��0 8 0 0q�6"   �� 5      -   5        $��lbl_Left��5   +   $
��Left��6   $��10 8 0 0q�6;   $��18(�6M   5       �� 5!      .+�5"      �� -   5        $��lbl_BodyOfMessge��5"      $��fody of messagfe��66   {�.  $
��Bold"�5#   '   	 �� TextWrapping$	 WrapWithOverflow=�69   
�������$��16(�5%      $��
10 20 10 0q�6"   5'      5)      �� 5*      $��Bottom=�6   $��2��64   $��	50 0 50 0q�6A   $ 
Horizontal=�6T   $��Right=�5+      .+�5,      �� -   5        $��btnClipboard��5.      $��0q�5-   +   $��0 0 50 0q�5/      $��35��6'   $��40��62   $��0q�6>   ��5-      Z� .��50      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 	Clipboard=�6.   $��30��6?   $��40��6J   $��0 0 0 0q�51   ,    � ToolTip$ نسخ الرسالة��6=   
�������$��Bottom=�53   .   $��Right=�6I   54      �� 55      $ 25��6   ._�56      �� -   5        $��	btnCencel��56      $��40��57      $	��100��6)   $��0q�58   3   ��57   5   Z� ��58      Z� .��59      �� $ 
Horizontal=�6%   .+�5:      �� $��
الغاء��6(   
���  ��66     5;      $

 Undo=�66   $��5 3 0 0q�6B   
���  ��6S   5<      5=      5>      �� 5?      $ 25��6   $��10 0 0 0q�6+   
���   �$��0q�6Q   ._�5@      �� -   5        $��btnOK��5@      $��40��5B      $	��100��6)   
���   �$��0q�5C   3   ��5B   5   Z� ��5C      Z� .��5D      �� $ 
Horizontal=�6%   .+�5E      �� $��
موافق��6(   
���   �66     5F      $

 Done=�66   $��5 3 0 0q�6B   
���   �6S   5G      5H      5I      5J      5K      5M      5N      