   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TinyCollege.Views.SchoolTinyCollege.Views.School  5      1    +TinyCollege.Views.School.SchoolAddingWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:TinyCollege.Views.School     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � Title$  
Add School��5	      $	��440��5
      $	��575��5      
�������$X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5      $��14(�5      $��Medium"�5         MaterialDesignBody#���   5       � DataContext 5      ��  �� Path$ SchoolModule�  Locator �� Source# [ .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�5      $��5q�5        PrimaryHueMidBrush#���  5      .��5      �  � ColumnDefinitions 5      �� 5       $��* �6'   �� 5!      $
��auto �6'   .+�5$      �� $��0,0,10,0q�5%      $��Center=�5&      $��12(�5'        TextHeaderStyle#��[ 5(      $��
ADD SCHOOL��5)      �� 5+      $��1��5,      $��Right=�5-       �� Orientation$ 
Horizontal=�5.      .+�5/      �� $��0,0,10,0q�50      $��0q�51        MaterialDesignFlatButton#���  53      ��52      �� $ SaveSchoolCommand���54      '  !MaterialDesignThemes.Wpf.PackIcon  55      $��25��56   !   $��25��57   !     SecondaryAccentBrush#���  58   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ ContentSave=�59   !   5;      �� 5=      $��0,0,10,0q�5>      $��0q�5?      #���  5A      ��5@      �� $ CancelSchoolCommand���5B        5C      $��25��5D   !   $��25��5E   !   #���  5F   !   $ BlockHelper=�5G   !   5I      5J      5K      5L      #  MaterialDesignThemes.Wpf.Card  5N   
   $��1��5O      $��5,5,5,0q�5P      $��10q�5Q       5R      �� $ 	NewSchool�.��5S      �  5T      �� 5U      $
��Auto �6$   �� 5V      $
��Auto �6$   �� 5W      $
��Auto �6$    5Z      �� 5[      $��* �6'   �� 5\      $��* �6'   �� 5]      $��* �6'   .+�5`      �  5a      �� 5b      $
��Auto �6+   �� 5c      $
��Auto �6+   .+�5f        $��35��5g      $��35��5h      $��
10,10,10,0q�5i      $��Center=�5j      $��Center=�5k      #���  5l      $ School=�5m      �� 5o      $��1��6!   $��5,0,0,0q�61   .+�5p      �� $	��100��5q      $��	0,10,10,0q�5r      $��12(�5s      ��5t      �� $ 
SchoolName� �� UpdateSourceTrigger$ PropertyChanged=��� 5u      $��10(�5v      $��Italic$�5w        TextInfoHeaderStyle#��[ 5x      $��School Name��5y      5z      5{      � 5}      $��1��6    5~      �� 5      $
��Auto �6+   �� 5�      $
��Auto �6+   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5�      $��Center=�5�      $��Center=�5�      #���  5�      $
 City=�5�      �� 5�      $��1��6!   $��5,0,0,0q�61   .+�5�      �� $	��100��5�      $��	0,10,10,0q�5�      $��12(�5�      ��5�      �� $ Address�$ PropertyChanged=��� 5�      $��10(�5�      $��Italic$�5�      #��[ 5�      $��Address��5�      5�      5�      � 5�      $��2��6    5�      �� 5�      $
��Auto �6+   �� 5�      $
��Auto �6+   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5�      $��Center=�5�      $��Center=�5�      #���  5�      $ Account=�5�      �� 5�      $��1��6!   $��5,0,0,0q�61   .+�5�      �� $��	0,10,10,0q�5�      $��12(�5�        TextInfoStyle#��[ 5�       5�      �� $ Professor.Model���5�      `� 5�   "   	 �� StringFormat$	 {0}, {1} {2}.��6/   .1�5�   &   �� $ ProfessorFamilyName�6.   �� 5�   &   $ ProfessorFirstName�6.   �� 5�   &   $ ProfessorMiddleName[0]�6.   5�   #   5�      �� 5�      $��10(�5�      $��Italic$�5�      #��[ 5�      $
��Dean��5�      5�      5�      5�      5�      �� 5�   
   $��2��5�      $��5q�5�       5�      �� $ 	NewSchool�.+�5�      &   System.Windows.Controls.DataGrid  $	��375��5�      $	��375��5�      $��5q�5�      $	��Top=�5�      
   AutoGenerateColumns
 .  
������   DataGridStyle   	CellStyle# �  5�      $   HorizontalScrollBarVisibility$
 Auto=�5�      ��5�      �� $ ProfessorList� �� SelectedItem 5�      �� $ 	Professor�   Columns 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6-      Header 5�      �� 5�      $��Center=�5�   !   $��10(�5�   !   $
��Bold"�5�   !   
���   �#��[ 5�   !   $��Professor No��5�   !      CellTemplate 5�      �� 5�      .R�5�   "   �� $��Center=�5�   %   $��10(�5�   %   
���   �#��[ 5�   %   ��5�   %   �� $ Model.ProfessorId�5�      5�        5�      $	 200 6-    5�      �� 5�      $��Center=�5�   !   $��10(�5�   !   $
��Bold"�5�   !   
���   �#��[ 5�   !   $
��Name��5�   !    5�      �� 5�      .R�5�   "   �� $ 
Horizontal=�6-   .+�5�   &   �� $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   ��5�   )   �� $ Model.ProfessorFamilyName��� 5�   &   $��Center=�5�   )   $��10(�5�   )   
���   �#��[ 5�   )   $��, ��5�   )   �� 5   &   $��Center=�5  )   $��10(�5  )   
���   �#��[ 5  )   ��5  )   �� $ Model.ProfessorFirstName��� 5  &   $��Center=�5  )   $��10(�5  )   
���   �#��[ 5
  )   $�� ��5  )   �� 5  &   $��Center=�5  )   $��10(�5  )   
���   �#��[ 5  )   ��5  )   �� $" Model.ProfessorMiddleName[0]��� 5  &   $��Center=�5  )   $��10(�5  )   
���   �#��[ 5  )   $��.��5  )   5  #   5     5       5     $	 100 6-    5     �� 5     $��Center=�5   !   $��10(�5!  !   $
��Bold"�5"  !   
���   �#��[ 5$  !   $��Status��5%  !    5'     �� 5(     .R�5)  "   �� $��Center=�5*  %   $��10(�5+  %   
���   �#��[ 5-  %   ��5.  %   �� $ Model.ProfessorStatus�5/     51     53     54     55     56     