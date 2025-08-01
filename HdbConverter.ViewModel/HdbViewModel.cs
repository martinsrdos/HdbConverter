using CommunityToolkit.Mvvm.ComponentModel;
using HdbConverter.Lib;

namespace HdbConverter.ViewModel;

/// <summary>
/// ViewModel for the HdbConverter main window.
/// </summary>
public partial class HdbViewModel : ObservableObject
{

    private readonly Converter _converter;

    [ObservableProperty]
    private string _bin = string.Empty;

    [ObservableProperty]
    private string _dec = string.Empty;

    [ObservableProperty]
    private string _hex = string.Empty;


    public HdbViewModel()
    {
        _bin = _dec = _hex = string.Empty;
        _converter = new();
    }


    partial void OnBinChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            Dec = Hex = string.Empty;
            return;
        }
        Dec = _converter.Bin2Dec(value);
        Hex = _converter.Bin2Hex(value);
    }

    partial void OnDecChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            Bin = Hex = string.Empty;
            return;
        }
        Bin = _converter.Dec2Bin(value);
        Hex = _converter.Dec2Hex(value);
    }

    partial void OnHexChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            Bin = Dec = string.Empty;
            return;
        }
        Bin = _converter.Hex2Bin(value);
        Dec = _converter.Hex2Dec(value);
    }

}
