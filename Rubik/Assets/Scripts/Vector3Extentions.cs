using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extentions
{
    public static Vector3 ToInt(this Vector3 value)
    {
        float x = (float)Math.Round(value.x, 0);
        float y = (float)Math.Round(value.y, 0);
        float z = (float)Math.Round(value.z, 0);
        return new Vector3(x, y, z);
    }
}
