   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TinyCollege.Views.SchoolTinyCollege.Views.School  5      8    2TinyCollege.Views.School.SchoolEditInformationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:TinyCollege.Views.School     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5	        � DataContext  5      ��  �� Path$! SchoolModule.SelectedSchool�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�6#     PrimaryHueMidBrush#���  6/   .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��auto �6'   .+�5      �� $��0,0,10,0q�5      $��Center=�5      $��12(�5        TextHeaderStyle#��[ 5       $��EDIT INFORMATION��5!      �� 5#      $��1��5$      $��Right=�5%       �� Orientation$ 
Horizontal=�5&      .+�5'      �� $��0,0,10,0q�5(        SecondaryAccentBrush#���  5)      ��5*      �� $ SaveCommand���5+      '  !MaterialDesignThemes.Wpf.PackIcon  5,      $��25��5-   !   $��25��5.   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ ContentSave=�5/   !   51      �� 53      $��0,0,10,0q�54      #���  55      ��56      �� $ CancelCommand���57        58      $��25��59   !   $��25��5:   !   $ BlockHelper=�5;   !   5=      5>      5?      5@      #  MaterialDesignThemes.Wpf.Card  5B   
   $��1��5C      $��5,5,5,0q�5D      $��10q�5E        5F      �� $ 	EditModel�.��5G      �  5H      �� 5I      $
��Auto �6$   �� 5J      $
��Auto �6$   �� 5K      $
��Auto �6$    5N      �� 5O      $��* �6'   �� 5P      $��* �6'   �� 5Q      $��* �6'   .+�5T      �  5U      �� 5V      $
��Auto �6+   �� 5W      $
��Auto �6+   .+�5Z        $��35��5[      $��35��5\      $��
10,10,10,0q�5]      $��Center=�5^      $��Center=�5_      #���  5`      $ School=�5a      �� 5c      $��1��6!   $��5,0,0,0q�61   .+�5d      �� $	��100��5e      $��	0,10,10,0q�5f      $��12(�5g      ��5h      �� $ 
SchoolName� �� UpdateSourceTrigger$ PropertyChanged=��� 5i      $��10(�5j      $��Italic$�5k        TextInfoHeaderStyle#��[ 5l      $��School Name��5m      5n      5o      � 5q      $��1��6    5r      �� 5s      $
��Auto �6+   �� 5t      $
��Auto �6+   .+�5w        $��35��5x      $��35��5y      $��
10,10,10,0q�5z      $��Center=�5{      $��Center=�5|      #���  5}      $
 City=�5~      �� 5�      $��1��6!   $��5,0,0,0q�61   .+�5�      �� $	��100��5�      $��	0,10,10,0q�5�      $��12(�5�      ��5�      �� $ Address�$ PropertyChanged=��� 5�      $��10(�5�      $��Italic$�5�      #��[ 5�      $��Address��5�      5�      5�      � 5�      $��2��6    5�      �� 5�      $
��Auto �6+   �� 5�      $
��Auto �6+   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5�      $��Center=�5�      $��Center=�5�      #���  5�      $ Account=�5�      �� 5�      $��1��6!   $��5,0,0,0q�61   .+�5�      �� $��	0,10,10,0q�5�      $��12(�5�        TextInfoStyle#��[ 5�        5�      �� $ Professor.Model���5�      `� 5�   "    �� StringFormat$ {0}, {1} {2}.��6/   .1�5�   &   �� $ ProfessorFamilyName�6.   �� 5�   &   $ ProfessorFirstName�6.   �� 5�   &   $ ProfessorMiddleName[0]�6.   5�   #   5�      �� 5�      $��10(�5�      $��Italic$�5�      #��[ 5�      $
��Dean��5�      5�      5�      5�      5�      �� 5�   
   $��2��5�      $��5q�5�        5�      �� $ 	EditModel�.+�5�      &   System.Windows.Controls.DataGrid  $	��375��5�      $	��375��5�      $��5q�5�      $	��Top=�5�      	   AutoGenerateColumns	 .  
������   DataGridStyle
   	CellStyle#
 �  5�      $   HorizontalScrollBarVisibility$
 Auto=�5�      ��5�      �� $ ProfessorList� �� SelectedItem 5�      �� $ 	Professor�   Columns 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6-      Header 5�      �� 5�      $��Center=�5�   !   $��10(�5�   !   $
��Bold"�5�   !   
���   �#��[ 5�   !   $��Professor No��5�   !      CellTemplate 5�      �� 5�      .R�5�   "   �� $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $ Model.ProfessorId�5�      5�        5�      $	 200 6-    5�      �� 5�      $��Center=�5�   !   $��10(�5�   !   $
��Bold"�5�   !   
���   �#��[ 5�   !   $
��Name��5�   !    5�      �� 5�      .R�5�   "   �� $ 
Horizontal=�6-   .+�5�   &   �� $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   ��5�   )   �� $ Model.ProfessorFamilyName��� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   $��, ��5�   )   �� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   ��5�   )   �� $ Model.ProfessorFirstName��� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   $�� ��5�   )   �� 5   &   $��Center=�5  )   $��10(�5  )   
���   �#��[ 5  )   ��5  )   �� $" Model.ProfessorMiddleName[0]��� 5  &   $��Center=�5  )   $��10(�5  )   
���   �#��[ 5
  )   $��.��5  )   5  #   5     5       5     $	 100 6-    5     �� 5     $��Center=�5  !   $��10(�5  !   $
��Bold"�5  !   
���   �#��[ 5  !   $��Status��5  !    5     �� 5     .R�5  "   �� $��Center=�5  %   $��10(�5  %   
���   �#��[ 5!  %   ��5"  %   �� $ Model.ProfessorStatus�5#     5%     5'     5(     5)     5*     