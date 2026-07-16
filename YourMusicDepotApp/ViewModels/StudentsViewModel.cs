using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.Repositories.Interfaces;
using YourMusicDepotApp.Views;

namespace YourMusicDepotApp.ViewModels
{

   
    // ViewModel for managing students in the YourMusicDepot application.
    // It handles operations like adding, editing, deleting, and filtering students.

    public class StudentsViewModel : INotifyPropertyChanged
    {
        private readonly IStudentRepository _studentRepository;
        private Student _selectedStudent;
        private List<Student> _allStudents;

        // Commands for various student-related actions.
        public ICommand OpenAddStudentWindowCommand { get; private set; }
        public ICommand AddNewStudentCommand { get; private set; }

        public ICommand EditStudentCommand { get; private set; }

        public ICommand DeleteStudentCommand { get; private set; }

        // Properties for managing new and existing student details.
        private string _newStudentFirstName;
        public string NewStudentFirstName
        {
            get => _newStudentFirstName;
            set
            {
                _newStudentFirstName = value;
                
                OnPropertyChanged(nameof(NewStudentFirstName));
            }
        }

        private string _newStudentLastName;
        public string NewStudentLastName
        {
            get => _newStudentLastName;
            set
            {
                _newStudentLastName = value;
                
                OnPropertyChanged(nameof(NewStudentLastName));
            }
        }
        // NewStudentPhoneNumber property with validation
        private string _newStudentPhoneNumber;
        public string NewStudentPhoneNumber
        {
            get => _newStudentPhoneNumber;
            set
            {
                _newStudentPhoneNumber = value;
                
                OnPropertyChanged(nameof(NewStudentPhoneNumber));
            }
        }

        // NewStudentEmail property with validation
        private string _newStudentEmail;
        public string NewStudentEmail
        {
            get => _newStudentEmail;
            set
            {
                _newStudentEmail = value;
                
                OnPropertyChanged(nameof(NewStudentEmail));
            }
        }

        // NewStudentInstrument property with validation
        private string _newStudentInstrument;
        public string NewStudentInstrument
        {
            get => _newStudentInstrument;
            set
            {
                _newStudentInstrument = value;
                
                OnPropertyChanged(nameof(NewStudentInstrument));
            }
        }

        // NewStudentSkillLevel property with validation
        private string _newStudentSkillLevel;
        public string NewStudentSkillLevel
        {
            get => _newStudentSkillLevel;
            set
            {
                _newStudentSkillLevel = value;
                
                OnPropertyChanged(nameof(NewStudentSkillLevel));
            }
        }

        // NewStudentAge property with validation
        private byte _newStudentAge;
        public byte NewStudentAge
        {
            get => _newStudentAge;
            set
            {
                _newStudentAge = value;
                
                OnPropertyChanged(nameof(NewStudentAge));
            }
        }

        // NewStudentAccountPassword property with validation
        private string _newStudentAccountPassword;
        public string NewStudentAccountPassword
        {
            get => _newStudentAccountPassword;
            set
            {
                _newStudentAccountPassword = value;
                
                OnPropertyChanged(nameof(NewStudentAccountPassword));
            }
        }
        // Edit properties for editing student details.
        public string EditStudentFirstName { get; set; }
        public string EditStudentLastName { get; set; }
        public string EditStudentPhoneNumber { get; set; }
        public string EditStudentEmail { get; set; }
        public string EditStudentInstrument { get; set; }
        public string EditStudentSkillLevel { get; set; }
        public byte EditStudentAge { get; set; }
        public string EditStudentAccountPassword { get; set; }
        public ICommand SaveEditCommand { get; private set; }
        public ObservableCollection<Student> Students { get; private set; }

