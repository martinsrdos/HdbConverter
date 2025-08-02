using CommunityToolkit.Mvvm.ComponentModel;
using HdbConverter.Lib;

namespace HdbConverter.ViewModel;

/// <summary>
/// ViewModel for the HdbConverter main window.
/// </summary>
public partial class HdbViewModel : ObservableObject
{

    private readonly Converter _converter;
    private bool _isUpdating = false;

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
        if (_isUpdating) return;
        _isUpdating = true;
        Dec = _converter.Bin2Dec(value);
        Hex = _converter.Bin2Hex(value);
        _isUpdating = false;
    }

    partial void OnDecChanged(string value)
    {
        if (_isUpdating) return;
        _isUpdating = true;
        Bin = _converter.Dec2Bin(value);
        Hex = _converter.Dec2Hex(value);
        _isUpdating = false;
    }

    partial void OnHexChanged(string value)
    {
        if (_isUpdating) return;
        _isUpdating = true;
        Bin = _converter.Hex2Bin(value);
        Dec = _converter.Hex2Dec(value);
        _isUpdating = false;
    }

}
