using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ExtensionMethods
{
    public static Vector3 CalculatePosition(Vector3 basePosition, List<GameObject> list)
    {
        Vector3 spawnPosition = Vector3.zero;
        if (list.Count > 0)
        {
            spawnPosition = list.Last().transform.position + Vector3.up / 15f;
        }
        else
        {
            spawnPosition = basePosition;
        }

        return spawnPosition;
    }
}
