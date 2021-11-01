using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathfindingScript : MonoBehaviour
{
    public static bool readyToScan = false;
    bool oneTime = true;

    void Update()
    {

        if (readyToScan == true && oneTime == true)
        {
            AstarPath.FindAstarPath();
            AstarPath.active.Scan();
            oneTime = false;
        }
    }
}
