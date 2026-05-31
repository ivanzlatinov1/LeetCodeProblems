class Solution:
    def asteroidsDestroyed(self, mass: int, asteroids: list[int]) -> bool:
        # sort the asteroids in ascending order, so every next asteroid has bigger mass than the previous one
        asteroids.sort()

        for asteroid in asteroids:
            # if the current asteroid has bigger mass than the accumulated Earth mass, it can't be destroyed
            if asteroid > mass:
                return False

            # add the asteroid mass to the accumulated Earth mass
            mass += asteroid

        # best case: every asteroid is destroyed
        return True


sol = Solution()
print(sol.asteroidsDestroyed(10, [3, 9, 19, 5, 21]))
