   M S B A M L   `   `   `  ���� a  ]ModernUIForWPFSample.WithoutBackButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ModernUIForWPFSample.WithoutBackButton&ModernUIForWPFSample.WithoutBackButton  @    :ModernUIForWPFSample.WithoutBackButton.Views.FixedOverHead   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     RWithoutBackButton4clr-namespace:ModernUIForWPFSample.WithoutBackButton     -     >�Name$  FixedOverHead1��$
��1366��$	��700�� � 	Resources    fixedOverheadViewSource��%   &	        �� .��� -    �Name$ 
LayoutRoot�� � DataContext# [   � ColumnDefinitions �� $��0* ��� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFBEBEBE�� � Offset$ 0Q�� $ 	#FFEAE8E8��$ 1Q�.+��� ���	#FFFBFBFB$��44,79,776,103q�$��2���� $��Fixed overhead��$
��Left=�$��	13,11,0,0q�  SimpleLabel#���  $	��Top=�$��22(�$��37��$	��194��
���   �$��2���� $��Add Overhead Details��$
��Left=�$��	59,79,0,0q�#���  $	��Top=�$	��243��$��18.667(�$��47��
���   �$��2���� ���	#B5FFFFFF$
��Left=�$��3��$��
44,108,0,0q�
���   �$	��Top=�$	��360��$��0��$��2���� $
��Left=�$��97�����	#FFFBFBFB$	��Top=�$	��648��$��
610,79,0,0q�$��2���� $��Edit and Delete��$
��Left=�$��
618,79,0,0q�#���  $	��Top=�$	��243��$��18.667(�$��47��
���   �$��2���� ���	#B5FFFFFF$
��Left=�$��3��$��610,108,0,0q�
���   �$	��Top=�$	��360��$��0��$��2���� $
��Left=�$	��413�����	#FFFBFBFB$	��Top=�$	��648��$��610,184,0,0q�$��2���� -   	 ��Name$	 
lblAddDate��$��*��$
��Left=�$��433,129,0,0q�$	��Top=����	#FF9E0505$��23��$��29��$��36(�$y�Hidden=�$��2����Z� �� -   $	 lblAddShipName��$��*��$
��Left=�$��508,164,0,0q�$	��Top=����	#FF9E0505$��23��$��29��$��36(�$y�Hidden=�$��2����Z� �� -   $	 lblAddNoPieces��$��*��$
��Left=�$��433,206,0,0q�$	��Top=����	#FF9E0505$��23��$��29��$��36(�$y�Hidden=�$��2����Z� �� -   $	 	lblAddPPP��$��*��$
��Left=�$��433,246,0,0q�$	��Top=����	#FF9E0505$��23��$��29��$��36(�$y�Hidden=�$��2����Z� �� -   $	 lblAddTrans��$��*��$
��Left=�$��433,287,0,0q�$	��Top=����	#FF9E0505$��23��$��29��$��36(�$y�Hidden=�$��2����Z� �� -   $	 lblAddSupCom��$��*��$
��Left=�$��433,326,0,0q�$	��Top=����	#FF9E0505$��23��$��29��$��36(�$y�Hidden=�$��2����Z� �� -	   $	 
lblAddMisc��$��*��$
��Left=�$��433,366,0,0q�$	��Top=����	#FF9E0505$��23��$��29��$��36(�$y�Hidden=�$��2����Z� �� -
   
 ��Name$
 	btnFOHAdd��$	��Add��$
��Left=�$��377,556,0,0q�$	��Top=�$��95�� J� RenderTransformOrigin$ 0.5,0.5&�$��27��$��2���� -   $
 btnFOHReset��$��Reset��$
��Left=�$��252,556,0,0q�$	��Top=�$��95��$ 0.5,0.5&�$��26��$��2���� -    ��Name$ txtFOHAddElectricityCost��$
��Left=�$��22��$��324,147,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��148�� �� TextAlignment$ Right=� � ToolTip$ Enter a whole number��$��2���� -   $ txtFOHAddWaterCost��$
��Left=�$��22��$��324,178,0,0q�$
 Wrap=�$	��Top=�$	��148��$ Right=�$ Enter a whole number��$��2���� -   $ txtFOHAddSalaryCost��$
��Left=�$��24��$��324,210,0,0q�$
 Wrap=�$	��Top=�$	��148��$ Right=�$ Enter a whole number��$��2���� -   $ txtFOHAddFuleCost��$
��Left=�$��22��$��324,244,0,0q�$
 Wrap=�$	��Top=�$	��148��$ Right=�$ Enter a whole number��$��2���� -   $  txtFOHAddPhoneInternetCost��$
��Left=�$��22��$��324,276,0,0q�$
 Wrap=�$	��Top=�$	��148��$ Right=�$ Enter a whole number��$��2���� -   $ txtFOHAddOTCost��$
��Left=�$��22��$��324,308,0,0q�$
 Wrap=�$	��Top=�$	��148��$ Right=�$ Enter a whole number��$��2���� -   $  txtFOHAddMiscellaneousCost��$
��Left=�$��22��$��324,339,0,0q�$
 Wrap=�$	��Top=�$	��148��$ Right=�$ Enter a whole number��$��2���� -   $( "txtFOHAddRentMortgageLeaseLoanCost��$
��Left=�$��22��$��324,371,0,0q�$
 Wrap=�$	��Top=�$	��148��$ Right=�$ Enter a whole number��$��2���� -   $ txtFOHAddTaxCost��$
��Left=�$��22��$��324,403,0,0q�$
 Wrap=�$	��Top=�$	��148��$ Right=�$ Enter a whole number��$��2���� -   $ txtFOHAddOther��$
��Left=�$��22��$��324,434,0,0q�$
 Wrap=�$	��Top=�$	��148��$ Right=�$ Enter a whole number��$��2���� -   $ txtFOHToataOHCost��$
��Left=�$��22��$��324,518,0,0q�$
 Wrap=�$	��Top=�$	��148��$ Right=�$  �����	#FF767272$��2��|�.  ��Z� �� -   $	 lblFOHElectricity��$��Electricity��$
��Left=�$��
61,147,0,0q�$	��Top=�$	��178��
���   �$��16(�$��31��$��2���� -   $	 lblFOHWater��$��Water��$
��Left=�$��
61,178,0,0q�$	��Top=�$	��178��
���   �$��16(�$��31��$��2���� -   $	 lblFOHSalary��$��Salary��$
��Left=�$��
61,210,0,0q�$	��Top=�$	��178��
���   �$��16(�$��31��$��2���� -   $	 
lblFOHFuel��$
��Fuel��$
��Left=�$��
61,244,0,0q�$	��Top=�$	��178��
���   �$��16(�$��31��$��2���� -   $	 lblFOHPhoneInternet��$��Phone + Internet Bills��$
��Left=�$��
61,276,0,0q�$	��Top=�$	��178��
���   �$��16(�$��31��$��2���� -   $	 lblFOHOT��$��Overtime��$
��Left=�$��
61,308,0,0q�$	��Top=�$	��178��
���   �$��16(�$��31��$��2���� -   $	 lblFOHMiscellaneous��$��Miscellaneous��$
��Left=�$��
61,339,0,0q�$	��Top=�$	��178��
���   �$��16(�$��31��$��2���� -   $&	  lblFOHWaterRentMortgageLeaseLoan��$��Rent/Mortgage/Lease/Loan��$
��Left=�$��
61,371,0,0q�$	��Top=�$	��220��
���   �$��16(�$��31��$��2���� -   $	 lblFOHWaterTax��$	��Tax��$
��Left=�$��
61,403,0,0q�$	��Top=�$	��178��
���   �$��16(�$��31��$��2���� -    $	 lblFOHTotalOH��$��Total Overheads��$
��Left=�$��
59,518,0,0q�$	��Top=�$	��178��
���   �$��16(�$��31��$��2���� -!    ��Name$ cmbFOHmonthComboBox��$
��Left=�$��324,118,0,0q�$	��Top=�$	��148��$��22��$��2���� -"   $	 lblFOHForTheMonth��$��For The Month��$
��Left=�$	��Top=�$��
61,122,0,0q�
���   �$��16(�$��31��$	��115��$��2���� -#   $	 lblFOHErrForMonth��$�� ��$
��Left=�$��476,124,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$��2��$y�Hidden=�����  �� ImageSource$H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -$   $	 lblFOHErrElectricityCost��$�� ��$
��Left=�$��476,153,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$��2��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -%   $	 lblFOHErrWaterCost��$�� ��$
��Left=�$��476,184,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$��2��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -&   $	 lblFOHErrSalatyCost��$�� ��$
��Left=�$��476,217,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$��2��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -'   $	 lblFOHErrFuleCost��$�� ��$
��Left=�$��476,250,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$��2��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -(   $ 	 lblFOHErrPhoneInternetCost��$�� ��$
��Left=�$��476,281,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$��2��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -)   $	 lblFOHErrOTCost��$�� ��$
��Left=�$��476,313,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$��2��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -*   $ 	 lblFOHErrMiscellaneousCost��$�� ��$
��Left=�$��476,344,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$��2��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -+   $(	 "lblFOHErrRentMortgageLeaseLoanCost��$�� ��$
��Left=�$��476,379,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$��2��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -,   $	 lblFOHErrTaxCost��$�� ��$
��Left=�$��476,408,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$��2��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� $	��LKR��$
��Left=�$��498,147,0,0q�$	��Top=����	#FF333333$��14(�$��2����Z� �� $	��LKR��$
��Left=�$��498,178,0,0q�$	��Top=����	#FF333333$��14(�$��2����Z� �� $	��LKR��$
��Left=�$��498,210,0,0q�$	��Top=����	#FF333333$��14(�$��2����Z� �� $	��LKR��$
��Left=�$��498,244,0,0q�$	��Top=����	#FF333333$��14(�$��2����Z� �� $	��LKR��$
��Left=�$��498,276,0,0q�$	��Top=����	#FF333333$��14(�$��2����Z� �� $	��LKR��$
��Left=�$��498,308,0,0q�$	��Top=����	#FF333333$��14(�$��2����Z� �� $	��LKR��$
��Left=�$��498,339,0,0q�$	��Top=����	#FF333333$��14(�$��2����Z� �� $	��LKR��$
��Left=�$��498,371,0,0q�$	��Top=����	#FF333333$��14(�$��2����Z� �� $	��LKR��$
��Left=�$��498,403,0,0q�$	��Top=����	#FF333333$��14(�$��2����Z� �� $	��LKR��$
��Left=�$��498,521,0,0q�$	��Top=����	#FF333333$��14(�$��2����Z� �� --   $
 	btnFOHCal��$��	Calculate��$
��Left=�$��436,477,0,0q�$	��Top=�$��95��$ 0.5,0.5&�$��24��$��2���� -.   $ cmbFOHForMonthYear��$��2��$
��Left=�$��239,118,0,0q�$	��Top=�$��78���� -/   $	 lblFOHWaterOther��$��Other��$
��Left=�$��
59,434,0,0q�$	��Top=�$	��178��
���   �$��16(�$��31��$��2���� $	��LKR��$
��Left=�$��498,434,0,0q�$	��Top=����	#FF333333$��14(�$��2����Z� &   System.Windows.Controls.DataGrid  -0     Name$ fixedOverheadDataGrid��   AutoGenerateColumns .  $��2��   EnableRowVirtualization . $��610,184,108,103q�   RowDetailsVisibilityMode$ VisibleWhenSelected=����	#FF333333   GridLinesVisibility$	 All=�   HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 ���������    Columns 0  *System.Windows.Controls.DataGridTextColumn  -1   electricityColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Electricity��   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Electricity+  -2   fixIDColumn��$ Fix ID��$ SizeToHeader  �� *FixID+  -3   
fuelColumn��$
 Fuel��$ SizeToHeader  �� *Fuel+  -4   
miscColumn��$
 Misc��$ SizeToHeader  �� *Misc+  -5   
yearColumn��$
 Year��$ SizeToHeader  �� *Year+  -6   monthColumn��$ Month��$ SizeToHeader  �� *Month+  -7   otColumn��$ Ot��$ SizeToHeader  �� *Ot+  -8   otherColumn��$ Other��$ SizeToHeader  �� *Other+  -9   phoneAnInternetColumn��$ Phone An Internet��$ SizeToHeader  �� *PhoneAnInternet+  -:   rentOrMortgageColumn��$ Rent Or Mortgage��$ SizeToHeader  �� *RentOrMortgage+  -;   salaryColumn��$ Salary��$ SizeToHeader  �� *Salary+  -<   	taxColumn��$	 Tax��$ SizeToHeader  �� *Tax+  -=   waterColumn��$ Water��$ SizeToHeader  �� *Water+�� ->   $	 lblFOHForTheMonth_Copy��$
��Year��$
��Left=�$	��Top=�$��634,122,0,0q�
���   �$��16(�$��31��$	��115��$��2���� -?   $	 lblFOHForTheMonth_Copy1��$��Month��$
��Left=�$	��Top=�$��849,122,0,0q�
���   �$��16(�$��31��$	��115��$��2���� -@   $ cmbFOHEditYear��$��2��$
��Left=�$��687,122,0,0q�$	��Top=�$	��148���� -A   $ cmbFOHEditMonth��$��2��$
��Left=�$��920,122,0,0q�$	��Top=�$	��148���� -B   $
 btnFOHDelete��$��2��$��Delete��$
��Left=�$��1122,122,0,0q�$	��Top=�$��95���� -C   $	 lbleditFOHID��$��2��$
��0000��$
��Left=�$��176,565,0,0q�$	��Top=�$y�Hidden=