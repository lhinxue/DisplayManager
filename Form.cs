using DisplayManager.utils;

namespace DisplayManager
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Hide();
            this.ShowInTaskbar = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResolutionManager.ChangeResolution(2560, 1440);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ResolutionManager.ChangeResolution(1920, 1080);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ScreenManager.ExtendScreen();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ScreenManager.InternalScreenOnly();
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
