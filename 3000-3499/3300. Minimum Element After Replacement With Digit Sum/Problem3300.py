class Solution:
    def minElement(self, nums: list[int]) -> int:
        min_el = float("inf")

        for num in nums:
            digit_sum = 0

            while num > 0:
                digit_sum += num % 10
                num //= 10

            min_el = min(min_el, digit_sum)

        return int(min_el)


sol = Solution()
print(sol.minElement([999, 19, 199]))
