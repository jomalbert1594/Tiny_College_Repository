   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TinyCollege.Views.CourseTinyCollege.Views.Course  5      1    +TinyCollege.Views.Course.AddingCourseWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:TinyCollege.Views.Course     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � Title$  AddingCourseWindow��5	      $	��650��5
      $	��650��5      
�������$X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5      $��14(�5      $��Medium"�5         MaterialDesignBody#���   5       � DataContext 5      ��  �� Path$ CourseModule�  Locator �� Source# [ .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�5      $��5q�5        PrimaryHueMidBrush#���  5      .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5       $
��Auto �6'   .+�5#      �� $��5,0,0,0q�5$      $��Center=�5%      $��12(�5&        TextHeaderStyle#��[ 5'      $��
ADD COURSE��5(      �� 5*      $��1��5+      $��20,0,0,0q�5,      $��Right=�5-       �� Orientation$ 
Horizontal=�5.      .+�5/      �� $��0,0,10,0q�50      $��0q�51        MaterialDesignFlatButton#���  53      ��52      �� $ SaveCourseCommand���54      '  !MaterialDesignThemes.Wpf.PackIcon  55      $��25��56   !   $��25��57   !     SecondaryAccentBrush#���  58   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ ContentSave=�59   !   5;      �� 5=      $��0,0,10,0q�5>      $��0q�5?      #���  5A      ��5@      �� $ CancelCourseCommand���5B        5C      $��25��5D   !   $��25��5E   !   #���  5F   !   $ BlockHelper=�5G   !   5I      5J      5K      5L      #  MaterialDesignThemes.Wpf.Card  5N   
   $��1��5O      $��5,5,5,0q�5P      $��10q�5Q      .��5R      �� .+�5S      �  6   �� $ 	NewCourse� 5T      �� 5U      $
��Auto �6(   �� 5V      $
��Auto �6(   �� 5W      $
��Auto �6(    5Z      �� 5[      $��* �6+   �� 5\      $��* �6+   �� 5]      $��* �6+   .+�5`      �  5a      �� 5b      $
��Auto �6/   �� 5c      $
��Auto �6/   .+�5f        $��35��5g      $��35��5h      $��
10,10,10,0q�5i      #���  5j      $
 Book=�5k      �� 5m      $��1��6%   .+�5n      �� $��75��5o   !   $��	0,10,10,0q�5p   !   $��12(�5q   !   ��5r   !   �� $ CourseId� �� UpdateSourceTrigger$ PropertyChanged=��� 5s      $��10(�5t   !   $��Italic$�5u   !     TextInfoHeaderStyle#��[ 5v   !   $��Course Code��5w   !   5x      5y      � 5{      $��1��6    5|      �� 5}      $
��Auto �6/   �� 5~      $
��Auto �6/   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5�      #���  5�      $
 Book=�5�      �� 5�      $��1��6%   .+�5�      �� $��75��5�   !   $��	0,10,10,0q�5�   !   $��12(�5�   !   	 �� TextWrapping$
	 Wrap=�5�   !   ��5�   !   �� $ 
CourseName�$ PropertyChanged=�5�   !   �� 5�      $��10(�5�   !   $��Italic$�5�   !   #��[ 5�   !   $��Course Name��5�   !   $
��Wrap=�5�   !   5�      5�      � 5�      $��2��6    5�      �� 5�      $
��Auto �6/   �� 5�      $
��Auto �6/   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5�      #���  5�      $ 
CreditCard=�5�      �� 5�      $��1��6%   .+�5�      �� $��75��5�   !   $��	0,10,10,0q�5�   !   $��12(�5�   !   $
	 Wrap=�5�   !   ��5�   !   �� $ CourseUnits�$ PropertyChanged=�5�   !   �� 5�      $��10(�5�   !   $��Italic$�5�   !   #��[ 5�   !   $��Units��5�   !   5�      5�      5�      �� 5�      $��2,0,0,0q�6    6.   �� $ 	NewCourse�.+�5�      �  5�      �� 5�      $
��Auto �6/   �� 5�      $
��Auto �6/   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5�      #���  5�      $ ChairSchool=�5�      �� 5�      $��1��6%   .+�5�      �� $��	0,10,10,0q�5�   !   $��12(�5�   !     TextInfoStyle#��[ 5�   !   ��5�   !   �� $% Department.Model.DepartmentName��� 5�      $��10(�5�   !   $��Italic$�5�   !   #��[ 5�   !   $��
Department��5�   !   5�      5�      &   System.Windows.Controls.DataGrid  5�      $	��350��5�      $	��350��5�      $��5,5,5,35q�5�      $	��Top=�5�      
   AutoGenerateColumns
 .  
������   DataGridStyle   	CellStyle# �  5�      $   HorizontalScrollBarVisibility$
 Auto=�5�      ��5�      �� $ DepartmentList� �� SelectedItem 5�      �� $ 
Department�   Columns 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 65      Header 5�   "   �� 5�   &   $��Center=�5�   )   $��10(�5�   )   $
��Bold"�5�   )   
���   �#��[ 5�   )   $��Department ID��5�   )      CellTemplate 5�   "   �� 5�   &   .R�5�   *   �� $��15,0,0,0q�5�   -   $��Center=�5�   -   $��10(�5�   -   $
��Bold"�5�   -   
���   �#��[ 5�   -   ��5�   -   �� $ Model.DepartmentId�5�   '   5�        5�      $	 150 65    5�   "   �� 5�   &   $��Center=�5�   )   $��10(�5�   )   $
��Bold"�5�   )   
���   �#��[ 5�   )   $��Department Name��5�   )    5�   "   �� 5�   &   .R�5   *   �� $��15,0,0,0q�5  -   $��Center=�5  -   $��10(�5  -   
���   �#��[ 5  -   ��5  -   �� $ Model.DepartmentName�5  '   5	       5
     $	 100 65    5  "   �� 5  &   $��Center=�5  )   $��10(�5  )   $
��Bold"�5  )   
���   �#��[ 5  )   $��School��5  )    5  "   �� 5  &   .R�5  *   �� $��15,0,0,0q�5  -   $��Center=�5  -   $��10(�5  -   
���   �#��[ 5  -   ��5  -   �� $ School.Model.SchoolName�5  '   5     5!     5"     5#     5$     5%     5&     