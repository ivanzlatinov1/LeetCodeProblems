class Solution:
    def minimumCost(self, cost: list[int]) -> int:
        # sort the candies' costs in descending order to remove the maximum cost possible after buying 2 candies
        cost = sorted(cost, reverse=True)
        # initialize counter variable to track when we encounter the third candy, which will be free
        counter = 0
        # we can calculate the number of free candies by dividing all the candies by 3 (because every 3rd is free)
        free_candies = int(len(cost) / 3)
        # store the minimum cost for all the candies at 'ans' variable
        ans = 0

        # iterate through all the candies in descending order
        for i in range(len(cost)):
            # if we haven't reached the third candy, we increase the counter and add the candy's price to 'ans'
            if counter < 2:
                counter += 1
                ans += cost[i]
            # we reach the third candy so we get it for free
            elif counter == 2 and free_candies > 0:
                counter = 0
                free_candies -= 1
            # we reached the third candy but there are no free candies left, so we need to buy it
            elif counter == 2 and free_candies == 0:
                counter = 0
                ans += cost[i]

        return ans


sol = Solution()
print(sol.minimumCost([1, 2, 3]))
