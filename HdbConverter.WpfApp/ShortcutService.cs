using System.Windows.Input;

namespace HdbConverter.WpfApp;

public class ShortcutService : IShortcutService
{
    public PressedKeys GetPressedKeys(KeyEventArgs keyArgs)
    {
        if (keyArgs.Key == Key.Escape)
            return PressedKeys.Esc;

        if (keyArgs.Key == Key.Delete && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            return PressedKeys.CtrlDel;

        if (keyArgs.Key == Key.F1)
            return PressedKeys.F1;

        if (keyArgs.Key == Key.Up)
            return PressedKeys.Up;

        if (keyArgs.Key == Key.Down)
            return PressedKeys.Down;

        if (keyArgs.Key == Key.C && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            return PressedKeys.CtrlC;

        return PressedKeys.None;
    }
}


public interface IShortcutService
{
    /// <summary>
    /// Returns key, which are pressed.
    /// </summary>
    /// <param name="keys">KeyEventArgs - pressed keys</param>
    /// <returns>PressedKey, my enum</returns>
    PressedKeys GetPressedKeys(KeyEventArgs keys);
}