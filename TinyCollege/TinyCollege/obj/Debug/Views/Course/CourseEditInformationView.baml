   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TinyCollege.Views.CourseTinyCollege.Views.Course  5      8    2TinyCollege.Views.Course.CourseEditInformationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:TinyCollege.Views.Course     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � DataContext  5      ��  �� Path$  CourseModule.SelecteCourse�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�6#     PrimaryHueMidBrush#���  6/   .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��5,0,0,0q�5      $��Center=�5      $��12(�5        TextHeaderStyle#��[ 5      $��EDIT COURSE��5      �� 5!      $��1��5"      $��20,0,0,0q�5#      $��Right=�5$       �� Orientation$ 
Horizontal=�5%      .+�5&      �� $��0,0,10,0q�5'      $��0q�5(        MaterialDesignFlatButton#���  5*      ��5)      �� $ SaveCommand���5+      '  !MaterialDesignThemes.Wpf.PackIcon  5,      $��25��5-   !   $��25��5.   !     SecondaryAccentBrush#���  5/   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ ContentSave=�50   !   52      �� 54      $��0,0,10,0q�55      $��0q�56      #���  58      ��57      �� $ CancelCommand���59        5:      $��25��5;   !   $��25��5<   !   #���  5=   !   $ BlockHelper=�5>   !   5@      5A      5B      5C      #  MaterialDesignThemes.Wpf.Card  5E   
   $��1��5F      $��5,5,5,0q�5G      $��10q�5H      .��5I      �� .+�5J      �   6   �� $ 	EditModel� 5K      �� 5L      $
��Auto �6(   �� 5M      $
��Auto �6(   �� 5N      $
��Auto �6(    5Q      �� 5R      $��* �6+   �� 5S      $��* �6+   �� 5T      $��* �6+   .+�5W      �  5X      �� 5Y      $
��Auto �6/   �� 5Z      $
��Auto �6/   .+�5]        $��35��5^      $��35��5_      $��
10,10,10,0q�5`      #���  5a      $
 Book=�5b      �� 5d      $��1��6%   .+�5e      �� $��	0,10,10,0q�5f   !   $��12(�5g   !     TextInfoStyle#��[ 5h   !   ��5i   !   �� $ CourseId��� 5j      $��10(�5k   !   $��Italic$�5l   !     TextInfoHeaderStyle#��[ 5m   !   $��Course Code��5n   !   5o      5p      � 5r      $��1��6    5s      �� 5t      $
��Auto �6/   �� 5u      $
��Auto �6/   .+�5x        $��35��5y      $��35��5z      $��
10,10,10,0q�5{      #���  5|      $
 Book=�5}      �� 5      $��1��6%   .+�5�      �� $��75��5�   !   $��	0,10,10,0q�5�   !   $��12(�5�   !    �� TextWrapping$
 Wrap=�5�   !   ��5�   !   �� $ 
CourseName� �� UpdateSourceTrigger$ PropertyChanged=�5�   !   �� 5�      $��10(�5�   !   $��Italic$�5�   !   #��[ 5�   !   $��Course Name��5�   !   $
��Wrap=�5�   !   5�      5�      � 5�      $��2��6    5�      �� 5�      $
��Auto �6/   �� 5�      $
��Auto �6/   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5�      #���  5�      $ 
CreditCard=�5�      �� 5�      $��1��6%   .+�5�      �� $��75��5�   !   $��	0,10,10,0q�5�   !   $��12(�5�   !   $
 Wrap=�5�   !   ��5�   !   �� $ CourseUnits�$ PropertyChanged=�5�   !   �� 5�      $��10(�5�   !   $��Italic$�5�   !   #��[ 5�   !   $��Units��5�   !   5�      5�      5�      �� 5�      $��2,0,0,0q�6     6.   �� $ 	EditModel�.+�5�      �  5�      �� 5�      $
��Auto �6/   �� 5�      $
��Auto �6/   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5�      #���  5�      $ ChairSchool=�5�      �� 5�      $��1��6%   .+�5�      �� $��	0,10,10,0q�5�   !   $��12(�5�   !   #��[ 5�   !   ��5�   !   �� $% Department.Model.DepartmentName��� 5�      $��10(�5�   !   $��Italic$�5�   !   #��[ 5�   !   $��
Department��5�   !   5�      5�      &   System.Windows.Controls.DataGrid  5�      $	��350��5�      $	��350��5�      $��5,5,5,35q�5�      $	��Top=�5�      	   AutoGenerateColumns	 .  
������   DataGridStyle
   	CellStyle#
 �  5�      $   HorizontalScrollBarVisibility$
 Auto=�5�      ��5�      �� $ DepartmentList� �� SelectedItem 5�      �� $ 
Department�   Columns 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 65      Header 5�   "   �� 5�   &   $��Center=�5�   )   $��10(�5�   )   $
��Bold"�5�   )   
���   �#��[ 5�   )   $��Department ID��5�   )      CellTemplate 5�   "   �� 5�   &   .R�5�   *   �� $��15,0,0,0q�5�   -   $��Center=�5�   -   $��10(�5�   -   $
��Bold"�5�   -   
���   �#��[ 5�   -   ��5�   -   �� $ Model.DepartmentId�5�   '   5�        5�      $	 150 65    5�   "   �� 5�   &   $��Center=�5�   )   $��10(�5�   )   $
��Bold"�5�   )   
���   �#��[ 5�   )   $��Department Name��5�   )    5�   "   �� 5�   &   .R�5�   *   �� $��15,0,0,0q�5�   -   $��Center=�5�   -   $��10(�5�   -   
���   �#��[ 5�   -   ��5�   -   �� $ Model.DepartmentName�5�   '   5        5     $	 100 65    5  "   �� 5  &   $��Center=�5  )   $��10(�5  )   $
��Bold"�5  )   
���   �#��[ 5  )   $��School��5	  )    5  "   �� 5  &   .R�5  *   �� $��15,0,0,0q�5  -   $��Center=�5  -   $��10(�5  -   
���   �#��[ 5  -   ��5  -   �� $ School.Model.SchoolName�5  '   5     5     5     5     5     5     5     