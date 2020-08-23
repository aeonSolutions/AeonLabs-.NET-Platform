using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CheckComboBox
{
    public class CheckedComboBox : ComboBox
    {
        internal new class Dropdown : Form
        {
            internal class CCBoxEventArgs : EventArgs
            {
                private bool assignVals;

                public bool AssignValues
                {
                    get
                    {
                        return assignVals;
                    }

                    set
                    {
                        assignVals = value;
                    }
                }

                private EventArgs e;

                public EventArgs EventArgs
                {
                    get
                    {
                        return e;
                    }

                    set
                    {
                        e = value;
                    }
                }

                public CCBoxEventArgs(EventArgs e, bool assignValues) : base()
                {
                    this.e = e;
                    AssignValues = assignValues;
                }
            }

            internal class CustomCheckedListBox : CheckedListBox
            {
                private int curSelIndex = -1;

                public CustomCheckedListBox() : base()
                {
                    SelectionMode = SelectionMode.One;
                    HorizontalScrollbar = true;
                }

                protected override void OnKeyDown(KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        ((Dropdown)Parent).OnDeactivate(new CCBoxEventArgs(null, true));
                        e.Handled = true;
                    }
                    else if (e.KeyCode == Keys.Escape)
                    {
                        ((Dropdown)Parent).OnDeactivate(new CCBoxEventArgs(null, false));
                        e.Handled = true;
                    }
                    else if (e.KeyCode == Keys.Delete)
                    {
                        for (int i = 0, loopTo = Items.Count - 1; i <= loopTo; i++)
                            SetItemChecked(i, e.Shift);
                        e.Handled = true;
                    }

                    base.OnKeyDown(e);
                }

                protected override void OnMouseMove(MouseEventArgs e)
                {
                    base.OnMouseMove(e);
                    int index = IndexFromPoint(e.Location);
                    Debug.WriteLine("Mouse over item: " + (index >= 0 ? GetItemText(Items[index]) : "None"));
                    if (index >= 0 && index != curSelIndex)
                    {
                        curSelIndex = index;
                        SetSelected(index, true);
                    }
                }
            }

            private CheckedComboBox ccbParent;
            private string oldStrValue = "";

            public bool ValueChanged
            {
                get
                {
                    string newStrValue = ccbParent.Text;
                    if (oldStrValue.Length > 0 && newStrValue.Length > 0)
                    {
                        return oldStrValue.CompareTo(newStrValue) != 0;
                    }
                    else
                    {
                        return oldStrValue.Length != newStrValue.Length;
                    }
                }
            }

            private bool[] checkedStateArr;
            private bool dropdownClosed = true;
            private CustomCheckedListBox cclb;

            public CustomCheckedListBox List
            {
                get
                {
                    return cclb;
                }

                set
                {
                    cclb = value;
                }
            }

            public Dropdown(CheckedComboBox _ccbParent)
            {
                ccbParent = _ccbParent;
                SuspendLayout();
                InitializeComponent();
                ResumeLayout();
                ShowInTaskbar = false;
                cclb.ItemCheck += new ItemCheckEventHandler(cclb_ItemCheck);
            }

            private void InitializeComponent()
            {
                cclb = new CustomCheckedListBox();
                SuspendLayout();
                cclb.BorderStyle = BorderStyle.None;
                cclb.Dock = DockStyle.Fill;
                cclb.FormattingEnabled = true;
                cclb.Location = new Point(0, 0);
                cclb.Name = "_cclb";
                cclb.Size = new Size(47, 15);
                cclb.TabIndex = 0;
                AutoScaleDimensions = new SizeF(6.0F, 13.0F);
                AutoScaleMode = AutoScaleMode.Font;
                BackColor = Color.White;
                ClientSize = new Size(47, 16);
                ControlBox = false;
                Controls.Add(cclb);
                ForeColor = Color.Black;
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
                MinimizeBox = false;
                Name = "ccbParent";
                StartPosition = FormStartPosition.Manual;
                ResumeLayout(false);
            }

            public string GetCheckedItemsStringValue()
            {
                var sb = new StringBuilder("");
                for (int i = 0, loopTo = cclb.CheckedItems.Count - 1; i <= loopTo; i++)
                    sb.Append(cclb.GetItemText(cclb.CheckedItems[i])).Append(ccbParent.ValueSeparator);
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - ccbParent.ValueSeparator.Length, ccbParent.ValueSeparator.Length);
                }

                return sb.ToString();
            }

            public void CloseDropdown(bool enactChanges)
            {
                if (dropdownClosed)
                {
                    return;
                }

                Debug.WriteLine("CloseDropdown");
                if (enactChanges)
                {
                    ccbParent.SelectedIndex = -1;
                    ccbParent.Text = GetCheckedItemsStringValue();
                }
                else
                {
                    for (int i = 0, loopTo = cclb.Items.Count - 1; i <= loopTo; i++)
                        cclb.SetItemChecked(i, checkedStateArr[i]);
                }

                dropdownClosed = true;
                ccbParent.Focus();
                Hide();
                ccbParent.OnDropDownClosed(new CCBoxEventArgs(null, false));
            }

            protected override void OnActivated(EventArgs e)
            {
                Debug.WriteLine("OnActivated");
                base.OnActivated(e);
                dropdownClosed = false;
                oldStrValue = ccbParent.Text;
                checkedStateArr = new bool[cclb.Items.Count];
                for (int i = 0, loopTo = cclb.Items.Count - 1; i <= loopTo; i++)
                    checkedStateArr[i] = cclb.GetItemChecked(i);
            }

            protected override void OnDeactivate(EventArgs e)
            {
                Debug.WriteLine("OnDeactivate");
                base.OnDeactivate(e);
                CCBoxEventArgs ce = e as CCBoxEventArgs;
                if (ce is object)
                {
                    CloseDropdown(ce.AssignValues);
                }
                else
                {
                    CloseDropdown(true);
                }
            }

            private void cclb_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                // RaiseEvent ccbParent.ItemCheck(sender, e)
            }
        }

        private System.ComponentModel.IContainer components = null;
        private Dropdown _dropdown;
        private string _valueSeparator;

        public string ValueSeparator
        {
            get
            {
                return _valueSeparator;
            }

            set
            {
                _valueSeparator = value;
            }
        }

        public bool CheckOnClick
        {
            get
            {
                return _dropdown.List.CheckOnClick;
            }

            set
            {
                _dropdown.List.CheckOnClick = value;
            }
        }

        public new string DisplayMember
        {
            get
            {
                return _dropdown.List.DisplayMember;
            }

            set
            {
                _dropdown.List.DisplayMember = value;
            }
        }

        public new CheckedListBox.ObjectCollection Items
        {
            get
            {
                return _dropdown.List.Items;
            }
        }

        public CheckedListBox.CheckedItemCollection CheckedItems
        {
            get
            {
                return _dropdown.List.CheckedItems;
            }
        }

        public CheckedListBox.CheckedIndexCollection CheckedIndices
        {
            get
            {
                return _dropdown.List.CheckedIndices;
            }
        }

        public bool ValueChanged
        {
            get
            {
                return _dropdown.ValueChanged;
            }
        }

        public event ItemCheckEventHandler ItemCheck;

        // Public Event ItemCheck(sender As Object, e As ItemCheckEventHandler)

        public CheckedComboBox() : base()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            ValueSeparator = ", ";
            DropDownHeight = 1;
            DropDownStyle = ComboBoxStyle.DropDown;
            _dropdown = new Dropdown(this);
            CheckOnClick = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components is object)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            DoDropDown();
        }

        private void DoDropDown()
        {
            if (!_dropdown.Visible)
            {
                var rect = RectangleToScreen(ClientRectangle);
                _dropdown.Location = new Point(rect.X, rect.Y + Size.Height);
                int count = _dropdown.List.Items.Count;
                if (count > MaxDropDownItems)
                {
                    count = MaxDropDownItems;
                }
                else if (count == 0)
                {
                    count = 1;
                }

                _dropdown.Size = new Size(Size.Width, _dropdown.List.ItemHeight * count + 2);
                _dropdown.Show(this);
            }
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            if (e is Dropdown.CCBoxEventArgs)
            {
                base.OnDropDownClosed(e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                OnDropDown(null);
            }

            e.Handled = !e.Alt && !(e.KeyCode == Keys.Tab) && !(e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Home || e.KeyCode == Keys.End);
            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
            base.OnKeyPress(e);
        }

        public bool GetItemChecked(int index)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", "value out of range");
            }
            else
            {
                return _dropdown.List.GetItemChecked(index);
            }
        }

        public void SetItemChecked(int index, bool isChecked)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", "value out of range");
            }
            else
            {
                _dropdown.List.SetItemChecked(index, isChecked);
                Text = _dropdown.GetCheckedItemsStringValue();
            }
        }

        public CheckState GetItemCheckState(int index)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", "value out of range");
            }
            else
            {
                return _dropdown.List.GetItemCheckState(index);
            }
        }

        public void SetItemCheckState(int index, CheckState stateCore)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("index", "value out of range");
            }
            else
            {
                _dropdown.List.SetItemCheckState(index, stateCore);
                Text = _dropdown.GetCheckedItemsStringValue();
            }
        }
    }
}