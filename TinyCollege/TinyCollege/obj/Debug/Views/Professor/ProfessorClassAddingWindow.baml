   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TinyCollege.Views.ProfessorTinyCollege.Views.Professor  5      <    6TinyCollege.Views.Professor.ProfessorClassAddingWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TinyCollege.Views.Professor     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � Title$   ProfessorClassAddingWindow��5	      $	��825��5
      $	��425��5       � WindowStartupLocation$ CenterOwner=�5       � DataContext 5      ��  �� Path$ ClassModule�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�5      $��5q�5        PrimaryHueMidBrush#���  5      .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0,0,10,0q�5       $��Center=�5!      $��12(�5"        TextHeaderStyle#��[ 5#      $��ADD CLASS ASSIGNMENT��5$      �� 5&      $��1��5'      $��Right=�5(       �� Orientation$ 
Horizontal=�5)      .+�5*      �� $��0,0,10,0q�5+      $��0q�5,        MaterialDesignFlatButton#���  5.      ��5-      �� $ SaveProfessorClassCommand���5/      '  !MaterialDesignThemes.Wpf.PackIcon  50      $��25��51   !   $��25��52   !     SecondaryAccentBrush#���  53   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ ContentSave=�54   !   56      �� 58      $��0,0,10,0q�59      $��0q�5:      #���  5<      ��5;      �� $! CancelProfessorclassCommand���5=        5>      $��25��5?   !   $��25��5@   !   #���  5A   !   $ BlockHelper=�5B   !   5D      5E      5F      5G      &   System.Windows.Controls.DataGrid  5I   
   $��1��5J      $	��235��5K      $	��235��5L      $��	5,5,5,100q�5M      	   AutoGenerateColumns	 .  
������   DataGridStyle
   	CellStyle#
 �  5P      $   HorizontalScrollBarVisibility$
 Auto=�5Q      ��5R      �� $ ClassModule.IdleClassList�# [   �� SelectedItem 5S      �� $ SelectedClass� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5T      4  .System.Windows.Controls.DataGridTemplateColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6)      Header 5V      �� 5W      $��Center=�5X      $��10(�5Y      $
��Bold"�5Z      
���   �  TextInfoHeaderStyle#��[ 5\      $��
Class Code��5]         CellTemplate 5_      �� 5`      .R�5a      �� $��15,0,0,0q�5b   !   $��Center=�5c   !   $��10(�5d   !   
���   �#��[ 5f   !   ��5g   !   �� $ Model.ClassId�5h      5j        5k      $	 100 6)    5l      �� 5m      $��Center=�5n      $��10(�5o      $
��Bold"�5p      
���   �#��[ 5r      $��Course Description��5s       5u      �� 5v      .R�5w      �� $��15,0,0,0q�5x   !   $��Center=�5y   !   $��10(�5z   !   
���   �#��[ 5|   !   ��5}   !   �� $ Course.Model.CourseId�5~      5�        5�      $	 200 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Course Name��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Course.Model.CourseName�5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Schedule��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�6)   $ 
Horizontal=�6;   .+�5�   "   �� $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $ 
Model.Time��� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   $�� ��5�   %   �� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $ 	Model.Day�5�      5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Section��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Model.ClassName�5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $
��Room��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Room.Model.RoomName�5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Units��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Course.Model.CourseUnits�5�      5�      5�      5�      5      