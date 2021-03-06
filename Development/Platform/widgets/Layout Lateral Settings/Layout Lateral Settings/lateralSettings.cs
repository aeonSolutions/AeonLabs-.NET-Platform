﻿using AeonLabs.Environment.Core;
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

        private ResourceManager resources;

        public lateralSettingsForm(environmentVarsCore _enVars)
        {
            resources = new ResourceManager(GetType().Namespace + ".config.strings", Assembly.GetExecutingAssembly());

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            enVars = _enVars;

            // This call is required by the designer.
            SuspendLayout();
            InitializeComponent();

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(enVars.currentLang);
            var backGroundImageToolTip = new ToolTip();
            backGroundImageToolTip.SetToolTip(selectBackGroundImage, resources.GetString("backGroundImage", CultureInfo.CurrentCulture));
            var colorPalleteToolTip = new ToolTip();
            colorPalleteToolTip.SetToolTip(selectPanelBackColor, resources.GetString("colorPallete", CultureInfo.CurrentCulture));
            panelForm.BackColor = Color.FromArgb(Convert.ToInt32(enVars.layoutDesign.PanelTransparencyIndex), enVars.layoutDesign.PanelBackColor);
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

        private environmentVarsCore enVars;
        private ToolTip backGroundImageToolTip = new ToolTip();
        private ToolTip colorPalleteToolTip = new ToolTip();

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            enVars.layoutDesign.PanelTransparencyIndex = trackBar.Value;
            var dataUpdate = new updateMainAppClass();
            dataUpdate.enVars = enVars;
            dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT;
            enVars.updateViewLayout?.Invoke(this, ref dataUpdate);
        }

        private void selectPanelBackColor_Click_1(object sender, EventArgs e)
        {
            if (ColorPickerDialog.ShowDialog() == DialogResult.OK)
            {
                enVars.layoutDesign.PanelBackColor = ColorPickerDialog.Color;
                var dataUpdate = new updateMainAppClass();
                dataUpdate.enVars = enVars;
                dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT;
                enVars.updateViewLayout?.Invoke(this, ref dataUpdate);
            }
        }

        private void selectBackGroundImage_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Title = resources.GetString("openFile", CultureInfo.CurrentCulture);
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = resources.GetString("imageFile", CultureInfo.CurrentCulture) + " jpg|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dataUpdate = new updateMainAppClass();
                dataUpdate.enVars = enVars;
                dataUpdate.backGroundFileName = openFileDialog1.FileName;
                dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT_BACKGROUND;
                enVars.updateViewLayout?.Invoke(this, ref dataUpdate);
            }
        }
    }
}
