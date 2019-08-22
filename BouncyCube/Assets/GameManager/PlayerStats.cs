using UnityEngine;

public static class PlayerStats
{
    public static int TotalScore { get; set; }

    public static int TotalJumps { get; set; }

    public static int TotalDoubleJumps { get; set; }

    public static int TotalFails { get; set; }

    public static string Name { get; set; }

    public static void ResetPlayerStats()
    {
        TotalScore = 0;
        TotalJumps = 0;
        TotalDoubleJumps = 0;
        TotalFails = 0;
        Name = null;
    }

}
