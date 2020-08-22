using AeonLabs.Environment;
using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace AeonLabs.PlugIns.SideBar.Settings
{

    public partial class lateralSettingsForm : FormCustomized
    {

        private ResourceManager resources = new ResourceManager(Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace + ".config.strings", Assembly.GetExecutingAssembly());


        public lateralSettingsForm(environmentVarsCore _envars, ref environmentVarsCore.updateMainLayoutDelegate _updateMainApp)
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
            backGroundImageToolTip.SetToolTip(selectBackGroundImage, resources.GetString("backGroundImage", CultureInfo.CurrentCulture));
            var colorPalleteToolTip = new ToolTip();
            colorPalleteToolTip.SetToolTip(selectPanelBackColor, resources.GetString("colorPallete", CultureInfo.CurrentCulture));
            panelForm.BackColor = Color.FromArgb(Convert.ToInt32(envars.layoutDesign.PanelTransparencyIndex), envars.layoutDesign.PanelBackColor);
            ResumeLayout();

        }

        protected override CreateParams CreateParams
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

        private void sideBarSettingsForm_reSize(object sender, EventArgs e)
        {
        }

        private void sideBarSettingsForm_Load(object sender, EventArgs e)
        {
        }

        private void sideBarSettingsForm_shown(object sender, EventArgs e)
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
                updateMainApp.Invoke(this, ref dataUpdate);
            }
        }

        private void selectBackGroundImage_Click(object sender, EventArgs e)
        {
            var OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Title = resources.GetString("openFile", CultureInfo.CurrentCulture);
            OpenFileDialog1.Multiselect = false;
            OpenFileDialog1.Filter = resources.GetString("imageFile", CultureInfo.CurrentCulture) + " jpg|*.jpg";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dataUpdate = new updateMainAppClass();
                dataUpdate.envars = envars;
                dataUpdate.backGroundFileName = OpenFileDialog1.FileName;
                dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT_BACKGROUND;
                updateMainApp.Invoke(this, ref dataUpdate);
            }
        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            envars.layoutDesign.PanelTransparencyIndex = trackBar.Value;
            var dataUpdate = new updateMainAppClass();
            dataUpdate.envars = envars;
            dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT;
            updateMainApp.Invoke(this, ref dataUpdate);
        }
    }
}
