   M S B A M L   `   `   `  ���� a  ]ModernUIForWPFSample.WithoutBackButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ModernUIForWPFSample.WithoutBackButton&ModernUIForWPFSample.WithoutBackButton  @    :ModernUIForWPFSample.WithoutBackButton.Views.FOBPurchasing   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     RWithoutBackButton4clr-namespace:ModernUIForWPFSample.WithoutBackButton     -     >�Name$  FOBPurchasing1�� � 	Resources    accessoryViewSource  fabricViewSource��%   &	        &	      �� �� .��� -    �Name$ 
LayoutRoot��$
��1366��$	��700�� � DataContext# [  ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFBEBEBE�� � Offset$ 0Q�� $ 	#FFEAE8E8��$ 1Q�.+��� $��FOB Purchase ��$
��Left=�$��12.972,11.041,0,0q�  SimpleLabel#���  $	��Top=�$��21.333(�$��37.452��$��194.018��
���   ��� $	��580��$��	10,53,0,0q�$
��1283��$
��Left=�$	��Top=�.@��� $��Fabric��$��	-2,-2,2,0q�$	��640��.��� ���	#FFE5E5E5$��0,0,1,1q�$
��1276��$	��551�� � ColumnDefinitions �� $
��915* ��� $
��361* �.+��� ���	#FFFBFBFB$��10,10,392,43q��� $!��Add Fabric Purchase Details��$
��Left=�$��	14,14,0,0q�#���  $	��Top=�$	��243��$��18.667(�$��47��
���   ��� ���	#B5FFFFFF$
��Left=�$��3��$��	10,41,0,0q�
���   �$	��Top=�$	��360��$��0���� $
��Left=�$	��359�����	#FFFBFBFB$	��Top=�$	��648��$��552,159,0,0q�$��2��(  "System.Windows.Controls.DatePicker  -   	  Name$	 dtsFOBPAddFab��$
��Left=�$��
302,76,0,0q�$	��Top=�$	��168���� -   
 ��Name$
 cmbFOBPAddFabType��$
��Left=�$��302,126,0,0q�$	��Top=�$	��168�� �� 
IsEditable . �� -    ��Name$ txtFOBPAddFabPricePerYard��$
��Left=�$��23��$��302,166,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��168���� -   $ txtFOBPAddFabYardage��$
��Left=�$��23��$��302,206,0,0q�$
 Wrap=�$	��Top=�$	��168���� -   $# txtFOBPAddFabCourierTransport��$
��Left=�$��23��$��302,246,0,0q�$
 Wrap=�$	��Top=�$	��168���� $
��Date��$
��Left=�$��	52,76,0,0q�$	��Top=�$	��168��
���   �$��16(�$��31���� $��Price per Yard��$
��Left=�$��
52,166,0,0q�$	��Top=�$	��168��
���   �$��16(�$��31���� $��Yardage��$
��Left=�$��
52,206,0,0q�$	��Top=�$	��168��
���   �$��16(�$��31���� $��Courier / Transport��$
��Left=�$��
52,246,0,0q�$	��Top=�$	��168��
���   �$��16(�$��31���� $
��Cost��$
��Left=�$��
52,346,0,0q�$	��Top=�$	��168��
���   �$��16(�$��31���� -   $ txtFOBPAddFabCost��$
��Left=�$��23��$��302,346,0,0q�$
 Wrap=�$	��Top=�$	��168��{�.  �� $��Category��$
��Left=�$��
52,126,0,0q�$	��Top=�$	��168��
���   �$��16(�$��31���� -	   $��	Calculate��$
��Left=�$��386,289,0,0q�$	��Top=�$	��112���� -
    ��Name$ btnFOBPAddFab��$	��Add��$
��Left=�$��358,448,0,0q�$	��Top=�$	��112���� $
��Left=�$��97�����	#FFFBFBFB$	��Top=�$	��648��$��
552,10,0,0q�$��2���� $��Actual Cost per Yard��$
��Left=�$��
52,386,0,0q�$	��Top=�$	��205��
���   �$��16(�$��31���� -   $$ txtFOBPAddFabActualCostPerYard��$
��Left=�$��23��$��302,386,0,0q�$
 Wrap=�$	��Top=�$	��168��{�.  �� -   $��Reset��$
��Left=�$��222,448,0,0q�$	��Top=�$	��112���� $	��LKR��$
��Left=�$��490,166,0,0q�$	��Top=����	#FF333333$��14(���Z� �� $	��LKR��$
��Left=�$��490,346,0,0q�$	��Top=����	#FF333333$��14(���Z� �� $	��LKR��$
��Left=�$��490,386,0,0q�$	��Top=����	#FF333333$��14(���Z� �� -    ��Name$ lblFOBPFabErrPricePerYard��$�� ��$
��Left=�$��477,173,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$y�Hidden=�����  �� ImageSource$H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ lblFOBPFabErrYardage��$�� ��$
��Left=�$��477,213,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $# lblFOBPFabErrCourierTransport��$�� ��$
��Left=�$��477,252,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ lblFOBPFabErrType��$�� ��$
��Left=�$��477,132,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -   $ lblFOBPFabErrDate��$�� ��$
��Left=�$��
477,82,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� $	��LKR��$
��Left=�$��490,246,0,0q�$	��Top=����	#FF333333$��14(���Z� &   System.Windows.Controls.DataGrid  -     Name$ fabricDataGrid��   AutoGenerateColumns .     EnableRowVirtualization . $��552,112,76,43q�   RowDetailsVisibilityMode$ VisibleWhenSelected=����	#FF333333$��2������  �� Source# [    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   categoryColumn1��,  &System.Windows.Controls.DataGridColumn   Header$ Category��   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Category+  -   fabIDColumn��$ Fab ID��$ SizeToHeader  �� *FabID+  -   	iDColumn1��$ ID��$ SizeToHeader  �� *ID+  -   pricePerYardColumn��$ Price Per Yard��$ SizeToHeader  �� *PricePerYard+  -   transportCostColumn1��$ Transport Cost��$ SizeToHeader  �� *TransportCost+  -   yardageColumn��$ Yardage��$ SizeToHeader  �� *	Yardage+�� -   $
 cmbFOBPFabEditCatogery��$
��Left=�$��
639,60,0,0q�$	��Top=�$	��175���� -   $
 cmbFOBPFabEditID��$
��Left=�$��
884,61,0,0q�$	��Top=�$	��176��$��2���� -   $ btnFOBPFabDelete��$��Delete��$
��Left=�$��
160,60,0,0q�$	��Top=�$	��112��$��22��$��1���� $��Edit and Delete��$
��Left=�$��
556,14,0,0q�#���  $	��Top=�$	��243��$��18.667(�$��47��
���   ��� ���	#B5FFFFFF$
��Left=�$��3��$��
552,41,0,0q�
���   �$	��Top=�$	��360��$��0���� -   $ lblFOBPFabEditType��$��Category��$
��Left=�$��
564,61,0,0q�$	��Top=�$	��168��
���   �$��16(�$��31���� -   $ lblFOBPFabEditFabID��$��Fab ID��$
��Left=�$��
824,61,0,0q�$	��Top=�$��70��
���   �$��16(�$��31���� -   $ lbleditFabID��$
��0000��$
��Left=�$��
72,422,0,0q�$	��Top=�$y�Hidden=��� $��Accessories ��$��-3,0,-326,0q�.��� ���	#FFE5E5E5$��0,0,1,1q�$
��1276��$	��551��.+��� ���	#FFFBFBFB$��10,10,753,33q��� $'��!Add Accessories  Purchase Details��$
��Left=�$��	14,14,0,0q�#���  $	��Top=�$	��297��$��18.667(�$��47��
���   ��� ���	#B5FFFFFF$
��Left=�$��3��$��	10,41,0,0q�
���   �$	��Top=�$	��360��$��0���� $
��Left=�$	��394�����	#FFFBFBFB$	��Top=�$	��648��$��552,124,0,0q�  -   $	 dtsFOBPAddAccDate��$
��Left=�$��
302,76,0,0q�$	��Top=�$	��168���� -    $
 cmbFOBPAddAccType��$
��Left=�$��302,117,0,0q�$	��Top=�$	��168�� . �� -!   $
 cmbFOBPAddAccUnit��$
��Left=�$��302,157,0,0q�$	��Top=�$	��168�� . �� -"   $ txtFOBPAddAccPricePerUnit��$
��Left=�$��23��$��302,194,0,0q�$
 Wrap=�$	��Top=�$	��168���� -#   $ txtFOBPAddAccNoOfUnits��$
��Left=�$��23��$��302,232,0,0q�$
 Wrap=�$	��Top=�$	��168���� -$   $# txtFOBPAddAccCourierTransport��$
��Left=�$��23��$��302,270,0,0q�$
 Wrap=�$	��Top=�$	��168���� -%   $ btnFOBPAddAccCalc��$��	Calculate��$
��Left=�$��386,311,0,0q�$	��Top=�$	��112���� -&   $ btnFOBPAddAccAdd��$	��Add��$
��Left=�$��358,448,0,0q�$	��Top=�$	��112���� -'   $ lblFOBPAddAccDate��$
��Date��$
��Left=�$��	52,76,0,0q�$	��Top=�$	��168��$��16(�
���   �$��31���� -(   $ lblFOBPAddAccPricePreUnit��$��Price per Unit��$
��Left=�$��
52,194,0,0q�$	��Top=�$	��192��$��16(�
���   �$��31���� -)   $ lblFOBPAddAccNoOfUnits��$��No. Of Units��$
��Left=�$��
52,233,0,0q�$	��Top=�$	��168��$��16(�
���   �$��31���� -*   $# lblFOBPAddAccCourierTransport��$��Courier / Transport��$
��Left=�$��
52,270,0,0q�$	��Top=�$	��168��$��16(�
���   �$��31���� -+   $ lblFOBPAddAccCost��$
��Cost��$
��Left=�$��
52,346,0,0q�$	��Top=�$	��168��$��16(�
���   �$��31���� -,   $ txtFOBPAddAccCost��$
��Left=�$��23��$��302,346,0,0q�$
 Wrap=�$	��Top=�$	��168��{�.  �� --   $ lblFOBPAddAccType��$��Category��$
��Left=�$��
52,117,0,0q�$	��Top=�$	��168��$��16(�
���   ��� $
��Left=�$��97�����	#FFFBFBFB$	��Top=�$	��648��$��
552,10,0,0q��� -.   $$ lblFOBPAddAccActualCostPerUnit��$��Actual Cost per Unit��$
��Left=�$��
52,386,0,0q�$	��Top=�$	��192��$��16(�
���   �$��31���� -/   $$ txtFOBPAddAccActualCostPerUnit��$
��Left=�$��23��$��302,386,0,0q�$
 Wrap=�$	��Top=�$	��168��{�.  �� -0   $ btnFOBPAddAccReset��$��Reset��$
��Left=�$��222,448,0,0q�$	��Top=�$	��112���� -1   $ lblFOBPErrAccPricePreUnit��$�� ��$
��Left=�$��477,197,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10�� J� RenderTransformOrigin$ 
2.4,-4.233&�$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -2   $ lblFOBPErrAccNoOfUnits��$�� ��$
��Left=�$��477,237,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -3   $# lblFOBPErrAccCourierTransport��$�� ��$
��Left=�$��477,276,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -4   $ lblFOBPErrAccType��$�� ��$
��Left=�$��477,125,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� -5   $ lblFOBPErrAccDate��$�� ��$
��Left=�$��
477,82,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png���� $	��LKR��$
��Left=�$��490,196,0,0q�$	��Top=����	#FF333333$��14(���Z� �� $	��LKR��$
��Left=�$��490,346,0,0q�$	��Top=����	#FF333333$��14(���Z� �� $	��LKR��$
��Left=�$��490,386,0,0q�$	��Top=����	#FF333333$��14(���Z� �� $	��LKR��$
��Left=�$��490,236,0,0q�$	��Top=����	#FF333333$��14(���Z�   -6   $ accessoryDataGrid�� .   .  $��552,112,76,45q�$ VisibleWhenSelected=����	#FF333333����    -7   accIDColumn��$ Acc ID��$ SizeToHeader  �� *AccID+  -8   categoryColumn��$ Category��$ SizeToHeader  �� *
Category+  -9   iDColumn��$ ID��$ SizeToHeader  �� *ID+  -:   noOfUnitsColumn��$ No Of Units��$ SizeToHeader  �� *	NoOfUnits+  -;   pricePerUnitColumn��$ Price Per Unit��$ SizeToHeader  �� *PricePerUnit+  -<   transportCostColumn��$ Transport Cost��$ SizeToHeader  �� *TransportCost+  -=   unitTypeColumn��$ 	Unit Type��$ SizeToHeader  �� *
UnitType+�� $��Edit and Delete��$
��Left=�$��
556,14,0,0q�#���  $	��Top=�$	��243��$��18.667(�$��47��
���   ��� ���	#B5FFFFFF$
��Left=�$��3��$��
552,41,0,0q�
���   �$	��Top=�$	��360��$��0���� ->   $
 cmbFOBPAccEditCatogery��$
��Left=�$��
648,61,0,0q�$	��Top=�$	��174���� -?   $
 cmbFOBPAccEditID��$
��Left=�$��
892,61,0,0q�$	��Top=�$	��175���� -@   $ btnFOBPAccDelete��$��Delete��$
��Left=�$��1078,61,0,0q�$	��Top=�$	��112��$��26���� -A   $ lblFOBPAccEditType��$��Category��$
��Left=�$��
570,61,0,0q�$	��Top=�$	��168��
���   �$��16(�$��31���� -B   $ lblFOBPAccEditFabID��$��Acc ID��$
��Left=�$��
836,61,0,0q�$	��Top=�$��94��
���   �$��16(�$��31���� -C   $ lbleditAssID��$��00000��$
��Left=�$��117,461,0,0q�$	��Top=�$y�Hidden=��� -D   $ lblFOBPAddAccType_Copy��$
��Unit��$
��Left=�$��
52,154,0,0q�$	��Top=�$	��168��$��16(�
���   ��� $	��LKR��$
��Left=�$��490,270,0,0q�$	��Top=����	#FF333333$��14(���Z� �� -E   $ lblFOBPErrAccUnit��$�� ��$
��Left=�$��477,166,0,0q�$	��Top=�$��18(�
���  ��$��10��$��10��$y�Hidden=����� $H B/ModernUIForWPFSample.WithoutBackButton;component/Images/error.png��