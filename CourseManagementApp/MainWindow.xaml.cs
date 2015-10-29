using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CourseManagementApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Contracts.Course newCourse;

        public MainWindow()
        {
            InitializeComponent();
            newCourse = new Contracts.Course { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) };
            this.DataContext = newCourse;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {

            newCourse.Instructors = (from li in InstructorList.SelectedItems.Cast<ListBoxItem>()
                                    select new Contracts.Person(li.Content.ToString())).ToList();

            CourseWF.CourseServiceClient client =
                new CourseManagementApp.CourseWF.CourseServiceClient();
            try
            {
                var createdCourseId = client.CreateCourse(newCourse);
                if (createdCourseId.HasValue)
                    newCourse.CourseID = createdCourseId.Value;

                MessageBox.Show("Class created successfully", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An exception occurred submitting the course");
            }
            finally
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();
                else
                    client.Abort();
            }
            
        }

        

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            CourseWF.CourseServiceClient client =
                new CourseManagementApp.CourseWF.CourseServiceClient();
            try
            {
                client.CloseRegistrations(newCourse.CourseID);

                MessageBox.Show("Registrations are now closed", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An exception occurred closing the registrations");
            }
            finally
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();
                else
                    client.Abort();
            }
        }
    }
}
