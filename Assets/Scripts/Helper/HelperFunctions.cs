using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperFunctions
{
    /// <summary>
    /// Returns a screen location based on where the object is in the array.
    /// </summary>
    /// <param name="x">X location of object.</param>
    /// <param name="y">Y location of object.</param>
    /// <returns>Vector2 of location.</returns>
    public static Vector2 GetScreenLocationBasedOnArrayPosition(Vector2 point)
    {
        return new Vector2(point.x / 2f, point.y / 2f);
    }

    /// <summary>
    /// Returns a screen location based on where the object is in the array.
    /// </summary>
    /// <param name="x">X location of object.</param>
    /// <param name="y">Y location of object.</param>
    /// <returns>Vector2 of location.</returns>
    public static Vector2 GetScreenLocationBasedOnArrayPosition(float x, float y)
    {
        return new Vector2(x / 2f, y / 2f);
    }

    /// <summary>
    /// Returns a screen location based on where the object is in the array.
    /// </summary>
    /// <param name="x">X location of object.</param>
    /// <param name="y">Y location of object.</param>
    /// <returns>Vector2 of location.</returns>
    public static Vector2 GetScreenLocationBasedOnArrayPosition(int x, int y)
    {
        return new Vector2(x / 2f, y / 2f);
    }
}
