   M S B A M L   `   `   `  ���� a  ]ModernUIForWPFSample.WithoutBackButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ModernUIForWPFSample.WithoutBackButton&ModernUIForWPFSample.WithoutBackButton  D    >ModernUIForWPFSample.WithoutBackButton.Views.StockLotPurchases   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     RWithoutBackButton4clr-namespace:ModernUIForWPFSample.WithoutBackButton     -     >�Name$  StockLotPurchases1��$	��700��$
��1366�����	#FFE9ECF0 � 	Resources    actualCostViewSource   purchasingShipmentViewSource��%   &	        &	      �� �� .��� -    �Name$ 
LayoutRoot�� � DataContext# [  ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFBEBEBE�� � Offset$ 0Q�� $ 	#FFEAE8E8��$ 1Q�.+��� ���	#FFFBFBFB$��44,64,776,118q��� $��Stock Lot Purchase��$
��Left=�$��12.972,11.041,0,0q�  SimpleLabel#���  $	��Top=�$��21.333(�$��37.452��$��194.018��
���   ��� $��Add Purchase Details��$
��Left=�$��	59,64,0,0q�#���  $	��Top=�$	��243��$��18.667(�$��47��
���   ��� ���	#B5FFFFFF$
��Left=�$��3��$��	44,93,0,0q�
���   �$	��Top=�$	��360��$��0���� $
��Date��$
��Left=�#���  $	��Top=�$	��243��$��16(�$��47��
���   �$��
59,116,0,0q��� $��Shipment Title��$
��Left=�#���  $	��Top=�$	��243��$��16(�$��47��
���   �$��
59,156,0,0q��� $��Number of Pieces��$
��Left=�#���  $	��Top=�$	��243��$��16(�$��47��
���   �$��
59,196,0,0q��� $��Price Per Piece��$
��Left=�#���  $	��Top=�$	��243��$��16(�$��47��
���   �$��
59,236,0,0q��� $��	Transport��$
��Left=�#���  $	��Top=�$	��243��$��16(�$��47��
���   �$��
59,276,0,0q��� $��Supplier Commission��$
��Left=�#���  $	��Top=�$	��243��$��16(�$��47��
���   �$��
59,316,0,0q��� $��Miscellaneous��$
��Left=�#���  $	��Top=�$	��243��$��16(�$��47��
���   �$��
59,356,0,0q��� $��Total Shipment Cost��$
��Left=�#���  $	��Top=�$	��243��$��16(�$��46��
���   �$��
59,435,0,0q��� $��Actual Cost Per Piece��$
��Left=�$��
59,481,0,0q�#���  $	��Top=�$	��243��$��16(�$��47��
���   ��� -    ��Name$ txtAddNoPieces��$
��Left=�$��23��$��304,197,0,0q�	 �� TextWrapping$
	 Wrap=�$	��Top=�$	��148��
 �� TextAlignment$
 Right=� � ToolTip$ Enter a whole number���� -   $ txtAddPricePiece��$
��Left=�$��23��$��304,237,0,0q�$
	 Wrap=�$	��Top=�$	��148��$
 Right=�$ Enter amount���� -   $ txtAddTrans��$
��Left=�$��23��$��304,277,0,0q�$
	 Wrap=�$	��Top=�$	��148��$
 Right=�$ Enter Amount���� -   $ txtAddSupComm��$
��Left=�$��23��$��304,317,0,0q�$
	 Wrap=�$	��Top=�$	��148��$
 Right=�$ Enter Amount���� -   $ 
txtAddMisc��$
��Left=�$��23��$��304,357,0,0q�$
	 Wrap=�$	��Top=�$	��148��$
 Right=�(  "System.Windows.Controls.DatePicker  -     Name$ 
txtAddDate��$
��Left=�$��304,116,0,0q�$	��Top=�$	��148��   FirstDayOfWeek$ Monday=�$ Select date of purchase��   DisplayDate$ 
2015-03-14��|�.  �� $	��LKR��$
��Left=�$��486,238,0,0q�$	��Top=����	#FF333333$��14(���Z� �� $	��LKR��$
��Left=�$��486,281,0,0q�$	��Top=����	#FF333333$��14(���Z� �� $	��LKR��$
��Left=�$��486,321,0,0q�$	��Top=����	#FF333333$��14(���Z� �� $	��LKR��$
��Left=�$��486,358,0,0q�$	��Top=����	#FF333333$��14(���Z� �� -	   $ txtAddTotalCost��$
��Left=�$��23��$��304,435,0,0q�$
	 Wrap=�$	��Top=�$	��148��$
 Right=����	#FF767272|�.  $ Total Shipment Cost���� -
   $ 	txtAddCPP��$
��Left=�$��23��$��304,481,0,0q�$
	 Wrap=�$	��Top=�$	��148��$
 Right=����	#FF767272|�.  $ Actual Cost Per Piece���� -    ��Name$ curlbl2��$	��LKR��$
��Left=�$��486,483,0,0q�$	��Top=����	#FF333333$��14(���Z� �� -   $ curlbl1��$	��LKR��$
��Left=�$��486,439,0,0q�$	��Top=����	#FF333333$��14(���Z� �� -    ��Name$ btnAdd��$	��Add��$
��Left=�$��434,543,0,0q�$	��Top=�$��93���� -   $ btnResetAdd��$��Reset��$
��Left=�$��328,543,0,0q�$	��Top=�$��93���� -   $
��Left=�$��94�����	#FFFBFBFB$	��Top=�$	��648��$��
634,64,0,0q��� $��Edit / Remove Shipment��$
��Left=�$��
659,79,0,0q�#���  $	��Top=�$	��243��$��18.667(�$��47��
���   ��� ���	#B5FFFFFF$
��Left=�$��3��$��634,108,0,0q�
���   �$	��Top=�$	��360��$��0���� $��Ship ID��$
��Left=�#���  $	��Top=�$��46��$��26��
���   �$��965,123,0,0q��� $��Shipment Title��$
��Left=�#���  $	��Top=�$	��118��$��26��
���   �$��659,123,0,0q��� -    ��Name$ txtDelShipName��$
��Left=�$��744,119,0,0q�$	��Top=�$	��205��$��24���� -   $ 	btnDelete��$��Delete��$
��Left=�$��1171,119,0,0q�$	��Top=�$��93��$��24���� $
��Left=�$	��411�����	#FFFBFBFB$	��Top=�$	��648��$��634,171,0,0q��� $
��Date��$
��Left=�#���  $	��Top=�$��46��$��26��
���   �$��659,183,0,0q�  -   $ txtSearchDate��$
��Left=�$��705,179,0,0q�$	��Top=�$	��148��$��11(�$��24���� $��Shipment Title��$
��Left=�#���  $	��Top=�$	��118��$��26��
���   �$��866,183,0,0q��� -   $ 	btnSearch��$��Search��$
��Left=�$��1171,179,0,0q�$	��Top=�$��93��$��24���� -   $ txtSearchShipName��$
��Left=�$��24��$��951,179,0,0q�$
	 Wrap=�$	��Top=�$	��205���� -   $ 
lblAddDate��$�� ��$
��Left=�$��457,126,0,0q�$	��Top=����	#FF9E0505$��10��$��10��$��36(�$y�Hidden=�����  �� ImageSource$H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ lblAddShipName��$�� ��$
��Left=�$��532,162,0,0q�$	��Top=����	#FF9E0505$��10��$��10��$��36(�$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ lblAddNoPieces��$�� ��$
��Left=�$��457,203,0,0q�$	��Top=����	#FF9E0505$��10��$��10��$��36(�$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ 	lblAddPPP��$�� ��$
��Left=�$��457,243,0,0q�$	��Top=����	#FF9E0505$��10��$��10��$��36(�$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ lblAddTrans��$�� ��$
��Left=�$��457,284,0,0q�$	��Top=����	#FF9E0505$��10��$��10��$��36(�$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ lblAddSupCom��$�� ��$
��Left=�$��457,323,0,0q�$	��Top=����	#FF9E0505$��10��$��10��$��36(�$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ 
lblAddMisc��$�� ��$
��Left=�$��457,363,0,0q�$	��Top=����	#FF9E0505$��10��$��10��$��36(�$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ txtAddShipName��$
��Left=�$��23��$��304,156,0,0q�$
	 Wrap=�$	��Top=�$	��223�� J� RenderTransformOrigin$ 0.5,0.5&�$ Enter Shipment Name���� -   $��	Calculate��$
��Left=�$��434,391,0,0q�$	��Top=�$��93��&   System.Windows.Controls.DataGrid  -     Name$  purchasingShipmentDataGrid��   AutoGenerateColumns .     EnableRowVirtualization . $��659,221,102,131q�   RowDetailsVisibilityMode$ VisibleWhenSelected=����	#FF333333   
IsReadOnly .    GridLinesVisibility$	 All=�����  �� Source# [    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   titleColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Title��   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Title+  -    shipmentIDColumn��$ Shipment ID��$ SizeToHeader  �� *
ShipmentID+  -!   
dateColumn��$
 Date��$ SizeToHeader  �� *Date+  -"   noOfPiecesColumn��$ Pieces��$ SizeToHeader  �� *
NoOfPieces+  -#   pricePerPieceColumn��$ Price/Piece��$ SizeToHeader  �� *PricePerPiece+  -$   transportCostColumn��$ 	Transport��$ SizeToHeader  �� *TransportCost+  -%   supplierCommissionColumn��$ 
Commission��$ SizeToHeader  �� *SupplierCommission+  -&   micelleneousColumn��$ Micelleneous��$ SizeToHeader  �� *Micelleneous+�� -'   $ 
txtDelDate��$
��Left=�$��1016,119,0,0q�$	��Top=�$	��140��$��24�� �� SelectedIndex$ 0���� -(   $ btnEdit��$
��Edit��$
��Left=�$��434,543,0,0q�$	��Top=�$��93���� -)   $ 	lblShipID��$�� ��$
��Left=�$��
445,21,0,0q�$	��Top=�$	��145�����	#FF110101$y�Hidden=��� -*   $ dropCurrency��$
��Left=�$��307,395,0,0q�$	��Top=�$	��104��$ Select Currency Type��$ -0.696,0.818&�$ 0��