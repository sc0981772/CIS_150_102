using System;
using System.Collections.Generic;
using System.IO;
using UWPapp;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using static Uno.UI.FeatureConfiguration;

namespace UWPapp
{
        public class MainPage : Windows.UI.Xaml.Controls.Page
        {
        private List<Student> students = new List<Student>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = IDTextBox.Text;
                var firstName = FirstNameTextBox.Text;
                var lastName = LastNameTextBox.Text;
                var className = ClassTextBox.Text;
                var courseGrade = CourseGradeTextBox.Text;

                var student = new Student(id, firstName, lastName, className, courseGrade);
                students.Add(student);
                DisplayStudents();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                ErrorTextBlock.Text = $"Error: {ex.Message}";
            }
        }

        private void DisplayStudents()
        {
            object value = StudentListBox();
            foreach (var student in students)
            {
                Add(student.ToString());
            }
        }

        private void Add(string v)
        {
            throw new NotImplementedException();
        }

        private object StudentListBox()
        {
            throw new NotImplementedException();
        }

        private void ClearInputFields()
        {
            IDTextBox.Text = string.Empty;
            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            ClassTextBox.Text = string.Empty;
            CourseGradeTextBox.Text = string.Empty;
        }

        private async void SaveStudents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var savePicker = new FileSavePicker
                {
                    SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                    SuggestedFileName = "StudentGrades",
                };
                savePicker.FileTypeChoices.Add("CSV File", new List<string>() { ".csv" });

                StorageFile file = await savePicker.PickSaveFileAsync();
                if (file != null)
                {
                    var lines = new List<string>();
                    foreach (var student in students)
                    {
                        lines.Add($"{student.ID},{student.LastName},{student.FirstName},{student.Class},{student.CourseGrade}");
                    }
                    await FileIO.WriteLinesAsync(file, lines);
                }
            }
            catch (Exception ex)
            {
                ErrorTextBlock.Text = $"Error: {ex.Message}";
            }
        }

        private async void ReadStudents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openPicker = new FileOpenPicker
                {
                    SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                    ViewMode = PickerViewMode.List
                };
                openPicker.FileTypeFilter.Add(".csv");

                StorageFile file = await openPicker.PickSingleFileAsync();
                if (file != null)
                {
                    var lines = await FileIO.ReadLinesAsync(file);
                    students.Clear();
                    foreach (var line in lines)
                    {
                        var fields = line.Split(',');
                        if (fields.Length == 5)
                        {
                            var student = new Student(fields[0], fields[2], fields[1], fields[3], fields[4]);
                            students.Add(student);
                        }
                    }
                    DisplayStudents();
                }
            }
            catch (Exception ex)
            {
                ErrorTextBlock.Text = $"Error: {ex.Message}";
            }
        }

        private class IDTextBox
        {
            public static string Text { get; internal set; }
        }

        private class FirstNameTextBox
        {
            public static string Text { get; internal set; }
        }

        private class LastNameTextBox
        {
            public static string Text { get; internal set; }
        }

        private class ClassTextBox
        {
            public static string Text { get; internal set; }
        }

        private class CourseGradeTextBox
        {
            public static string Text { get; internal set; }
        }

        private class ErrorTextBlock
        {
            public static string Text { get; internal set; }
        }


        internal class studentListBox
        {
            public static object Items { get; internal set; }

            internal static void Add(string v)
            {
                throw new NotImplementedException();
            }

            //internal static object Items()
            //{
            //    throw new NotImplementedException();
            //}

            //internal static object Items()
            //{
            //throw new NotImplementedException();
            //}
        }
    }
}