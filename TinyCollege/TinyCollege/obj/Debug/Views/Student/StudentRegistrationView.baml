   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:TinyCollege.Views.StudentTinyCollege.Views.Student  5      7    1TinyCollege.Views.Student.StudentRegistrationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:TinyCollege.Views.Student     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � DataContext  5      ��  �� Path$ EnrollmentModule�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�6#     PrimaryHueMidBrush#���  6/   .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0,0,10,0q�5      $��Center=�5      $��12(�5        TextHeaderStyle#��[ 5      $��ENROLLED SUBJECTS��5      �� 5!      $��1��5"      $��Right=�5#       �� Orientation$ 
Horizontal=�5$      .+�5&      �� $��0,0,10,0q�5'      $��0q�5(        MaterialDesignFlatButton#���  5*      ��5)      �� $" PrintStudentEnrollmentReport���5+      '  !MaterialDesignThemes.Wpf.PackIcon  5,      $��25��5-   !   $��25��5.   !     SecondaryAccentBrush#���  5/   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ Printer=�50   !   52      �� 54      $��0,0,10,0q�55      $��0q�56      #���  58      ��57      �� $! AddStudentEnrollmentCommand���59        5:      $��25��5;   !   $��25��5<   !   #���  5=   !   $
 Plus=�5>   !   5@      �� 5B      $��0,0,10,0q�5C      $��0q�5D      #���  5F      ��5E      �� $$ DeleteStudentEnrollmentCommand���5G        5H      $��25��5I   !   $��25��5J   !   #���  5K   !   $ Delete=�5L   !   5N      5O      5P      5Q      &   System.Windows.Controls.DataGrid  5S   
   $��1��5T      $	��250��5U      $	��250��5V      $��0,0,0,10q�5W         AutoGenerateColumns .  
������   DataGridStyle   	CellStyle# [ 5Z      $	   HorizontalScrollBarVisibility$
	 Auto=�5[      ��5\      �� $! SelectedStudent.Enrollments�
 �� SelectedItem
 5]      �� $ SelectedEnrollment�   Columns 5^      4  .System.Windows.Controls.DataGridTemplateColumn  5_      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 75 6)      Header 5`      �� 5a      $��Center=�5b      $��10(�5c      $
��Bold"�5d      
���   �  TextInfoHeaderStyle#��[ 5f      $��
Class Code��5g         CellTemplate 5i      �� 5j      .R�5k      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  $��15,0,0,0q�6B   C	  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase 	  OpeningEffect 6T   D
  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension
  *SlideInFromRight+ 
  Duration$ 0:0:0.1X�.��5l   "   �� $��Center=�5m   %   $��10(�5n   %   
���   �#��[ 5p   %   ��5q   %   �� $ Class.Model.ClassId�5r      5s      5u        5v      $	 115 6)    5w      �� 5x      $��Center=�5y      $��10(�5z      $
��Bold"�5{      
���   �#��[ 5}      $��Course Description��5~       5�      �� 5�      .R�5�        $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5�   "   �� $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $! Class.Course.Model.CourseId�5�      5�      5�        5�      $	 200 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Course Name��5�       5�      �� 5�      .R�5�        $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5�   "   �� $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $# Class.Course.Model.CourseName�5�      5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Date Enrolled��5�       5�      �� 5�      .R�5�        $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5�   "   �� $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $ Model.EnrollmentDate� �� StringFormat$ d��5�      5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Schedule��5�       5�      �� 5�      .R�5�        $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5�   "   �� $ 
Horizontal=�6-   .+�5�   &   �� $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   ��5�   )   �� $ Class.Model.Time��� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   $�� ��5�   )   �� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   ��5�   )   �� $ Class.Model.Day�5�   #   5�      5�      5�        5�      $	 150 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��
Instructor��5�       5�      �� 5�      .R�5�        $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5�   "   �� $ 
Horizontal=�6-   .+�5�   &   �� $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   ��5�   )   �� $/ )Class.Professor.Model.ProfessorFamilyName��� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   $��, ��5�   )   �� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   ��5   )   �� $. (Class.Professor.Model.ProfessorFirstName��� 5  &   $��Center=�5  )   $��10(�5  )   
���   �#��[ 5  )   $�� ��5  )   �� 5  &   $��Center=�5  )   $��10(�5	  )   
���   �#��[ 5  )   ��5  )   �� $2 ,Class.Professor.Model.ProfessorMiddleName[0]��� 5  &   $��Center=�5  )   $��10(�5  )   
���   �#��[ 5  )   $��.��5  )   5  #   5     5     5       5     $	 100 6)    5     �� 5     $��Center=�5     $��10(�5     $
��Bold"�5     
���   �#��[ 5     $
��Room��5       5"     �� 5#     .R�5$       $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5%  "   �� $��Center=�5&  %   $��10(�5'  %   
���   �#��[ 5)  %   ��5*  %   �� $ Class.Room.Model.RoomName�5+     5,     5.       5/     $ 75 6)    50     �� 51     $��Center=�52     $��10(�53     $
��Bold"�54     
���   �#��[ 56     $��Units��57      59     �� 5:     .R�5;       $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5<  "   �� $��Center=�5=  %   $��10(�5>  %   
���   �#��[ 5@  %   ��5A  %   �� $$ Class.Course.Model.CourseUnits�5B     5C     5E       5F     $	 150 6)    5G     �� 5H     $��Center=�5I     $��10(�5J     $
��Bold"�5K     
���   �#��[ 5M     $��
Department��5N      5P     �� 5Q     .R�5R       $��15,0,0,0q�6B    6T   
  *SlideInFromRight+$ 0:0:0.1X�.��5S  "   �� $��Center=�5T  %   $��10(�5U  %   
���   �#��[ 5W  %   ��5X  %   �� $2 ,Class.Course.Department.Model.DepartmentName�5Y     5Z     5\     5^     5_     5`     