using HdbConverter.Lib;

namespace HdbConverter.Test;

public class ConverterTest
{
    private Converter _converter;


    public ConverterTest()
    {
        _converter = new Converter();
    }


    #region "Decimal tests"

    [Theory]
    [InlineData("", "")]
    [InlineData("0", "0")]
    [InlineData("-876593", "Only positive numbers!")]
    [InlineData("12g", "Wrong DEC number!")]
    [InlineData("18446744073709551616", "Bigger than ulong")]
    [InlineData("123", "7B")]
    [InlineData("00123", "7B")]
    public void Dec2Hex_ShouldHandleAllCases(string input, string expected)
    {
        var result = _converter.Dec2Hex(input);
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("", "")]
    [InlineData("0", "0")]
    [InlineData("-876593", "Only positive numbers!")]
    [InlineData("12g", "Wrong DEC number!")]
    [InlineData("18446744073709551616", "Bigger than ulong")]
    [InlineData("126", "1111110")]
    [InlineData("0126", "1111110")]
    public void Dec2Bin_ShouldHandleAllCases(string input, string expected)
    {
        var result = _converter.Dec2Bin(input);
        Assert.Equal(expected, result);
    }



    #endregion


    #region "Hexadecimal tests"

    [Theory]
    [InlineData("", "")]
    [InlineData("0", "0")]
    [InlineData("-876593", "Only positive numbers!")]
    [InlineData("10000000000000000", "Bigger than ulong")]
    [InlineData("ABCDEF8473w", "wrong HEX number!")]
    [InlineData("FE", "254")]
    [InlineData("0FE", "254")]
    public void Hex2Dec_ShouldHandleAllCases(string input, string expected)
    {
        var result = _converter.Hex2Dec(input);
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("", "")]
    [InlineData("0", "0")]
    [InlineData("-876593", "Only positive numbers!")]
    [InlineData("10000000000000000", "Bigger than ulong")]
    [InlineData("ABCDEF8473w", "wrong HEX number!")]
    [InlineData("7E", "1111110")]
    [InlineData("07E", "1111110")]
    public void Hex2Bin_ShouldHandleAllCases(string input, string expected)
    {
        var result = _converter.Hex2Bin(input);
        Assert.Equal(expected, result);
    }


    #endregion


    #region "Binary tests"


    [Theory]
    [InlineData("", "")]
    [InlineData("0", "0")]
    [InlineData("-876593", "Only positive numbers!")]
    [InlineData("2", "Wrong BIN number!")]
    [InlineData("1111110", "126")]
    [InlineData("01111110", "126")]
    public void Bin2Dec_ShouldHandleAllCases(string input, string expected)
    {
        var result = _converter.Bin2Dec(input);
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("", "")]
    [InlineData("0", "0")]
    [InlineData("-876593", "Only positive numbers!")]
    [InlineData("2", "Wrong BIN number!")]
    [InlineData("1111110", "7E")]
    [InlineData("01111110", "7E")]
    public void Bin2Hex_ShouldHandleAllCases(string input, string expected)
    {
        var result = _converter.Bin2Hex(input);
        Assert.Equal(expected, result);
    }


    #endregion

}
