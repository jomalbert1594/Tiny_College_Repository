   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TinyCollege.Views.ProfessorTinyCollege.Views.Professor  5      3    -TinyCollege.Views.Professor.ProfessorEditView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TinyCollege.Views.Professor     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        � DataContext  5      ��  �� Path$# ClassModule.SelectedProfessor�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��
10,10,10,0q�5      $��5q�5        PrimaryHueMidBrush#���  5      .��5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'   .+�5      �� $��0,0,10,0q�5      $��Center=�5      $��12(�5         TextHeaderStyle#��[ 5!      $��EDIT PROFESSOR��5"      �� 5$      $��1��5%      $��Right=�5&       �� Orientation$ 
Horizontal=�5'      .+�5(      �� $��0,0,10,0q�5)      $��0q�5*        MaterialDesignFlatButton#���  5,      ��5+      �� $ SaveCommand���5-      '  !MaterialDesignThemes.Wpf.PackIcon  5.      $��25��5/   !   $��25��50   !     SecondaryAccentBrush#���  51   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ ContentSave=�52   !   54      �� 56      $��0,0,10,0q�57      $��0q�58      #���  59      ��5:      �� $ CancelCommand���5;        5<      $��25��5=   !   $��25��5>   !   #���  5?   !   $ BlockHelper=�5@   !   5B      5C      5D      5E      #  MaterialDesignThemes.Wpf.Card  5G   
   $��1��5H      $��5q�5I      $��10q�5J      .��5K      �� .+�5L      �   6   �� $ 	EditModel� 5M      �� 5N      $
