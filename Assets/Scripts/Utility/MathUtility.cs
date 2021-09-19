using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MathUtility
{
    public static float SumOfList(IEnumerable<float> list)
    {
        return list.Aggregate(0f, (x,y) => x + y);
    }
}
