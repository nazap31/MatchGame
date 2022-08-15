namespace MatchGame_
{
    public partial class Game : Form
    {
        private Random random = new Random();

        private List<String> icons = new List<string>() {
            "!","!","n","n",
            ",",",","k","k",
            "b","b","v","v",
            "w","w", "z","z"
        };
        Label? firstClicked = null;
        Label? secondClicked = null;
        public Game()
        {
            InitializeComponent();
            AssingIconsToSquares();
        }
       
        private void AssingIconsToSquares()
        {
            foreach (Control control in table.Controls)
            {

                Label? iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);

                }

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                return;
            }
            Label? clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                {
                    return;
                }
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
            
                }
              secondClicked = clickedLabel;
              secondClicked.ForeColor = Color.Black;
              CheckForWinner();
              if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
              timer1.Start();
            }
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
           foreach (Control control in table.Controls)
            {
                Label? iconLabel = control as Label;
                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        return;
                    }
                }
        
            }
            MessageBox.Show("You won the match game!", "Congratulations");
            Close();
        }
    }
}