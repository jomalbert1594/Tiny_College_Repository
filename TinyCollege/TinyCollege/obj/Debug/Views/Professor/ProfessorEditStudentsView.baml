   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TinyCollege.Views.ProfessorTinyCollege.Views.Professor  5      ;    5TinyCollege.Views.Professor.ProfessorEditStudentsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TinyCollege.Views.Professor     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  $	��375��5      $	��375��5      $��5q�5      $	��Top=�5          AutoGenerateColumns  .  
������    DataGridStyle   	CellStyle# �   5      $   HorizontalScrollBarVisibility$
 Auto=�5      ��5      ��  �� Path$1 +ClassModule.SelectedClass.EditClassesGrades�  Locator �� Source# [    Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6)      Header 5      �� 5      $��Center=�5      $��10(�5      $
��Bold"�5      
���   �  TextInfoHeaderStyle#��[ 5      $��
Student Id��5          CellTemplate 5"      �� 5#      .R�5$      �� $��15,0,0,0q�5%   !   $��Center=�5&   !   $��10(�5'   !   
���   �#��[ 5)   !   ��5*   !   �� $ Student.Model.StudentId�5+      5-        5.      $	 115 6)    5/      �� 50      $��Center=�51      $��10(�52      $
��Bold"�53      
���   �#��[ 55      $
��Name��56       58      �� 59      .R�5:      �� 	 �� Orientation$	 
Horizontal=�6)   .+�5;   "   �� $��15,0,0,0q�5<   %   $��Center=�5=   %   $��10(�5>   %   
���   �#��[ 5@   %   ��5A   %   �� $$ Student.Model.StudentFirstName��� 5B   "   $��0,0,0,0q�5C   %   $��Center=�5D   %   $��10(�5E   %   
���   �#��[ 5G   %   $�� ��5H   %   �� 5I   "   $��5,0,0,0q�5J   %   $��Center=�5K   %   $��10(�5L   %   
���   �#��[ 5N   %   ��5O   %   �� $% Student.Model.StudentMiddleName��� 5P   "   $��0,0,0,0q�5Q   %   $��Center=�5R   %   $��10(�5S   %   
���   �#��[ 5U   %   $�� ��5V   %   �� 5W   "   $��5,0,0,0q�5X   %   $��Center=�5Y   %   $��10(�5Z   %   
���   �#��[ 5\   %   ��5]   %   �� $% Student.Model.StudentFamilyName�5^      5_      5a        5b      $	 100 6)    5c      �� 5d      $��Center=�5e      $��10(�5f      $
��Bold"�5g      
���   �#��[ 5i      $��Prelim��5j       5l      �� 5m      .R�5n      � $��15,0,0,0q�6#   .+�5o   "   �� $��50��5p   %   $��Center=�5q   %   $��10(�5r   %   
���   ���5t   %   �� $ Prelim�
 �� UpdateSourceTrigger$
 PropertyChanged=�5u      5v      5x        5y      $	 100 6)    5z      �� 5{      $��Center=�5|      $��10(�5}      $
��Bold"�5~      
���   �#��[ 5�      $��Midterm��5�       5�      �� 5�      .R�5�      � $��15,0,0,0q�6#   .+�5�   "   �� $��50��5�   %   $��Center=�5�   %   $��10(�5�   %   
���   ���5�   %   �� $ Midterm�$
 PropertyChanged=�5�      5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��PreFinal��5�       5�      �� 5�      .R�5�      � $��15,0,0,0q�6#   .+�5�   "   �� $��50��5�   %   $��Center=�5�   %   $��10(�5�   %   
���   ���5�   %   �� $ Prefinal�$
 PropertyChanged=�5�      5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Final��5�       5�      �� 5�      .R�5�      � $��15,0,0,0q�6#   .+�5�   "   �� $��50��5�   %   $��Center=�5�   %   $��10(�5�   %   
���   ���5�   %   �� $ Final�$
 PropertyChanged=�5�      5�      5�      5�      5�      5�      