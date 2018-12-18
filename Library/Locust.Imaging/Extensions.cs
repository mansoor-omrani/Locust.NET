using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Imaging
{
    public static class ImageHelper
    {
        private const int OrientationKey = 0x0112;
        private const int NotSpecified = 0;
        private const int NormalOrientation = 1;
        private const int MirrorHorizontal = 2;
        private const int UpsideDown = 3;
        private const int MirrorVertical = 4;
        private const int MirrorHorizontalAndRotateRight = 5;
        private const int RotateLeft = 6;
        private const int MirorHorizontalAndRotateLeft = 7;
        private const int RotateRight = 8;

        // https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
        // https://stackoverflow.com/questions/33310562/some-images-are-being-rotated-when-resized
        public static Bitmap ResizeImage(string path, decimal scale)
        {
            var rbytes = File.ReadAllBytes(path);

            using (var mr = new MemoryStream())
            {
                mr.Write(rbytes, 0, rbytes.Length);

                var image = Image.FromStream(mr);

                var width = (int)(image.Width * scale);
                var height = (int)(image.Height * scale);

                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);

                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.Default;
                    graphics.InterpolationMode = InterpolationMode.Default;
                    graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

                    if (image.PropertyIdList.Contains(OrientationKey))
                    {
                        var orientation = (int)image.GetPropertyItem(OrientationKey).Value[0];
                        switch (orientation)
                        {
                            case NotSpecified: // Assume it is good.
                            case NormalOrientation:
                                // No rotation required.
                                break;
                            case MirrorHorizontal:
                                destImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                break;
                            case UpsideDown:
                                destImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                break;
                            case MirrorVertical:
                                destImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                                break;
                            case MirrorHorizontalAndRotateRight:
                                destImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                                break;
                            case RotateLeft:
                                destImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                break;
                            case MirorHorizontalAndRotateLeft:
                                destImage.RotateFlip(RotateFlipType.Rotate270FlipX);
                                break;
                            case RotateRight:
                                destImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                break;
                            default:
                                throw new NotImplementedException("An orientation of " + orientation + " isn't implemented.");
                        }
                    }

                }

                return destImage;
            }
        }
        public static Bitmap ResizeImage(string path, int width, int height)
        {
            var rbytes = File.ReadAllBytes(path);

            using (var mr = new MemoryStream())
            {
                mr.Write(rbytes, 0, rbytes.Length);

                var image = Image.FromStream(mr);

                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);

                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.Default;
                    graphics.InterpolationMode = InterpolationMode.Default;
                    graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

                    if (image.PropertyIdList.Contains(OrientationKey))
                    {
                        var orientation = (int)image.GetPropertyItem(OrientationKey).Value[0];
                        switch (orientation)
                        {
                            case NotSpecified: // Assume it is good.
                            case NormalOrientation:
                                // No rotation required.
                                break;
                            case MirrorHorizontal:
                                destImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                break;
                            case UpsideDown:
                                destImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                break;
                            case MirrorVertical:
                                destImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                                break;
                            case MirrorHorizontalAndRotateRight:
                                destImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                                break;
                            case RotateLeft:
                                destImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                break;
                            case MirorHorizontalAndRotateLeft:
                                destImage.RotateFlip(RotateFlipType.Rotate270FlipX);
                                break;
                            case RotateRight:
                                destImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                break;
                            default:
                                throw new NotImplementedException("An orientation of " + orientation + " isn't implemented.");
                        }
                    }

                }

                return destImage;
            }
        }
        public static Bitmap ScaleXImage(string path, int width)
        {
            var rbytes = File.ReadAllBytes(path);

            using (var mr = new MemoryStream())
            {
                mr.Write(rbytes, 0, rbytes.Length);

                var image = Image.FromStream(mr, true, false);
                var scale = width * 1.0 / image.Width; // image.Width > width ? width * 1.0 / image.Width : image.Width * 1.0 / width;
                var height = (int)(image.Height * scale);
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);

                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.Default;
                    graphics.InterpolationMode = InterpolationMode.Default;
                    graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

                    if (image.PropertyIdList.Contains(OrientationKey))
                    {
                        var orientation = (int)image.GetPropertyItem(OrientationKey).Value[0];
                        switch (orientation)
                        {
                            case NotSpecified: // Assume it is good.
                            case NormalOrientation:
                                // No rotation required.
                                break;
                            case MirrorHorizontal:
                                destImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                break;
                            case UpsideDown:
                                destImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                break;
                            case MirrorVertical:
                                destImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                                break;
                            case MirrorHorizontalAndRotateRight:
                                destImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                                break;
                            case RotateLeft:
                                destImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                break;
                            case MirorHorizontalAndRotateLeft:
                                destImage.RotateFlip(RotateFlipType.Rotate270FlipX);
                                break;
                            case RotateRight:
                                destImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                break;
                            default:
                                throw new NotImplementedException("An orientation of " + orientation + " isn't implemented.");
                        }
                    }

                }

                return destImage;
            }
        }
        public static Bitmap ScaleYImage(string path, int height)
        {
            var rbytes = File.ReadAllBytes(path);

            using (var mr = new MemoryStream())
            {
                mr.Write(rbytes, 0, rbytes.Length);

                var image = Image.FromStream(mr, true, false);
                var scale = height * 1.0 / image.Height; // image.Height > height ? height * 1.0 / image.Height: image.Height * 1.0 / height;
                var width = (int)(image.Width * scale);
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);

                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.Default;
                    graphics.InterpolationMode = InterpolationMode.Default;
                    graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

                    if (image.PropertyIdList.Contains(OrientationKey))
                    {
                        var orientation = (int)image.GetPropertyItem(OrientationKey).Value[0];
                        switch (orientation)
                        {
                            case NotSpecified: // Assume it is good.
                            case NormalOrientation:
                                // No rotation required.
                                break;
                            case MirrorHorizontal:
                                destImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                break;
                            case UpsideDown:
                                destImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                break;
                            case MirrorVertical:
                                destImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                                break;
                            case MirrorHorizontalAndRotateRight:
                                destImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                                break;
                            case RotateLeft:
                                destImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                break;
                            case MirorHorizontalAndRotateLeft:
                                destImage.RotateFlip(RotateFlipType.Rotate270FlipX);
                                break;
                            case RotateRight:
                                destImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                break;
                            default:
                                throw new NotImplementedException("An orientation of " + orientation + " isn't implemented.");
                        }
                    }

                }

                return destImage;
            }
        }
    }
}
