   M S B A M L   `   `   `  ����G  CSupplySystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SupplySystem.PL.PL_HelperSupplySystem.PL.PL_Helper  5   	   %    SupplySystem.PL.PL_Helper.LogIn   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v19.2, Version=19.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SupplySystem.PL.PL_Helper     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6?   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6�   $��RightToLeft=�5        � WindowStyle$
  None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
      
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	    � WindowState$ Normal=�6    � Title$ LogIn��5   	   $	��320��6   $	��500��6$   .��5      ��  �� CornerRadius$ 8��6      PrimaryBackgroundColor#���   6   ._�5   
   � -   5        .+�5      �� -   5        $	��280��5      $	��Top=�6"   $ 	8 8 180 8��6:   
�������6f   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $	��300��6   $��RightToLeft=�6%   .+�5      �� $��10 15q�6   .+�5      �� -   5        $��lbl_UnitNameId��5   $   $��
UnitNameId��6:   $��20(�6L   �� 5      -   5        $��txt_HelloorLogin��5       $��Login��5   $   $��20q�61   
���   �$��30(�5   4   $��Great Vibes)�6B   6]   �� 5      $ 
Horizontal=�6%   $��10q�6>   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  -   5        $��icon_UnitName_and_UserNo��5   5      Kind$ Company=�5   6   $��25��6E   $��25��5   2   
���   �6>   %  DevExpress.Xpf.Editors.TextEdit  5      -   5        	  Name$	 txt_UnitName_and_UserNo��5   +   $��16(�5   &   $
��10 0q�5   &   $	��200��66   5       �� 5!      $ 
Horizontal=�6%   $��10q�6>   .+�5"        -   5        $&�� icon_UnitidName_and_UserPassword��5#      $ IdCard=�5$      $��25��6+   $��25��66   
���   �6B     5%      -   5        $	 txt_UnitidName��5'      $��16(�5&      $
��10 0q�5'   5   $	��200��6C   ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  5(      -	   5        
  Name$
 txt_Password��5)      $��16(�5(   4   $y�	Collapsed=�6B   $
��10 0q�5+   4   $	��200��6B   5,      �� 5.      $��	0 10 30 0q�6!   $��Right=�64   .+�5/      �� -
   5         ��Name$ btnLogin��55   5   $	��100��5/   !   $��40��6-     MaterialDesignRaisedButton#��[ 50   !   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��51      $��1q�52   !   
���   �
��� � �
�������$��Login��56   8   57      58      59      5:      �� 5;      $	��130��6   .+�5<      �� $��/Images/tabweebnew.png��6   $��	0 100 0 0q�5=      $	��130��5>   -   $	��130��69   5?      �� 5@      .+�5A      �� -   5        $ btnClose��5C      $��10 20q�5B        IconButtonsStyle#��[ 5C   #    	 close#���  6M   
 � Tag$ IsCloseButton��6�   5D      5E      5F      5G      5H      