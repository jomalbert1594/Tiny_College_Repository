   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TinyCollege.Views.SchoolTinyCollege.Views.School  5      7    1TinyCollege.Views.School.SchoolDepartmentListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:TinyCollege.Views.School     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � DataContext  5      ��  �� Path$! SchoolModule.SelectedSchool�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�6#     PrimaryHueMidBrush#���  6/   .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0,0,10,0q�5      $
��Left=�5      $��Center=�5      $��12(�5        TextHeaderStyle#��[ 5       $��DEPARTMENTS��5!      5"      5#      &   System.Windows.Controls.DataGrid  5%   
   $��1��5&      $	��375��5'      $	��375��5(      $��5q�5)      $	��Top=�5*         AutoGenerateColumns .  
������   DataGridStyle   	CellStyle# �  5-      $   HorizontalScrollBarVisibility$
 Auto=�5.      ��5/      �� $ DepartmentList�   Columns 50      4  .System.Windows.Controls.DataGridTemplateColumn  51      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6)   
   Header
 52      �� 53      $��Center=�54      $��10(�55      $
��Bold"�56      
���   �  TextInfoHeaderStyle#��[ 58      $��Department ID��59         CellTemplate 5;      �� 5<      .R�5=      �� $��15,0,0,0q�5>   !   $��Center=�5?   !   $��10(�5@   !   
���   �#��[ 5B   !   ��5C   !   �� $ Model.DepartmentId�5D      5F        5G      $		 150 6)   
 5H      �� 5I      $��Center=�5J      $��10(�5K      $
��Bold"�5L      
���   �#��[ 5N      $��Department Name��5O       5Q      �� 5R      .R�5S      �� $��15,0,0,0q�5T   !   $��Center=�5U   !   $��10(�5V   !   
���   �#��[ 5X   !   ��5Y   !   �� $ Model.DepartmentName�5Z      5\        5]      $		 200 6)   
 5^      �� 5_      $��Center=�5`      $��10(�5a      $
��Bold"�5b      
���   �#��[ 5d      $
��Name��5e       5g      �� 5h      .R�5i      �� $��15,0,0,0q�6)    �� Orientation$ 
Horizontal=�6;   .+�5j   "   �� $��Center=�5k   %   $��10(�5l   %   
���   �#��[ 5n   %   ��5o   %   �� $. (DepartmentHead.Model.ProfessorFamilyName��� 5p   "   $��Center=�5q   %   $��10(�5r   %   
���   �#��[ 5t   %   $��, ��5u   %   �� 5v   "   $��Center=�5w   %   $��10(�5x   %   
���   �#��[ 5z   %   ��5{   %   �� $- 'DepartmentHead.Model.ProfessorFirstName��� 5|   "   $��Center=�5}   %   $��10(�5~   %   
���   �#��[ 5�   %   $�� ��5�   %   �� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $1 +DepartmentHead.Model.ProfessorMiddleName[0]��� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   $��.��5�   %   5�      5�      5�      5�      5�      5�      