   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:TinyCollege.Views.DepartmentTinyCollege.Views.Department  5      >    8TinyCollege.Views.Department.DepartmentProfessorListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:TinyCollege.Views.Department     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � DataContext  5      ��  �� Path$ DepartmentModule�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�5      $��5q�5        PrimaryHueMidBrush#���  5      .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0,0,10,0q�5      $
��Left=�5       $��Center=�5!      $��12(�5"        TextHeaderStyle#��[ 5#      $��PROFESSORS LIST��5$      5%      5&      &   System.Windows.Controls.DataGrid  5(   
   $��1��5)      $	��375��5*      $	��375��5+      $��5q�5,      $	��Top=�5-         AutoGenerateColumns .  
������   DataGridStyle   	CellStyle# �  50      $   HorizontalScrollBarVisibility$
 Auto=�51      ��52      �� $# SelectedDepartment.Professors�   Columns 53      4  .System.Windows.Controls.DataGridTemplateColumn  54      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6)   
   Header
 55      �� 56      $��Center=�57      $��10(�58      $
��Bold"�59      
���   �  TextInfoHeaderStyle#��[ 5;      $��Professor No��5<         CellTemplate 5>      �� 5?      .R�5@      �� $��15,0,0,0q�5A   !   $��Center=�5B   !   $��10(�5C   !   
���   �#��[ 5E   !   ��5F   !   �� $ Model.ProfessorId�5G      5I        5J      $		 200 6)   
 5K      �� 5L      $��Center=�5M      $��10(�5N      $
��Bold"�5O      
���   �#��[ 5Q      $
��Name��5R       5T      �� 5U      .R�5V      �� $��15,0,0,0q�6)    �� Orientation$ 
Horizontal=�6;   .+�5W   "   �� $��Center=�5X   %   $��10(�5Y   %   
���   �#��[ 5[   %   ��5\   %   �� $ Model.ProfessorFamilyName��� 5]   "   $��Center=�5^   %   $��10(�5_   %   
���   �#��[ 5a   %   $��, ��5b   %   �� 5c   "   $��Center=�5d   %   $��10(�5e   %   
���   �#��[ 5g   %   ��5h   %   �� $ Model.ProfessorFirstName��� 5i   "   $��Center=�5j   %   $��10(�5k   %   
���   �#��[ 5m   %   $�� ��5n   %   �� 5o   "   $��Center=�5p   %   $��10(�5q   %   
���   �#��[ 5s   %   ��5t   %   �� $" Model.ProfessorMiddleName[0]��� 5u   "   $��Center=�5v   %   $��10(�5w   %   
���   �#��[ 5y   %   $��.��5z   %   5{      5}      5        5�      $		 100 6)   
 5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Status��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Model.ProfessorStatus�5�      5�      5�      5�      5�      