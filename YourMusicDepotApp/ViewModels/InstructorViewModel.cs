using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.Repositories.Interfaces;
using System.Linq;
using YourMusicDepotApp.Views;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Windows;
using System.Text.RegularExpressions;

namespace YourMusicDepotApp.ViewModels
{
    // Inherits from INotifyPropertyChanged to notify views of property changes.
    public class InstructorViewModel : INotifyPropertyChanged
    {
        // Repository for handling instructor data operations.
        private readonly IInstructorRepository _instructorRepository;

        // Collection of Instructor objects to be used by the view.
        public ObservableCollection<Instructor> Instructors { get; private set; }

        // ICommand properties for handling user actions from the UI.
        public ICommand AddInstructorCommand { get; private set; }
        // Constructor initializing the repository and loading data.
        public InstructorViewModel(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
            LoadInstructors();
            InitializeCommands();
        }

        // Initializes commands with their respective actions and conditions.
        private void InitializeCommands()
        {
            AddInstructorCommand = new RelayCommand(
            execute: param => AddInstructorExecute(param),
            canExecute: CanAddInstructorExecute);
        }
        // Properties for instructor details.
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _credentials;
        public string Credentials
        {
            get => _credentials;
            set
            {
                _credentials = value;
                
                OnPropertyChanged(nameof(Credentials));
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                
                OnPropertyChanged(nameof(Email));
            }
        }
        // Validates the instructor's first name.
        private Dictionary<string, string> _errors = new Dictionary<string, string>();



        // Represents the currently selected instructor in the UI.
        private Instructor _selectedInstructor;
        public Instructor SelectedInstructor
        {
            get => _selectedInstructor;
            set
            {
                _selectedInstructor = value;
                // Notify any bindings that the selected instructor has changed.

                OnPropertyChanged(nameof(SelectedInstructor));
               
            }
        }
       
      
        // Loads instructors from the repository asynchronously.
        private async void LoadInstructors()
        {
            var instructors = await _instructorRepository.GetAllWithLastLessonAsync();
            Instructors = new ObservableCollection<Instructor>(instructors);
            OnPropertyChanged(nameof(Instructors));
        }


        // Handles adding a new instructor.
        private async void AddInstructorExecute(object parameter)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Credentials) || string.IsNullOrWhiteSpace(PhoneNumber) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_errors.Any())
            {
                MessageBox.Show("Please correct the errors before adding the instructor.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Pass the instructor data for addition.
            var newInstructor = new Instructor
            {
                InstructorFirstName = this.FirstName,
                InstructorLastName = this.LastName,
                InstructorCredential = string.IsNullOrWhiteSpace(Credentials) ? "Default Credential" : Credentials,
                InstructorPhoneNumber = this.PhoneNumber,
                InstructorEmail = this.Email
            };
            // Add the instructor to the database.
            await _instructorRepository.AddAsync(newInstructor);
            LoadInstructors(); // Refresh the list which is bound to the ListView

            MessageBox.Show("Instructor added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        // Determines whether adding an instructor is allowed.
        private bool CanAddInstructorExecute(object parameter)
        {

            return !_errors.Any();
        }

        // Implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to invoke the PropertyChanged event.
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ICommand _openAddInstructorWindowCommand;
        public ICommand OpenAddInstructorWindowCommand
        {
            get
            {
                if (_openAddInstructorWindowCommand == null)
                {
                    _openAddInstructorWindowCommand = new RelayCommand(param => OpenAddInstructorWindow());
                }
                return _openAddInstructorWindowCommand;
            }
        }
        // Method to open the AddInstructor window.
        private void OpenAddInstructorWindow()
        {
            var addInstructorWindow = new AddInstructorWindow
            {
                DataContext = this
            };
            addInstructorWindow.ShowDialog();
        }
        // ICommand property for editing an instructor.
        private ICommand _editInstructorCommand;
        public ICommand EditInstructorCommand
        {
            get
            {
                if (_editInstructorCommand == null)
                {
                    _editInstructorCommand = new RelayCommand(
                        execute: param => EditInstructor(),
                        canExecute: param => SelectedInstructor != null
                    );
                }
                return _editInstructorCommand;
            }
        }
        // Method to edit an instructor.
        private void EditInstructor()
        {
            var editWindow = new EditInstructorWindow
            {
                // EditInstructorWindow's DataContext is of type InstructorViewModel
                DataContext = new InstructorViewModel(_instructorRepository)
                {
                    SelectedInstructor = this.SelectedInstructor,
                    FirstName = SelectedInstructor.InstructorFirstName,
                    LastName = SelectedInstructor.InstructorLastName,
                    Credentials = SelectedInstructor.InstructorCredential,
                    PhoneNumber = SelectedInstructor.InstructorPhoneNumber,
                    Email = SelectedInstructor.InstructorEmail
                }
            };
            editWindow.ShowDialog();
        }

        // ICommand property for saving changes made to an instructor.
        private ICommand _saveInstructorChangesCommand;
        public ICommand SaveInstructorChangesCommand
        {
            get
            {
                if (_saveInstructorChangesCommand == null)
                {
                    _saveInstructorChangesCommand = new RelayCommand(
                        execute: param => SaveInstructorChanges(),
                        canExecute: param => SelectedInstructor != null
                    );
                }
                return _saveInstructorChangesCommand;
            }
        }
        // Method to save changes made to an instructor.
        public async void SaveInstructorChanges()
        {
            if (SelectedInstructor != null)
            {
                var instructorToUpdate = await _instructorRepository.GetByIdAsync(SelectedInstructor.InstructorID);
                if (instructorToUpdate != null)
                {
                    instructorToUpdate.InstructorFirstName = FirstName;
                    instructorToUpdate.InstructorLastName = LastName;
                    instructorToUpdate.InstructorCredential = Credentials;
                    instructorToUpdate.InstructorPhoneNumber = PhoneNumber;
                    instructorToUpdate.InstructorEmail = Email;

                    await _instructorRepository.UpdateAsync(instructorToUpdate);
                    LoadInstructors(); // Refresh the list

                    // Update the SelectedInstructor property to refresh the detail view
                    SelectedInstructor = instructorToUpdate;
                    OnPropertyChanged(nameof(SelectedInstructor));
                }
            }
        }
        // ICommand property for deleting an instructor.
        private ICommand _deleteInstructorCommand;
        public ICommand DeleteInstructorCommand
        {
            get
            {
                if (_deleteInstructorCommand == null)
                {
                    _deleteInstructorCommand = new RelayCommand(
                        execute: param => DeleteInstructor(),
                        canExecute: param => SelectedInstructor != null
                    );
                }
                return _deleteInstructorCommand;
            }
        }
        // Method to delete an instructor.
        private async void DeleteInstructor()
        {
            if (SelectedInstructor != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {SelectedInstructor.InstructorFirstName} {SelectedInstructor.InstructorLastName}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    await _instructorRepository.DeleteAsync(SelectedInstructor.InstructorID);
                    Instructors.Remove(SelectedInstructor);

                    // Select next available instructor or null if list is empty
                    SelectedInstructor = Instructors.FirstOrDefault();

                    MessageBox.Show("Instructor deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        // Method to delete an instructor.
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterInstructors();
            }
        }
        //Filter instructors for search 
        private async void FilterInstructors()
        {
            var filteredInstructors = await _instructorRepository.GetFilteredInstructorsAsync(_searchText);

            Instructors.Clear();
            foreach (var instructor in filteredInstructors)
            {
                Instructors.Add(instructor);
            }

            SelectedInstructor = Instructors.FirstOrDefault();
            OnPropertyChanged(nameof(Instructors));
        }





    }
}
