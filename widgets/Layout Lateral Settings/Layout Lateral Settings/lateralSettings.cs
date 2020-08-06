using System;
using System.Drawing;
using System.Windows.Forms;

namespace AeonLabs.PlugIns.SideBar.Settings
{
    public partial class lateralSettingsForm
    {
        public lateralSettingsForm()
        {
            InitializeComponent();
            _selectBackGroundImage.Name = "selectBackGroundImage";
            _selectPanelBackColor.Name = "selectPanelBackColor";
            _MacTrackBar1.Name = "MacTrackBar1";
            _panelForm.Name = "panelForm";
        }

        public lateralSettingsForm(Global.AeonLabs.Environment.environmentVarsCore _envars, ref environmentVarsCore.updateMainLayoutDelegate _updateMainApp)
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            envars = _envars;
            updateMainApp = _updateMainApp;

            // This call is required by the designer.
            SuspendLayout();
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(envars.currentLang);
            var backGroundImageToolTip = new ToolTip();
            backGroundImageToolTip.SetToolTip(selectBackGroundImage, My.Resources.strings.backGroundImage);
            var colorPalleteToolTip = new ToolTip();
            colorPalleteToolTip.SetToolTip(selectPanelBackColor, My.Resources.strings.colorPallete);
            panelForm.BackColor = Color.FromArgb(envars.layoutDesign.PanelTransparencyIndex, envars.layoutDesign.PanelBackColor);
            ResumeLayout();
            _selectBackGroundImage.Name = "selectBackGroundImage";
            _selectPanelBackColor.Name = "selectPanelBackColor";
            _MacTrackBar1.Name = "MacTrackBar1";
            _panelForm.Name = "panelForm";
        }

        protected new override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 33554432;
                return cp;
            }
        }

        private environmentVarsCore envars;
        private environmentVarsCore.updateMainLayoutDelegate updateMainApp;
        private ToolTip backGroundImageToolTip = new ToolTip();
        private ToolTip colorPalleteToolTip = new ToolTip();

        private void Form1_Resize(object sender, EventArgs e)
        {
            MacTrackBar1.BorderStyle = BorderStyle.None;
        }

        private void messageBoxForm_Load(object sender, EventArgs e)
        {
        }

        private void messageBoxForm_show(object sender, EventArgs e)
        {
        }

        private void selectPanelBackColor_Click(object sender, EventArgs e)
        {
            if (ColorPickerDialog.ShowDialog() == DialogResult.OK)
            {
                envars.layoutDesign.PanelBackColor = ColorPickerDialog.Color;
                var dataUpdate = new updateMainAppClass();
                dataUpdate.envars = envars;
                dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT;
                updateMainApp.Invoke(this, dataUpdate);
            }
        }

        private void MacTrackBar2_ValueChanged(object sender, decimal value)
        {
            envars.layoutDesign.PanelTransparencyIndex = value;
            var dataUpdate = new updateMainAppClass();
            dataUpdate.envars = envars;
            dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT;
            updateMainApp.Invoke(this, dataUpdate);
        }

        private void panelForm_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void selectBackGroundImage_Click(object sender, EventArgs e)
        {
            var OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Title = My.Resources.strings.openFile;
            OpenFileDialog1.Multiselect = false;
            OpenFileDialog1.Filter = My.Resources.strings.imageFile + " jpg|*.jpg";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dataUpdate = new updateMainAppClass();
                dataUpdate.envars = envars;
                dataUpdate.backGroundFileName = OpenFileDialog1.FileName;
                dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT_BACKGROUND;
                updateMainApp.Invoke(this, dataUpdate);
            }
        }
    }
}