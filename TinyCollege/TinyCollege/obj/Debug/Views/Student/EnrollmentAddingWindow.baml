   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:TinyCollege.Views.StudentTinyCollege.Views.Student  5      6    0TinyCollege.Views.Student.EnrollmentAddingWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:TinyCollege.Views.Student     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � Title$  Add Enrollment��5	      $
��1175��5
      $	��375��5       � DataContext 5      ��  �� Path$ EnrollmentModule�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�5      $��5q�5        PrimaryHueMidBrush#���  5      .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� $��0,0,10,0q�5      $��Center=�5       $��12(�5!        TextHeaderStyle#��[ 5"      $��ADD ENROLLMENT��5#      �� 5%      $��1��5&      $��Right=�5'       �� Orientation$ 
Horizontal=�5(      .+�5)      �� $��0,0,10,0q�5*      $��0q�5+        MaterialDesignFlatButton#���  5-      ��5,      �� $" SaveStudentEnrollmentCommand���5.      '  !MaterialDesignThemes.Wpf.PackIcon  5/      $��25��50   !   $��25��51   !     SecondaryAccentBrush#���  52   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ ContentSave=�53   !   55      �� 57      $��0,0,10,0q�58      $��0q�59      #���  5;      ��5:      �� $! CancelSaveEnrollmentCommand���5<        5=      $��25��5>   !   $��25��5?   !   #���  5@   !   $ BlockHelper=�5A   !   5C      5D      5E      5F      &   System.Windows.Controls.DataGrid  5H   
   $��1��5I      $	��235��5J      $	��235��5K      $��	0,0,0,100q�5L         AutoGenerateColumns .  
������   DataGridStyle	   	CellStyle#	 �  5O      $
   HorizontalScrollBarVisibility$

 Auto=�5P      ��5Q      �� $! ClassModule.ModuleClassList�# [   �� SelectedItem 5R      �� $ SelectedClass� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5S      4  .System.Windows.Controls.DataGridTemplateColumn  5T      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6)      Header 5U      �� 5V      $��Center=�5W      $��10(�5X      $
��Bold"�5Y      
���   �  TextInfoHeaderStyle#��[ 5[      $��
Class Code��5\         CellTemplate 5^      �� 5_      .R�5`      �� $��15,0,0,0q�5a   !   $��Center=�5b   !   $��10(�5c   !   
���   �#��[ 5e   !   ��5f   !   �� $ Model.ClassId�5g      5i        5j      $	 100 6)    5k      �� 5l      $��Center=�5m      $��10(�5n      $
��Bold"�5o      
���   �#��[ 5q      $��Course Description��5r       5t      �� 5u      .R�5v      �� $��15,0,0,0q�5w   !   $��Center=�5x   !   $��10(�5y   !   
���   �#��[ 5{   !   ��5|   !   �� $ Course.Model.CourseId�5}      5        5�      $	 200 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Course Name��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Course.Model.CourseName�5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Schedule��5�       5�      �� 5�      .R�5�      �� $��	15,10,0,0q�6)   $ 
Horizontal=�6<   .+�5�   "   �� $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $ 
Model.Time� �� StringFormat$ d���� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $ 	Model.Day�$ d��5�      5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Section��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Model.ClassName�5�      5�        5�      $	 200 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��
Instructor��5�       5�      �� 5�      .R�5�      �� $��	15,10,0,0q�6)   $ 
Horizontal=�6<   .+�5�   "   �� $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $) #Professor.Model.ProfessorFamilyName��� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   $��, ��5�   %   �� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $( "Professor.Model.ProfessorFirstName��� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   $�� ��5�   %   �� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $, &Professor.Model.ProfessorMiddleName[0]��� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   $��.��5�   %   5�      5�      5�        5�      $	 100 6)    5�      �� 5      $��Center=�5     $��10(�5     $
��Bold"�5     
���   �#��[ 5     $
��Room��5      5     �� 5	     .R�5
     �� $��15,0,0,0q�5  !   $��Center=�5  !   $��10(�5  !   
���   �#��[ 5  !   ��5  !   �� $ Room.Model.RoomName�5     5       5     $	 100 6)    5     �� 5     $��Center=�5     $��10(�5     $
��Bold"�5     
���   �#��[ 5     $��Units��5      5     �� 5     .R�5      �� $��15,0,0,0q�5!  !   $��Center=�5"  !   $��10(�5#  !   
���   �#��[ 5%  !   ��5&  !   �� $ Course.Model.CourseUnits�5'     5)       5*     $	 150 6)    5+     �� 5,     $��Center=�5-     $��10(�5.     $
��Bold"�5/     
���   �#��[ 51     $��
Department��52      54     �� 55     .R�56     �� $��15,0,0,0q�57  !   $��Center=�58  !   $��10(�59  !   
���   �#��[ 5;  !   ��5<  !   �� $, &Course.Department.Model.DepartmentName�5=     5?     5A     5B     5C     