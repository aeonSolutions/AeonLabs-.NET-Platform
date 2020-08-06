using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.AddOn.Meteo
{
    [DesignerGenerated()]
    public partial class meteo_frm : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(meteo_frm));
            _weather_pic = new PictureBox();
            _city_txt = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _site_combo = new ComboBox();
            _site_combo.SelectedIndexChanged += new EventHandler(site_combo_SelectedIndexChanged);
            _select_location_lbl = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _descricao_txt = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _meteo_txt = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _PictureBoxDoubleBuffer1 = new ConstructionSiteLogistics.Gui.Forms.Core.PictureBoxDoubleBuffer();
            _AlphaGradientPanel1 = new BlueActivity.AlphaGradientPanel();
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            _LabelDoubleBuffer1 = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _LabelDoubleBuffer2 = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _Label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)_weather_pic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxDoubleBuffer1).BeginInit();
            _AlphaGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // weather_pic
            // 
            _weather_pic.Image = (Image)resources.GetObject("weather_pic.Image");
            _weather_pic.InitialImage = (Image)resources.GetObject("weather_pic.InitialImage");
            _weather_pic.Location = new Point(740, 768);
            _weather_pic.Margin = new Padding(4, 5, 4, 5);
            _weather_pic.Name = "_weather_pic";
            _weather_pic.Size = new Size(116, 116);
            _weather_pic.SizeMode = PictureBoxSizeMode.StretchImage;
            _weather_pic.TabIndex = 1;
            _weather_pic.TabStop = false;
            // 
            // city_txt
            // 
            _city_txt.AutoSize = true;
            _city_txt.BackColor = Color.Maroon;
            _city_txt.Font = new Font("Verdana", 48.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _city_txt.ForeColor = Color.White;
            _city_txt.Location = new Point(341, 768);
            _city_txt.Margin = new Padding(4, 0, 4, 0);
            _city_txt.Name = "_city_txt";
            _city_txt.Size = new Size(379, 116);
            _city_txt.TabIndex = 2;
            _city_txt.Text = "Cidade";
            // 
            // site_combo
            // 
            _site_combo.BackColor = SystemColors.ActiveBorder;
            _site_combo.DropDownStyle = ComboBoxStyle.Simple;
            _site_combo.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _site_combo.FormattingEnabled = true;
            _site_combo.Location = new Point(18, 81);
            _site_combo.Margin = new Padding(4, 5, 4, 5);
            _site_combo.Name = "_site_combo";
            _site_combo.Size = new Size(612, 441);
            _site_combo.TabIndex = 3;
            // 
            // select_location_lbl
            // 
            _select_location_lbl.AutoSize = true;
            _select_location_lbl.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _select_location_lbl.ForeColor = Color.White;
            _select_location_lbl.Location = new Point(27, 36);
            _select_location_lbl.Margin = new Padding(4, 0, 4, 0);
            _select_location_lbl.Name = "_select_location_lbl";
            _select_location_lbl.Size = new Size(327, 44);
            _select_location_lbl.TabIndex = 4;
            _select_location_lbl.Text = "Another Location";
            // 
            // descricao_txt
            // 
            _descricao_txt.AutoSize = true;
            _descricao_txt.BackColor = Color.Maroon;
            _descricao_txt.Font = new Font("Verdana", 12.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _descricao_txt.ForeColor = Color.White;
            _descricao_txt.Location = new Point(341, 905);
            _descricao_txt.Margin = new Padding(4, 0, 4, 0);
            _descricao_txt.Name = "_descricao_txt";
            _descricao_txt.Size = new Size(40, 29);
            _descricao_txt.TabIndex = 5;
            _descricao_txt.Text = "...";
            // 
            // meteo_txt
            // 
            _meteo_txt.AutoSize = true;
            _meteo_txt.BackColor = Color.Maroon;
            _meteo_txt.Font = new Font("Verdana", 14.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _meteo_txt.ForeColor = Color.White;
            _meteo_txt.Location = new Point(31, 640);
            _meteo_txt.Margin = new Padding(4, 0, 4, 0);
            _meteo_txt.Name = "_meteo_txt";
            _meteo_txt.Size = new Size(371, 34);
            _meteo_txt.TabIndex = 6;
            _meteo_txt.Text = "Aguarde um momento....";
            // 
            // PictureBoxDoubleBuffer1
            // 
            _PictureBoxDoubleBuffer1.Dock = DockStyle.Fill;
            _PictureBoxDoubleBuffer1.Image = (Image)resources.GetObject("PictureBoxDoubleBuffer1.Image");
            _PictureBoxDoubleBuffer1.Location = new Point(0, 0);
            _PictureBoxDoubleBuffer1.Name = "_PictureBoxDoubleBuffer1";
            _PictureBoxDoubleBuffer1.Size = new Size(1850, 1166);
            _PictureBoxDoubleBuffer1.TabIndex = 338;
            _PictureBoxDoubleBuffer1.TabStop = false;
            // 
            // AlphaGradientPanel1
            // 
            _AlphaGradientPanel1.BackColor = Color.Transparent;
            _AlphaGradientPanel1.Border = true;
            _AlphaGradientPanel1.BorderColor = SystemColors.ActiveBorder;
            _AlphaGradientPanel1.Colors.Add(_ColorWithAlpha1);
            _AlphaGradientPanel1.ContentPadding = new Padding(0);
            _AlphaGradientPanel1.Controls.Add(_Label1);
            _AlphaGradientPanel1.Controls.Add(_LabelDoubleBuffer2);
            _AlphaGradientPanel1.Controls.Add(_site_combo);
            _AlphaGradientPanel1.Controls.Add(_select_location_lbl);
            _AlphaGradientPanel1.Controls.Add(_meteo_txt);
            _AlphaGradientPanel1.CornerRadius = 50;
            _AlphaGradientPanel1.Corners = (BlueActivity.Corner)(BlueActivity.Corner.TopLeft | BlueActivity.Corner.BottomLeft);
            _AlphaGradientPanel1.Dock = DockStyle.Right;
            _AlphaGradientPanel1.Gradient = false;
            _AlphaGradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            _AlphaGradientPanel1.GradientOffset = 1.0F;
            _AlphaGradientPanel1.GradientSize = new Size(0, 0);
            _AlphaGradientPanel1.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            _AlphaGradientPanel1.Grayscale = false;
            _AlphaGradientPanel1.Image = null;
            _AlphaGradientPanel1.ImageAlpha = 75;
            _AlphaGradientPanel1.ImagePadding = new Padding(5);
            _AlphaGradientPanel1.ImagePosition = BlueActivity.ImagePosition.BottomRight;
            _AlphaGradientPanel1.ImageSize = new Size(48, 48);
            _AlphaGradientPanel1.Location = new Point(1207, 0);
            _AlphaGradientPanel1.Name = "_AlphaGradientPanel1";
            _AlphaGradientPanel1.Rounded = true;
            _AlphaGradientPanel1.Size = new Size(643, 1166);
            _AlphaGradientPanel1.TabIndex = 339;
            // 
            // ColorWithAlpha1
            // 
            _ColorWithAlpha1.Alpha = 80;
            _ColorWithAlpha1.Color = Color.Black;
            _ColorWithAlpha1.Parent = _AlphaGradientPanel1;
            // 
            // LabelDoubleBuffer1
            // 
            _LabelDoubleBuffer1.AutoSize = true;
            _LabelDoubleBuffer1.BackColor = Color.Maroon;
            _LabelDoubleBuffer1.Font = new Font("Arial Rounded MT Bold", 72.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _LabelDoubleBuffer1.ForeColor = Color.White;
            _LabelDoubleBuffer1.Location = new Point(21, 768);
            _LabelDoubleBuffer1.Name = "_LabelDoubleBuffer1";
            _LabelDoubleBuffer1.Size = new Size(297, 166);
            _LabelDoubleBuffer1.TabIndex = 340;
            _LabelDoubleBuffer1.Text = "16º";
            // 
            // LabelDoubleBuffer2
            // 
            _LabelDoubleBuffer2.AutoSize = true;
            _LabelDoubleBuffer2.Font = new Font("Microsoft Sans Serif", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _LabelDoubleBuffer2.ForeColor = Color.White;
            _LabelDoubleBuffer2.Location = new Point(11, 580);
            _LabelDoubleBuffer2.Name = "_LabelDoubleBuffer2";
            _LabelDoubleBuffer2.Size = new Size(273, 40);
            _LabelDoubleBuffer2.TabIndex = 7;
            _LabelDoubleBuffer2.Text = "Weather Details";
            // 
            // Label1
            // 
            _Label1.BackColor = Color.White;
            _Label1.Location = new Point(14, 557);
            _Label1.Name = "_Label1";
            _Label1.Size = new Size(616, 4);
            _Label1.TabIndex = 8;
            // 
            // meteo_frm
            // 
            AutoScaleDimensions = new SizeF(9.0F, 20.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1850, 1166);
            ControlBox = false;
            Controls.Add(_LabelDoubleBuffer1);
            Controls.Add(_city_txt);
            Controls.Add(_weather_pic);
            Controls.Add(_descricao_txt);
            Controls.Add(_AlphaGradientPanel1);
            Controls.Add(_PictureBoxDoubleBuffer1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "meteo_frm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Informação Meteorologica";
            TransparencyKey = SystemColors.Control;
            ((System.ComponentModel.ISupportInitialize)_weather_pic).EndInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxDoubleBuffer1).EndInit();
            _AlphaGradientPanel1.ResumeLayout(false);
            _AlphaGradientPanel1.PerformLayout();
            Load += new EventHandler(meteo_frm_Load);
            Shown += new EventHandler(meteo_frm_show);
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox _weather_pic;

        internal PictureBox weather_pic
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _weather_pic;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_weather_pic != null)
                {
                }

                _weather_pic = value;
                if (_weather_pic != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _city_txt;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer city_txt
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _city_txt;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_city_txt != null)
                {
                }

                _city_txt = value;
                if (_city_txt != null)
                {
                }
            }
        }

        private ComboBox _site_combo;

        internal ComboBox site_combo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _site_combo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_site_combo != null)
                {
                    _site_combo.SelectedIndexChanged -= site_combo_SelectedIndexChanged;
                }

                _site_combo = value;
                if (_site_combo != null)
                {
                    _site_combo.SelectedIndexChanged += site_combo_SelectedIndexChanged;
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _select_location_lbl;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer select_location_lbl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _select_location_lbl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_select_location_lbl != null)
                {
                }

                _select_location_lbl = value;
                if (_select_location_lbl != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _descricao_txt;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer descricao_txt
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _descricao_txt;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_descricao_txt != null)
                {
                }

                _descricao_txt = value;
                if (_descricao_txt != null)
                {
                }
            }
        }

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _meteo_txt;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer meteo_txt
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _meteo_txt;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_meteo_txt != null)
                {
                }

                _meteo_txt = value;
                if (_meteo_txt != null)
                {
                }
            }
        }

        private Gui.Forms.Core.PictureBoxDoubleBuffer _PictureBoxDoubleBuffer1;

        internal Gui.Forms.Core.PictureBoxDoubleBuffer PictureBoxDoubleBuffer1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBoxDoubleBuffer1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBoxDoubleBuffer1 != null)
                {
                }

                _PictureBoxDoubleBuffer1 = value;
                if (_PictureBoxDoubleBuffer1 != null)
                {
                }
            }
        }

        private BlueActivity.AlphaGradientPanel _AlphaGradientPanel1;

        internal BlueActivity.AlphaGradientPanel AlphaGradientPanel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AlphaGradientPanel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AlphaGradientPanel1 != null)
                {
                }

                _AlphaGradientPanel1 = value;
                if (_AlphaGradientPanel1 != null)
                {
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

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private Gui.Forms.Core.LabelDoubleBuffer _LabelDoubleBuffer2;

        internal Gui.Forms.Core.LabelDoubleBuffer LabelDoubleBuffer2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelDoubleBuffer2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelDoubleBuffer2 != null)
                {
                }

                _LabelDoubleBuffer2 = value;
                if (_LabelDoubleBuffer2 != null)
                {
                }
            }
        }

        private Gui.Forms.Core.LabelDoubleBuffer _LabelDoubleBuffer1;

        internal Gui.Forms.Core.LabelDoubleBuffer LabelDoubleBuffer1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelDoubleBuffer1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelDoubleBuffer1 != null)
                {
                }

                _LabelDoubleBuffer1 = value;
                if (_LabelDoubleBuffer1 != null)
                {
                }
            }
        }
    }
}