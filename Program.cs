// Welcome!
// This repository contains my solutions to various LeetCode problems I have worked through.
// For full problem descriptions and additional details, please refer to the official LeetCode problem page.

while (true)
{
    Console.WriteLine("\nEnter a problem number (0 to exit, 'ls' to list problems):");
    string input = Console.ReadLine()!;

    if (input == "0")
        break;

    if (input.Equals("ls", StringComparison.CurrentCultureIgnoreCase))
    {
        Display.Problems();
        continue;
    }

    if (!int.TryParse(input, out int problem))
    {
        Console.WriteLine("Invalid input! Please enter a number or 'ls'.");
        continue;
    }

    switch (problem)
    {
        case 17:
            Console.WriteLine("[" + string.Join(", ", Problem17.LetterCombinations("23")) + "]");
            break;

        case 66:
            Console.WriteLine(string.Join(", ", Problem66.PlusOne([9, 8, 9])));
            break;

        case 657:
            Console.WriteLine(Problem657.JudgeCircle("UDUD"));
            break;

        case 1009:
            Console.WriteLine(Problem1009.BitwiseComplement(5));
            break;

        case 1415:
            Console.WriteLine(Problem1415.GetHappyString(1, 3));
            break;

        case 1594:
            Console.WriteLine(Problem1594.MaxProductPath([[1, -2, 1], [1, -2, 1], [3, -4, 1]]));
            break;

        case 1758:
            Console.WriteLine(Problem1758.MinOperations("1111"));
            break;

        case 1784:
            Console.WriteLine(Problem1784.CheckOnesSegment("1001"));
            break;

        case 1886:
            Console.WriteLine(Problem1886.FindRotation(
                [[0, 0, 0], [0, 1, 0], [1, 1, 1]],
                [[1, 1, 1], [0, 1, 0], [0, 0, 0]]
            ));
            break;

        case 1980:
            Console.WriteLine(Problem1980.FindDifferentBinaryString(["111", "011", "001"]));
            break;

        case 2075:
            Console.WriteLine(Problem2075.DecodeCiphertext("iveo    eed   l te   olc", 4));
            break;

        case 2839:
            Console.WriteLine(Problem2839.CanBeEqual("abcd", "cdab"));
            break;

        case 2946:
            Console.WriteLine(Problem2946.AreSimilar(
                [[1, 2, 1, 2], [5, 5, 5, 5], [6, 3, 6, 3]], 2));
            break;

        case 3070:
            Console.WriteLine(Problem3070.CountSubmatrices(
                [[7, 6, 3], [6, 6, 1]], 18));
            break;

        case 3129:
            Console.WriteLine(Problem3129.NumberOfStableArrays(3, 3, 2));
            break;

        case 3296:
            Console.WriteLine(Problem3296.MinNumberOfSeconds(4, [2, 1, 1]));
            break;

        case 3418:
            Console.WriteLine(Problem3418.MaximumAmount(
                [[0, 1, -1], [1, -2, 3], [2, -3, 4]]));
            break;

        case 3643:
            Console.WriteLine(Problem3643.ReverseSubmatrix(
                [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12], [13, 14, 15, 16]], 1, 0, 3));
            break;

        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
}