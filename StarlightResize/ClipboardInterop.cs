using System.Drawing;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;

namespace StarlightResize
{
    internal class ClipboardInterop
    {
        private const uint CF_BITMAP = 2;

        internal static void SetClipboardData(Bitmap image)
        {
            if (PInvoke.OpenClipboard(HWND.Null))
            {
                PInvoke.EmptyClipboard();

                var hBitmap = GetCompatibleBitmap(image);
                PInvoke.SetClipboardData(CF_BITMAP, new HANDLE(hBitmap.Value));

                PInvoke.CloseClipboard();

                // The bitmap is now owned by the clipboard. We need to remove our reference to it.
                PInvoke.DeleteObject(hBitmap);
            }
        }

        private static HBITMAP GetCompatibleBitmap(Bitmap bitmap)
        {
            var screenDC = PInvoke.GetDC(HWND.Null);

            // GDI+ returns a DIBSECTION based HBITMAP. The clipboard only deals well with bitmaps created using
            // CreateCompatibleBitmap(). So, we convert the DIBSECTION into a compatible bitmap.
            var hBitmap = bitmap.GetHbitmap();

            // Create a compatible DC to render the source bitmap.
            var sourceDC = PInvoke.CreateCompatibleDC(screenDC);
            var sourceBitmapSelection = PInvoke.SelectObject(sourceDC, new HBITMAP(hBitmap));

            // Create a compatible DC and a new compatible bitmap.
            var destinationDC = PInvoke.CreateCompatibleDC(screenDC);
            HBITMAP compatibleBitmap = PInvoke.CreateCompatibleBitmap(
                screenDC,
                bitmap.Size.Width,
                bitmap.Size.Height
            );

            // Select the new bitmap into a compatible DC and render the blt the original bitmap.
            var destinationBitmapSelection = PInvoke.SelectObject(destinationDC, compatibleBitmap);
            PInvoke.BitBlt(
                destinationDC,
                0,
                0,
                bitmap.Size.Width,
                bitmap.Size.Height,
                sourceDC,
                0,
                0,
                ROP_CODE.SRCCOPY
            );

            PInvoke.SelectObject(destinationDC, destinationBitmapSelection);
            PInvoke.DeleteDC(destinationDC);

            PInvoke.SelectObject(sourceDC, sourceBitmapSelection);
            PInvoke.DeleteDC(sourceDC);

            PInvoke.ReleaseDC(HWND.Null, screenDC);

            return compatibleBitmap;
        }
    }
}
