   M S B A M L   `   `   `  ����]  YCarService.Admin.Modules.Worksheet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:CarService.Admin.Modules.Worksheet.Views.Partials1CarService.Admin.Modules.Worksheet.Views.Partials  5      Z VCarService.Admin.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�fclr-namespace:CarService.Admin.Infrastructure.ValueConverters;assembly=CarService.Admin.Infrastructure/CarService.Admin.Infrastructure.ValueConverters 5      L    FCarService.Admin.Modules.Worksheet.Views.Partials.WorksheetTableHeader   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Qlocal?clr-namespace:CarService.Admin.Modules.Worksheet.Views.Partials     5      �sharedConvertersfclr-namespace:CarService.Admin.Infrastructure.ValueConverters;assembly=CarService.Admin.Infrastructure     5        � 	Resources  5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $L F/CarService.Admin.Infrastructure;component/Styles/SharedResources.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   
������� � ColumnDefinitions 5       �� 5!      $��* �6#   �� 5"      $��* �6#   .+�5%      �� $��Car Service details:��6   $��0��5&      $��5 0 0 0q�6(      WorksheetTableHeader#��[  5'      �� 5)      $��Partner details:��6   $��1��5*      $��5 0 0 0q�6(   #��[  5+      5-      �� 50   
   $��1��6   
���   �$��0 1 0 1q�51   %   ._�52      �  53      �� 54      $��* �6'   �� 55      $��* �6'   .+�59      �� $��0��6   
���   �$��0 0 1 0q�5:       �� Padding$ 10q�63   ._�5;      ��  �� Orientation$ Vertical=�6!   .+�5<      �� $��Car Service��6$   $
��Bold"�5=   $   �� 5>      $��Address��6$   �� 5?      $��Phone number��6$   �� 5@      $��
Tax number��6$   5A      5B      �� 5E      $��1��6   
���   �$ 10q�5F      ._�5G      �� $ Vertical=�6!   .+�5H      ]� ��.  .+�5I      �� $
��Left=�6(   $
��Bold"�5N   (   $
��Wrap=�5O   (   ��5J   (   �� **(DataContext.Reservation.Partner.FullName+ �� RelativeSource ��  �� Mode$ FindAncestor=�	 �� AncestorLevel$	 2��
 �� AncestorType"
 >�5O   (   5P      ]� 5Q      ��.  .+�5R      �� $
��Left=�6(   $
��Wrap=�5W   (   ��5S   (   �� *)'DataContext.Reservation.Partner.Address+ �� $ FindAncestor=�$	 2��"
 >�5W   (   5X      5Y      5Z      5\      5]      �� 5`   
   $��2��6   
���   �$��0 0 0 1q�5a   %   ._�5b      �  5c      �� 5d      $��* �6'   �� 5e      $��* �6'   �� 5f      $��* �6'   .+�5j      � $��0��6    5k      �� 5l      $
��Auto �6(   �� 5m      $
��Auto �6(   .+�5p      �� $��0��6   
���   �$ 5q�6>   $��0 0 1 1q�5q      
�������._�5r      �� $��Reservation date:��6%   #��[  5s   %   $��Center=�5t   %   5u      �� 5w      $��1��6   
���   �$ 5q�6>   $��0 0 1 0q�5x      ._�5y      �� $ 
Horizontal=�6%   $��Center=�5z   %   .+�5{      �� $
��Bold"�5   (   ��5{   (   �� *$"DataContext.Reservation.Time.Month+ �� $ FindAncestor=�$	 2��"
 >�5   (   �� 5�      $��/��6(   $
��Bold"�5�   (   �� 5�      $
��Bold"�5�   (   ��5�   (   �� *" DataContext.Reservation.Time.Day+ �� $ FindAncestor=�$	 2��"
 >�5�   (   �� 5�      $��/��6(   $
��Bold"�5�   (   �� 5�      $
��Bold"�5�   (   ��5�   (   �� *#!DataContext.Reservation.Time.Year+ �� $ FindAncestor=�$	 2��"
 >�5�   (   5�      5�      5�      � 5�      $��1��6    5�      �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   .+�5�      �� $��0��6   
���   �$ 5q�6>   $��0 0 1 1q�5�      
�������._�5�      �� $��	Mechanic:��6%   #��[  5�   %   $��Center=�5�   %   5�      �� 5�      $��1��6   
���   �$ 5q�6>   $��0 0 1 0q�5�      ._�5�      ]� ��.  $��Center=�5�   $   .+�5�      �� $
��Bold"�5�   )   ��5�   )   �� *DataContext.User.FullName+ �� $ FindAncestor=�$	 2��"
 >�5�   )   5�      5�      5�      � 5�      $��2��6    5�      �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   .+�5�      �� $��0��6   
���   �$ 5q�6>   $��0 0 0 1q�5�      
�������._�5�      �� $��Reservation type:��6%   #��[  5�   %   $��Center=�5�   %   5�      �� 5�      $��1��6   
���   �$ 5q�6>   ._�5�      �� $
��Bold"�5�   %   $��Center=�5�   %   ��5�   %   �� *#!DataContext.Reservation.Type.Name+ �� $ FindAncestor=�$	 2��"
 >�5�   %   5�      5�      5�      5�      �� 5�   
   $��3��6   
���   �$��0 0 0 1q�5�      y�5�      �� *Reservation.Comment+ �� 	Converter ]  WCarService.Admin.Infrastructure.ValueConverters.StringContentToVisibilityValueConverter  ._�5�      �  5�      �� 5�      $
��Auto �6$   �� 5�      $��* �6$   .+�5�      �� $��0��6   
���   �$ 5q�6:   $��0 0 0 1q�5�      
�������._�5�      �� $��Comment:��6!   #��[  5�   !   5�      �� 5�      $��1��6   $
 10 5q�6&   $
��Left=�5�      ._�5�      �� $
��Bold"�5�   !   $
��Wrap=�5�   !    �� TextAlignment$
 Left=�5�   !   ��5�   !   �� *!DataContext.Reservation.Comment+ �� $ FindAncestor=�$	 2��"
 >�5�   !   5�      5�      5�      �� 5�   
   $��4��6   $ 5 10 0 0q�5�      $��0 0 0 1q�5�      
���   �$��2��5�   %   ._�5�      �� $ Vertical=�6   .+�5�      �� $��Materials and components:��6     	MenuTitle#��[ 5�        FontSizeRegular#��[ 5�      
���   �5�      5�      5�      �� 5�   
   $��5��6   
���   �$��0 0 0 1q�5�   %   
�������._�5     �  5     �� 5     $��50 �6'   �� 5     $��* �6'   �� 5     $��* �6'   �� 5     $��* �6'   .+�5     �� $��0��6   
���   �$��0 0 1 0q�5     �� 5     $��1��6   $ 5q�6)   
���   �$��0 0 1 0q�5     ._�5     �� $��Name:��6    $
��Bold"�5      $��Center=�5      5     �� 5     $��2��6   $ 5q�6)   
���   �$��0 0 1 0q�5  )   ._�5     �� $��	Quantity:��6    $
��Bold"�5      $��Center=�5      5     �� 5     $��3��6   $ 5q�6)   ._�5     �� $��
Price: ($)��6    $
��Bold"�5      $��Center=�5       5!     5#     5%     5'     5)     