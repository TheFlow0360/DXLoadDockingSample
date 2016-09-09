using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Xpf.Docking;

namespace DXSample4
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BaseLayoutItem> _childViews;

        public ObservableCollection<BaseLayoutItem> ChildViews
        {
            get { return _childViews; }
            set { _childViews = value; OnPropertyChanged(); }
        }

        private ICommand _openDialogCommand;

        public ICommand OpenDialogCommand
        {
            get { return _openDialogCommand; }
        }

        public MainWindowViewModel()
        {
            _childViews = new ObservableCollection<BaseLayoutItem>();
            _openDialogCommand = new DelegateCommand(OpenDialogExecute);
        }
        
        private void OpenDialogExecute()
        {
            var child = new DocumentPanel
            {
                Content = new Dialog(),
                ClosingBehavior = ClosingBehavior.ImmediatelyRemove,
                Tag = "DocumentHost"
            };

            ChildViews.Add(child);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}