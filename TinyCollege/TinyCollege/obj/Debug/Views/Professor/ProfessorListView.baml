   M S B A M L   `   `   `  ����F  BTinyCollege, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TinyCollege.Views.ProfessorTinyCollege.Views.Professor  5      3    -TinyCollege.Views.Professor.ProfessorListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TinyCollege.Views.Professor     5      U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullW SMaterialDesignThemes.MahApps, Version=0.0.7.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�6#      PrimaryHueMidBrush#���   6/   .��5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'   .+�5      �� $��0,0,10,0q�5      $
��Left=�5      $��Center=�5      $��12(�5        TextHeaderStyle#��[ 5      $��
PROFESSORS��5       �� 5"      $��1��5#      $��Right=�5$       �� Orientation$ 
Horizontal=�5%      .+�5&      �� $��0,0,10,0q�5'      $��0q�5(        MaterialDesignFlatButton#���  5*      ��5)      ��  �� Path$$ ProfessorModule.AddProfCommand�  Locator �� Source# [ ��5+      '  !MaterialDesignThemes.Wpf.PackIcon  5,      $��25��5-   !   $��25��5.   !     SecondaryAccentBrush#���  5/   !   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�50   !   52      �� 54      $��0,0,10,0q�55      $��0q�56      $��Right=�57      #���  59      ��58      �� $# ClassModule.DeleteProfCommand�# [ ��5:        5;      $��25��5<   !   $��25��5=   !   #���  5>   !   $ Delete=�5?   !   5A      5B      5C      5D      �� 5F   
   $��1��5G      $��5q�5H      
������ 
������ ��5K      �� $# ProfessorModule.ProfessorList�# [  �� SelectedItem 5L      �� $# ClassModule.SelectedProfessor�# [ ��5M      �� 5N      .R�5O      �� $ 
Horizontal=�6!   .+�5P      � .+�5Q      A� $��30��5R   !   $��30��5S   !   #���   5T   !   �� 5U      $��Center=�5V   !   $��Center=�5W   !   $ 
Horizontal=�5X   !   .+�5Y   "   �� $��12(�5Z   %   
�������  TextInfoHeaderStyle#��[ 5\   %   ��5]   %   �� $! Model.ProfessorFirstName[0]��� 5^   "   $��12(�5_   %   
�������#��[ 5a   %   ��5b   %   �� $" Model.ProfessorFamilyName[0]�5c      5d      �� 5f      $��10,0,0,0q�5g      $��Center=�5h      $ 
Horizontal=�5i      .+�5j      �� $��12(�5k   !   
���   �#��[ 5m   !   ��5n   !   �� $ Model.ProfessorFamilyName��� 5o      $��12(�5p   !   
���   �#��[ 5r   !   $��, ��5s   !   �� 5t      $��12(�5u   !   
���   �#��[ 5w   !   ��5x   !   �� $ Model.ProfessorFirstName��� 5y      $��12(�5z   !   
���   �#��[ 5|   !   $�� ��5}   !   �� 5~      $��12(�5   !   
���   �#��[ 5�   !   ��5�   !   �� $" Model.ProfessorMiddleName[0]��� 5�      $��12(�5�   !   
���   �#��[ 5�   !   $��.��5�   !   5�      5�      5�      5�      5�      5�      