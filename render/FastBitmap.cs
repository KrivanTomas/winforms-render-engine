using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;


// from https://www.kpsoftwaredev.com/2021/06/winforms-fast-graphics.html

namespace WinformRender.Views
{
    public class FastBitmap : PictureBox
    {
        private GCHandle _handle;
        private IntPtr _addr;
        private UInt32[] _pixels;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Create();
        }

        private void Create()
        {
            Cleanup();

            int width = ClientSize.Width;
            int height = ClientSize.Height;

            int bitsPerPixel = ((int)PixelFormat.Format32bppArgb & 0xff00) >> 8;
            int bytesPerPixel = (bitsPerPixel + 7) / 8;
            int stride = 4 * ((width * bytesPerPixel + 3) / 4);

            _pixels = new UInt32[width * height];
            _handle = GCHandle.Alloc(_pixels, GCHandleType.Pinned);
            _addr = Marshal.UnsafeAddrOfPinnedArrayElement(_pixels, 0);
            Image = new Bitmap(width, height, stride, PixelFormat.Format32bppArgb, _addr);
        }

        private void Cleanup()
        {
            if (null != Image)
            {
                Image.Dispose();
                Image = null;
            }

            if (_handle.IsAllocated)
                _handle.Free();
        }
    }
}
