using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BarCodeDemo.ApService;
using MovieSearchApi.Model;
using System.Collections.ObjectModel;
 

namespace BarCodeDemo.ViewCommands
{
    public partial class MovieViewModel : ObservableObject
    {
        private string _searchQuery;
        private bool _isBarcodePopupVisible;
        private readonly IApiService _apiService;

        [ObservableProperty]
        private string searchQuery = "moana-2";

        private bool _hasMoreMovies = true;
        private int _currentPage = 1;
        public ObservableCollection<MovieClientSide> Movies { get; } = new();

        [ObservableProperty]
        private bool isLoading; // Tracks loading state

        public MovieViewModel(IApiService apiService) => _apiService = apiService;

        [RelayCommand]
        private async Task SearchMovies()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
                return;

            try
            {
                IsLoading = true; // Show loading indicator
                Movies.Clear();

                var results = await _apiService.SearchMoviesAsync(SearchQuery);
                foreach (var movie in results)
                {
                    Movies.Add(movie);
                }
            }
            catch (Exception ex)
            {
                // Handle errors (log them, show a message, etc.)
                Console.WriteLine($"Error fetching movies: {ex.Message}");
            }
            finally
            {
                IsLoading = false; // Hide loading indicator
            }
        }

        [RelayCommand]
        private async void OnViewDetails(Movie movie)
        {
            // Navigate to the detail page with the selected movie

            AppData.MovieId = movie.Id;

            await Shell.Current.GoToAsync($"///MovieDetailPage?MovieId={Uri.EscapeDataString(movie.Id.ToString())}");


        }

        [RelayCommand]
        private async Task ScanBarcodeCommand()
        {
        }

        [RelayCommand]
        private async void OpenBarcodeScanPage()
        {
            await Shell.Current.GoToAsync("///barcodeScanPage");
        }

        public void HandleBarcodeDetected(string barcodeValue)
        {
            SearchQuery = barcodeValue;
        }
    }
}