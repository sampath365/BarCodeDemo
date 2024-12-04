using BarCodeDemo.ApService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieSearchApi.Model;
using System.Windows.Input;

namespace BarCodeDemo.ViewCommands
{
    public partial class MovieDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private MovieDetailsWithCast selectedMovieDetails;
        public string  MovieId { get; set; }
        [ObservableProperty]
        private bool isLoading; // Tracks loading state
        private readonly IApiService _apiService;

        [ObservableProperty]
        private MovieDetails movie;

        [ObservableProperty]
        private List<Cast> cast;

        public MovieDetailViewModel(IApiService apiService) => _apiService = apiService;
        [RelayCommand]
        private async Task Back()
        {
            await Shell.Current.GoToAsync("///MainPage");  // Navigate back to the previous page
        }
       
        public async Task LoadMovieDetails()
        {
            IsLoading = true; // Show loading indicator

            try
            {
                // Fetch movie details using the API service
                SelectedMovieDetails = await _apiService.GetMovieDetailsAsync(MovieId);
                Movie = SelectedMovieDetails.Movie;
                Cast = SelectedMovieDetails.Cast;
            }
            catch (Exception ex)
            {
                 
                Console.WriteLine($"Error fetching movie details: {ex.Message}");
            }
            finally
            {
                IsLoading = false; // Hide loading indicator
            }
        }
    }
}
