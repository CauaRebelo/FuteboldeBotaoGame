using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Info_Player
{
    private static string p_namep1 = "Player 1";
    private static string p_namep2 = "Player 2";
    private static int p_scorep1 = 0;
    private static int p_scorep2 = 0;
    private static int p_teamp1 = 0;
    private static int p_teamp2 = 0;
    private static int p_death_projectile1 = 0;
    private static int p_death_projectile2 = 0;

    public static string namep1
    {
        get { return p_namep1; }
        set { p_namep1 = value; }
    }

    public static string namep2
    {
        get { return p_namep2; }
        set { p_namep2 = value; }
    }

    public static int scorep1
    {
        get { return p_scorep1; }
        set { p_scorep1 = value; }
    }

    public static int scorep2
    {
        get { return p_scorep2; }
        set { p_scorep2 = value; }
    }

    public static int teamp1
    {
        get { return p_teamp1; }
        set { p_teamp1 = value; }
    }

    public static int teamp2
    {
        get { return p_teamp2; }
        set { p_teamp2 = value; }
    }

    public static int death_projectile1
    {
        get { return p_death_projectile1; }
        set { p_death_projectile1 = value; }
    }

    public static int death_projectile2
    {
        get { return p_death_projectile2; }
        set { p_death_projectile2 = value; }
    }
}
