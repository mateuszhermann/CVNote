using System;
namespace MyCVNote
{
    public partial class About : Gtk.Window
    {
        public About() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
