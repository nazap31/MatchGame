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

        public Game()
        {
            InitializeComponent();
            AssingIconsToSquares();
        }
       
        private void AssingIconsToSquares()
        {
            foreach (Control control in table.Controls)
            {

                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);

                }



            }


        }


    }
}