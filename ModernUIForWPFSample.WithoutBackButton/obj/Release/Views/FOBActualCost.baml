   M S B A M L   `   `   `  ���� a  ]ModernUIForWPFSample.WithoutBackButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ModernUIForWPFSample.WithoutBackButton&ModernUIForWPFSample.WithoutBackButton  @    :ModernUIForWPFSample.WithoutBackButton.Views.FOBActualCost   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     RWithoutBackButton4clr-namespace:ModernUIForWPFSample.WithoutBackButton     -     � 	Resources     bnSFrequencyViewSource  actualCostViewSource & "actualCostAccessoryCostsViewSource �� Source �� Source��%R   &	        &	      &	 
     7  �� �� ��  �� *AccessoryCosts+8   .��� $
��Auto�� � DataContext# [  $��0,-1,0,1q�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFBEBEBE�� � Offset$ 0Q�� $ 	#FFEAE8E8��$ 1Q�.+��� $
��Left=�$	��556��$��6,52,0,0q�
�������$	��Top=�$	��837���� $
��Left=�$	��556��$��
848,52,0,0q�
�������$	��Top=�$	��448���� $
��Left=�$	��205��$��108,122,0,0q�
�������$	��Top=�$	��728���� $
��Left=�$	��205��$��107,348,0,0q�
�������$	��Top=�$	��729���� $!��FOB Actual Cost Calculation��$
��Left=�$��	13,11,0,0q�  SimpleLabel#���  $	��Top=�$��22(�$��37��$	��273��
���   ��� -    ��Name$ cmbSelectItem��$
��Left=�$��
117,71,0,0q�$	��Top=�$	��269��$��30���� $��Select Item��$
��Left=�$��	19,66,0,0q�$	��Top=�$��27��$	��108��$��16(�
���   ��� -   	 ��Name$	 lblStylishDisplay��$�� ��$
��Left=�$��-166,273,0,0q�$	��Top=�$��90��$	��452��$��68(�$
��Bold"�
 J� RenderTransformOrigin$
 0.5,0.5&����	#FF9B9B9Bz�V� .~��� �� ��  �� Angle$	 -90Q�T� �� -    ��Name$ lstBoxFabType��$
��Left=�$	��133��$��115,186,0,0q�$	��Top=�$	��166�����	#FF323232$ �� IsSynchronizedWithCurrentItem$ FalseY��� $��Fabric��$
��Left=�$��118,121,0,0q�$	��Top=�$��22��$	��166��$
 0.5,0.5&����	#FF171717$��16(��� $��Accessories��$
��Left=�$��115,348,0,0q�$	��Top=�$��21��$	��166��$
 0.5,0.5&����	#FF171717$��16(��� -   $ cmbFabTypes��$
��Left=�$��115,149,0,0q�$	��Top=�$	��166��$��32��{�.  �� -    ��Name$ txtCostPYard��$
��Left=�$��32��$��282,149,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��167��{�.  �� -   $ 
txtConsump��$
��Left=�$��32��$��451,149,0,0q�$
 Wrap=�$	��Top=�$	��167��{�.  �� -    ��Name$ btnAddFabToList��$��Add to List��$
��Left=�$��619,149,0,0q�$	��Top=�$	��166��$��32��{�.  �� -	   $ lstBoxFabCPY��$
��Left=�$	��133��$��282,186,0,0q�$	��Top=�$	��167�����	#FF323232$ FalseY��� -
   $ lstBoxFabComsup��$
��Left=�$	��133��$��451,186,0,0q�$	��Top=�$	��167�����	#FF323232�� -   $ lstBoxFabCost��$
��Left=�$	��133��$��619,186,0,0q�$	��Top=�$	��166�����	#FF323232�� -   $ lstBoxAccType��$
��Left=�$	��133��$��115,413,0,0q�$	��Top=�$	��167�����	#FF323232�� -   $ cmbAccTypes��$
��Left=�$��115,376,0,0q�$	��Top=�$	��167��$��32��{�.  �� -   $ txtWeightPItem��$
��Left=�$��32��$��284,376,0,0q�$
 Wrap=�$	��Top=�$	��167��{�.  �� -   $ txtCostOfHgrams��$
��Left=�$��32��$��452,376,0,0q�$
 Wrap=�$	��Top=�$	��121��{�.  �� -   $ 	txtAccAmt��$
��Left=�$��32��$��574,376,0,0q�$
 Wrap=�$	��Top=�$��44��{�.  �� -   $ btnAddAccList��$��Add to List��$
��Left=�$��620,376,0,0q�$	��Top=�$	��167��$��32��{�.  �� -   $ lstBoxAccWPI��$
��Left=�$	��133��$��284,413,0,0q�$	��Top=�$	��167�����	#FF323232�� -   $ lstBoxAccCostForH��$
��Left=�$	��133��$��452,413,0,0q�$	��Top=�$	��121�����	#FF323232�� -   $ lstBoxAccCostPI��$
��Left=�$	��133��$��620,413,0,0q�$	��Top=�$	��167�����	#FF323232�� -   $ btnCal��$	��Add��$
��Left=�$��627,563,0,0q�$	��Top=�$	��160��$��36���� $��Cost per yard��$
��Left=�$��285,125,0,0q�$	��Top=�$	��163��
���   ��� $��
Consumtion��$
��Left=�$��453,125,0,0q�$	��Top=�$	��163��
���   ��� $
��Cost��$
��Left=�$��620,125,0,0q�$	��Top=�$	��162��
���   ��� $��Weight per item (grams)��$
��Left=�$��285,353,0,0q�$	��Top=�$	��163��
���   ��� $��Cost of 100 grams��$
��Left=�$��453,353,0,0q�$	��Top=�$	��120��
���   ��� $
��Cost��$
��Left=�$��620,353,0,0q�$	��Top=�$	��163��
���   ��� $
��Left=�$��1��$��115,143,0,0q�$	��Top=�$	��670��
�������&   System.Windows.Controls.DataGrid  -     Name$ actualCostDataGrid��   AutoGenerateColumns .     EnableRowVirtualization . $��860,123,56,215q�   RowDetailsVisibilityMode$ VisibleWhenSelected=����	#FF333333   GridLinesVisibility$	 All=�   HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 300 $
��Auto��$
��Auto������ # [    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   aCostIDColumn��,  &System.Windows.Controls.DataGridColumn   Header$ ACost ID��   Width$	 150 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	ACostID+  -   iDColumn��$ ID��$	 100  �� *ID+  -   totalCostColumn��$ 
Total Cost��$ SizeToHeader  �� *	TotalCost+�� -   $ lstBoxFabCostID��$
��Left=�$	��133��$��
10,186,0,0q�$	��Top=�$��93�����	#FF323232$ FalseY��� -   $ lstBoxAccCostID��$
��Left=�$	��133��$��
10,413,0,0q�$	��Top=�$��93�����	#FF323232$ FalseY��� -   $ cmbEditAcost��$
��Left=�$��
932,68,0,0q�$	��Top=�$	��236��$��32���� $��Select��$
��Left=�$��
860,74,0,0q�$	��Top=�$��27��$��72��$��16(�
���   ��� -   $��Delete��$
��Left=�$��1173,69,0,0q�$	��Top=�$	��108��$��32���� -   $ lstBoxAccAmt��$
��Left=�$	��133��$��574,413,0,0q�$	��Top=�$��45�����	#FF323232�� $	��Amt��$
��Left=�$��578,353,0,0q�$	��Top=�$��36��
���   ��� -   $ btnResetAll��$��	Reset All��$
��Left=�$��448,563,0,0q�$	��Top=�$	��160��$��36���� -    $��CA��$
��Left=�$��784,270,0,0q�$	��Top=�$��57��$��37��$
��Bold"�
�������$
 0.5,0.5&� � ToolTip$ Clear all on Fabrics��z�V� .~��� �� �� $	 -90Q�T� �� -!   $��R��$
��Left=�$��789,207,0,0q�$	��Top=�$��47��$��37��$
��Bold"�
�������$
 0.5,0.5&�$ Remove the selected row��z�V� .~��� �� �� $	 -90Q�T� �� -"   $��CA��$
��Left=�$��784,502,0,0q�$	��Top=�$��57��$��38��$
��Bold"�
�������$
 0.5,0.5&�$ Clear all on Accessories��z�V� .~��� �� �� $	 -90Q�T� �� -#   $��R��$
��Left=�$��788,436,0,0q�$	��Top=�$��47��$��36��$
��Bold"�
�������$
 0.5,0.5&�$ Remove the selected row��z�V� .~��� �� �� $	 -90Q�T� �� -$   $ cmbCurrency��$
��Left=�$��
445,71,0,0q�$	��Top=�$	��120��$��30���� $��CM��$
��Left=�$��
403,71,0,0q�$	��Top=�$��25��$��30��
���   �$��16(��� $
��  CM��$
��Left=�$��862,533,0,0q�$	��Top=�$��95��$��34�����	#FF464646���	#FF918F8F$��20(��� $�� Total Cost��$
��Left=�$��1081,533,0,0q�$	��Top=�$	��108��$��34�����	#FF464646���	#FF918F8F$��20(��� -%   $	 lblCmDisplay��$�� ��$
��Left=�$��962,533,0,0q�$	��Top=�$��95��$��34�����	#FF464646���	#FF918F8F$��20(�$
��Bold"��� -&   $	 lblActCost_Display��$�� ��$
��Left=�$��1194,533,0,0q�$	��Top=�$��95��$��34�����	#FF464646���	#FF918F8F$��20(�$
��Bold"