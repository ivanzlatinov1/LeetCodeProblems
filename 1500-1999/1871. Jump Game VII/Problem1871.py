class Solution(object):
    def canReach(self, s: str, minJump: int, maxJump: int) -> bool:
        n = len(s)

        # if the last character is different than '0', reaching the end is impossible
        if s[-1] != "0":
            return False

        # creating dp array filled with False values
        dp = [False] * n

        # starting position is marked as True
        dp[0] = True

        # store how many reachable indices exist in the valid jump window
        reach = 0

        for i in range(1, n):

            # add dp[i - minJump] when it enters the window
            if i >= minJump:
                reach += dp[i - minJump]

            # remove dp[i - maxJump - 1] when it leaves the window
            if i > maxJump:
                reach -= dp[i - maxJump - 1]

            if reach > 0 and s[i] == "0":
                dp[i] = True

        # return the last index of the dp array to see if tha last index of the string has been reached
        return dp[-1]


sol = Solution()
print(sol.canReach("011010", 2, 3))
