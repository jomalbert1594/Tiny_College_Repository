   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TinyCollege.Views.ProfessorTinyCollege.Views.Professor  5      8    2TinyCollege.Views.Professor.ProfessorClassListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TinyCollege.Views.Professor     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � DataContext  5      ��  �� Path$ ClassModule�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�5      $��5q�5        PrimaryHueMidBrush#���  5      .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0,0,10,0q�5      $��Center=�5      $��12(�5         TextHeaderStyle#��[ 5!      $��CLASS ASSIGNMENTS��5"      �� 5$      $��1��5%      $��Right=�5&       �� Orientation$ 
Horizontal=�5'      .+�5)      �� $��0,0,10,0q�5*      $��0q�5+        MaterialDesignFlatButton#���  5-      ��5,      �� $" ViewProfessorStudentsCommand���5.      '  !MaterialDesignThemes.Wpf.PackIcon  5/      $��25��50   !   $��25��51   !     SecondaryAccentBrush#���  52   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ ViewList=�53   !   55      �� 56      $��0,0,10,0q�57      $��0q�58      #���  5:      ��59      �� $ AddProfessorClassCommand���5;        5<      $��25��5=   !   $��25��5>   !   #���  5?   !   $
 Plus=�5@   !   5B      �� 5D      $��0,0,10,0q�5E      $��0q�5F      #���  5H      ��5G      �� $! DeleteProfessorClassCommand���5I        5J      $��25��5K   !   $��25��5L   !   #���  5M   !   $ Delete=�5N   !   5P      5Q      5R      5S      &   System.Windows.Controls.DataGrid  5U   
   $��1��5V      $	��235��5W      $	��235��5X      $��5,0,5,88q�5Y         AutoGenerateColumns .  
������   DataGridStyle   	CellStyle# �  5\      $	   HorizontalScrollBarVisibility$
	 Auto=�5]      ��5^      �� $ SelectedProfessor.Classes�
 �� SelectedItem
 5_      �� $ SelectedClass�   Columns 5`      4  .System.Windows.Controls.DataGridTemplateColumn  5a      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6)      Header 5b      �� 5c      $��Center=�5d      $��10(�5e      $
��Bold"�5f      
���   �  TextInfoHeaderStyle#��[ 5h      $��
Class Code��5i         CellTemplate 5k      �� 5l      .R�5m      �� $��15,0,0,0q�5n   !   $��Center=�5o   !   $��10(�5p   !   
���   �#��[ 5r   !   ��5s   !   �� $ Model.ClassId�5t      5v        5w      $	 115 6)    5x      �� 5y      $��Center=�5z      $��10(�5{      $
��Bold"�5|      
���   �#��[ 5~      $��Course Description��5       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Course.Model.CourseId�5�      5�        5�      $	 200 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Course Name��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Course.Model.CourseName�5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Schedule��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�6)   $ 
Horizontal=�6;   .+�5�   "   �� $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $ 
Model.Time��� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   $�� ��5�   %   �� 5�   "   $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $ 	Model.Day�5�      5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $
��Room��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Room.Model.RoomName�5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Units��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Course.Model.CourseUnits�5�      5�      5�      5�      5�      