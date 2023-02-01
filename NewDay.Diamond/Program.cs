using NewDay.Diamond;

// The DiamondStringGenerator class takes only a char, so the validation on that is just to validate that the char
// is correct. I'm not going to validate that the caller is calling with the correct argument as that is the 
// responsiblity of the calling code and I'm assuming this console app is just a dummy placeholder for that.
Console.WriteLine(new DiamondStringGenerator().GenerateDiamond(args[0][0]));
