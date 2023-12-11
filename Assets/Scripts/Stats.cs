using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats
{
    public static int BreadCount { get; set; }

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        BreadCount = 0;
    }
}
