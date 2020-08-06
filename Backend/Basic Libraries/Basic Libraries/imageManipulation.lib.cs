using System;
using System.Drawing;

namespace AeonLabs.BasicLibraries
{
    public static class imageManipulationLib
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public static Image cropImage(Image sourceImage, Point pos, Size panelSize, Size ClientSize)
        {
            double wRatio = sourceImage.Width / (double)ClientSize.Width;
            double hRatio = sourceImage.Height / (double)ClientSize.Height;
            var area = new Rectangle((int)(pos.X * wRatio), (int)(pos.Y * hRatio), (int)(panelSize.Width * wRatio), (int)(panelSize.Height * hRatio));
            var outPut = new Bitmap(panelSize.Width, panelSize.Height);
            var DescREctangle = new Rectangle(0, 0, outPut.Width, outPut.Height);
            var g = Graphics.FromImage(outPut);
            g.DrawImage(sourceImage, DescREctangle, area, GraphicsUnit.Pixel);
            g.Save();
            g.Dispose();
            return outPut;
        }

        public static Bitmap ResizeImage(Image SourceImage, int TargetWidth, int TargetHeight)
        {
            var bmSource = new Bitmap(SourceImage);
            return ResizeImage(bmSource, TargetWidth, TargetHeight);
        }

        public static Bitmap ResizeImage(Bitmap bmSource, int TargetWidth, int TargetHeight)
        {
            var bmDest = new Bitmap(TargetWidth, TargetHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            double nSourceAspectRatio = bmSource.Width / (double)bmSource.Height;
            double nDestAspectRatio = bmDest.Width / (double)bmDest.Height;
            int NewX = 0;
            int NewY = 0;
            int NewWidth = bmDest.Width;
            int NewHeight = bmDest.Height;
            if (nDestAspectRatio == nSourceAspectRatio)
            {
            }
            // same ratio
            else if (nDestAspectRatio > nSourceAspectRatio)
            {
                // Source is taller
                NewWidth = Convert.ToInt32(Math.Floor(nSourceAspectRatio * NewHeight));
                NewX = Convert.ToInt32(Math.Floor((bmDest.Width - NewWidth) / (double)2));
            }
            else
            {
                // Source is wider
                NewHeight = Convert.ToInt32(Math.Floor(1 / nSourceAspectRatio * NewWidth));
                NewY = Convert.ToInt32(Math.Floor((bmDest.Height - NewHeight) / (double)2));
            }

            using (var grDest = Graphics.FromImage(bmDest))
            {
                grDest.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                grDest.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                grDest.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                grDest.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                grDest.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                grDest.DrawImage(bmSource, NewX, NewY, NewWidth, NewHeight);
            }

            return bmDest;
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}