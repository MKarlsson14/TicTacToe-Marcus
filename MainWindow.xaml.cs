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

namespace TicTacToe_Marcus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random random = new Random();
        List<Button> buttons;

        public MainWindow()
        {
            InitializeComponent();
            RestartGame();
        }

        private void PlayerMove_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;                     
            button.IsEnabled = false;
            button.Background = Brushes.Blue;
            button.UpdateLayout();
            buttons.Remove(button);
            if (!CheckGameOver())
            {               
                ComputerMove();
            }
            else
            {
                MessageBox.Show("Player Wins!!");
            }
            

        }
        private void ComputerMove()
        {
            if(buttons.Count > 0)
            {
                var index = random.Next(buttons.Count);
                buttons[index].IsEnabled = false;
                buttons[index].Background = Brushes.Red;
                buttons.RemoveAt(index);
                if (CheckGameOver())
                {
                    MessageBox.Show("Computer Wins!!");
                }

            }
        }

        private void startGameBtn_Click(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }

        private bool CheckGameOver()
        {

            if (Button1.Background == Brushes.Blue && Button2.Background == Brushes.Blue && Button3.Background == Brushes.Blue
             || Button4.Background == Brushes.Blue && Button5.Background == Brushes.Blue && Button6.Background == Brushes.Blue
             || Button7.Background == Brushes.Blue && Button8.Background == Brushes.Blue && Button9.Background == Brushes.Blue
             || Button1.Background == Brushes.Blue && Button5.Background == Brushes.Blue && Button9.Background == Brushes.Blue
             || Button7.Background == Brushes.Blue && Button5.Background == Brushes.Blue && Button3.Background == Brushes.Blue
             || Button1.Background == Brushes.Blue && Button4.Background == Brushes.Blue && Button7.Background == Brushes.Blue
             || Button2.Background == Brushes.Blue && Button5.Background == Brushes.Blue && Button8.Background == Brushes.Blue
             || Button3.Background == Brushes.Blue && Button6.Background == Brushes.Blue && Button9.Background == Brushes.Blue
             || Button1.Background == Brushes.Red && Button2.Background == Brushes.Red && Button3.Background == Brushes.Red
             || Button4.Background == Brushes.Red && Button5.Background == Brushes.Red && Button6.Background == Brushes.Red
             || Button7.Background == Brushes.Red && Button8.Background == Brushes.Red && Button9.Background == Brushes.Red
             || Button7.Background == Brushes.Red && Button5.Background == Brushes.Red && Button3.Background == Brushes.Red
             || Button1.Background == Brushes.Red && Button4.Background == Brushes.Red && Button7.Background == Brushes.Red
             || Button2.Background == Brushes.Red && Button5.Background == Brushes.Red && Button8.Background == Brushes.Red
             || Button3.Background == Brushes.Red && Button6.Background == Brushes.Red && Button9.Background == Brushes.Red
             ) return true;    
            else return false;
        }

        private void RestartGame()
        {
            buttons = new List<Button> { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };

            foreach (var btn in buttons)
            {
                btn.IsEnabled = true;
                btn.Background = Brushes.Transparent;             
            }
        }
    }
}