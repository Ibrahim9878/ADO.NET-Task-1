using ADO_TASK_1.Databases;
using ADO_TASK_1.Models;
using System.Windows;
namespace ADO_TASK_1;

public partial class SignUpWindow : Window
{
    public SignUpWindow()
    {
        InitializeComponent();
    }

    private void RegisterClick(object sender, RoutedEventArgs e)
    {
        if(CPasswordBox.Text == PasswordBox.Text)
        {
            User user = new User(NameBox.Text, SurnameBox.Text, int.Parse(AgeBox.Text), LoginBox.Text, PasswordBox.Text);
            Database.users.Add(user);
            Database.WriteUsersToDatabase();
        }
        else
        {
            MessageBox.Show("Confirm pasword duz deyil");
        }
        Close();
    }
}
