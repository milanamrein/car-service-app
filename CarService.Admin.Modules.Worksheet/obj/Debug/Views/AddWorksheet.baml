   M S B A M L   `   `   `  ����]  YCarService.Admin.Modules.Worksheet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:CarService.Admin.Modules.Worksheet.Views(CarService.Admin.Modules.Worksheet.Views  5      u?clr-namespace:CarService.Admin.Modules.Worksheet.Views.Partials1CarService.Admin.Modules.Worksheet.Views.Partials  5      Z VCarService.Admin.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�fclr-namespace:CarService.Admin.Infrastructure.ValueConverters;assembly=CarService.Admin.Infrastructure/CarService.Admin.Infrastructure.ValueConverters 5      �\clr-namespace:CarService.Admin.Infrastructure.Views;assembly=CarService.Admin.Infrastructure%CarService.Admin.Infrastructure.Views 5	      ;    5CarService.Admin.Modules.Worksheet.Views.AddWorksheet   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:CarService.Admin.Modules.Worksheet.Views     5      Tpartials?clr-namespace:CarService.Admin.Modules.Worksheet.Views.Partials     5      �sharedConvertersfclr-namespace:CarService.Admin.Infrastructure.ValueConverters;assembly=CarService.Admin.Infrastructure     5      tsharedViews\clr-namespace:CarService.Admin.Infrastructure.Views;assembly=CarService.Admin.Infrastructure     5	      P LPrism.Wpf, Version=6.3.0.0, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5
      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  .  � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $L F/CarService.Admin.Infrastructure;component/Styles/SharedResources.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ._�5       ;  5CarService.Admin.Infrastructure.Views.ErrorMessageBox  5!      �� 5$   
   $��1��6      PrimaryDarkBrush#��[  5%      $��0 0 0 2q�5&      ._�5'      ��  �� Orientation$ Vertical=�6   .+�5)      �� $ 
Horizontal=�6   .+�5,      ��   FontAwesomeFileText#��[ 6       TextBlockIconLargeAccentMain#��[ 5-       �� 5.      $��
Worksheet:��6      	MenuTitle#��[ 5/       $��5 0 0 0q�50       52      � 55       � IsIndeterminate .   MainProgressBar#��[ 56      y�57      �� *	IsLoading+ �� 	Converter W  QCarService.Admin.Infrastructure.ValueConverters.IsLoadingVisibilityValueConverter  5:      5;      �� 5>   
   $��2��6    �� Padding$ 15q�6   y�5?      �� *	IsLoading+ V  PCarService.Admin.Infrastructure.ValueConverters.IsLoadedVisibilityValueConverter  ._�5A      �� $��1q�6   
���   �
�������._�5B      �  5C      �� 5D      $
��Auto �6(   �� 5E      $��* �6(   �� 5F      $
��Auto �6(   .+�5J      L   FCarService.Admin.Modules.Worksheet.Views.Partials.WorksheetTableHeader  $��0��64   � 5M      $��1��6    5N      �� 5O      $��* �6,   �� 5P      $
��Auto �6,   .+�5T      F   @CarService.Admin.Modules.Worksheet.Views.Partials.WorksheetTable  $��0��62   B   <CarService.Admin.Modules.Worksheet.Views.Partials.TotalPrice  5W      $��1��6.   5Y      �� 5\      $��2��6   
���   �$��0 1 0 0q�5^      y�5_      �� *AddedMaterials.Count+ U  OCarService.Admin.Infrastructure.ValueConverters.CountToVisibilityValueConverter  	 �� ConverterParameter$
	 this��._�5c      � 
 � ColumnDefinitions
 5d      �� 5e   "   $��* �63   �� 5f   "   $
��Auto �63   �� 5g   "   $��* �63   .+�5j      �� $ 
Horizontal=�6)   $��10q�5k   -   $��1��69   .+�5m   "   �� $��0 0 5 0q�6)     ButtonConfirmation#��[ 5n   -   ��5o   -   �� *ConfirmWorksheetCommand+.��5p   &   �� $ 
Horizontal=�61   .+�5q   *   ��   FontAwesomeSuccess#��[ 64     SuccessMessageIcon#��[ 5r   8   �� 5s   *   $��Confirm��64   5t   '   5u   #   �� 5v   "   $��5 0 0 0q�6)     ButtonCancel#��[ 5w   -   $��Reservations��5y   -   ��5x   -   �� *NavigateCommand+.��5z   &   �� $ 
Horizontal=�61   .+�5{   *   ��  	 FontAwesomeCancel#��[	 64    
 ErrorMessageIcon#��[
 5|   8   
�������5}   8   �� 5~   *   $��Cancel��64   5   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      