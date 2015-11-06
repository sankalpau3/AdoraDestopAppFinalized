using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernUIForWPFSample.WithoutBackButton.Views
{
    public class ChartController : INotifyPropertyChanged 
    {
        public ObservableCollection<string> ChartTypes { get; set; }        // A list structure to hold several types of charts
        private String ChartType;                                           // Variable to hold chart type name

        public ChartController()
        {
            // Add items to chart types list
            ChartTypes = new ObservableCollection<string>();
            ChartTypes.Add("Pie");
            ChartTypes.Add("Doughnut");
            ChartTypes.Add("Clustered Bar");
            ChartTypes.Add("Clustered Column");
            ChartTypes.Add("Stacked Bar");
            ChartTypes.Add("Stacked Column");
           
        }

        public ChartController(String type)
        {
            // Add items to chart types list
            ChartTypes = new ObservableCollection<string>();
            ChartTypes.Add("Pie");
            ChartTypes.Add("Doughnut");
            ChartTypes.Add("Clustered Bar");
            ChartTypes.Add("Clustered Column");
            ChartTypes.Add("Stacked Bar");
            ChartTypes.Add("Stacked Column");
           
            ChartType = type;   // Assign the chart type name
        }

        private string _simpleStringProperty;   // variable to get the selected chart type
        public string SimpleStringProperty
        {
            get { return _simpleStringProperty; }
            set
            {
                String baseUrl = "..\\Graphs\\GraphTemplates\\";    // Base url of the graphs folder which contains templates
                String type = ChartType;

                _simpleStringProperty = value;

                // If the graph type is set
                if (type != null && type != "")
                {
                    // If the selected value is pie chart
                    if (value.Equals("Pie"))
                    {
                        // Direct the controller to the relevent piechart and get the required chart
                        String path = baseUrl + type + "\\PieChart.xaml";
                        SelectedPageChart = new Uri(path, UriKind.Relative);
                    }
                    else if (value.Equals("Doughnut"))
                    {
                        String path = baseUrl + type + "\\DoughnutChart.xaml";
                        SelectedPageChart = new Uri(path, UriKind.Relative);
                    }
                    else if (value.Equals("Clustered Column"))
                    {
                        String path = baseUrl + type + "\\ClusteredColumnChart.xaml";
                        SelectedPageChart = new Uri(path, UriKind.Relative);
                    }
                    else if (value.Equals("Clustered Bar"))
                    {
                        String path = baseUrl + type + "\\ClusteredBarChart.xaml";
                        SelectedPageChart = new Uri(path, UriKind.Relative);
                    }
                    else if (value.Equals("Stacked Bar"))
                    {
                        String path = baseUrl + type + "\\StackedBarChart.xaml";
                        SelectedPageChart = new Uri(path, UriKind.Relative);
                    }
                    else if (value.Equals("Stacked Column"))
                    {
                        String path = baseUrl + type + "\\StackedColumnChart.xaml";
                        SelectedPageChart = new Uri(path, UriKind.Relative);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select and feed the criteria to generate graph");
                }
               
                OnPropertyChanged("SimpleStringProperty");

            }
        }

        private Uri _selectedPageChart;     // Uri variable to hold the selected chart
        public Uri SelectedPageChart
        {
            get { return _selectedPageChart; }
            set
            {
                _selectedPageChart = value;
                OnPropertyChanged("SelectedPageChart");
            }
        }

        // This method detects the combo box value changes and sets the chart type accordingly
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    
}
