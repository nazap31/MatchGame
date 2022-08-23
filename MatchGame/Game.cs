using System.Media;

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
        SoundPlayer sonido = new SoundPlayer();
        int seg = 0;
        int min = 0;
        int hor = 0;
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
                    try
                    {
                        timer2.Start();
                        sonido.Stream = Properties.Resources.click_wav;
                        sonido.Play();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex);
                    }
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
            
                }
              secondClicked = clickedLabel;
              secondClicked.ForeColor = Color.Black;
              CheckForWinner();
              if (firstClicked.Text == secondClicked.Text)
              {
                    try
                    {
                        sonido.Stream = Properties.Resources.win_wav;
                        sonido.Play();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex);
                    }
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
            try
            {
                sonido.Stream = Properties.Resources.fail_wav;
                sonido.Play();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            seg = seg + 1;
            segundos.Text = seg.ToString();

            if (seg == 60)
            {
                min += 1;
                minutos.Text = min.ToString();
                seg = 0;
            }
            if (min == 60)
            {
                hor += 1;
                horas.Text = hor.ToString();
                min += 0;
            }

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
            try
            {
                sonido.Stream = Properties.Resources.youwin_wav;
                sonido.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            timer2.Stop();
            MessageBox.Show("You won the match game!", "Congratulations");
            MessageBox.Show("Tiempo trascurrido :" + " " + hor + " " + "horas" + ": " + min + " " +"minutos" + ": " + seg + " " +"segundos");
            Close();
        }
    }
}
