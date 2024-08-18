using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<int> _countItems;

        public ObservableCollection<int> CountItems
        {
            get => _countItems;
            set
            {
                _countItems = value;
                OnPropertyChanged(nameof(CountItems));
            }
        }

        public MainPage()
        {
            InitializeComponent();
            CountItems = new ObservableCollection<int>();
            LoadCountItems();
            BindingContext = this;
        }

        private void LoadCountItems()
        {
            for (int i = 0; i < 10; i++)
            {
                CountItems.Add(i);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        int count = 0;
        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
