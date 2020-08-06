using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BlueActivity
{
    public class AlphaGradientPanel : Panel
    {
        public AlphaGradientPanel()
        {
            clGradient = new ColorWithAlphaCollection(this);

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            this.FontChanged += AlphaGradientPanel_FontChanged;
            this.PaddingChanged += AlphaGradientPanel_PaddingChanged;
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            this.Paint += AlphaGradientPanel_Paint;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            BackColor = Color.Transparent;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private bool bRoundCorners = true;

        [Category("Borders")]
        public bool Rounded
        {
            get
            {
                return bRoundCorners;
            }

            set
            {
                bRoundCorners = value;
                Invalidate();
            }
        }

        private Corner eCorners = Corner.All;

        [Category("Borders")]
        public Corner Corners
        {
            get
            {
                return eCorners;
            }

            set
            {
                eCorners = value;
                Invalidate();
            }
        }

        private Color clBorder = SystemColors.ActiveBorder;

        [Category("Borders")]
        public Color BorderColor
        {
            get
            {
                return clBorder;
            }

            set
            {
                clBorder = value;
                Invalidate();
            }
        }

        private bool bGradient = true;

        [Category("Content")]
        public bool Gradient
        {
            get
            {
                return bGradient;
            }

            set
            {
                bGradient = value;
                Invalidate();
            }
        }

        private bool bBorder = true;

        [Category("Borders")]
        public bool Border
        {
            get
            {
                return bBorder;
            }

            set
            {
                bBorder = value;
                Invalidate();
            }
        }

        private int iCornerRadius = 20;

        [Category("Borders")]
        public int CornerRadius
        {
            get
            {
                return iCornerRadius;
            }

            set
            {
                iCornerRadius = value;
                Invalidate();
            }
        }

        private LinearGradientMode gmMode = LinearGradientMode.Vertical;

        [Category("Content")]
        public LinearGradientMode GradientMode
        {
            get
            {
                return gmMode;
            }

            set
            {
                gmMode = value;
                Invalidate();
            }
        }

        private Image imImage;

        [Category("Image")]
        public Image Image
        {
            get
            {
                return imImage;
            }

            set
            {
                imImage = value;
                Invalidate();
            }
        }

        private ImagePosition eImagePosition = ImagePosition.BottomRight;

        [Category("Image")]
        public ImagePosition ImagePosition
        {
            get
            {
                return eImagePosition;
            }

            set
            {
                eImagePosition = value;
                Invalidate();
            }
        }

        private Size szImageSize = new Size(48, 48);

        [Category("Image")]
        public Size ImageSize
        {
            get
            {
                return szImageSize;
            }

            set
            {
                szImageSize = value;
                Invalidate();
            }
        }

        private int iImageAlpha = 75;

        [Category("Image")]
        public int ImageAlpha
        {
            get
            {
                return iImageAlpha;
            }

            set
            {
                iImageAlpha = value;
                Invalidate();
            }
        }

        private Padding pdImage = new Padding(5);

        [Category("Image")]
        public Padding ImagePadding
        {
            get
            {
                return pdImage;
            }

            set
            {
                pdImage = value;
                Invalidate();
            }
        }

        private Padding pdContent = new Padding(0);

        [Category("Content")]
        public Padding ContentPadding
        {
            get
            {
                return pdContent;
            }

            set
            {
                pdContent = value;
                Invalidate();
            }
        }

        private bool bGrayscale = false;

        [Category("Image")]
        public bool Grayscale
        {
            get
            {
                return bGrayscale;
            }

            set
            {
                bGrayscale = value;
                Invalidate();
            }
        }

        private Size szGradient;

        [Category("Content")]
        public Size GradientSize
        {
            get
            {
                return szGradient;
            }

            set
            {
                szGradient = value;
                Invalidate();
            }
        }

        private WrapMode wmWrap = WrapMode.Tile;

        [Category("Content")]
        public WrapMode GradientWrapMode
        {
            get
            {
                return wmWrap;
            }

            set
            {
                wmWrap = value;
                Invalidate();
            }
        }

        private float snOffset = 1;

        [Category("Content")]
        public float GradientOffset
        {
            get
            {
                return snOffset;
            }

            set
            {
                snOffset = value;
                Invalidate();
            }
        }

        private ColorWithAlphaCollection clGradient;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Content")]
        public ColorWithAlphaCollection Colors
        {
            get
            {
                return clGradient;
            }
        }

        private void AlphaGradientPanel_FontChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void AlphaGradientPanel_PaddingChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void AlphaGradientPanel_Paint(object sender, PaintEventArgs e)
        {
            Brush brBrush;
            var rcClient = new Rectangle(ContentPadding.Left, ContentPadding.Top, Width - ContentPadding.Right - ContentPadding.Left, Height - ContentPadding.Bottom - ContentPadding.Top);
            if (Gradient)
            {
                Rectangle rcBrush;
                if (GradientSize != default)
                {
                    rcBrush = new Rectangle(0, 0, GradientSize.Width, GradientSize.Height);
                }
                else
                {
                    rcBrush = rcClient;
                }

                if (Colors.Count > 1)
                {
                    brBrush = new LinearGradientBrush(rcBrush, Color.White, Color.White, GradientMode);
                    {
                        var withBlock = (LinearGradientBrush)brBrush;
                        if (GradientWrapMode == WrapMode.Clamp)
                            GradientWrapMode = WrapMode.Tile;
                        withBlock.WrapMode = GradientWrapMode;
                        withBlock.SetSigmaBellShape(snOffset);
                        var cb = new ColorBlend(Colors.Count);
                        for (int i = 0, loopTo = Colors.Count - 1; i <= loopTo; i++)
                        {
                            cb.Positions[i] = 1.0F / (cb.Positions.Length - 1) * i;
                            cb.Colors[i] = Color.FromArgb(Colors[i].Alpha, Colors[i].Color.R, Colors[i].Color.G, Colors[i].Color.B);
                        }

                        withBlock.InterpolationColors = cb;
                    }
                }
                else
                {
                    brBrush = new SolidBrush(Color.Transparent);
                    e.Graphics.DrawString("[GRADIENT] Not enough color (at least 2 needed)", SystemFonts.DialogFont, Brushes.Black, 5, 5);
                }
            }
            else if (Colors.Count > 0)
            {
                var cwa = Colors[0];
                brBrush = new SolidBrush(Color.FromArgb(cwa.Alpha, cwa.Color.R, cwa.Color.G, cwa.Color.B));
            }
            else
            {
                brBrush = new SolidBrush(Color.Transparent);
                e.Graphics.DrawString("[SOLID] Not enough color (at least 1 needed)", SystemFonts.DialogFont, Brushes.Black, 5, 5);
            }

            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            var rcBorder = new Rectangle(rcClient.X, rcClient.Y, rcClient.Width - 1, rcClient.Height - 1);
            var rcContent = rcClient;
            if (Rounded)
            {
                e.Graphics.FillPath(brBrush, DrawingHelper.RoundedRect(rcContent, iCornerRadius, Corners));
                if (Border == true)
                {
                    e.Graphics.DrawPath(new Pen(BorderColor), DrawingHelper.RoundedRect(rcBorder, iCornerRadius, Corners));
                }
            }
            else
            {
                e.Graphics.FillRectangle(brBrush, rcContent);
                if (Border == true)
                {
                    e.Graphics.DrawRectangle(new Pen(BorderColor), rcBorder);
                }
            }


            // Dim brShadow As New SolidBrush(Color.FromArgb(85, 0, 0, 0))

            // e.Graphics.DrawString("This is a title", Font, brShadow, ContentPadding.Left + 2, ContentPadding.Right + 2)
            // e.Graphics.DrawString("This is a title", Font, Brushes.White, ContentPadding.Left, ContentPadding.Right)

            if (Image is object)
            {
                Bitmap btBitmap = (Bitmap)Image;
                var arArray = new[] { new float[] { 1, 0, 0, 0, 0 }, new float[] { 0, 1, 0, 0, 0 }, new float[] { 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, (float)(ImageAlpha / (double)100), 0 }, new float[] { 0, 0, 0, 0, 1 } };
                ColorMatrix clrMatrix;
                if (Grayscale)
                {
                    clrMatrix = new ColorMatrix(new float[][] { new float[] { 0.299F, 0.299F, 0.299F, 0, 0 }, new float[] { 0.587F, 0.587F, 0.587F, 0, 0 }, new float[] { 0.114F, 0.114F, 0.114F, 0, 0 }, new float[] { 0, 0, 0, (float)(ImageAlpha / (double)100), 0 }, new float[] { 0, 0, 0, 0, 1 } });




                }
                else
                {
                    clrMatrix = new ColorMatrix(new float[][] { new float[] { 1, 0, 0, 0, 0 }, new float[] { 0, 1, 0, 0, 0 }, new float[] { 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, (float)(ImageAlpha / (double)100), 0 }, new float[] { 0, 0, 0, 0, 1 } });




                }

                var imgAttributes = new ImageAttributes();
                imgAttributes.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                var rcImage = default(Rectangle);
                switch (ImagePosition)
                {
                    case ImagePosition.TopLeft:
                        {
                            rcImage = new Rectangle(ContentPadding.Left + ImagePadding.Left, ImagePadding.Top + ContentPadding.Top, ImageSize.Width, ImageSize.Height);
                            break;
                        }

                    case ImagePosition.BottomRight:
                        {
                            rcImage = new Rectangle(ContentPadding.Right + rcContent.Width - ImageSize.Width - ImagePadding.Right, ContentPadding.Top + rcContent.Height - ImageSize.Height - ImagePadding.Bottom, ImageSize.Width, ImageSize.Height);
                            break;
                        }

                    case ImagePosition.TopRight:
                        {
                            rcImage = new Rectangle(ContentPadding.Right + rcContent.Width - ImageSize.Width - ImagePadding.Right, ImagePadding.Top + ContentPadding.Top, ImageSize.Width, ImageSize.Height);
                            break;
                        }

                    case ImagePosition.BottomLeft:
                        {
                            rcImage = new Rectangle(ContentPadding.Right + ImagePadding.Left, rcContent.Height - ImageSize.Height - ImagePadding.Bottom + ContentPadding.Top, ImageSize.Width, ImageSize.Height);
                            break;
                        }

                    case ImagePosition.Center:
                        {
                            rcImage = new Rectangle((int)((rcContent.Width - ImageSize.Width) / (double)2 + ContentPadding.Left), (int)((rcContent.Height - ImageSize.Height) / (double)2 + ContentPadding.Top), ImageSize.Width, ImageSize.Height);
                            break;
                        }
                }

                e.Graphics.DrawImage(btBitmap, rcImage, 0, 0, btBitmap.Width, btBitmap.Height, GraphicsUnit.Pixel, imgAttributes);
            }
        }
    }
}