class Solution:
    def check(self, nums: list[int]) -> bool:
        drops = 0

        for i in range(1, len(nums)):

            # If previous element is greater than current, it's a drop
            if nums[i - 1] > nums[i]:
                drops += 1  # Increment drop counter

        # Check the wrap-around: last element compared to first (circular check)
        if nums[-1] > nums[0]:
            drops += 1  # Wrap-around drop found - another descent at rotation boundary

        # A valid rotated sorted array has at most 1 drop (the rotation point)
        return drops < 2


solution = Solution()
print(solution.check([3, 1, 2]))  # prints true
