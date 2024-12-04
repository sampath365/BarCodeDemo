namespace BarCodeDemo;

using BarCodeDemo.ViewCommands;

[QueryProperty(nameof(MovieId), "MovieId")]
public partial class MovieDetailPage : ContentPage
{
    public string MovieId => AppData.MovieId.ToString();
    private readonly MovieDetailViewModel _viewModel;

    public MovieDetailPage(MovieDetailViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
      
        if (!string.IsNullOrEmpty(MovieId))
        {
            _viewModel.MovieId = MovieId;
            await _viewModel.LoadMovieDetails(); 
        }  
    }

    
}