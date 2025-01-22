using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;

namespace Lab5.MAUI.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDataRepository _dataRepository;

        public MainPageViewModel(IDataRepository dataRepository)
        {
            Title = "Loading ...";
            _dataRepository = dataRepository;

            LoadCommand = new RelayCommand(LoadData);
            SelectAuthorCommand = new RelayCommand(ShowDetails);

            LoadData();
        }

        public MainPageViewModel()
        {

        }

        public async void ShowDetails()
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "Author", SelectedAuthor }
            };

            await Shell.Current.GoToAsync("//BooksPage", navigationParameter);
        }

        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private Author[] _authors;

        public Author[] Authors
        {
            get
            {
                return _authors;
            }
            set
            {
                _authors = value;
                OnPropertyChanged();
            }
        }

        private Author _selectedAuthor;
        public Author SelectedAuthor
        {
            get
            {
                return _selectedAuthor;
            }
            set
            {
                _selectedAuthor = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadCommand { get; }

        public ICommand SelectAuthorCommand { get; }

        public async void LoadData()
        {
            Title = "Loading ...";

            var data = await _dataRepository.GetAuthorsAsync();
            Authors = data;
            Title = "Number of authors: " + data.Length;
        }
    }
}
