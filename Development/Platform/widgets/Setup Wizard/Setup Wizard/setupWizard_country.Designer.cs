using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ConstructionSiteLogistics.Setup.Gui2
{
    [DesignerGenerated()]
    public partial class setupWizard_country : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(setupWizard_country));
            _chooseCountry = new ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer();
            _show_all_lang = new CheckBox();
            _show_all_lang.CheckedChanged += new EventHandler(show_all_lang_CheckedChanged);
            _ListBox1 = new ListBox();
            _ListBox1.SelectedIndexChanged += new EventHandler(ListBox1_SelectedIndexChanged);
            _PictureBox1 = new PictureBox();
            _ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
            _selectionOkpic = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_selectionOkpic).BeginInit();
            SuspendLayout();
            // 
            // chooseCountry
            // 
            _chooseCountry.AutoSize = true;
            _chooseCountry.BackColor = Color.Transparent;
            _chooseCountry.Font = new Font("Trajan Pro", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _chooseCountry.ForeColor = Color.Black;
            _chooseCountry.Location = new Point(451, 408);
            _chooseCountry.Margin = new Padding(4, 0, 4, 0);
            _chooseCountry.Name = "_chooseCountry";
            _chooseCountry.Size = new Size(327, 23);
            _chooseCountry.TabIndex = 11;
            _chooseCountry.Text = "Choose the Country you're in";
            // 
            // show_all_lang
            // 
            _show_all_lang.AutoSize = true;
            _show_all_lang.BackColor = Color.Transparent;
            _show_all_lang.Font = new Font("Trajan Pro", 8.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _show_all_lang.ForeColor = Color.Black;
            _show_all_lang.Location = new Point(585, 635);
            _show_all_lang.Margin = new Padding(4, 5, 4, 5);
            _show_all_lang.Name = "_show_all_lang";
            _show_all_lang.Size = new Size(119, 24);
            _show_all_lang.TabIndex = 4;
            _show_all_lang.Text = "Show all";
            _show_all_lang.UseVisualStyleBackColor = false;
            // 
            // ListBox1
            // 
            _ListBox1.BackColor = Color.WhiteSmoke;
            _ListBox1.BorderStyle = BorderStyle.FixedSingle;
            _ListBox1.Font = new Font("Arial", 8.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _ListBox1.FormattingEnabled = true;
            _ListBox1.ItemHeight = 18;
            _ListBox1.Location = new Point(585, 443);
            _ListBox1.Margin = new Padding(4, 5, 4, 5);
            _ListBox1.Name = "_ListBox1";
            _ListBox1.Size = new Size(380, 182);
            _ListBox1.TabIndex = 3;
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            _PictureBox1.Location = new Point(455, 64);
            _PictureBox1.Margin = new Padding(4, 5, 4, 5);
            _PictureBox1.Name = "_PictureBox1";
            _PictureBox1.Size = new Size(634, 332);
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
            // selectionOkpic
            // 
            _selectionOkpic.Image = (Image)resources.GetObject("selectionOkpic.Image");
            _selectionOkpic.Location = new Point(972, 585);
            _selectionOkpic.Name = "_selectionOkpic";
            _selectionOkpic.Size = new Size(40, 40);
            _selectionOkpic.SizeMode = PictureBoxSizeMode.StretchImage;
            _selectionOkpic.TabIndex = 12;
            _selectionOkpic.TabStop = false;
            _selectionOkpic.Visible = false;
            // 
            // setupWizard_country
            // 
            AutoScaleDimensions = new SizeF(9.0F, 20.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1600, 742);
            ControlBox = false;
            Controls.Add(_selectionOkpic);
            Controls.Add(_chooseCountry);
            Controls.Add(_PictureBox1);
            Controls.Add(_ListBox1);
            Controls.Add(_show_all_lang);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "setupWizard_country";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.DarkGray;
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)_selectionOkpic).EndInit();
            VisibleChanged += new EventHandler(setupWizard_1_VisibleChanged);
            Load += new EventHandler(setupWizard_0_frm_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private CheckBox _show_all_lang;

        internal CheckBox show_all_lang
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _show_all_lang;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_show_all_lang != null)
                {
                    _show_all_lang.CheckedChanged -= show_all_lang_CheckedChanged;
                }

                _show_all_lang = value;
                if (_show_all_lang != null)
                {
                    _show_all_lang.CheckedChanged += show_all_lang_CheckedChanged;
                }
            }
        }

        private ListBox _ListBox1;

        internal ListBox ListBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ListBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ListBox1 != null)
                {
                    _ListBox1.SelectedIndexChanged -= ListBox1_SelectedIndexChanged;
                }

                _ListBox1 = value;
                if (_ListBox1 != null)
                {
                    _ListBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
                }
            }
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

        private Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer _chooseCountry;

        internal Global.ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer chooseCountry
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chooseCountry;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chooseCountry != null)
                {
                }

                _chooseCountry = value;
                if (_chooseCountry != null)
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

        private PictureBox _selectionOkpic;

        internal PictureBox selectionOkpic
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _selectionOkpic;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_selectionOkpic != null)
                {
                }

                _selectionOkpic = value;
                if (_selectionOkpic != null)
                {
                }
            }
        }
    }
}