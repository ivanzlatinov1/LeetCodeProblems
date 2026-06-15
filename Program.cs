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

        case 29:
            Console.WriteLine(Problem29.Divide(10, 3));
            break;

        case 48:
            Problem48.Rotate([[1, 2, 3], [4, 5, 6], [7, 8, 9]]);
            break;

        case 61:
            Problem61.ListNode head = new(1, new(2, new(3, new(4, new(5)))));
            Problem61.ListNode? rotatedList = Problem61.RotateRight(head, 2);
            Problem61.PrintList(rotatedList);
            break;

        case 66:
            Console.WriteLine(string.Join(", ", Problem66.PlusOne([9, 8, 9])));
            break;

        case 136:
            Console.WriteLine(Problem136.SingleNumber([4, 1, 2, 1, 2]));
            break;

        case 153:
            Console.WriteLine(Problem153.FindMin([3, 4, 5, 1, 2]));
            break;

        case 202:
            Console.WriteLine(Problem202.IsHappy(19));
            break;

        case 396:
            Console.WriteLine(Problem396.MaxRotateFunction([4, 3, 2, 6]));
            break;

        case 657:
            Console.WriteLine(Problem657.JudgeCircle("UDUD"));
            break;

        case 788:
            Console.WriteLine(Problem788.RotatedDigits(10));
            break;

        case 796:
            Console.WriteLine(Problem796.RotateString("abcde", "cdeab"));
            break;

        case 874:
            Console.WriteLine(Problem874.RobotSim([4, -1, 4, -2, 4], [[2, 4]]));
            break;

        case 1009:
            Console.WriteLine(Problem1009.BitwiseComplement(5));
            break;

        case 1306:
            Console.WriteLine(Problem1306.CanReach([4, 2, 3, 0, 3, 1, 2], 5));
            break;

        case 1391:
            Console.WriteLine(Problem1391.HasValidPath([[2, 4, 3], [6, 5, 2]]));
            break;

        case 1415:
            Console.WriteLine(Problem1415.GetHappyString(1, 3));
            break;

        case 1559:
            Console.WriteLine(Problem1559.ContainsCycle([['a', 'a', 'a', 'a'], ['a', 'b', 'b', 'a'], ['a', 'b', 'b', 'a'], ['a', 'a', 'a', 'a']]));
            break;

        case 1594:
            Console.WriteLine(Problem1594.MaxProductPath([[1, -2, 1], [1, -2, 1], [3, -4, 1]]));
            break;

        case 1665:
            Console.WriteLine(Problem1665.MinimumEffort([[1, 3], [2, 4], [10, 11], [10, 12], [8, 9]]));
            break;

        case 1758:
            Console.WriteLine(Problem1758.MinOperations("1111"));
            break;

        case 1784:
            Console.WriteLine(Problem1784.CheckOnesSegment("1001"));
            break;

        case 1855:
            Console.WriteLine(Problem1855.MaxDistance([55, 30, 5, 4, 2], [100, 20, 10, 10, 5]));
            break;

        case 1861:
            Problem1861.RotateTheBox([['#', '.', '#']]);
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

        case 2033:
            Console.WriteLine(Problem2033.MinOperations([[2, 4], [6, 8]], 2));
            break;

        case 2075:
            Console.WriteLine(Problem2075.DecodeCiphertext("iveo    eed   l te   olc", 4));
            break;

        case 2078:
            Console.WriteLine(Problem2078.MaxDistance([1, 1, 1, 6, 1, 1, 1]));
            break;

        case 2095:
            Problem2095.DeleteMiddle(new(1, new(3, new(4, new(7, new(1, new(2, new(6))))))));
            break;

        case 2130:
            Console.WriteLine(Problem2130.PairSum(new(5, new(4, new(2, new(1))))));
            break;

        case 2161:
            Console.WriteLine(Problem2161.PivotArray([9, 12, 5, 10, 14, 3, 10], 10));
            break;

        case 2452:
            Console.WriteLine(string.Join(" ", Problem2452.TwoEditWords(["word", "note", "ants", "wood"], ["wood", "joke", "moat"])));
            break;

        case 2515:
            Console.WriteLine(Problem2515.ClosestTarget(["hello", "i", "am", "leetcode", "hello"], "hello", 1));
            break;

        case 2540:
            Console.WriteLine(Problem2540.GetCommon([1, 2, 3], [2, 4]));
            break;

        case 2574:
            Console.WriteLine(Problem2574.LeftRightDifference([10, 4, 8, 3]));
            break;

        case 2615:
            Console.WriteLine(Problem2615.Distance([1, 3, 1, 1, 2]));
            break;

        case 2770:
            Console.WriteLine(Problem2770.MaximumJumps([1, 3, 6, 4, 1, 2], 2));
            break;

        case 2784:
            Console.WriteLine(Problem2784.IsGood([1, 3, 3, 2]));
            break;

        case 2833:
            Console.WriteLine(Problem2833.FurthestDistanceFromOrigin("_R__LL_"));
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

        case 3660:
            Console.WriteLine(string.Join(" ", Problem3660.MaxValue([2, 3, 1])));
            break;

        case 3689:
            Console.WriteLine(Problem3689.MaxTotalValue([1, 3, 2], 2));
            break;

        case 3740:
            Console.WriteLine(Problem3740.MinimumDistance([2, 6, 2, 6, 2, 6, 2, 2, 2]));
            break;

        case 3742:
            Console.WriteLine(Problem3742.MaxPathScore([[0, 1], [2, 0]], 1));
            break;

        case 3761:
            Console.WriteLine(Problem3761.MinMirrorPairDistance([12, 34, 46, 21, 12]));
            break;

        case 3838:
            Console.WriteLine(Problem3838.MapWordWeights(
                    ["abcd", "def", "xyz"],
                    [5, 3, 12, 14, 1, 2, 3, 2, 10, 6, 6, 9, 7, 8, 7, 10, 8, 9, 6, 9, 9, 8, 3, 7, 7, 2]));
            break;

        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
}