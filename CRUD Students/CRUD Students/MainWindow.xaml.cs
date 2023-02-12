using CRUD_Students.Data.StudentDbContext;
using CRUD_Students.Model;
using CRUD_Students.Services;
using System.Windows;


namespace CRUD_Students
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly StudentDbContext _dbContext;
        private readonly StudentService _studentService;

        public MainWindow()
        {
            InitializeComponent();

            _dbContext = new StudentDbContext();
            _studentService = new StudentService(_dbContext);

            dataGridStudents.ItemsSource = _studentService.GetAllStudents();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Show add student dialog
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Show update student dialog
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = dataGridStudents.SelectedItem as Student;
            if (selectedStudent != null)
            {
                _studentService.DeleteStudent(selectedStudent.Id);
                dataGridStudents.ItemsSource = _studentService.GetAllStudents();
            }
        }
    }
}
