using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossFlip : MonoBehaviour
{
    public AIPath aiPath;

    void Update()
    {
        if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }
        else if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
        }
    }
}