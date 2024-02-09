using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Layout;


// from https://www.kpsoftwaredev.com/2021/06/winforms-fast-graphics.html

namespace WinformRender.Views
{
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultBindingProperty("Image")]
    [DefaultProperty("Image")]
    [Designer("System.Windows.Forms.Design.PictureBoxDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Docking(DockingBehavior.Ask)]
    public partial class FastBitmap : PictureBox
    {
        private GCHandle _handle;
        private IntPtr _addr;
        public UInt32[] _pixels;

        public FastBitmap() : base()
        {
        }

        //[Category("Custom")]
        //[Browsable(true)]
        //[Description("fast bitmap for rendering")]
        //[Editor(typeof(System.Windows.Forms.Design.WindowsFormsComponentEditor),typeof(System.Drawing.Design.UITypeEditor))]

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
            base.Image = new Bitmap(width, height, stride, PixelFormat.Format32bppArgb, _addr);
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
