   M S B A M L   `   `   `  ����a  ]ModernUIForWPFSample.WithoutBackButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ModernUIForWPFSample.WithoutBackButton&ModernUIForWPFSample.WithoutBackButton  5      ;    5ModernUIForWPFSample.WithoutBackButton.Views.fobSales   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      RWithoutBackButton4clr-namespace:ModernUIForWPFSample.WithoutBackButton     5      -   5          � 	Resources  5	         fOBSalesFrequencyViewSource��%   &	        �� 5
   
   6   5      .��5      �  � DataContext# [  6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFBEBEBE��6    � Offset$ 0Q�61   � 5      $ 	#FFF6F5F5��6   $ 1Q�61   5      .+�5   
   �� $
��Left=�6   $	��590��6/   $��	26,50,0,0q�6<   $	��Top=�6O   $	��600��6g   
���������5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ 	#FFBEBEBE��6#   $ 0Q�65   � 5      $ 	#FFF6F5F5��6#   $ 1Q�65   5      5      �� 5   
   $��	FOB Sales��6   $
��Left=�6$   $��	10,10,0,0q�6?   $	��Top=�6R   $��35��6j   $	��211��6v   $��22(�6�   
���   �6�   �� 5   
   $��Factory Name��6   $
��Left=�6'   $��
64,161,0,0q�6B   $	��Top=�6V   $��29��6n   $	��118��6z   
���   �$��16(�6�   �� 5    
   $"��Add/Update FOB Sales Details��6   $
��Left=�67   $��	39,64,0,0q�6R     SimpleLabel#���  6e   $	��Top=�6�   $	��273��6�   $��18.667(�6�   $��32��6�   $
��Bold"�6�   
���   �6�   �� 5!   
   ���	#B5FFFFFF$
��Left=�6%   $��4��6@   $��
26,101,0,0q�6K   
�������$	��Top=�6n   $	��358��6�   $��0��6�   �� 5"   
   -   5         ��Name$ factoryNameFobSalesText��5"       �� 
IsReadOnly . $
��Left=�6E   $��28��6`   $��234,161,0,0q�6l    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��338��6�   �� 5#   
   -   5        	 ��Name$	 searchCombo��5#      $
��Left=�6r   $��
64,118,0,0q�6�   $	��Top=�6�   $	��508��6�   $��36��6�   
 �� 
IsEditable
 .  �� IsTextSearchEnabled .  6�   �� 5$   
   $��Description��6   $
