   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TinyCollege.Views.BuildingTinyCollege.Views.Building  5      A%clr-namespace:TinyCollege.Views.ClassTinyCollege.Views.Class  5      C&clr-namespace:TinyCollege.Views.CourseTinyCollege.Views.Course  5      K*clr-namespace:TinyCollege.Views.DepartmentTinyCollege.Views.Department  5	      )clr-namespace:TinyCollegeTinyCollege  5      I)clr-namespace:TinyCollege.Views.ProfessorTinyCollege.Views.Professor  5      ?$clr-namespace:TinyCollege.Views.RoomTinyCollege.Views.Room  5      C&clr-namespace:TinyCollege.Views.SchoolTinyCollege.Views.School  5      E'clr-namespace:TinyCollege.Views.StudentTinyCollege.Views.Student  5          TinyCollege.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =building(clr-namespace:TinyCollege.Views.Building     5      7class%clr-namespace:TinyCollege.Views.Class     5      9course&clr-namespace:TinyCollege.Views.Course     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      A
department*clr-namespace:TinyCollege.Views.Department     5	      E ADragablz, Version=0.0.3.182, Culture=neutral, PublicKeyToken=null6dragablz'http://dragablz.net/winfx/xaml/dragablz  5
      %localclr-namespace:TinyCollege  5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      ;	professor)clr-namespace:TinyCollege.Views.Professor   5      1room$clr-namespace:TinyCollege.Views.Room   5      5school&clr-namespace:TinyCollege.Views.School   5      7student'clr-namespace:TinyCollege.Views.Student   5        � Title$  
