using System;
using System.Drawing;
using System.Windows.Forms;

namespace AeonLabs.Layouts.Dialogs
{
    public partial class messageBoxForm : FormCustomized
    {
        public messageBoxForm(global::System.String _message, global::System.String _title, MessageBoxButtons _buttons, MessageBoxIcon _icon, global::System.Int32 posx = -1, global::System.Int32 posy = -1, AeonLabs.Environment.Core.environmentVarsCore _state = default)
        {
            base.Load += messageBoxForm_Load;
            base.Shown += messageBoxForm_show;
            this.SizeChanged += AlignForms;
            this.Move += AlignForms;
            this.Layout += AlignForms;
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            // This call is required by the designer.
            this.SuspendLayout();

            InitializeComponent();
            this.ResumeLayout();

            msbox = new MessageBoxChild(_message, _title, _buttons, _icon, posx, posy);
        }

        private MessageBoxChild msbox;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 33554432;
                return cp;
            }
        }

        private void messageBoxForm_Load(global::System.Object sender, EventArgs e)
        {
            this.AddOwnedForm(msbox);
        }

        private void messageBoxForm_show(global::System.Object sender, EventArgs e)
        {
            this.DialogResult = msbox.ShowDialog();
        }

        private void AlignForms(global::System.Object sender, System.EventArgs e)
        {
            if (msbox is null)
            {
                return;
            }

            msbox.Location = this.PointToScreen(Point.Empty);
            msbox.Size = this.ClientSize;
            msbox.Invalidate();
        }

    }
}