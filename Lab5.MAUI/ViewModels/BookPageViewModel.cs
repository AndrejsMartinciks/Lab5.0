using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;

namespace Lab5.MAUI.ViewModels
{
    public class BooksPageViewModel : ViewModelBase
    {
        private readonly IDataRepository _dataRepository;

        public BooksPageViewModel()
        {

        }
        public BooksPageViewModel(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;

            DeleteCommand = new RelayCommand(DeleteBook);
            SelectBookCommand = new RelayCommand(BookSelected);

            DeleteConfirmCommand = new RelayCommand(ConfirmDeleteBook);
            DeleteCancelCommand = new RelayCommand(CancelDeleteBook);

            EditAuthorCommand = new RelayCommand(EditAuthorDetails);

            UpdateConfirmCommand = new RelayCommand(ConfirmUpdateAuthor);
            UpdateCancelCommand = new RelayCommand(CancelUpdateAuthor);

            ValidateCommand = new RelayCommand(ValidateAuthor);

            IsEditEnabled = false;
            IsReadOnly = !IsEditEnabled;
        }

        private void ValidateAuthor()
        {
            IsAuthorDataValid();
        }

        Author author;
        public Author Author
        {
            get => author;
            set
            {
                author = value;

                IsDeleteEnabled = false;

                OnPropertyChanged();

                LoadData();
            }
        }

        private Book[] _books;

        public Book[] Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadData()
        {
            var data = await _dataRepository.GetAuthorBooksAsync(Author.Id);
            Books = data;
        }

        public ICommand DeleteCommand { get; }

        public ICommand SelectBookCommand { get; }

        public ICommand DeleteConfirmCommand { get; }

        public ICommand DeleteCancelCommand { get; }

        public ICommand EditAuthorCommand { get; }

        public ICommand UpdateConfirmCommand { get; }

        public ICommand UpdateCancelCommand { get; }

        public ICommand ValidateCommand { get; }

        public void DeleteBook()
        {
            IsDeleteConfirmationVisible = true;
        }

        public void BookSelected()
        {
            IsDeleteEnabled = true;
        }

        public void EditAuthorDetails()
        {
            IsEditEnabled = true;
            IsReadOnly = !IsEditEnabled;
        }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
            }
        }

        private bool _isDeleteEnabled;
        public bool IsDeleteEnabled
        {
            get
            {
                return _isDeleteEnabled;
            }
            set
            {
                _isDeleteEnabled = value;
                OnPropertyChanged();
            }
        }

        private bool _isDeleteConfirmationVisible;
        public bool IsDeleteConfirmationVisible
        {
            get
            {
                return _isDeleteConfirmationVisible;
            }
            set
            {
                _isDeleteConfirmationVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _isEditEnabled;
        public bool IsEditEnabled
        {
            get
            {
                return _isEditEnabled;
            }
            set
            {
                _isEditEnabled = value;
                OnPropertyChanged();
            }
        }

        private bool _isReadOnly;
        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }
            set
            {
                _isReadOnly = value;
                OnPropertyChanged();
            }
        }

        private bool _isCodeInValid;
        public bool IsCodeInValid
        {
            get
            {
                return _isCodeInValid;
            }
            set
            {
                _isCodeInValid = value;
                OnPropertyChanged();
            }
        }

        private bool _isNameInValid;
        public bool IsNameInValid
        {
            get
            {
                return _isNameInValid;
            }
            set
            {
                _isNameInValid = value;
                OnPropertyChanged();
            }
        }

        private bool _isSurnameInValid;
        public bool IsSurnameInValid
        {
            get
            {
                return _isSurnameInValid;
            }
            set
            {
                _isSurnameInValid = value;
                OnPropertyChanged();
            }
        }

        private void CancelDeleteBook()
        {
            IsDeleteConfirmationVisible = false;
        }

        private async void ConfirmDeleteBook()
        {
            await _dataRepository.DeleteBook(Author.Id, SelectedBook.Id);
            IsDeleteConfirmationVisible = false;
            IsDeleteEnabled = false;

            await LoadData();
        }

        private void CancelUpdateAuthor()
        {
            IsEditEnabled = false;
            IsReadOnly = !IsEditEnabled;
        }

        private async void ConfirmUpdateAuthor()
        {
            if (!IsAuthorDataValid())
            {
                return;
            }

            await _dataRepository.UpdateAuthorAsync(Author);

            OnPropertyChanged(nameof(Author));

            IsEditEnabled = false;
            IsReadOnly = !IsEditEnabled;
        }

        private bool IsAuthorDataValid()
        {
            IsCodeInValid = string.IsNullOrEmpty(Author.Name);

            IsNameInValid = string.IsNullOrEmpty(Author.Surname);

            IsSurnameInValid = string.IsNullOrEmpty(Author.Country);

            if (string.IsNullOrEmpty(Author.Name)
                || string.IsNullOrEmpty(Author.Surname)
                || string.IsNullOrEmpty(Author.Country))
            {
                return false;
            }

            return true;
        }
    }
}
