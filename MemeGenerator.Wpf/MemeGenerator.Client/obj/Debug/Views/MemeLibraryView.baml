   M S B A M L   `   `   `  ����H  DMemeGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MemeGenerator.Client.ViewsMemeGenerator.Client.Views  5      0    *MemeGenerator.Client.Views.MemeLibraryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:MemeGenerator.Client.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��5 �6   .+�5   
   �� -   5        $��LoadMemeByUser��5   9   $��5q�6   $��1��6   $��1��6,   .��6O   Load your memes6`   �� 5   
   -   5        $��LoadMemeByTitle��5   9   $��5q�6   $��2��6   $��1��6,   .��6P   Load memes by title6e   �� 5   
   -   5        $��SearchByNameProperty��5   d   $��5q�6   $��3��6   $��1��6-   $��25��6:   $
��Left=�6I   $	��200��6�   �� 5   
   -   5         ��Name$ Memes��5   U   $��1��6   $��3��6#   $��2��67   $��2��6D   $��Stretch=�6d   $	��Top=�6�   ��5       �� 5!      .R�5"      A�  A� Columns$ 2��6"   $��Stretch=�6.   5#      ��5%      �� 5&      .R�5'      ��  �� Orientation$ Vertical=�6!   $��Stretch=�68   $��Stretch=�6T   .+�5(      �� $��Stretch=�69   $	��Top=�6W   $��UniformToFill=�6o   ��6    �� *Image+6o   �� 5)      $��Stretch=�6;   $��Bottom=�6Y   ��6$   �� *Title+6Y   5*      5+      5-      5.      5/      