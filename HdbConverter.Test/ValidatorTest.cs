using System.ComponentModel.DataAnnotations;
using Xunit;
using HdbConverter.Lib;

namespace HdbConverter.Test;

public class ValidatorTest
{


    [Theory]
    [InlineData("98825082740834", true)]
    [InlineData("0000001487646153613268532", true)]
    [InlineData("-80283640", false)]
    [InlineData("178397a8", false)]
    [InlineData("", false)]
    public void IsDecimalTest_ShouldRecogniseDecimalNumber(string input, bool expected)
    {
        bool result = input.IsPositiveDecimal();
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("10100101011111101000100101010000000000111010101000010101000000111101010111110100110000011", true)]
    [InlineData("-10001010", false)]
    [InlineData("101110101e010", false)]
    [InlineData("", false)]
    public void IsBinaryTest_ShouldPassOnlyZerosAndOnes(string input, bool expected)
    {
        bool result = input.IsBinary();
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("8098532110abCDEf", true)]
    [InlineData("ABCDEF", true)]
    [InlineData("328792359872", true)]
    [InlineData("-1234", false)]
    [InlineData("", false)]
    [InlineData("0993409DSA", false)]
    public void IsHexadecimalTest(string input, bool expected)
    {
        bool result = input.IsHexadecimalPositive();
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("a-ůdgihpáščáqhla98Q83-", false)]
    [InlineData("-", true)]
    [InlineData("", false)]
    [InlineData("-ůas9093", true)]
    public void IsNegativeTest(string input, bool expected)
    {
        bool result = input.IsNegative();
        Assert.Equal(expected, result);
    }

}
