   M S B A M L   `   `   `  ����P  LProducentKonsumentWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProducentKonsumentWPFProducentKonsumentWPF  5   	   &     ProducentKonsumentWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ProducentKonsumentWPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      -   5         �Name$ Output��5   *   $��2* �6   6*   �� 5      -   5        $ Start��5   *   $��1* �6   6*   �� 5      -   5        $ Input��5   *   $��2* �6   6*    � RowDefinitions 5   
   �� 5      -   5        $ ModeRow��5   (   $��4* �6   6(   �� 5      -   5        $ 
StorageRow��5   (   $��3* �6   6(   �� 5      -   5        $ StartRow��5   (   $��1* �6   6(   .+�5   
   �� -   5        $��outputModeLabel0��5      $��0��6(   $��Center=�65   $��Center=�6W   $��0��6{   $��WYBIERZ TRYB��6�   $��1,1,1,1q�6�   
���   �$
��Bold"�6�   $��24(�6�   $��40, 60, 0, 100q�6�   �� 5   
   -   5        $��inputModeComboBox��5      $��0��6-   $��2��6:   $��Center=�6J   $��Center=�6l   $��0, 60, 60, 100q�6�   .@�5      �� $%��Jeden producent jeden konsument��6   �� 5      $(��"Wielu producentów jeden konsument��6   �� 5      $(��"Jeden producent wielu konsumentów��6   �� 5      $+��%Wielu producentów wielu konsumentów��6   5      �� 5   
   -	   5        $��outputModeLabel1��5      $��1��6(   $��Center=�65   $��Center=�6W   $��0��6{   $��ROZMIAR MAGAZYNU��6�   $��1,1,1,1q�6�   
���   �$
��Bold"�6�   $��24(�6�   $��40, 50, 0, 50q�6�   �� 5   
   -
   5        $��inputStorageSizeTextBox��5      $��1��62   $��2��6?   $��Center=�6O   $��Center=�6j   
���   �$��24(�6�   $��0, 50, 60, 50q�6�   $	��250��6�   $��50��6�   �� 5   
   -   5        $��StartButton��5      $��2��6$   $��1��61   $��Center=�6A   $��Center=�6^   $��10, 10, 10, 10q�6y   $	��250��6�   $��50��6�   $��START��6�   6�   5       5"      