   M S B A M L   `   `   `  ���� a  ]ModernUIForWPFSample.WithoutBackButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ModernUIForWPFSample.WithoutBackButton&ModernUIForWPFSample.WithoutBackButton  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem A    ;ModernUIForWPFSample.WithoutBackButton.Views.StockLotsSales   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     RWithoutBackButton4clr-namespace:ModernUIForWPFSample.WithoutBackButton     9System&clr-namespace:System;assembly=mscorlib     -   $	��700��$
��1366��  � 	Resources     bnSFrequencyViewSource  showBnSDetailViewSource��%   &	        &	      �� �� .��� .+�� -    �Name$ 
LayoutRoot�� � DataContext$  ������  �� EndPoint$ 0.5,1&� � MappingMode$ RelativeToBoundingBox=� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFBEBEBE��� $ 	#FFF6F5F5�� � Offset$ 0.985Q�.+��� $��Remove Frequency Details��$
��Left=�$��
546,53,0,0q�  SimpleLabel#���  $	��Top=�$	��520��$��18.667(�$��47��$
��Bold"�
���   ���Z� �� $
��Left=�$	��522��
�������$	��Top=�$	��487��$��	30,53,0,0q��� $��Stock Lots Sales��$
��Left=�$��15.972,11.041,0,0q�#���  $	��Top=�$��21.333(�$��37.452��$��176.018��
���   ��� $��Shipment Purchase Date��$
��Left=�$��
44,140,0,0q�#���  $	��Top=�$	��244��$��16(�$��47��
���   ��� $��No. of Pieces Available��$
��Left=�$��
44,181,0,0q�#���  $	��Top=�$	��242��$��16(�$��47��
���   ��� $��Frequency ID��$
��Left=�$��
44,261,0,0q�#���  $	��Top=�$	��244��$��16(�$��47��
���   ��� $��Number of Pieces��$
��Left=�$��
44,301,0,0q�#���  $	��Top=�$	��244��$��16(�$��47��
���   ��� $��Price per Piece��$
��Left=�$��
44,341,0,0q�#���  $	��Top=�$	��242��$��16(�$��47��
���   ��� $#��Add / Update New Sale Details��$
��Left=�$��	44,57,0,0q�#���  $	��Top=�$	��520��$��18.667(�$��47��$
��Bold"�
���   ���Z� �� ���	#B5FFFFFF$
��Left=�$��2��$��	30,87,0,0q�
�������$	��Top=�$	��358��$��0���� $��Shipment Title��$
��Left=�$	��Top=�$��
44,103,0,0q�
���   �$��16(��� $��Cost per Piece��$
��Left=�$	��Top=�$��
46,220,0,0q�
���   �$��16(� J� RenderTransformOrigin$ 0.542,2.512&��� -   	 ��Name$	 txtNumberOfPieces��$
��Left=�$��23��$��263,301,0,0q�
 �� TextWrapping$

 Wrap=�$	��Top=�$	��165�� � ToolTip$E ?Number of pieces should less than or equals to pieces available���� -   $	 txtPricePerPiece��$
��Left=�$��23��$��263,343,0,0q�$

 Wrap=�$	��Top=�$	��165��$ Price per piece���� -    ��Name$ btnAdd��$	��Add��$
��Left=�$��379,533,0,0q�$	��Top=�$	��124��$ Add details ��$ 
0.484,1.01&�����  �� Source# [  �� -   $ btnReset��$��Reset��$
��Left=�$��263,533,0,0q�$	��Top=�$	��106��$ Reset the form���� $
��Left=�$	��381��
�������$	��Top=�$	��738��$��528,194,0,0q��� -    ��Name$ dropFrequencyID��$
��Left=�$��263,261,0,0q�$	��Top=�$	��106��$X RSelect the next frequency number to add a new one or pick any other number to edit�� �� SelectedIndex$ 0���� $��Next :��$
��Left=�$��406,263,0,0q�#���  $	��Top=�$��52��$��16(�$��47��
���   ��� -    ��Name$ lblNextFrequencyID��$��01��$
��Left=�$��477,263,0,0q�#���  $	��Top=�$��40��$��16(�$��47��
���   �$' !This is the next frequency number���� $
��Left=�$	��127��
�������$	��Top=�$	��738��$��
528,53,0,0q��� ���	#B5FFFFFF$
��Left=�$��2��$��
531,82,0,0q�
�������$	��Top=�$	��358��$��0���� $��Shipment Title��$
��Left=�$	��Top=�$��
546,96,0,0q�
���   �$��16(��� $
��Date��$
��Left=�$��1017,93,0,0q�#���  $	��Top=�$��54��$��16(�$��48��
���   ��� $��Frequency ID��$
��Left=�$��542,133,0,0q�#���  $	��Top=�$	��244��$��16(�$��47��
���   ��� -	   $ dropRmFrequencyID��$
��Left=�$��805,133,0,0q�$	��Top=�$	��106��$! Pick frequency id to remove�� �� 
IsEditable . $ 0���� -
   $ 
btnRmReset��$��Reset��$
��Left=�$��1004,138,0,0q�$	��Top=�$��95��$" Click to add entered details���� -   $ dropDate��$
��Left=�$��263,140,0,0q�$	��Top=�$	��237��$* $Select Purchase Date of the Shipment��$ 0���� -   $	 txtAddNoPieces��$
��Left=�$��23��$��263,181,0,0q�$

 Wrap=�$	��Top=�$	��165�� �� TextAlignment$ Right=�$  Number of pieces remaining��{�.  ���	#FF767272
��������� -   $	 txtAddCostPiece��$
��Left=�$��23��$��263,222,0,0q�$

 Wrap=�$	��Top=�$	��165��$ Right=����	#FF767272|�.  $ Cost per piece��
��������� -   $ lblCurrency��$	��LKR��$
��Left=�$��477,224,0,0q�$	��Top=����	#FF333333$��14(�$ 2.718,-3.264&���Z� �� -   $ lblCurrency2��$	��LKR��$
��Left=�$��442,345,0,0q�$	��Top=����	#FF333333$��14(�$ 2.718,-3.264&���Z� �� -   $ 
dropRmDate��$
��Left=�$��1001,93,0,0q�$	��Top=�$	��237��$ 0��$% Pick date of shipment to remove���� -   $ btnRmRemove��$��Delete��$
��Left=�$��1114,138,0,0q�$	��Top=�$	��124��$" Click to add entered details���� $��Selling Date��$
��Left=�$��
44,388,0,0q�#���  $	��Top=�$	��242��$��16(�$��47��
���   �(  "System.Windows.Controls.DatePicker  -     Name$ dateSellDate��$
��Left=�$��263,387,0,0q�$	��Top=�$	��237��$ Date of Sale���� $��Total Price��$
��Left=�$��
44,440,0,0q�#���  $	��Top=�$	��242��$��16(�$��47��
���   ��� -   $	 txtAddTotalPrice��$
��Left=�$��22��$��263,437,0,0q�$

 Wrap=�$	��Top=�$	��165��$ Right=�$ Total price��{�.  ���	#FF767272
��������� -   $ lblCurrency3��$	��LKR��$
��Left=�$��442,442,0,0q�$	��Top=����	#FF333333$��14(�$ 2.718,-3.264&���Z� �� -   $ dropCurrency��$
��Left=�$��263,470,0,0q�$	��Top=�$	��104��$ Select Currency Type��$ -0.696,0.818&�$ 0���� $
��Date��$
��Left=�#���  $	��Top=�$��46��$��26��
���   �$��544,222,0,0q�$��16(�  -   $ calSearchDate��$
��Left=�$��594,222,0,0q�$	��Top=�$	��169��$��11(�$��24���� $��Shipment Title��$
��Left=�#���  $	��Top=�$	��118��$��26��
���   �$��786,220,0,0q�$��16(��� -   $ 	btnSearch��$��Search��$
��Left=�$��1146,222,0,0q�$	��Top=�$��94��$��24��$ 1.343,0.375&��� -   $	 txtSearchShipName��$
��Left=�$��24��$��910,222,0,0q�$

 Wrap=�$	��Top=�$	��218���� -   $ errNoOfPieces��$�� ��$
��Left=�$��470,351,0,0q�$	��Top=�$��10��$��10��$ 	2.262,1.9&�$y�Hidden=�����  �� ImageSource$H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ errPricePerPiece��$�� ��$
��Left=�$��470,392,0,0q�$	��Top=�$��10��$��10��$ 	2.262,1.9&�$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ btnCalc��$��	Calculate��$
��Left=�$��376,470,0,0q�$	��Top=�$	��124��$ Calculate total price���� -   $ errShipmentName��$�� ��$
��Left=�$��544,148,0,0q�$	��Top=�$��10��$��10��$ 	2.262,1.9&�$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ dropShipmentName��$
��Left=�$��263,101,0,0q�$	��Top=�$	��237�� . �� -   $ dropRmShipmentName��$
��Left=�$��
674,96,0,0q�$	��Top=�$	��237�� . $% Pick shipment details to remove��&   System.Windows.Controls.DataGrid  -     Name$ showBnSDetailDataGrid��   AutoGenerateColumns .     EnableRowVirtualization . $��544,261,126,160q�   RowDetailsVisibilityMode$ VisibleWhenSelected=����	#FF333333���	#FFE1E1E1
�������   
IsReadOnly .    GridLinesVisibility$	 All=�   HorizontalGridLinesBrush �	#FFC8C8C8   VerticalGridLinesBrush �	#FFC6BFBF���� # [    Columns 0  *System.Windows.Controls.DataGridTextColumn  -    shipment_NameColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Shipment Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 190 1  +System.Windows.Controls.DataGridBoundColumn    Binding  �� *Shipment_Name+  -!   frequency_DateColumn��$
 Date��$ 75   �� *Frequency_Date+  -"   frequency_NoColumn��$ Fre.No��$ SizeToHeader   �� *Frequency_No+  -#   number_of_PiecesColumn��$ No Of Pieces��$ SizeToHeader   �� *Number_of_Pieces+  -$   price_per_pieceColumn��$ Price per piece��$ SizeToHeader   �� *Price_per_piece+  -%   total_GrossColumn��$ Total Gross��$ SizeToHeader   �� *Total_Gross+�� $��Set Currency��$
��Left=�$��
46,475,0,0q�#���  $	��Top=�$	��116��$��16(�$��47��
���   