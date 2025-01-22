using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;
using Lab5.MAUIData.Services;
using Lab5.MAUI.ViewModels;

namespace Lab5.MAUI;

[QueryProperty(nameof(Author), "Author")]
public partial class BooksPage : ContentPage
{
    private Lab5.MAUI.ViewModels.BooksPageViewModel _viewModel;

    Author author;
    public Author Author
    {
        get => author;
        set
        {
            author = value;
            _viewModel.Author = value;
            OnPropertyChanged();
        }
    }

    public BooksPage(Lab5.MAUI.ViewModels.BooksPageViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }
}
