using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ModernUIForWPFSample.WithoutBackButton.Data
{
    class FOBPurchasingDAO
    {
        //this method is used to update the combobox contet according to the users key strocks in accessories tab, catagory combo box
        public void updateSearchComboBoxAcc(ComboBox cmbBox)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    String searchText = cmbBox.Text.ToString();

                    
                    var accType = (from e in a.Accessories
                                       where e.Category.Contains(searchText)
                                       select new { e.Category, e.UnitType }
                   ).Distinct().ToList();

                    List<String> nList = new List<string>();

                    for (int i = 0; i < accType.Count; i++)
                    {
                        String n = accType[i].Category.ToString();
                        String nm = n;
                        nList.Add(nm);
                    }
                    cmbBox.ItemsSource = nList;
                    cmbBox.IsDropDownOpen = true;
                }
            }
            catch (Exception e)
            {
            }
        }



        //this method is used to update the combobox contet according to the users key strocks in fabric tab, catagory combo box
        public void updateSearchComboBoxFab(ComboBox cmbBox)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    String searchText = cmbBox.Text.ToString();

                   
                    var fabtype = (from e in a.Fabrics
                                       where e.Category.Contains(searchText)
                                       select new { e.Category }
                   ).Distinct().ToList();

                    List<String> nList = new List<string>();

                    for (int i = 0; i < fabtype.Count; i++)
                    {
                        String n = fabtype[i].Category.ToString();
                      

                        String nm = n;
                        nList.Add(nm);
                    }
                    cmbBox.ItemsSource = nList;
                    cmbBox.IsDropDownOpen = true;
                }
            }
            catch (Exception e)
            {
            }
        }

        //this method will update the combo box unit in accessories according to the users key strokes
        public void updateSearchComboBoxAccUni(ComboBox cmbBox)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    String searchText = cmbBox.Text.ToString();


                    var unitType = (from e in a.Accessories
                                       where e.UnitType.Contains(searchText)
                                       select new { e.UnitType }
                   ).Distinct().ToList();

                    List<String> nList = new List<string>();

                    for (int i = 0; i < unitType.Count; i++)
                    {
                        String n = unitType[i].UnitType.ToString();


                        String nm = n;
                        nList.Add(nm);
                    }
                    cmbBox.ItemsSource = nList;
                    cmbBox.IsDropDownOpen = true;
                }
            }
            catch (Exception e)
            {
            }
        }

        //populate combo box unit
        public void populateAccUnit(ComboBox cmbBox)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var unitType = (from e in a.Accessories
                                   select e.UnitType
                   ).Distinct().ToList();
                    cmbBox.ItemsSource = unitType;
                }
            }
            catch (Exception e)
            {
            }
        }

        //populate combo box fab catogory
        public void populateFabCat(ComboBox cmbBox)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var catog = (from e in a.Fabrics
                                    select e.Category
                   ).Distinct().ToList();
                    cmbBox.ItemsSource = catog;
                }
            }
            catch (Exception e)
            {
            }
        }
        public void populateAccCat(ComboBox cmbBox)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    var catog = (from e in a.Accessories
                                 select e.Category
                   ).Distinct().ToList();
                    cmbBox.ItemsSource = catog;
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
