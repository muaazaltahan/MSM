using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Views;
using Microsoft.Maui.Storage;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel() 
        {
            Systems = new ObservableCollection<string>();
            Systems.Add("نظام النقاط");
            Systems.Add("نظام التسميع");
            Systems.Add("نظام المكافآت");
        }

        [ObservableProperty]
        private ObservableCollection<string> systems;

        [ObservableProperty]
        private ImageSource imageSource;
        
        [ICommand]
        async void PickFile()
        {
            var res = await FilePicker.PickAsync(
                new PickOptions { FileTypes = FilePickerFileType.Images }
            );
            if (res != null)
            {
                var stream = await res.OpenReadAsync();
                ImageSource = ImageSource.FromStream(() => stream);
            }
        }
    }

}
