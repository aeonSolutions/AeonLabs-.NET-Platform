using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.PlugIns.SideBar.Settings
{
    [DesignerGenerated()]
    public partial class lateralSettingsForm : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _ColorPickerDialog = new ColorDialog();
            _ToolTips = new ToolTip(components);
            _selectBackGroundImage = new FontAwesome.Sharp.IconPictureBox();
            _selectBackGroundImage.Click += new EventHandler(selectBackGroundImage_Click);
            _selectPanelBackColor = new FontAwesome.Sharp.IconPictureBox();
            _selectPanelBackColor.Click += new EventHandler(selectPanelBackColor_Click);
            _MacTrackBar1 = new XComponent.SliderBar.MACTrackBar();
            _MacTrackBar1.ValueChanged += MacTrackBar2_ValueChanged;
            _panelForm = new PanelDoubleBuffer();
            _panelForm.Paint += panelForm_Paint_1;
            ((System.ComponentModel.ISupportInitialize)_selectBackGroundImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_selectPanelBackColor).BeginInit();
            _panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // selectBackGroundImage
            // 
            _selectBackGroundImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _selectBackGroundImage.BackColor = Color.Transparent;
            _selectBackGroundImage.Cursor = Cursors.Hand;
            _selectBackGroundImage.IconChar = FontAwesome.Sharp.IconChar.Image;
            _selectBackGroundImage.IconColor = Color.White;
            _selectBackGroundImage.IconSize = 20;
            _selectBackGroundImage.Location = new Point(40, 44);
            _selectBackGroundImage.Name = "_selectBackGroundImage";
            _selectBackGroundImage.Size = new Size(20, 20);
            _selectBackGroundImage.TabIndex = 3;
            _selectBackGroundImage.TabStop = false;
            // 
            // selectPanelBackColor
            // 
            _selectPanelBackColor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _selectPanelBackColor.BackColor = Color.Transparent;
            _selectPanelBackColor.Cursor = Cursors.Hand;
            _selectPanelBackColor.IconChar = FontAwesome.Sharp.IconChar.Palette;
            _selectPanelBackColor.IconColor = Color.White;
            _selectPanelBackColor.IconSize = 20;
            _selectPanelBackColor.Location = new Point(3, 44);
            _selectPanelBackColor.Name = "_selectPanelBackColor";
            _selectPanelBackColor.Size = new Size(20, 20);
            _selectPanelBackColor.TabIndex = 2;
            _selectPanelBackColor.TabStop = false;
            // 
            // MacTrackBar1
            // 
            _MacTrackBar1.BackColor = Color.Transparent;
            _MacTrackBar1.BorderColor = Color.Transparent;
            _MacTrackBar1.Dock = DockStyle.Top;
            _MacTrackBar1.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _MacTrackBar1.ForeColor = Color.White;
            _MacTrackBar1.IndentHeight = 6;
            _MacTrackBar1.LargeChange = 10;
            _MacTrackBar1.Location = new Point(0, 0);
            _MacTrackBar1.Maximum = 100;
            _MacTrackBar1.Minimum = 0;
            _MacTrackBar1.Name = "_MacTrackBar1";
            _MacTrackBar1.Size = new Size(400, 38);
            _MacTrackBar1.TabIndex = 1;
            _MacTrackBar1.TextTickStyle = TickStyle.None;
            _MacTrackBar1.TickColor = Color.White;
            _MacTrackBar1.TickFrequency = 10;
            _MacTrackBar1.TickHeight = 4;
            _MacTrackBar1.TickStyle = TickStyle.Both;
            _MacTrackBar1.TrackerColor = Color.White;
            _MacTrackBar1.TrackerSize = new Size(16, 16);
            _MacTrackBar1.TrackLineColor = Color.White;
            _MacTrackBar1.TrackLineHeight = 3;
            _MacTrackBar1.Value = 0;
            // 
            // panelForm
            // 
            _panelForm.Controls.Add(_MacTrackBar1);
            _panelForm.Controls.Add(_selectBackGroundImage);
            _panelForm.Controls.Add(_selectPanelBackColor);
            _panelForm.Dock = DockStyle.Fill;
            _panelForm.Location = new Point(0, 0);
            _panelForm.Name = "_panelForm";
            _panelForm.PANEL_CLOSED_STATE_DIM = 40;
            _panelForm.PANEL_OPEN_STATE_DIM = 400;
            _panelForm.Size = new Size(400, 113);
            _panelForm.TabIndex = 356;
            // 
            // lateralSettingsForm
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(400, 113);
            ControlBox = false;
            Controls.Add(_panelForm);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "lateralSettingsForm";
            Opacity = 0D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Silver;
            ((System.ComponentModel.ISupportInitialize)_selectBackGroundImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)_selectPanelBackColor).EndInit();
            _panelForm.ResumeLayout(false);
            Resize += new EventHandler(Form1_Resize);
            Load += new EventHandler(messageBoxForm_Load);
            Shown += new EventHandler(messageBoxForm_show);
            ResumeLayout(false);
        }

        private XComponent.SliderBar.MACTrackBar _MacTrackBar1;

        private XComponent.SliderBar.MACTrackBar MacTrackBar1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MacTrackBar1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MacTrackBar1 != null)
                {
                    _MacTrackBar1.ValueChanged -= MacTrackBar2_ValueChanged;
                }

                _MacTrackBar1 = value;
                if (_MacTrackBar1 != null)
                {
                    _MacTrackBar1.ValueChanged += MacTrackBar2_ValueChanged;
                }
            }
        }

        private FontAwesome.Sharp.IconPictureBox _selectPanelBackColor;

        internal FontAwesome.Sharp.IconPictureBox selectPanelBackColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _selectPanelBackColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_selectPanelBackColor != null)
                {
                    _selectPanelBackColor.Click -= selectPanelBackColor_Click;
                }

                _selectPanelBackColor = value;
                if (_selectPanelBackColor != null)
                {
                    _selectPanelBackColor.Click += selectPanelBackColor_Click;
                }
            }
        }

        private ColorDialog _ColorPickerDialog;

        internal ColorDialog ColorPickerDialog
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ColorPickerDialog;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ColorPickerDialog != null)
                {
                }

                _ColorPickerDialog = value;
                if (_ColorPickerDialog != null)
                {
                }
            }
        }

        private FontAwesome.Sharp.IconPictureBox _selectBackGroundImage;

        internal FontAwesome.Sharp.IconPictureBox selectBackGroundImage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _selectBackGroundImage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_selectBackGroundImage != null)
                {
                    _selectBackGroundImage.Click -= selectBackGroundImage_Click;
                }

                _selectBackGroundImage = value;
                if (_selectBackGroundImage != null)
                {
                    _selectBackGroundImage.Click += selectBackGroundImage_Click;
                }
            }
        }

        private ToolTip _ToolTips;

        internal ToolTip ToolTips
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolTips;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolTips != null)
                {
                }

                _ToolTips = value;
                if (_ToolTips != null)
                {
                }
            }
        }

        private PanelDoubleBuffer _panelForm;

        internal PanelDoubleBuffer panelForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _panelForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_panelForm != null)
                {
                    _panelForm.Paint -= panelForm_Paint_1;
                }

                _panelForm = value;
                if (_panelForm != null)
                {
                    _panelForm.Paint += panelForm_Paint_1;
                }
            }
        }
    }
}