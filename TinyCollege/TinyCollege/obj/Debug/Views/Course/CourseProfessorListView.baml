   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TinyCollege.Views.CourseTinyCollege.Views.Course  5      6    0TinyCollege.Views.Course.CourseProfessorListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:TinyCollege.Views.Course     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � DataContext  5      ��  �� Path$  CourseModule.SelecteCourse�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�6#     PrimaryHueMidBrush#���  6/   .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $
��Left=�5      $��Center=�5      $��12(�5        TextHeaderStyle#��[ 5      $��PROFESSORS ASSIGNED��5       �� 5"      $��1��5#      $��20,0,0,0q�5$      $��Right=�5%       �� Orientation$ 
Horizontal=�5&      .+�5'      �� $��0,0,10,0q�5(      $��0q�5)        MaterialDesignFlatButton#���  5+      ��5*      �� $% CourseModule.PrintCourseCommand�# [  ��5,      '  !MaterialDesignThemes.Wpf.PackIcon  5-      $��25��5.   !   $��25��5/   !     SecondaryAccentBrush#���  50   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ Printer=�51   !   53      54      55      56      &   System.Windows.Controls.DataGrid  58   
   $��1��59      $	��375��5:      $	��375��5;      $��5,5,5,35q�5<      $	��Top=�5=         AutoGenerateColumns .  
������   DataGridStyle   	CellStyle# �  5@      $	   HorizontalScrollBarVisibility$
	 Auto=�5A      ��5B      �� $ ProfessorList�
   Columns
 5C      4  .System.Windows.Controls.DataGridTemplateColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6)      Header 5E      �� 5F      $��Center=�5G      $��10(�5H      $
��Bold"�5I      
���   �  TextInfoHeaderStyle#��[ 5K      $��Professor No��5L         CellTemplate 5N      �� 5O      .R�5P      �� $��15,0,0,0q�5Q   !   $��Center=�5R   !   $��10(�5S   !   
���   �#��[ 5U   !   ��5V   !   �� $ Model.ProfessorId�5W      5Y        5Z      $	 200 6)    5[      �� 5\      $��Center=�5]      $��10(�5^      $
��Bold"�5_      
���   �#��[ 5a      $
��Name��5b       5d      �� 5e      .R�5f      �� $��15,0,0,0q�6)   $ 
Horizontal=�6;   .+�5g   "   �� $��Center=�5h   %   $��10(�5i   %   
���   �#��[ 5k   %   ��5l   %   �� $ Model.ProfessorFamilyName��� 5m   "   $��Center=�5n   %   $��10(�5o   %   
���   �#��[ 5q   %   $��, ��5r   %   �� 5s   "   $��0,0,5,0q�5t   %   $��Center=�5u   %   $��10(�5v   %   
���   �#��[ 5x   %   ��5y   %   �� $ Model.ProfessorFirstName��� 5z   "   $��Center=�5{   %   $��10(�5|   %   
���   �#��[ 5~   %   ��5   %   �� $" Model.ProfessorMiddleName[0]��� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   $��.��5�   %   5�      5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Status��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Model.ProfessorStatus�5�      5�        5�      $	 200 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��
Department��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $% Model.Department.DepartmentName�5�      5�      5�      5�      5�      