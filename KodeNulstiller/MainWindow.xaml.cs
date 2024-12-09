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

namespace KodeNulstiller
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Tjekker om adgangskoden er gyldig
        private bool ValidatePassword(string password)
        {
            // Tjekker om længden er mellem 8 og 32 tegn
            if (password.Length < 8 || password.Length > 32)
            {
                MessageBox.Show("Adgangskoden skal være mellem 8 og 32 tegn.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Tjekker om der er både store og små bogstaver
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower))
            {
                MessageBox.Show("Adgangskoden skal indeholde både store og små bogstaver.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Tjekker om der er tal
            if (!password.Any(char.IsDigit))
            {
                MessageBox.Show("Adgangskoden skal indeholde mindst et tal.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Tjekker om der er specialtegn
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Adgangskoden skal indeholde mindst et specialtegn (f.eks. !, @, #, $, osv.).", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Hvis alle krav er opfyldt
            return true;
        }

        // Reset password
        private void ResetPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            string newPassword = NewPasswordTextBox.Text; // Den nye adgangskode

            // Hvis adgangskoden er godkendt bliver den opdateret
            if (ValidatePassword(newPassword))
            {
                MessageBox.Show("Adgangskoden er blevet opdateret!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        } 
    }
}