��Left=�6&   $��
64,239,0,0q�6A   $	��Top=�6U   $��22��6m   $	��175��6y   
���   �$��16(�6�   �� 5%   
   $
��Item��6   $
��Left=�6   $��
64,201,0,0q�6:   $	��Top=�6N   
���   �$��16(�6y   $��62��6�   �� 5&   
   $,��&No of pieces Available                ��6   $
��Left=�6A   $��
64,278,0,0q�6\   $	��Top=�6p   ���	#FF070707$��16(�6�   �� 5'   
   $��Cost per piece��6   $
��Left=�6)   $��
64,318,0,0q�6D   $	��Top=�6X   ���	#FF222121$��16(�6�   �� 5(   
   -   5        $ textDescriptionFobSales��5(       . $
��Left=�6E   $��28��6`   $��234,239,0,0q�6l   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��338��6�   �� 5)   
   -   5        $ textNoOfPiecesFobSales��5)       . $
��Left=�6D   $��29��6_   $��234,278,0,0q�6k   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��338��6�   �� 5*   
   -   5        $ textCostPerPieceFobSales��5*       . $
��Left=�6F   $��29��6a   $��234,318,0,0q�6m   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��338��6�   �� 5+   
   -   5        $ textItemNameFobSales��5+       . $
��Left=�6B   $��28��6]   $��234,200,0,0q�6i   $
 Wrap=�6~   $�� ��6�   $	��Top=�6�   $	��338��6�   �� 5,   
   ���	#B5FFFFFF$
��Left=�6%   $��4��6@   $��
32,356,0,0q�6K   
�������$	��Top=�6n   $	��358��6�   $��0��6�   �� 5-   
   $��Frequency ID��6   $
��Left=�6'   $��
64,370,0,0q�6B   $	��Top=�6V   ���	#FF222121$��16(�6�   �� 5.   
   -   5        $	 frequencyIDComboBox��5.      $
��Left=�6i   $��234,370,0,0q�6�   $	��Top=�6�   $	��169��6�   $��29��6�   
 .  6�   �� 5/   
   $��No of pieces��6   $
��Left=�6'   $��
64,406,0,0q�6B   $	��Top=�6V   ���	#FF222121$��16(�6�   �� 50   
   -	   5        $ noOfPiecesFrequncyText��50       � ToolTip$&  Enter No of pieces going to sell��6W   $
��Left=�6�   $��29��6�   $��234,406,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��338��6�   6�   �� 51   
   $��Selling Price per piece��6   $
��Left=�62   $��
64,444,0,0q�6M   $	��Top=�6a   ���	#FF222121$��16(�6�   �� 52   
   -
   5        $' !sellingPricePerPieceFrequencyText��52      $ Enter Cost Per Piece��6m   $
��Left=�6�   $��28��6�   $��234,444,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��338��6�   6  �� 53   
   $��Total Price��6   $
��Left=�6&   $��
64,523,0,0q�6A   $	��Top=�6U   ���	#FF222121$��16(�6�   �� 54   
   -   5        $ totalPriceFrequencyText��54       . $
��Left=�6E   $��28��6`   $��234,523,0,0q�6l   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��338��6�   �� 55   
   -   5         ��Name$ resetButton��55      $��Reset��6@   $
��Left=�6P   $��
64,562,0,0q�6k   $	��Top=�6   $��86��6�   �� 56   
   -   5        $ frequencyAddButton��56      $��Add Frequency��6-   $
��Left=�6f   $��365,562,0,0q�6�   $	��Top=�6�   $	��207��6�   �� 57   
   -   5        $ frequencyDeleteButton��57      $��Delete Current Frequency��6T   $
��Left=�6w   $��172,562,0,0q�6�   $	��Top=�6�   $	��175��6�   �� 58   
   $��Selling Date��6   $
��Left=�6'   $��
62,488,0,0q�6B   $	��Top=�6V   ���	#FF222121$��16(�6�   (  "System.Windows.Controls.DatePicker  59   
   -   5          Name$ sellingDatePicker��59      $
��Left=�60   $��234,482,0,0q�6K   $	��Top=�6`   $	��338��6x   $��30��6�   �� 5:   
   $��	Next ID :��6   $
��Left=�6$   $��427,370,0,0q�6?   $	��Top=�6T   ���	#FF222121$��16(�6�   $��61��6�   �� 5;   
   -   5         ��Name$ nextIDLabel��5;      $�� ��6%   $
��Left=�60   $��506,404,0,0q�6K   $	��Top=�6`   ���	#FF222121$��16(�6�   �� 5<   
   -   5        $ errorLabelNoOfPieces��5<      $y�Hidden=�6.   $�� ��6B   $
��Left=�6M   $��581,449,0,0q�6h   $	��Top=�6}   $��21��6�   $��20��6�    J� RenderTransformOrigin$ -6.976,-8.132&�6�   ��5=      �� 5>       �� ImageSource$A ;/ModernUIForWPFSample.WithoutBackButton;component/error.png��6   5@      �� 5A   
   -   5        $ errorLabelSellingPrice��5A      $y�Hidden=�60   $�� ��6D   $
��Left=�6O   $��581,491,0,0q�6j   $	��Top=�6   $��21��6�   $��20��6�   $ -6.976,-8.132&�6�   ��5B      �� 5C      $A ;/ModernUIForWPFSample.WithoutBackButton;component/error.png��6   5E      &   System.Windows.Controls.DataGrid  5F   
   -   5          Name$ fOBSalesFrequencyDataGrid��5F         AutoGenerateColumns .     EnableRowVirtualization . $��641,116,26,60q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   ���	#FF333333   GridLinesVisibility$	 All=�6�      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �������6q   ��    Columns 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      -   5        
dateColumn��,  &System.Windows.Controls.DataGridColumn   Header$
 Date��5H   R      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Date+6`     5I      -   5        frequencyIDColumn��$ Frequency ID��5I   `   $ SizeToHeader 6v    6@   �� *FrequencyID+6v     5J      -   5        noOfPiecesColumn��$ No Of Pieces��5J   ^   $ SizeToHeader 6t    6?   �� *
NoOfPieces+6t     5K      -   5        pricePerPieceColumn��$ Price Per Piece��5K   d   $ SizeToHeader 6}    6B   �� *PricePerPiece+6}     5L      -   5        shipmentIDColumn��$ Shipment ID��5L   ^   $ SizeToHeader 6s    6?   �� *
ShipmentID+6s   5N      �� 5O   
   ���	#B5FFFFFF$
��Left=�6%   $��4��6@   $��641,101,0,0q�6K   
�������$	��Top=�6o   $	��358��6�   $��0��6�   �� 5P   
   $��All Frequencies��6   $
��Left=�6*   $��
645,64,0,0q�6E   #���  6Y   $	��Top=�6   $	��273��6�   $��18.667(�6�   $��32��6�   $
��Bold"�6�   
���   �6�   5Q      5R      