using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Random_Scale
{
    private static int Random_scale()
    {
        int scale_value = Random.Range(0, 100) switch
        {
            (>0) and (<10) => 2,
            (>10) and (<30) =>3,
            (> 30) and (< 60) => 4,
            (> 60) and (< 80) => 5,
            (> 80) and (< 90) => 6,
            _ => 7
        };       
        return scale_value;
    }
    public static Vector3 Random_scale_gen(Direction direction)
    {
        Vector3 scale = Vector3.one;
        int scale_value = Random_scale();
        if (direction == Direction.right)
            scale.x = scale_value;
        else
            scale.z = scale_value;

        return scale;
    }
}
