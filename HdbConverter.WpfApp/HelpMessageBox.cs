using System.Reflection;
using System.Windows;

namespace HdbConverter.WpfApp;

public static class HelpMessageBox
{
    private static string content = $"""
        ABOUT

        TITLE: HDB Converter
        VERSION: {Assembly.GetEntryAssembly()?.GetName().Version}
        AUTHOR: Martin Srdos
        CONTACT: martin.srdos@gmail.com
        SOURCE: github.com/martinsrdos
        COPYRIGHT: © 2025, Martin Srdos

        SHORTCUTS
        
        F1: This help
        CTRL + DEL: Clear all text boxes
        CTRL + C: Copy all text in selected text box
                  (without needing to mark everything)
        ESCAPE: Exit
        """;

    public static void Show()
    {
        MessageBox.Show(content);
    }
}
