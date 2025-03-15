using System.Globalization;

namespace HdbConverter.Lib;


public class Converter
{

    #region "From decimal"


    /// <summary>
    /// Convert DEC 2 HEX
    /// </summary>
    /// <param name="dec">decadic integer</param>
    /// <returns>string of dec value</returns>
    public string Dec2Hex(string dec)
    {
        var validResult = ValidateInput(dec, Validator.IsPositiveDecimal, NumSystem.DEC);

        if (!validResult.isValid)
            return validResult.message;

        bool isConverted = ulong.TryParse(dec, out ulong l);

        if (!isConverted)
            return Message.NotValid;

        return l.ToString("X");
    }


    /// <summary>
    /// Convert DEC 2 BIN
    /// </summary>
    /// <param name="dec"></param>
    /// <returns></returns>
    public string Dec2Bin(string dec)
    {
        var validResult = ValidateInput(dec, Validator.IsPositiveDecimal, NumSystem.DEC);

        if (!validResult.isValid)
            return validResult.message;

        bool isConverted = ulong.TryParse(dec, out ulong l);

        if (!isConverted)
            return Message.NotValid;

        return ConvertToBinary(l);
    }


    #endregion


    #region "From Hexadecimal"


    /// <summary>
    /// Convert HEX 2 DEC
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    public string Hex2Dec(string hex)
    {
        var validResult = ValidateInput(hex, Validator.IsHexadecimalPositive, NumSystem.HEX);

        if (!validResult.isValid)
            return validResult.message;

        ulong? convertedNumber = ConvertFromHexadecmal(hex);

        if (convertedNumber == null)
            return Message.NotValid;

        return convertedNumber.ToString()!;
    }


    /// <summary>
    /// Convert HEX 2 BIN
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    public string Hex2Bin(string hex)
    {
        var validResult = ValidateInput(hex, Validator.IsHexadecimalPositive, NumSystem.HEX);

        if (!validResult.isValid)
            return validResult.message;

        ulong? convertedNumber = ConvertFromHexadecmal(hex);

        if (convertedNumber == null)
            return Message.NotValid;

        return ConvertToBinary(convertedNumber);
    }


    #endregion


    #region "From binary"


    /// <summary>
    /// Convert BIN 2 DEC
    /// </summary>
    /// <param name="bin"></param>
    /// <returns></returns>
    public string Bin2Dec(string bin)
    {
        var validResult = ValidateInput(bin, Validator.IsBinary, NumSystem.BIN);

        if (!validResult.isValid)
            return validResult.message;

        ulong decimalNum;

        try
        {
            decimalNum = Convert.ToUInt64(bin, 2);
        }
        catch
        {
            return Message.NotValid;
        }

        return decimalNum.ToString();
    }


    /// <summary>
    /// Convert BIN 2 HEX.
    /// </summary>
    /// <param name="bin"></param>
    /// <returns></returns>
    public string Bin2Hex(string bin)
    {
        var validResult = ValidateInput(bin, Validator.IsBinary, NumSystem.BIN);

        if (!validResult.isValid)
            return validResult.message;

        ulong decimalNum;

        try
        {
            decimalNum = Convert.ToUInt64(bin, 2);
        }
        catch
        {
            return Message.NotValid;
        }

        return decimalNum.ToString("X");
    }


    #endregion


    #region "Private helpers"

    
    private string ConvertToBinary(ulong? number)
    {
        if (number == null)
            return "null";

        char[] bits = new char[64];

        for (int i = 63; i >= 0; i--)
        {
            bits[63 - i] = (((number >> i) & 1) == 1) ? '1' : '0';
        }

        var result =  new string(bits);
        return result.Contains('1') ? result.TrimStart('0') : "0";
    }

    /// <summary>
    /// Convert hexadecimal number tu ulong decimal.
    /// </summary>
    /// <param name="hex"></param>
    /// <returns>ulong decimal number or null if Parsing failed.</returns>
    private ulong? ConvertFromHexadecmal(string hex)
    {
        bool isConverted = ulong.TryParse(hex, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out ulong l);
        return isConverted ? l : null;
    }

    private static class Message
    {
        public static string OnlyPositiveNumbers = "Only positive numbers!";

        public static string WrongDec = "Wrong DEC number!";
        public static string WrongBin = "Wrong BIN number!";
        public static string WrongHex = "Wrong HEX number!";

        public static string NotValid = "Bigger than ulong";

        public static string GetWrongMessage(NumSystem numSystem)
        {
            return $"Wrong {numSystem.ToString()} number!";
        }
    };

    private (bool isValid, string message) ValidateInput(string input, Func<string, bool> testPositiveNumber,  NumSystem numericSystem)
    {
        if (input == "")
            return (isValid: false, message: "");

        if (Validator.IsNegative(input))
            return (isValid: false, message: Message.OnlyPositiveNumbers);

        if (!testPositiveNumber(input))
            return (isValid: false, message: Message.GetWrongMessage(numericSystem));

        return (isValid: true, "");
    }

    private enum NumSystem
    {
        HEX,
        DEC,
        BIN
    }


    #endregion


}
