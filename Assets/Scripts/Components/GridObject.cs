using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    None = 0,
    Path = 1,
    Turret = 2,
    CenterTower = 3
}

public class GridObject : MonoBehaviour
{

    #region Properties

    public ObjectType objectType;
    public Vector2 location;

    #endregion

    #region Constructors

    /// <summary>
    /// Empty constructor.
    /// </summary>
    public GridObject()
    {
        objectType = ObjectType.None;
        location = Vector2.zero;
    }

    /// <summary>
    /// Constructor for an object within the grid.
    /// </summary>
    /// <param name="_objectType">Type of object (i.e. None, Path, Turret, CenterTurret)</param>
    /// <param name="_location">Location of object in grid.</param>
    public GridObject(ObjectType _objectType, Vector2 _location)
    {
        objectType = _objectType;
        location = _location;
    }

    #endregion

}
