   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:TinyCollege.Views.StudentTinyCollege.Views.Student  5      4    .TinyCollege.Views.Student.StudentGradeListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:TinyCollege.Views.Student     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � DataContext  5      ��  �� Path$ EnrollmentModule�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�6#     PrimaryHueMidBrush#���  6/   .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0,0,10,0q�5      $��Center=�5      $��12(�5        TextHeaderStyle#��[ 5      $��GRADES��5      �� 5!      $��1��5"      $��Right=�5#       �� Orientation$ 
Horizontal=�5$      .+�5&      �� $��0,0,10,0q�5'      $��0q�5(        MaterialDesignFlatButton#���  5*      ��5)      �� $ PrintStudentGradeReport���5+      '  !MaterialDesignThemes.Wpf.PackIcon  5,      $��25��5-   !   $��25��5.   !     SecondaryAccentBrush#���  5/   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ Printer=�50   !   52      53      55      56      &   System.Windows.Controls.DataGrid  58   
   $��1��59      $	��250��5:      $	��250��5;      $��0,0,0,10q�5<         AutoGenerateColumns .  
������   DataGridStyle   	CellStyle# �  5?      $	   HorizontalScrollBarVisibility$
	 Auto=�5@      ��5A      �� $ SelectedStudent.Grades�
   Columns
 5B      4  .System.Windows.Controls.DataGridTemplateColumn  5C      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6)      Header 5D      �� 5E      $��Center=�5F      $��10(�5G      $
��Bold"�5H      
���   �  TextInfoHeaderStyle#��[ 5J      $��
Class Code��5K         CellTemplate 5M      �� 5N      .R�5O      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  $��15,0,0,0q�6B   C	  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase 	  OpeningEffect 6T   D
  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension
  *SlideInFromRight+ 
  Duration$ 0:0:0.1X�.��5P   "   �� $��Center=�5Q   %   $��10(�5R   %   
���   �#��[ 5T   %   ��5U   %   �� $ Class.Model.ClassId�5V      5W      5Y        5Z      $	 115 6)    5[      �� 5\      $��Center=�5]      $��10(�5^      $
��Bold"�5_      
���   �#��[ 5a      $��Course Description��5b       5d      �� 5e      .R�5f        $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5g   "   �� $��Center=�5h   %   $��10(�5i   %   
���   �#��[ 5k   %   ��5l   %   �� $! Class.Course.Model.CourseId�5m      5n      5p        5q      $	 200 6)    5r      �� 5s      $��Center=�5t      $��10(�5u      $
��Bold"�5v      
���   �#��[ 5x      $��Course Name��5y       5{      �� 5|      .R�5}        $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5~   "   �� $��Center=�5   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $# Class.Course.Model.CourseName�5�      5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��
Instructor��5�       5�      �� 5�      .R�5�        $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5�   "   �� $ 
Horizontal=�6-   .+�5�   &   �� $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   ��5�   )   �� $. (Class.Professor.Model.ProfessorFirstName��� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   $�� ��5�   )   �� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   ��5�   )   �� $2 ,Class.Professor.Model.ProfessorMiddleName[0]��� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   $��.��5�   )   �� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   $�� ��5�   )   �� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   ��5�   )   �� $/ )Class.Professor.Model.ProfessorFamilyName�5�   #   5�      5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Prelim��5�       5�      �� 5�      .R�5�        $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5�   "   �� $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   $�� ��5�   %   5�      5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Midterm��5�       5�      �� 5�      .R�5�        $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5�   "   �� $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   $�� ��5�   %   5�      5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��	Pre-Final��5�       5�      �� 5�      .R�5�        $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5�   "   �� $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   $�� ��5�   %   5      5     5       5     $	 100 6)    5     �� 5     $��Center=�5     $��10(�5     $
��Bold"�5	     
���   �#��[ 5     $��Final��5      5     �� 5     .R�5       $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5  "   �� $��Center=�5  %   $��10(�5  %   
���   �#��[ 5  %   $�� ��5  %   5     5     5     5     5     5     