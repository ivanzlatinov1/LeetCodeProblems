class Solution(object):
    def numberOfSpecialChars(self, word: str) -> int:
        ans = 0

        # create two sets for upper and lower letters
        lowerLetters = set()
        upperLetters = set()

        # add each letter to the corresponding set of letters
        for i in word:
            if i.islower():
                lowerLetters.add(i)
            elif i.isupper:
                upperLetters.add(i)

        # check for each lowercase letter if its upper variant appears in the other set
        for i in lowerLetters:
            if i.upper() in upperLetters:
                ans += 1

        # return the number of letters that appear both in lowercase and uppercase in {word}
        return ans


sol = Solution()
print(sol.numberOfSpecialChars("aaAbcBC"))
