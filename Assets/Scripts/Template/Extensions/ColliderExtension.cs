using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColliderExtension
{
    private readonly static float MAX_STEP_COUNT = 10000;

    public static bool TryGetRandomPointInCollider(this Collider2D zone, out Vector2 point, float offset = 0)
    {
        point = Vector2.zero;
        Vector2 min = zone.bounds.min;
        Vector2 max = zone.bounds.max;

        float minX = Mathf.Clamp(min.x + offset, min.x, max.x);
        float maxX = Mathf.Clamp(max.x - offset, min.x, max.x);
        float minY = Mathf.Clamp(min.y + offset, min.y, max.y);
        float maxY = Mathf.Clamp(max.y - offset, min.y, max.y);

        for (int i = 0; i < MAX_STEP_COUNT; i++)
        {
            float spawnX = Random.Range(minX, maxX);
            float spawnY = Random.Range(minY, maxY);
            point = new(spawnX, spawnY);

            if (zone.OverlapPoint(point)) return true;
        }

        Debug.LogWarning("Fail to get random point in spawn zone");
        return false;
    }
}
