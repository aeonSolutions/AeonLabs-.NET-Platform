using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    [DesignerGenerated()]
    public partial class setupWizard_addOns : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(setupWizard_addOns));
            _translation_apikey_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _translationApiKey = new TextBox();
            _weather_provider_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _weather_provider_lbl.Click += weather_provider_lbl_Click;
            _weatherProvider = new ComboBox();
            _translation_provider_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _translationProvider = new ComboBox();
            _enableWeather = new CheckBox();
            _enableWeather.CheckedChanged += new EventHandler(enableWeather_CheckedChanged);
            _enableTranslation = new CheckBox();
            _enableTranslation.CheckedChanged += new EventHandler(enableTranlation_CheckedChanged);
            _weather_apikey_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _weatherApiKey = new TextBox();
            _PictureBox1 = new PictureBox();
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // translation_apikey_lbl
            // 
            _translation_apikey_lbl.AutoSize = true;
            _translation_apikey_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _translation_apikey_lbl.ForeColor = Color.Black;
            _translation_apikey_lbl.Location = new Point(762, 267);
            _translation_apikey_lbl.Margin = new Padding(4, 0, 4, 0);
            _translation_apikey_lbl.Name = "_translation_apikey_lbl";
            _translation_apikey_lbl.Size = new Size(83, 23);
            _translation_apikey_lbl.TabIndex = 21;
            _translation_apikey_lbl.Text = "API Key";
            // 
            // translationApiKey
            // 
            _translationApiKey.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _translationApiKey.Location = new Point(853, 262);
            _translationApiKey.Margin = new Padding(4, 5, 4, 5);
            _translationApiKey.Name = "_translationApiKey";
            _translationApiKey.Size = new Size(352, 28);
            _translationApiKey.TabIndex = 20;
            // 
            // weather_provider_lbl
            // 
            _weather_provider_lbl.AutoSize = true;
            _weather_provider_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _weather_provider_lbl.ForeColor = Color.Black;
            _weather_provider_lbl.Location = new Point(740, 392);
            _weather_provider_lbl.Margin = new Padding(4, 0, 4, 0);
            _weather_provider_lbl.Name = "_weather_provider_lbl";
            _weather_provider_lbl.Size = new Size(105, 23);
            _weather_provider_lbl.TabIndex = 19;
            _weather_provider_lbl.Text = "Provider";
            // 
            // weatherProvider
            // 
            _weatherProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            _weatherProvider.FormattingEnabled = true;
            _weatherProvider.Items.AddRange(new object[] { "OpenWeatherMap.org" });
            _weatherProvider.Location = new Point(853, 387);
            _weatherProvider.Margin = new Padding(4, 5, 4, 5);
            _weatherProvider.Name = "_weatherProvider";
            _weatherProvider.Size = new Size(211, 28);
            _weatherProvider.TabIndex = 18;
            // 
            // translation_provider_lbl
            // 
            _translation_provider_lbl.AutoSize = true;
            _translation_provider_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _translation_provider_lbl.ForeColor = Color.Black;
            _translation_provider_lbl.Location = new Point(740, 229);
            _translation_provider_lbl.Margin = new Padding(4, 0, 4, 0);
            _translation_provider_lbl.Name = "_translation_provider_lbl";
            _translation_provider_lbl.Size = new Size(105, 23);
            _translation_provider_lbl.TabIndex = 17;
            _translation_provider_lbl.Text = "Provider";
            // 
            // translationProvider
            // 
            _translationProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            _translationProvider.FormattingEnabled = true;
            _translationProvider.Items.AddRange(new object[] { "Google" });
            _translationProvider.Location = new Point(853, 224);
            _translationProvider.Margin = new Padding(4, 5, 4, 5);
            _translationProvider.Name = "_translationProvider";
            _translationProvider.Size = new Size(211, 28);
            _translationProvider.TabIndex = 16;
            // 
            // enableWeather
            // 
            _enableWeather.AutoSize = true;
            _enableWeather.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _enableWeather.Location = new Point(703, 346);
            _enableWeather.Margin = new Padding(4, 5, 4, 5);
            _enableWeather.Name = "_enableWeather";
            _enableWeather.Size = new Size(492, 27);
            _enableWeather.TabIndex = 15;
            _enableWeather.Text = "Enable weather reports inside the platform";
            _enableWeather.UseVisualStyleBackColor = true;
            // 
            // enableTranslation
            // 
            _enableTranslation.AutoSize = true;
            _enableTranslation.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _enableTranslation.Location = new Point(703, 187);
            _enableTranslation.Margin = new Padding(4, 5, 4, 5);
            _enableTranslation.Name = "_enableTranslation";
            _enableTranslation.Size = new Size(448, 27);
            _enableTranslation.TabIndex = 14;
            _enableTranslation.Text = "Enable translation inside the platform";
            _enableTranslation.UseVisualStyleBackColor = true;
            // 
            // weather_apikey_lbl
            // 
            _weather_apikey_lbl.AutoSize = true;
            _weather_apikey_lbl.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _weather_apikey_lbl.ForeColor = Color.Black;
            _weather_apikey_lbl.Location = new Point(762, 430);
            _weather_apikey_lbl.Margin = new Padding(4, 0, 4, 0);
            _weather_apikey_lbl.Name = "_weather_apikey_lbl";
            _weather_apikey_lbl.Size = new Size(83, 23);
            _weather_apikey_lbl.TabIndex = 13;
            _weather_apikey_lbl.Text = "API Key";
            // 
            // weatherApiKey
            // 
            _weatherApiKey.Font = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _weatherApiKey.Location = new Point(853, 425);
            _weatherApiKey.Margin = new Padding(4, 5, 4, 5);
            _weatherApiKey.Name = "_weatherApiKey";
            _weatherApiKey.Size = new Size(352, 28);
            _weatherApiKey.TabIndex = 12;
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            _PictureBox1.Location = new Point(284, 160);
            _PictureBox1.Margin = new Padding(4, 5, 4, 5);
            _PictureBox1.Name = "_PictureBox1";
            _PictureBox1.Size = new Size(358, 352);
            _PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            _PictureBox1.TabIndex = 2;
            _PictureBox1.TabStop = false;
            // 
            // ColorWithAlpha1
            // 
            _ColorWithAlpha1.Alpha = 150;
            _ColorWithAlpha1.Color = Color.Black;
            _ColorWithAlpha1.Parent = null;
            // 
            // setupWizard_addOns
            // 
            AutoScaleDimensions = new SizeF(9.0F, 20.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1600, 742);
            ControlBox = false;
            Controls.Add(_translation_apikey_lbl);
            Controls.Add(_translationApiKey);
            Controls.Add(_PictureBox1);
            Controls.Add(_weather_provider_lbl);
            Controls.Add(_weather_apikey_lbl);
            Controls.Add(_weatherApiKey);
            Controls.Add(_weatherProvider);
            Controls.Add(_enableTranslation);
            Controls.Add(_translation_provider_lbl);
            Controls.Add(_enableWeather);
            Controls.Add(_translationProvider);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "setupWizard_addOns";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            VisibleChanged += new EventHandler(setupWizard_1_VisibleChanged);
            Load += new EventHandler(setupWizard_1_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox _PictureBox1;

        internal PictureBox PictureBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBox1 != null)
                {
                }

                _PictureBox1 = value;
                if (_PictureBox1 != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _weather_apikey_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer weather_apikey_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _weather_apikey_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_weather_apikey_lbl != null)
                {
                }

                _weather_apikey_lbl = value;
                if (_weather_apikey_lbl != null)
                {
                }
            }
        }

        private TextBox _weatherApiKey;

        internal TextBox weatherApiKey
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _weatherApiKey;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_weatherApiKey != null)
                {
                }

                _weatherApiKey = value;
                if (_weatherApiKey != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _translation_apikey_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer translation_apikey_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _translation_apikey_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_translation_apikey_lbl != null)
                {
                }

                _translation_apikey_lbl = value;
                if (_translation_apikey_lbl != null)
                {
                }
            }
        }

        private TextBox _translationApiKey;

        internal TextBox translationApiKey
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _translationApiKey;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_translationApiKey != null)
                {
                }

                _translationApiKey = value;
                if (_translationApiKey != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _weather_provider_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer weather_provider_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _weather_provider_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_weather_provider_lbl != null)
                {
                    _weather_provider_lbl.Click -= weather_provider_lbl_Click;
                }

                _weather_provider_lbl = value;
                if (_weather_provider_lbl != null)
                {
                    _weather_provider_lbl.Click += weather_provider_lbl_Click;
                }
            }
        }

        private ComboBox _weatherProvider;

        internal ComboBox weatherProvider
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _weatherProvider;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_weatherProvider != null)
                {
                }

                _weatherProvider = value;
                if (_weatherProvider != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _translation_provider_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer translation_provider_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _translation_provider_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_translation_provider_lbl != null)
                {
                }

                _translation_provider_lbl = value;
                if (_translation_provider_lbl != null)
                {
                }
            }
        }

        private ComboBox _translationProvider;

        internal ComboBox translationProvider
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _translationProvider;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_translationProvider != null)
                {
                }

                _translationProvider = value;
                if (_translationProvider != null)
                {
                }
            }
        }

        private CheckBox _enableWeather;

        internal CheckBox enableWeather
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _enableWeather;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_enableWeather != null)
                {
                    _enableWeather.CheckedChanged -= enableWeather_CheckedChanged;
                }

                _enableWeather = value;
                if (_enableWeather != null)
                {
                    _enableWeather.CheckedChanged += enableWeather_CheckedChanged;
                }
            }
        }

        private CheckBox _enableTranslation;

        internal CheckBox enableTranslation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _enableTranslation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_enableTranslation != null)
                {
                    _enableTranslation.CheckedChanged -= enableTranlation_CheckedChanged;
                }

                _enableTranslation = value;
                if (_enableTranslation != null)
                {
                    _enableTranslation.CheckedChanged += enableTranlation_CheckedChanged;
                }
            }
        }

        private BlueActivity.ColorWithAlpha _ColorWithAlpha1;

        internal BlueActivity.ColorWithAlpha ColorWithAlpha1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ColorWithAlpha1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ColorWithAlpha1 != null)
                {
                }

                _ColorWithAlpha1 = value;
                if (_ColorWithAlpha1 != null)
                {
                }
            }
        }
    }
}