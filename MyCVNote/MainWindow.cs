using System;
using Gtk;
using System.IO;
using MyCVNote;

public partial class MainWindow : Gtk.Window
{
    string CurrentFile;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void Open(object sender, EventArgs e)
    {
        FileChooserDialog filechooser =
        new FileChooserDialog("Choose the file to open",
            this,
            FileChooserAction.Open,
            "Cancel", ResponseType.Cancel,
            "Open", ResponseType.Accept);

        if (filechooser.Run() == (int)ResponseType.Accept)
        {
            string[] file = File.ReadAllLines(filechooser.Filename);
            CurrentFile = filechooser.Filename;
            foreach (var line in file)
            {
                textview2.Buffer.Text += line + "\n";
            }

        }

        filechooser.Destroy();

    }

    protected void SaveAs(object sender, EventArgs e)
    {
        FileChooserDialog fileChooser = new FileChooserDialog("Save Dialog",
        this,
        FileChooserAction.Save,
        "Cancel", ResponseType.Cancel,
        "Save", ResponseType.Accept
        );
        if (fileChooser.Run() == (int)ResponseType.Accept)
        {
            File.WriteAllText(fileChooser.Filename, textview2.Buffer.Text);

        }
        fileChooser.Destroy();
    }

    protected void Save(object sender, EventArgs e)
    {
        if (!File.Exists(CurrentFile))
        {
            button13.Click();
        }
        File.WriteAllText(CurrentFile, textview2.Buffer.Text);
    }

    protected void AboutWindow(object sender, EventArgs e)
    {
        About about = new About();

        about.Show();
    }
}
