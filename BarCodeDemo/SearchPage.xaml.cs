using BarCodeDemo.ViewCommands;
 

namespace BarCodeDemo;

public partial class SearchPage : ContentPage
{
    public SearchPage(MovieViewModel movieViewModel)
    {
        InitializeComponent();
        BindingContext = movieViewModel;
    }



}