        // Property to hold the selected student for editing.
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }
        // Property to hold the search text for filtering students.
        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterStudents();
            }
        }
        //Filter for search functionality
        private void FilterStudents()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadStudents();
            }
            else
            {
                var filteredList = _allStudents.Where(s =>
                                    s.FullName.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    s.StudentMusicProgresses.Any(p => p.StudentInstrument.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0))
                                    .ToList();

                Students.Clear();
                foreach (var student in filteredList)
                {
                    Students.Add(student);
                }
            }
        }
        // Constructor initializing the ViewModel.
        public StudentsViewModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            Students = new ObservableCollection<Student>();
            OpenAddStudentWindowCommand = new RelayCommand(OpenAddStudentWindow);
            AddNewStudentCommand = new RelayCommand(AddNewStudent);
            SaveEditCommand = new RelayCommand(param => SaveEdit(), param => SelectedStudent != null);
            EditStudentCommand = new RelayCommand(param => EditStudent(), param => SelectedStudent != null);
            DeleteStudentCommand = new RelayCommand(param => DeleteStudent(), param => SelectedStudent != null);
            LoadStudents();
        }
        private Dictionary<string, string> _errors = new Dictionary<string, string>();

       

        // Delete student functionality
        private async void DeleteStudent()
        {
            if (SelectedStudent != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {SelectedStudent.StudentFirstName} {SelectedStudent.StudentLastName}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    await _studentRepository.DeleteAsync(SelectedStudent.StudentID);
                    LoadStudents(); // Refresh the list after deletion
                    MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        // Methods for each command action(AddNewStudent, EditStudent, SaveEdit,etc.).
        private void EditStudent()
        {
            if (SelectedStudent != null)
            {
                var editWindow = new EditStudentWindow
                {
                    DataContext = this // Set DataContext to the ViewModel itself
                };
                // Initialize edit fields with the selected student's data
                EditStudentFirstName = SelectedStudent.StudentFirstName;
                EditStudentLastName = SelectedStudent.StudentLastName;
                EditStudentPhoneNumber = SelectedStudent.StudentPhoneNumber;
                EditStudentEmail = SelectedStudent.StudentEmail;
                EditStudentInstrument = SelectedStudent.FirstMusicProgress?.StudentInstrument;
                EditStudentSkillLevel = SelectedStudent.FirstMusicProgress?.StudentSkillLevel;
                EditStudentAge = SelectedStudent.StudentAge;
                EditStudentAccountPassword = SelectedStudent.StudentAccountPassword;

                editWindow.ShowDialog();
            }
        }
        private async void SaveEdit()
        {
            if (SelectedStudent != null)
            {
                // Perform validation before updating
                if (_errors.Any())
                {
                    MessageBox.Show("Please correct the errors before saving changes.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Update SelectedStudent with new values
                SelectedStudent.StudentFirstName = EditStudentFirstName;
                SelectedStudent.StudentLastName = EditStudentLastName;
                SelectedStudent.StudentPhoneNumber = EditStudentPhoneNumber;
                SelectedStudent.StudentEmail = EditStudentEmail;
                SelectedStudent.StudentAge = EditStudentAge;
                SelectedStudent.StudentAccountPassword = EditStudentAccountPassword;

                var musicProgress = SelectedStudent.StudentMusicProgresses.FirstOrDefault();
                if (musicProgress != null)
                {
                    musicProgress.StudentInstrument = EditStudentInstrument;
                    musicProgress.StudentSkillLevel = EditStudentSkillLevel;
                }

                await _studentRepository.UpdateAsync(SelectedStudent);
                LoadStudents(); // Refresh the list

                MessageBox.Show("Student details updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        //Opens the add student window
        private void OpenAddStudentWindow(object parameter)
        {
            var addStudentWindow = new AddStudentWindow
            {
                DataContext = this
            };
            addStudentWindow.ShowDialog();
        }
        private Window _addStudentWindow;

        public void SetAddStudentWindowReference(Window window)
        {
            _addStudentWindow = window;
        }
        //Method to add new student 
        public async void AddNewStudent(object parameter)
        {
            if (_errors.Any())
            {
                MessageBox.Show("Please correct the errors before adding a new student.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Validation for empty fields
            if (string.IsNullOrWhiteSpace(NewStudentFirstName) ||
                string.IsNullOrWhiteSpace(NewStudentLastName) ||
                string.IsNullOrWhiteSpace(NewStudentAccountPassword) ||
                string.IsNullOrWhiteSpace(NewStudentEmail) ||
                string.IsNullOrWhiteSpace(NewStudentPhoneNumber) ||
                string.IsNullOrWhiteSpace(NewStudentInstrument) ||
                string.IsNullOrWhiteSpace(NewStudentSkillLevel)
                ) 
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newStudent = new Student
            {
                StudentFirstName = NewStudentFirstName,
                StudentLastName = NewStudentLastName,
                StudentPhoneNumber = NewStudentPhoneNumber,
                StudentEmail = NewStudentEmail,
                StudentAge = NewStudentAge,
                StudentAccountPassword = NewStudentAccountPassword,

             
            };

            // Create StudentMusicProgress object and add it to newStudent
            var musicProgress = new StudentMusicProgress
            {
                StudentInstrument = NewStudentInstrument,
                StudentSkillLevel = NewStudentSkillLevel
            };
            newStudent.StudentMusicProgresses = new List<StudentMusicProgress> { musicProgress };
            await _studentRepository.AddAsync(newStudent);
            LoadStudents(); // Refresh the list
            MessageBox.Show("Student added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        // Loads all students from the database.
        private async void LoadStudents()
        {
            var students = await _studentRepository.GetAllWithDetailsAsync();
            _allStudents = students.ToList();
            Students.Clear();
            foreach (var student in _allStudents)
            {
                Students.Add(student);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
