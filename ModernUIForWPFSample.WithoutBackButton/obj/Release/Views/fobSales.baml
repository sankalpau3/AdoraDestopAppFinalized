   M S B A M L   `   `   `  ���� a  ]ModernUIForWPFSample.WithoutBackButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ModernUIForWPFSample.WithoutBackButton&ModernUIForWPFSample.WithoutBackButton  ;    5ModernUIForWPFSample.WithoutBackButton.Views.fobSales   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     RWithoutBackButton4clr-namespace:ModernUIForWPFSample.WithoutBackButton     -     � 	Resources     fOBSalesFrequencyViewSource��%   &	        �� .���  � DataContext# [  ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFBEBEBE�� � Offset$ 0Q�� $ 	#FFF6F5F5��$ 1Q�.+��� $
��Left=�$	��590��$��	26,50,0,0q�$	��Top=�$	��600��
����������� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFBEBEBE��$ 0Q�� $ 	#FFF6F5F5��$ 1Q��� $��	FOB Sales��$
��Left=�$��	10,10,0,0q�$	��Top=�$��35��$	��211��$��22(�
���   ��� $��Factory Name��$
��Left=�$��
64,161,0,0q�$	��Top=�$��29��$	��118��
���   �$��16(��� $"��Add/Update FOB Sales Details��$
��Left=�$��	39,64,0,0q�  SimpleLabel#���  $	��Top=�$	��273��$��18.667(�$��32��$
��Bold"�
���   ��� ���	#B5FFFFFF$
��Left=�$��4��$��
26,101,0,0q�
�������$	��Top=�$	��358��$��0���� -    ��Name$ factoryNameFobSalesText�� �� 
IsReadOnly . $
��Left=�$��28��$��234,161,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��338���� -   	 ��Name$	 searchCombo��$
��Left=�$��
64,118,0,0q�$	��Top=�$	��508��$��36��
 �� 
IsEditable
 .  �� IsTextSearchEnabled .  �� $��Description��$
��Left=�$��
64,239,0,0q�$	��Top=�$��22��$	��175��
���   �$��16(��� $
��Item��$
��Left=�$��
64,201,0,0q�$	��Top=�
���   �$��16(�$��62���� $,��&No of pieces Available                ��$
��Left=�$��
64,278,0,0q�$	��Top=����	#FF070707$��16(��� $��Cost per piece��$
��Left=�$��
64,318,0,0q�$	��Top=����	#FF222121$��16(��� -   $ textDescriptionFobSales�� . $
��Left=�$��28��$��234,239,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��338���� -   $ textNoOfPiecesFobSales�� . $
��Left=�$��29��$��234,278,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��338���� -   $ textCostPerPieceFobSales�� . $
��Left=�$��29��$��234,318,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��338���� -   $ textItemNameFobSales�� . $
��Left=�$��28��$��234,200,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��338���� ���	#B5FFFFFF$
��Left=�$��4��$��
32,356,0,0q�
�������$	��Top=�$	��358��$��0���� $��Frequency ID��$
��Left=�$��
64,370,0,0q�$	��Top=����	#FF222121$��16(��� -   $	 frequencyIDComboBox��$
��Left=�$��234,370,0,0q�$	��Top=�$	��169��$��29��
 .  �� $��No of pieces��$
��Left=�$��
64,406,0,0q�$	��Top=����	#FF222121$��16(��� -	   $ noOfPiecesFrequncyText�� � ToolTip$&  Enter No of pieces going to sell��$
��Left=�$��29��$��234,406,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��338���� $��Selling Price per piece��$
��Left=�$��
64,444,0,0q�$	��Top=����	#FF222121$��16(��� -
   $' !sellingPricePerPieceFrequencyText��$ Enter Cost Per Piece��$
��Left=�$��28��$��234,444,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��338���� $��Total Price��$
��Left=�$��
64,523,0,0q�$	��Top=����	#FF222121$��16(��� -   $ totalPriceFrequencyText�� . $
��Left=�$��28��$��234,523,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��338���� -    ��Name$ resetButton��$��Reset��$
��Left=�$��
64,562,0,0q�$	��Top=�$��86���� -   $ frequencyAddButton��$��Add Frequency��$
��Left=�$��365,562,0,0q�$	��Top=�$	��207���� -   $ frequencyDeleteButton��$��Delete Current Frequency��$
��Left=�$��172,562,0,0q�$	��Top=�$	��175���� $��Selling Date��$
��Left=�$��
62,488,0,0q�$	��Top=����	#FF222121$��16(�(  "System.Windows.Controls.DatePicker  -     Name$ sellingDatePicker��$
��Left=�$��234,482,0,0q�$	��Top=�$	��338��$��30���� $��	Next ID :��$
��Left=�$��427,370,0,0q�$	��Top=����	#FF222121$��16(�$��61���� -    ��Name$ nextIDLabel��$�� ��$
��Left=�$��506,404,0,0q�$	��Top=����	#FF222121$��16(��� -   $ errorLabelNoOfPieces��$y�Hidden=�$�� ��$
��Left=�$��581,449,0,0q�$	��Top=�$��21��$��20�� J� RenderTransformOrigin$ -6.976,-8.132&�����  �� ImageSource$A ;/ModernUIForWPFSample.WithoutBackButton;component/error.png���� -   $ errorLabelSellingPrice��$y�Hidden=�$�� ��$
��Left=�$��581,491,0,0q�$	��Top=�$��21��$��20��$ -6.976,-8.132&����� $A ;/ModernUIForWPFSample.WithoutBackButton;component/error.png��&   System.Windows.Controls.DataGrid  -     Name$ fOBSalesFrequencyDataGrid��   AutoGenerateColumns .     EnableRowVirtualization . $��641,116,26,60q�   RowDetailsVisibilityMode$ VisibleWhenSelected=����	#FF333333   GridLinesVisibility$	 All=�   HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 ���������    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   
dateColumn��,  &System.Windows.Controls.DataGridColumn   Header$
 Date��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Date+  -   frequencyIDColumn��$ Frequency ID��$ SizeToHeader  �� *FrequencyID+  -   noOfPiecesColumn��$ No Of Pieces��$ SizeToHeader  �� *
NoOfPieces+  -   pricePerPieceColumn��$ Price Per Piece��$ SizeToHeader  �� *PricePerPiece+  -   shipmentIDColumn��$ Shipment ID��$ SizeToHeader  �� *
ShipmentID+�� ���	#B5FFFFFF$
��Left=�$��4��$��641,101,0,0q�
�������$	��Top=�$	��358��$��0���� $��All Frequencies��$
��Left=�$��
645,64,0,0q�#���  $	��Top=�$	��273��$��18.667(�$��32��$
��Bold"�
���   