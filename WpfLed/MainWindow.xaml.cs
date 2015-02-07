using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;

namespace LedTest
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        #region Public properties

        private List<Color> _colorList = new List<Color>() { Colors.Red, Colors.Green, Colors.Blue };
        public List<Color> ColorList
        {
            get { return _colorList; }
        }

        bool? ledStatus;
        public bool? LedStatus
        {
            get { return ledStatus; }
            set
            {
                ledStatus = value;
                this.OnPropertyChanged("LedStatus");
            }
        }       

        private Color coloreOff;
        public Color ColoreOff
        {
            get { return coloreOff; }
            set
            {
                coloreOff = value;
                this.OnPropertyChanged("ColoreOff");
            }
        }

        private bool flash;
        public bool Flash
        {
            get { return flash; }
            set
            {
                flash = value;
                this.OnPropertyChanged("Flash");
            }
        }

        private Color _colorOn = Colors.Green;
        public Color ColorOn
        {
            get { return _colorOn; }            
        }

        private Color _colorOff = Colors.Red;
        public Color ColorOff
        {
            get { return _colorOff; }
        }       

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;           
        }

        #endregion

        #region Callbacks

        //change the status of the led in binding
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (ledWithoutBinding.IsActive == null)
                ledWithoutBinding.IsActive = true;
            else
                ledWithoutBinding.IsActive = !ledWithoutBinding.IsActive;
        }

        //change the status of the led in binding
        private void btnChange2_Click(object sender, RoutedEventArgs e)
        {
            if (LedStatus == null)
                LedStatus = true;
            else
                LedStatus = !LedStatus;

        }

        private void btnChangeColor_Click(object sender, RoutedEventArgs e)
        {
            if (ledWithoutBinding.IsActive == true) 
            {
                ledWithoutBinding.ColorOn = (Color)listboxChooseColor.SelectedItem;
            }
            else if (ledWithoutBinding.IsActive == false)
            {
                ledWithoutBinding.ColorOff = (Color)listboxChooseColor.SelectedItem;
            }
            else
            {
                ledWithoutBinding.ColorNull = (Color)listboxChooseColor.SelectedItem;
            }           
            
           //TODO  with binding

        }

        private void btnChangeFlash_Click(object sender, RoutedEventArgs e)
        {
            Flash = !Flash;
        }        

        private void btnChangeFlashNoBinding_Click(object sender, RoutedEventArgs e)
        {
            ledWithoutBinding.Flashing = !ledWithoutBinding.Flashing;
        }

        #endregion       

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        #endregion  


    }
}
