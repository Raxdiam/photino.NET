using System.Linq;

namespace PhotinoNET;

public interface IPhotinoDialog
{
    /// <summary>Title of the dialog window.</summary>
    string Title { get; set; }

    /// <summary>Default path the dialog is navigated to.</summary>
    string DefaultPath { get; set; }

    /// <summary>Enable or disable selection of multiple files or folders.</summary>
    bool MultiSelect { get; set; }

    /// <summary>Selected file name.</summary>
    string FileName { get; set; }

    /// <summary>
    /// Array of file filters. The way filters are used is different depending on the platform.<br />
    /// Note: Filter names are not used on macOS.
    /// </summary>
    (string Name, string[] Extensions)[] Filters { get; set; }

    /// <summary>Show the dialog window.</summary>
    bool Show(PhotinoWindow window);
}

public class PhotinoOpenDialog : IPhotinoDialog
{
    public string Title { get; set; }
    public string DefaultPath { get; set; }
    public bool MultiSelect { get; set; }
    public string FileName { get; set; }
    public (string Name, string[] Extensions)[] Filters { get; set; }
    public string[] FileNames { get; set; }
    public bool FoldersOnly { get; set; }

    public bool Show(PhotinoWindow window)
    {
        var results = window.ShowOpenDialog(FoldersOnly, Title ?? (FoldersOnly ? "Select folder" : "Open file"), DefaultPath, MultiSelect, Filters);

        FileNames = results;
        FileName = results?.FirstOrDefault();

        return results != null;
    }
}

public class PhotinoSaveDialog : IPhotinoDialog
{
    public string Title { get; set; }
    public string DefaultPath { get; set; }
    bool IPhotinoDialog.MultiSelect { get; set; }
    public string FileName { get; set; }
    public (string Name, string[] Extensions)[] Filters { get; set; }

    public bool Show(PhotinoWindow window)
    {
        var result = window.ShowSaveFile(Title ?? "Save file", DefaultPath, Filters);

        FileName = result;

        return result != null;
    }
}

public static class PhotinoMsgBox
{
    public static PhotinoDialogResult Show(PhotinoWindow window, string title, string text, PhotinoDialogButtons buttons = PhotinoDialogButtons.Ok, PhotinoDialogIcon icon = PhotinoDialogIcon.Info) =>
        window.ShowMessage(title, text, buttons, icon);
}