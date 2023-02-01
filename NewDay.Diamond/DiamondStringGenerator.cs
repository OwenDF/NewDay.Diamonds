namespace NewDay.Diamond;

public class DiamondStringGenerator
{
    private static readonly string UpperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static readonly string LowerAlphabet = UpperAlphabet.ToLower();
    
    public string GenerateDiamond(char maxCharacter)
    {
        if (!char.IsAsciiLetter(maxCharacter))
        {
            throw new ArgumentException("Must supply an ASCII letter", nameof(maxCharacter));
        }

        var alphabet = char.IsAsciiLetterLower(maxCharacter) ? LowerAlphabet : UpperAlphabet;
        var characterIndex = alphabet.IndexOf(maxCharacter);
        var squareSize = characterIndex * 2 + 1;
        var diamondArray = new char[squareSize][];
        for (var i = 0; i < diamondArray.Length; i++)
        {
            diamondArray[i] = Enumerable.Repeat(' ', squareSize).ToArray();
        }

        var finisedArray = GeneratePopulatedArray(diamondArray, 0, alphabet);
        return string.Join('\n', finisedArray.Select(x => new string(x)));
    }

    private char[][] GeneratePopulatedArray(char[][] arr, int rowNumber, string alphabet)
    {
        var midPointIndex = arr.Length / 2;
        if (rowNumber > midPointIndex) return arr;
        
        var topRow = arr[rowNumber];
        var bottomRow = arr[arr.Length - 1 - rowNumber];

        // This is the ugliest way of doing this but I kind of love it.
        topRow[midPointIndex - rowNumber] =
            topRow[midPointIndex + rowNumber] =
                bottomRow[midPointIndex - rowNumber] =
                    bottomRow[midPointIndex + rowNumber] =
                        alphabet[rowNumber];

        return GeneratePopulatedArray(arr, ++rowNumber, alphabet);
    }
}