   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TinyCollege.Views.RoomTinyCollege.Views.Room  5      .    (TinyCollege.Views.Room.RoomClassListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:TinyCollege.Views.Room     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � DataContext  5      ��  �� Path$ RoomModule.SelectedRoom�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�6#     PrimaryHueMidBrush#���  6/   .��5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0,0,10,0q�5      $��Center=�5      $��12(�5        TextHeaderStyle#��[ 5      $��CLASS ASSIGNMENTS��5      �� 5!      $��1��5"      $��Right=�5#       �� Orientation$ 
Horizontal=�5$      .+�5&      �� $��0,0,10,0q�5'      $��0q�5(        MaterialDesignFlatButton#���  5)      ��5*      '  !MaterialDesignThemes.Wpf.PackIcon  5+      $��25��5,   !   $��25��5-   !     SecondaryAccentBrush#���  5.   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ Printer=�5/   !   51      52      53      54      &   System.Windows.Controls.DataGrid  56   
   $��1��57      $	��375��58      $	��375��59      $��5q�5:      $	��Top=�5;         AutoGenerateColumns .  
������   DataGridStyle   	CellStyle# �  5>      $	   HorizontalScrollBarVisibility$
	 Auto=�5?      ��5@      �� $ Classes�
   Columns
 5A      4  .System.Windows.Controls.DataGridTemplateColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6)      Header 5C      �� 5D      $��Center=�5E      $��10(�5F      $
��Bold"�5G      
���   �  TextInfoHeaderStyle#��[ 5I      $��
Class Code��5J         CellTemplate 5L      �� 5M      .R�5N      �� $��15,0,0,0q�5O   !   $��Center=�5P   !   $��10(�5Q   !   
���   �#��[ 5S   !   ��5T   !   �� $ Model.ClassId�5U      5W        5X      $	 120 6)    5Y      �� 5Z      $��Center=�5[      $��10(�5\      $
��Bold"�5]      
���   �#��[ 5_      $��Course Description��5`       5b      �� 5c      .R�5d      �� $��15,0,0,0q�5e   !   $��Center=�5f   !   $��10(�5g   !   
���   �#��[ 5i   !   ��5j   !   �� $ Course.Model.CourseId�5k      5m        5n      $	 200 6)    5o      �� 5p      $��Center=�5q      $��10(�5r      $
��Bold"�5s      
���   �#��[ 5u      $��Course Name��5v       5x      �� 5y      .R�5z      �� $��15,0,0,0q�5{   !   $��Center=�5|   !   $��10(�5}   !   
���   �#��[ 5   !   ��5�   !   �� $ Course.Model.CourseName�5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Schedule��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Model.ClassSchedule�5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $
��Room��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Room.Model.RoomName�5�      5�        5�      $	 100 6)    5�      �� 5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      
���   �#��[ 5�      $��Units��5�       5�      �� 5�      .R�5�      �� $��15,0,0,0q�5�   !   $��Center=�5�   !   $��10(�5�   !   
���   �#��[ 5�   !   ��5�   !   �� $ Course.Model.CourseUnits�5�      5�      5�      5�      5�      