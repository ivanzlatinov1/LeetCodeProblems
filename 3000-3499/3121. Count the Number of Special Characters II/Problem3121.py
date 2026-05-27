class Solution(object):
    def numberOfSpecialChars(self, word: str) -> int:
        # create dictionary: [letter] -> index
        letters = dict()

        for i in range(len(word)):
            # get only the first occurance of the upper letter
            if word[i].isupper() and word[i] not in letters:
                letters[word[i]] = i

            # update index of every lower letter encountered
            if word[i].islower():
                letters[word[i]] = i

        ans = 0

        # for each lower-case key, if its index is smaller than the upper-case key, update ans
        for key in letters.keys():
            if key.islower() and key.upper() in letters:
                if letters[key] < letters[key.upper()]:
                    ans += 1

        return ans


sol = Solution()
print(sol.numberOfSpecialChars("AbBCab"))
