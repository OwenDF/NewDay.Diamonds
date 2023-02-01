using FluentAssertions;

namespace NewDay.Diamond.Tests;

public class DiamondStringGeneratorShould
{

    [Fact]
    public void ReturnASingleAForA()
    {
        new DiamondStringGenerator().GenerateDiamond('A').Should().Be("A");
    }
    
    [Fact]
    public void ReturnADiamondForB()
    {
        new DiamondStringGenerator().GenerateDiamond('B').Should().Be(Diamonds.BDiamond);
    }

    [Fact]
    public void ReturnADiamondForE()
    {
        new DiamondStringGenerator().GenerateDiamond('E').Should().Be(Diamonds.EDiamond);
    }

    [Fact]
    public void ReturnsADiamondForZ()
    {
        var diamond = new DiamondStringGenerator().GenerateDiamond('Z');
        
        diamond[52 * 25].Should().Be('Z');
        diamond[52 * 26 - 2].Should().Be('Z');
        diamond.Count(x => x == 'Z').Should().Be(2);
        diamond.Count(x => x == 'A').Should().Be(2);
        diamond.Count(x => x == 'I').Should().Be(4);
    }

    [Fact]
    public void ThrowInvalidArgumentExceptionForNonAlpha()
    {
        Assert.Throws<ArgumentException>(() => new DiamondStringGenerator().GenerateDiamond('1'));
    }
    
    [Fact]
    public void ReturnASingleAForLowerA()
    {
        new DiamondStringGenerator().GenerateDiamond('a').Should().Be("a");
    }
    
    [Fact]
    public void ReturnADiamondForLowerB()
    {
        new DiamondStringGenerator().GenerateDiamond('b').Should().Be(Diamonds.BDiamond.ToLower());
    }
}