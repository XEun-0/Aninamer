using System;
using System.Windows.Forms;

namespace Aninamer.components
{
    public class SyncedListBox : ListBox
    {
        public SyncedListBox Partner { get; set; }
        private bool internalSync = false;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_VSCROLL = 0x115;
            const int WM_MOUSEWHEEL = 0x20A;

            if (!internalSync && (m.Msg == WM_VSCROLL || m.Msg == WM_MOUSEWHEEL))
            {
                if (Partner != null)
                {
                    internalSync = true;  // prevents recursive loop
                    Partner.TopIndex = this.TopIndex;
                    internalSync = false;
                }
            }
        }
    }
}
