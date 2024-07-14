using ADO_TASK_1.Databases;
using System.Windows;

namespace ADO_TASK_1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Database.ReadUsersToDatabase();
    }

    private void SignInClick(object sender, RoutedEventArgs e)
    {
        if (Database.CheckLoginPwInUsers(LoginBox.Text, PasswordBox.Text) == true)
            MessageBox.Show("successfully logined");
        else MessageBox.Show("Bele adam yoxdur");
    }

    private void SignUpClick(object sender, RoutedEventArgs e)
    {
        SignUpWindow signUpWindow = new SignUpWindow();
        signUpWindow.ShowDialog();
    }
}