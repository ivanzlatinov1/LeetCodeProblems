class Solution:
    def totalWaviness(self, num1: int, num2: int) -> int:
        if num2 < 101:
            return 0

        waviness_digits = 0
        for i in range(num1, num2 + 1):
            if i < 101:
                continue

            num = i
            prev = num % 10
            current = int(num / 10) % 10
            next = int(num / 100) % 10

            if (current > prev and current > next) or (
                current < prev and current < next
            ):
                waviness_digits += 1

            num = int(num / 1000)
            while num > 0:
                prev = num % 10
                num = int(num / 10)

                if (next > prev and next > current) or (next < prev and next < current):
                    waviness_digits += 1

                current = num % 10

                if num != 0 and (
                    (prev > next and prev > current) or (prev < next and prev < current)
                ):
                    waviness_digits += 1
                num = int(num / 10)

                next = num % 10
                num = int(num / 10)

        return waviness_digits


sol = Solution()
print(sol.totalWaviness(4848, 4848))
