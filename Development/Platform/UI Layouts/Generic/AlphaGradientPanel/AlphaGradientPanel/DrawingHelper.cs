using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.CompilerServices;

namespace BlueActivity
{
    public class DrawingHelper
    {
        public static GraphicsPath RoundedRect(RectangleF rect, int cornerradius = 5, Corner roundedcorners = Corner.All)
        {
            var p = new GraphicsPath();
            float x = rect.X;
            float y = rect.Y;
            float w = rect.Width;
            float h = rect.Height;
            int r = cornerradius;
            p.StartFigure();
            // top left arc
            if (Conversions.ToBoolean(roundedcorners & Corner.TopLeft))
            {
                p.AddArc(new RectangleF(x, y, 2 * r, 2 * r), 180, 90);
            }
            else
            {
                p.AddLine(new PointF(x, y + r), new PointF(x, y));
                p.AddLine(new PointF(x, y), new PointF(x + r, y));
            }

            // top line
            p.AddLine(new PointF(x + r, y), new PointF(x + w - r, y));

            // top right arc
            if (Conversions.ToBoolean(roundedcorners & Corner.TopRight))
            {
                p.AddArc(new RectangleF(x + w - 2 * r, y, 2 * r, 2 * r), 270, 90);
            }
            else
            {
                p.AddLine(new PointF(x + w - r, y), new PointF(x + w, y));
                p.AddLine(new PointF(x + w, y), new PointF(x + w, y + r));
            }

            // right line
            p.AddLine(new PointF(x + w, y + r), new PointF(x + w, y + h - r));

            // bottom right arc
            if (Conversions.ToBoolean(roundedcorners & Corner.BottomRight))
            {
                p.AddArc(new RectangleF(x + w - 2 * r, y + h - 2 * r, 2 * r, 2 * r), 0, 90);
            }
            else
            {
                p.AddLine(new PointF(x + w, y + h - r), new PointF(x + w, y + h));
                p.AddLine(new PointF(x + w, y + h), new PointF(x + w - r, y + h));
            }

            // bottom line
            p.AddLine(new PointF(x + w - r, y + h), new PointF(x + r, y + h));

            // bottom left arc
            if (Conversions.ToBoolean(roundedcorners & Corner.BottomLeft))
            {
                p.AddArc(new RectangleF(x, y + h - 2 * r, 2 * r, 2 * r), 90, 90);
            }
            else
            {
                p.AddLine(new PointF(x + r, y + h), new PointF(x, y + h));
                p.AddLine(new PointF(x, y + h), new PointF(x, y + h - r));
            }

            // left line
            p.AddLine(new PointF(x, y + h - r), new PointF(x, y + r));

            // close figure...
            p.CloseFigure();
            return p;
        }

        public static GraphicsPath RoundedRect(Point location, Size size, int cornerradius = 5, Corner roundedcorners = Corner.All)
        {
            return RoundedRect(new RectangleF(location.X, location.Y, size.Width, size.Height), cornerradius, roundedcorners);
        }

        public static GraphicsPath RoundedRect(int x, int y, int width, int height, int cornerradius = 5, Corner roundedcorners = Corner.All)
        {
            return RoundedRect(new RectangleF(x, y, width, height), cornerradius, roundedcorners);
        }

        public static GraphicsPath RoundedRect(Rectangle rect, int cornerradius = 5, Corner roundedcorners = Corner.All)
        {
            return RoundedRect(new RectangleF(rect.Left, rect.Top, rect.Width, rect.Height), cornerradius, roundedcorners);
        }

        public static GraphicsPath RoundedRect(PointF location, SizeF size, int cornerradius = 5, Corner roundedcorners = Corner.All)
        {
            return RoundedRect(new RectangleF(location.X, location.Y, size.Width, size.Height), cornerradius, roundedcorners);
        }
    }

    [Flags()]
    public enum Corner
    {
        None = 0,
        TopLeft = 1,
        TopRight = 2,
        BottomLeft = 4,
        BottomRight = 8,
        All = TopLeft | TopRight | BottomLeft | BottomRight,
        TLBR = TopLeft | BottomRight,
        TRBL = TopRight | BottomLeft,
        TRBR = TopRight | BottomRight,
        TLBL = TopLeft | BottomLeft,
        TRTL = TopRight | TopLeft,
        BRBL = BottomRight | BottomLeft,
        AllxBottomRight = TopLeft | TopRight | BottomLeft
    }

    [Flags()]
    public enum ImagePosition
    {
        Center,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}