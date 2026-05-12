public class Problem1665
{
    public static int MinimumEffort(int[][] tasks)
    {
        // Sort tasks by:
        // (minimum required energy - actual consumed energy) descending
        Array.Sort(tasks, (a, b) => (b[1] - b[0]).CompareTo(a[1] - a[0]));

        // Remaining energy after completing processed tasks
        int remainingEnergy = 0;

        // Total actual energy spent so far
        int spentEnergy = 0;

        for (int i = 0; i < tasks.Length; ++i)
        {
            // tasks[i][0] = actual energy cost
            // tasks[i][1] = minimum required energy before starting

            // If current remaining energy is not enough to start this task, increase initial energy
            if (remainingEnergy < tasks[i][1]) remainingEnergy += tasks[i][1] - remainingEnergy;

            // Perform the task
            // 1. Decrease remaining energy by actual cost
            remainingEnergy -= tasks[i][0];
            // 2. Increase total spent energy.
            spentEnergy += tasks[i][0];
        }

        // Final answer: total spent energy + remaining one added during processing
        return spentEnergy + remainingEnergy;
    }
}