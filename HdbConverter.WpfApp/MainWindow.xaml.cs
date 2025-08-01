using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HdbConverter.WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IShortcutService _shortcutService;

    private TextBoxType activeTextBox;

    public MainWindow()
    {
        InitializeComponent();
        activeTextBox = TextBoxType.Dec;
        _shortcutService = new ShortcutService();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        activeTextBox = TextBoxType.Dec;
        Keyboard.Focus(textBoxDec);
    }

    #region "Handlers"

    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        HandleKeyDown(e);
    }

    #endregion


    #region "Shortcuts"

    private void HandleKeyDown(KeyEventArgs e)
    {
        switch (_shortcutService.GetPressedKeys(e))
        {
            case PressedKeys.Esc:
                Application.Current.Shutdown();
                break;

            case PressedKeys.F1:
                HelpMessageBox.Show();
                break;

            case PressedKeys.CtrlDel:
                textBoxDec.Text = string.Empty;
                textBoxHex.Text = string.Empty;
                textBoxBin.Text = string.Empty;
                break;

            case PressedKeys.CtrlC:
            {
                if (Keyboard.FocusedElement is TextBox focusedTextBox)
                {
                    Clipboard.SetText(focusedTextBox.Text);
                }
                break;
            }

            case PressedKeys.Up:
            {
                if (Keyboard.FocusedElement is TextBox focusedTextBox)
                {
                    if (!SetTextBoxFocus(Direction.Up, focusedTextBox.CaretIndex))
                    {
                        // sets carret at the home fo the text box
                        focusedTextBox.CaretIndex = 0;
                    }
                }
                break;
            }

            case PressedKeys.Down:
            {
                if (Keyboard.FocusedElement is TextBox focusedTextBox)
                {
                    if (!SetTextBoxFocus(Direction.Down, focusedTextBox.CaretIndex))
                        // sets caret at the end
                        focusedTextBox.CaretIndex = focusedTextBox.Text.Length;
                }
                break;
            }
        }
    }

    /// <summary>
    /// Sets active text box, and returns is changed. If it is not changed, returns false. It can be used for activate changing the caret between home/end.
    /// </summary>
    /// <param name="direction">Pressed arrow (up/down)</param>
    /// <returns>Focus changed</returns>
    private bool SetTextBoxFocus(Direction direction, int position)
    {
        const bool FocusChanged = true;

        switch (activeTextBox)
        {
            case TextBoxType.Dec:
                if (direction == Direction.Down)
                {
                    activeTextBox = TextBoxType.Hex;
                    textBoxHex.Focus();
                    textBoxHex.CaretIndex = position;
                    return FocusChanged;
                }
                return !FocusChanged;
            case TextBoxType.Hex:
                if (direction == Direction.Down)
                {
                    activeTextBox = TextBoxType.Bin;
                    textBoxBin.Focus();
                    textBoxBin.CaretIndex = position;
                    return FocusChanged;
                }
                else
                {
                    activeTextBox = TextBoxType.Dec;
                    textBoxDec.Focus();
                    textBoxDec.CaretIndex = position;
                    return FocusChanged;
                }
            case TextBoxType.Bin:
                if (direction == Direction.Up)
                {
                    activeTextBox = TextBoxType.Hex;
                    textBoxHex.Focus();
                    textBoxHex.CaretIndex = position;
                    return FocusChanged;
                }
                return !FocusChanged;
            default:
                return !FocusChanged;
        }
    }


    #endregion

}