MainWindow��5      $
��1366��5      $	��720��5      
�������$X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5      $��14(�5      $��Medium"�5         MaterialDesignBody#���   5       � WindowStartupLocation$ CenterScreen=�5       � 	Resources 5        MainTabControlStyle % !MaterialDesignTabablzControlStyle �� BasedOn �� 
TargetType  Dragablz.TabablzControl��%/   &	       7  �� 5   
   8   "  5"      5$      .��5&      � .+�5'   
   �� .+�5(      (  "MaterialDesignThemes.Wpf.ColorZone  $��10q�6'     PrimaryHueDarkBrush#���  64   .��5)      �  � ColumnDefinitions 5*      �� 5+      $��* �6+   �� 5,      $��* �6+   .+�5/      ��  �� Orientation$ 
Horizontal=�6!   .+�50      '  !MaterialDesignThemes.Wpf.PackIcon  $��20��51      $��20��52      $��0,0,10,0q�53      $��Center=�54      
��������  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ School=�56      �� 57      $��0,0,10,0q�58      $��Center=�59        TextHeaderStyle#��[ 5:      $��Tiny College, Inc.��5;      5<      �� 5>      $��1��5?      $��0,0,10,0q�5@      $��Right=�5A      $ 
Horizontal=�5B      .+�5C      � $��0,0,10,0q�6   .+�5D      A� $��30��5E   !   $��30��5F   !     SecondaryAccentBrush#���  5G   !     5H      $��20��5I   !   $��20��5J   !   $��Center=�5K   !   $��Center=�5L   !   
�������$ FaceProfile=�5N   !   5O      �� 5P      $��0,0,10,0q�5Q      $��Center=�5R      #��[ 5S      $��
My Profile��5T      �� 5V       * &MaterialDesignFloatingActionMiniButton#���  6!   ��5W      � 5X   "   .+�5Y   &   A� $��30��5Z   )   $��30��5[   )   
���  ��5\   )     5]   &   $��20��5^   )   $��20��5_   )   $��Center=�5`   )   $��Center=�5a   )   
�������$ Logout=�5c   )   5d   #   5f      5g      5h      5i        5j      $	��645��5k      $��0q�5l      #��[ 5m      .@�5n      �� $��Student��6   .��5o      � .+�5p      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent   J� Opacity$	 100Q�5q      	   RunHint$	 IsVisibleChanged=�5s      C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase
   OpeningEffectsOffset
 5r      O  IMaterialDesignThemes.Wpf.Transitions.IndexedItemOffsetMultiplierExtension  *
0:0:0.01+   OpeningEffects 5t      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5u   "      Kind$ SlideInFromTop=�6B     5v   "   $ FadeIn=�6B   .��5x      �  5y   "   �� 5z   &   $��* �67   �� 5{   &   $
��Auto �67   �� 5|   &   $��4* �67   .+�5~   "   /	   )TinyCollege.Views.Student.StudentListView	  $��10q�6:   �� 5   "   $��1��5�   %     PrimaryHueMidBrush#���  5�   %   $��2q�5�   %   � 5�   "   $��2��6'   .+�5�   &   �� $��Center=�5�   )   $��Center=�5�   )   $��20(�5�   )   $
��Bold"�5�   )     TextInfoHeaderStyle#��[ 5�   )   $��No Student Selected!��5�   )   y�5�   )   �� *" EnrollmentModule.SelectedStudent+ �� ConverterParameter$ inverse�� 	 NullToVisibilityConverter �� 	Converter# [	  
 Locator �� Source# [
 � 5�   &   y�6+   �� *" EnrollmentModule.SelectedStudent+# [	 # [
 .+�5�   *   � .+�5�   .   1
   +TinyCollege.Views.Student.StudentModuleView
  y�6H   �� *,*EnrollmentModule.SelectedStudent.IsEditing+  BoolToVisibilityConverter# [ # [
 /   )TinyCollege.Views.Student.EditStudentView  5�   .   y�6F   �� *,*EnrollmentModule.SelectedStudent.IsEditing+$ inverse��# [ # [
 5�   +   5�   '   5�   #   5�      5�      5�      5�      �� 5�      $��	Professor��6   .��5�      � .+�5�        $	 100Q�5�      $	 IsVisibleChanged=�5�      
 5�        *
0:0:0.01+ 5�        5�   "   $ SlideInFromTop=�6B     5�   "   $ FadeIn=�6B   .��5�      �  5�   "   �� 5�   &   $��* �67   �� 5�   &   $
��Auto �67   �� 5�   &   $��4* �67   .+�5�   "   3   -TinyCollege.Views.Professor.ProfessorListView  $��10q�6>   �� 5�   "   $��1��5�   %   #���  5�   %   $��2q�5�   %   � 5�   "   $��2��6'   .+�5�   &   �� $��Center=�5�   )   $��Center=�5�   )   $��20(�5�   )   $
��Bold"�5�   )   #��[ 5�   )   $��No Professor Selected!��5�   )   y�5�   )   �� *ClassModule.SelectedProfessor+$ inverse��# [	 # [
 � 5�   &   y�6+   �� *ClassModule.SelectedProfessor+# [	 # [
 .+�5�   *   � .+�5�   .   5   /TinyCollege.Views.Professor.ProfessorModuleView  y�6L   �� *)'ClassModule.SelectedProfessor.IsEditing+# [ # [
 3   -TinyCollege.Views.Professor.ProfessorEditView  5�   .   y�6J   �� *)'ClassModule.SelectedProfessor.IsEditing+$ inverse��# [ # [
 5�   +   5�   '   5�   #   5�      5�      5�      5�      �� 5�      $��Classes��6   .��5�      � .+�5�        $	 100Q�5�      $	 IsVisibleChanged=�5�      
 5�        *
0:0:0.01+ 5�        5�   "   $ SlideInFromTop=�6B     5�   "   $ FadeIn=�6B   .��5�      �  5�   "   �� 5�   &   $��* �67   �� 5�   &   $
��Auto �67   �� 5�   &   $��4* �67   .+�5�   "   +   %TinyCollege.Views.Class.ClassListView  $��10q�66   �� 5�   "   $��1��5�   %   #���  5�   %   $��2q�5�   %   � 5�   "   $��2��6'   .+�5�   &   �� $��Center=�5�   )   $��Center=�5�   )   $��20(�5�   )   $
��Bold"�5�   )   #��[ 5�   )   $��No Class Selected!��5�   )   y�5�   )   �� *!ClassModule.SelectedModuleClass+$ inverse��# [	 # [
 � 5�   &   y�6+   �� *!ClassModule.SelectedModuleClass+# [	 # [
 .+�5�   *   � .+�5�   .   -   'TinyCollege.Views.Class.ClassModuleView  y�6D   �� *+)ClassModule.SelectedModuleClass.IsEditing+# [ # [
 -   'TinyCollege.Views.Class.EditClassWindow  5�   .   $��10q�6D   y�6P   �� *+)ClassModule.SelectedModuleClass.IsEditing+$ inverse��# [ # [
 5�   +   5�   '   5�   #   5�      5�      5�      5�      �� 5�      $��Course��6   .��5�      � .+�5�        $	 100Q�5�      $	 IsVisibleChanged=�5�      
 5�        *
0:0:0.01+ 5�        5�   "   $ SlideInFromTop=�6B     5�   "   $ FadeIn=�6B   .��5�      �  5�   "   �� 5�   &   $��* �67   �� 5�   &   $
��Auto �67   �� 5�   &   $��4* �67   .+�5�   "   -   'TinyCollege.Views.Course.CourseListView  $��10q�68   �� 5�   "   $��1��5   %   #���  5  %   $��2q�5  %   � 5  "   $��2��6'   .+�5  &   �� $��Center=�5  )   $��Center=�5  )   $��20(�5  )   $
��Bold"�5  )   #��[ 5	  )   $��No Course Selected!��5
  )   y�5  )   �� *CourseModule.SelecteCourse+$ inverse��# [	 # [
 � 5  &   y�6+   �� *CourseModule.SelecteCourse+# [	 # [
 .+�5  *   � .+�5  .   /   )TinyCollege.Views.Course.CourseModuleView  y�6F   �� *&$CourseModule.SelecteCourse.IsEditing+# [ # [
 8   2TinyCollege.Views.Course.CourseEditInformationView  5  .   $��10q�6O   y�6[   �� *&$CourseModule.SelecteCourse.IsEditing+$ inverse��# [ # [
 5  +   5  '   5  #   5     5     5     5     �� 5     $
��Room��6   .��5     � .+�5       $	 100Q�5     $	 IsVisibleChanged=�5     
 5       *
0:0:0.01+ 5       5  "   $ SlideInFromTop=�6B     5   "   $ FadeIn=�6B   .��5"     �  5#  "   �� 5$  &   $��* �67   �� 5%  &   $
��Auto �67   �� 5&  &   $��4* �67   .+�5(  "   )   #TinyCollege.Views.Room.RoomListView  $��10q�64   �� 5)  "   $��1��5*  %   #���  5+  %   $��2q�5,  %   � 5-  "   $��2��6'   .+�5.  &   �� $��Center=�5/  )   $��Center=�50  )   $��20(�51  )   $
��Bold"�52  )   #��[ 53  )   $��No Room Selected!��54  )   y�55  )   �� *RoomModule.SelectedRoom+$ inverse��# [	 # [
 � 57  &   y�6+   �� *RoomModule.SelectedRoom+# [	 # [
 .+�58  *   � .+�59  .   +   %TinyCollege.Views.Room.RoomModuleView  y�6B   �� *#!RoomModule.SelectedRoom.IsEditing+# [ # [
 4   .TinyCollege.Views.Room.RoomEditInformationView  5:  .   $��10q�6K   y�6W   �� *#!RoomModule.SelectedRoom.IsEditing+$ inverse��# [ # [
 5;  +   5<  '   5=  #   5>     5?     5@     5A     �� 5B     $��
Department��6   .��5C     � .+�5D       $	 100Q�5E     $	 IsVisibleChanged=�5G     
 5F       *
0:0:0.01+ 5H       5I  "   $ SlideInFromTop=�6B     5J  "   $ FadeIn=�6B   .��5L     �  5M  "   �� 5N  &   $��* �67   �� 5O  &   $
��Auto �67   �� 5P  &   $��4* �67   .+�5R  "   5   /TinyCollege.Views.Department.DepartmentListVIew  $��10q�6@   �� 5S  "   $��1��5T  %   #���  5U  %   $��2q�5V  %   � 5W  "   $��2��6'   .+�5X  &   �� $��Center=�5Y  )   $��Center=�5Z  )   $��20(�5[  )   $
��Bold"�5\  )   #��[ 5]  )   $��No Department Selected!��5^  )   y�5_  )   �� *%#DepartmentModule.SelectedDepartment+$ inverse��# [	 # [
 � 5a  &   y�6+   �� *%#DepartmentModule.SelectedDepartment+# [	 # [
 .+�5b  *   � .+�5c  .   7   1TinyCollege.Views.Department.DepartmentModuleView  y�6N   �� */-DepartmentModule.SelectedDepartment.IsEditing+# [ # [
 @   :TinyCollege.Views.Department.DepartmentEditInformationView  5d  .   $��10q�6W   y�6c   �� */-DepartmentModule.SelectedDepartment.IsEditing+$ inverse��# [ # [
 5e  +   5f  '   5g  #   5h     5i     5j     5k     �� 5l     $��Building��6   .��5m     � .+�5n       $	 100Q�5o     $	 IsVisibleChanged=�5q     
 5p       *
0:0:0.01+ 5r       5s  "   $ SlideInFromTop=�6B     5t  "   $ FadeIn=�6B   .��5v     �  5w  "   �� 5x  &   $��* �67   �� 5y  &   $
��Auto �67   �� 5z  &   $��4* �67   .+�5|  "   1   +TinyCollege.Views.Building.BuildingListView  $��10q�6<   �� 5}  "   $��1��5~  %   #���  5  %   $��2q�5�  %   � 5�  "   $��2��6'   .+�5�  &   �� $��Center=�5�  )   $��Center=�5�  )   $��20(�5�  )   $
��Bold"�5�  )   #��[ 5�  )   $��No Building Selected!��5�  )   y�5�  )   �� *!BuildingModule.SelectedBuilding+$ inverse��# [	 # [
 � 5�  &   y�6+   �� *!BuildingModule.SelectedBuilding+# [	 # [
 .+�5�  *   � .+�5�  .   3   -TinyCollege.Views.Building.BuildingModuleView  y�6J   �� *+)BuildingModule.SelectedBuilding.IsEditing+# [ # [
 <   6TinyCollege.Views.Building.BuildingEditInformationForm  5�  .   $��10q�6S   y�6_   �� *+)BuildingModule.SelectedBuilding.IsEditing+$ inverse��# [ # [
 5�  +   5�  '   5�  #   5�     5�     5�     5�     �� 5�     $��School��6   .��5�     � .+�5�       $	 100Q�5�     $	 IsVisibleChanged=�5�     
 5�       *
0:0:0.01+ 5�       5�  "   $ SlideInFromTop=�6B     5�  "   $ FadeIn=�6B   .��5�     �  5�  "   �� 5�  &   $��* �67   �� 5�  &   $
��Auto �67   �� 5�  &   $��4* �67   .+�5�  "   -   'TinyCollege.Views.School.SchoolListView  $��10q�68   �� 5�  "   $��1��5�  %   #���  5�  %   $��2q�5�  %   � 5�  "   $��2��6'   .+�5�  &   �� $��Center=�5�  )   $��Center=�5�  )   $��20(�5�  )   $
��Bold"�5�  )   #��[ 5�  )   $��No School Selected!��5�  )   y�5�  )   �� *SchoolModule.SelectedSchool+$ inverse��# [	 # [
 � 5�  &   y�6+   �� *SchoolModule.SelectedSchool+# [	 # [
 .+�5�  *   � .+�5�  .   /   )TinyCollege.Views.School.SchoolModuleView  y�6F   �� *'%SchoolModule.SelectedSchool.IsEditing+# [ # [
 8    2TinyCollege.Views.School.SchoolEditInformationView   5�  .   $��10q�6O   y�6[   �� *'%SchoolModule.SelectedSchool.IsEditing+$ inverse��# [ # [
 5�  +   5�  '   5�  #   5�     5�     5�     5�     5�     5�     5�     5�     