��Auto �6(   �� 5O      $
��Auto �6(    5R      �� 5S      $��* �6+   �� 5T      $��* �6+   �� 5U      $��* �6+   .+�5Y      �  5Z      �� 5[      $
��Auto �6/   �� 5\      $��* �6/   .+�5_        $��35��5`      $��35��5a      $��
10,10,10,0q�5b      #���  5c      $ Account=�5d      �� 5f      $��1��6%   .+�5g      �� $��	0,10,10,0q�5h   !   $��12(�5i   !   ��5j   !   �� $ 	FirstName��� 5k      $��10(�5l   !   $��Italic$�5m   !     TextInfoHeaderStyle#��[ 5n   !   $��
First Name��5o   !   5p      5q      � 5s      $��1��6    5t      �� 5u      $
��Auto �6/   �� 5v      $��* �6/   .+�5y        $��35��5z      $��35��5{      $��
10,10,10,0q�5|      #���  5}      $
 City=�5~      �� 5�      $��1��6%   .+�5�      �� $��	0,10,10,0q�5�   !   $��12(�5�   !   ��5�   !   �� $ Address��� 5�      $��10(�5�   !   $��Italic$�5�   !   #��[ 5�   !   $��Address��5�   !   5�      5�      � 5�      $��1��6   $��2��6(    5�      �� 5�      $
��Auto �6/   �� 5�      $��* �6/   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5�      #���  5�      $ ContactMail=�5�      �� 5�      $��1��6%   .+�5�      �� $��	0,10,10,0q�5�   !   $��12(�5�   !   ��5�   !   �� $ 	ContactNo��� 5�      $��10(�5�   !   $��Italic$�5�   !   #��[ 5�   !   $��Contact No.��5�   !   5�      5�      � 5�      $��1��6    5�      �� 5�      $
��Auto �6/   �� 5�      $��* �6/   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5�      #���  5�      $ Account=�5�      �� 5�      $��1��6%   .+�5�      �� $��	0,10,10,0q�5�   !   $��12(�5�   !   ��5�   !   �� $ 
MiddleName��� 5�      $��10(�5�   !   $��Italic$�5�   !   #��[ 5�   !   $��Middle Name��5�   !   5�      5�      � 5�      $��1��6   $��1��6(    5�      �� 5�      $
��Auto �6/   �� 5�      $��* �6/   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5�      #���  5�      $
 Cake=�5�      �� 5�      $��1��6%   .+�5�      (  "System.Windows.Controls.DatePicker  $��	0,10,10,0q�5�   !      DisplayDate 5�   !   �� $ 	Birthdate�   SelectedDate 5�   !   �� $ 	Birthdate��� 5�      $��10(�5�   !   $��Italic$�5�   !   #��[ 5�   !   $��	Birthdate��5�   !   5�      5�      � 5�      $��2��6    5�      �� 5�      $
��Auto �6/   �� 5�      $��* �6/   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5�      #���  5�      $ Account=�5�      �� 5�      $��1��6%   .+�5�      �� $��	0,10,10,0q�5�   !   $��12(�5�   !   ��5�   !   �� $ 
FamilyName��� 5�      $��10(�5�   !   $��Italic$�5�   !   #��[ 5�   !   $��Family Name��5�   !   5�      5�      5�      �� 5�        6   �� $ 	EditModel�.+�5�      �  5�      �� 5�      $
��Auto �6/   �� 5�      $
��Auto �6/   .+�5�        $��35��5�      $��35��5�      $��
10,10,10,0q�5      #���  5     $ ChartArc=�5     �� 5     $��1��6%   .+�5     �� $	��100��5  !   $��	0,10,10,0q�5  !   ��5  !   �� $ 
StatusList�	 �� SelectedItem	 5	  !   �� $ Status�
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5
     $��10(�5  !   $��Italic$�5  !   #��[ 5  !   $��Status��5  !   5     5     �� 5     $��
10,10,10,0q�6!   .+�5     �  5     �� 5  "   $
��Auto �63   �� 5  "   $
��Auto �63   .+�5       $��35��5  !   $��35��5  !   $��	0,10,10,0q�5  !   #���  5  !   $ ChairSchool=�5  !   �� 5      $��1��6)   .+�5!  "   �� $��	0,10,10,0q�5"  %   $��12(�5#  %   
���   �#��[ 5%  %   ��5&  %   �� $% Department.Model.DepartmentName��� 5'  "   $��10(�5(  %   $��Italic$�5)  %   #��[ 5*  %   $��Division��5+  %   5,     5-     &   System.Windows.Controls.DataGrid  5/     $	��235��50     $	��235��51     $��5,5,5,50q�52        AutoGenerateColumns .  
������   DataGridStyle   	CellStyle# �  55     $   HorizontalScrollBarVisibility$
 Auto=�56     ��57     �� $ DepartmentList�	 58     �� $ 
Department�   Columns 59     4  .System.Windows.Controls.DataGridTemplateColumn  5:  "   ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$	 200	 69      Header 5;  &   �� 5<  *   $��Center=�5=  -   $��10(�5>  -   $
��Bold"�5?  -   
���   �#��[ 5A  -   $��Department ID��5B  -      CellTemplate 5D  &   �� 5E  *   .R�5F  .   �� $��15,0,0,0q�5G  1   $��Center=�5H  1   $��10(�5I  1   $
��Bold"�5J  1   
���   �#��[ 5L  1   ��5M  1   �� $ Model.DepartmentId�5N  +   5P  #     5Q  "   $	 150	 69    5R  &   �� 5S  *   $��Center=�5T  -   $��10(�5U  -   $
��Bold"�5V  -   
���   �#��[ 5X  -   $��Department Name��5Y  -    5[  &   �� 5\  *   .R�5]  .   �� $��15,0,0,0q�5^  1   $��Center=�5_  1   $��10(�5`  1   
���   �#��[ 5b  1   ��5c  1   �� $ Model.DepartmentName�5d  +   5f  #     5g  "   $	 100	 69    5h  &   �� 5i  *   $��Center=�5j  -   $��10(�5k  -   $
��Bold"�5l  -   
���   �#��[ 5n  -   $��School��5o  -    5q  &   �� 5r  *   .R�5s  .   �� $��15,0,0,0q�5t  1   $��Center=�5u  1   $��10(�5v  1   
���   �#��[ 5x  1   ��5y  1   �� $ School.Model.SchoolName�5z  +   5|  #   5~     5     5�     5�     5�     5�     5�     