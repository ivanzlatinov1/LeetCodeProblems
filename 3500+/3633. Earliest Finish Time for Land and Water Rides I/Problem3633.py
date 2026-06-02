class Solution:
    def earliestFinishTime(
        self,
        landStartTime: list[int],
        landDuration: list[int],
        waterStartTime: list[int],
        waterDuration: list[int],
    ) -> int:
        def getEarliestFinishTime(
            firstTimes: list[int],
            firstTimesDuration: list[int],
            secondTimes: list[int],
            secondTimeDuration: list[int],
        ) -> int:
            minTime = float("inf")
            for ind, time in enumerate(firstTimes):
                currentTime = time + firstTimesDuration[ind]

                addedCurrentTime = float("inf")
                for i in range(len(secondTimes)):
                    if secondTimes[i] <= currentTime:
                        addedCurrentTime = min(addedCurrentTime, secondTimeDuration[i])
                    else:
                        addedCurrentTime = min(
                            addedCurrentTime,
                            secondTimes[i] - currentTime + secondTimeDuration[i],
                        )

                minTime = min(currentTime + addedCurrentTime, minTime)
            return int(minTime)

        return min(
            getEarliestFinishTime(
                landStartTime, landDuration, waterStartTime, waterDuration
            ),
            getEarliestFinishTime(
                waterStartTime, waterDuration, landStartTime, landDuration
            ),
        )


sol = Solution()
print(
    sol.earliestFinishTime(
        landStartTime=[2, 8], landDuration=[4, 1], waterStartTime=[6], waterDuration=[3]
    )
)
print(
    sol.earliestFinishTime(
        landStartTime=[5], landDuration=[3], waterStartTime=[1], waterDuration=[10]
    )
)
