namespace BlackOut
{
    public partial class Form1 : Form
    {
        private List<FrmChild> Children { get; set; } = new();

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.3;
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.TopLevel = true;

            int left = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 50;
            int top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.DesktopBounds = new Rectangle(left, top, this.Width, this.Height);


            foreach (Screen screen in Screen.AllScreens)
            {
                FrmChild f = new(KillEnd)
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = screen.Bounds.Location,
                    FormBorderStyle = FormBorderStyle.None,
                    WindowState = FormWindowState.Maximized,
                };
                f.Show();

                Children.Add(f);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KillEnd();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                KillEnd();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            KillAllScreens();
        }

        private void KillEnd()
        {
            this.Close();
        }

        private void KillAllScreens()
        {
            foreach (FrmChild child in Children)
            {
                if (child != null)
                {
                    child.Close();
                }
            }
        }
    }
}