using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace BlueActivity
{
    [TypeConverter(typeof(ColorWithAlphaTypeConverter))]
    [DesignTimeVisible(false)]
    [ToolboxItem(false)]
    [Serializable()]
    public class ColorWithAlpha : Component
    {
        private Control ctlParent;

        [Browsable(false)]
        public Control Parent
        {
            get
            {
                return ctlParent;
            }

            set
            {
                ctlParent = value;
            }
        }

        public ColorWithAlpha() : base()
        {
            Invalidate();
        }

        public void Invalidate()
        {
            if (Parent is object)
            {
                Parent.Invalidate();
            }
        }

        private Color clColor = SystemColors.Control;
        private int iAlpha = 255;

        public Color Color
        {
            get
            {
                return clColor;
            }

            set
            {
                clColor = value;
                Invalidate();
            }
        }

        public int Alpha
        {
            get
            {
                return iAlpha;
            }

            set
            {
                iAlpha = value;
                Invalidate();
            }
        }
    }
}