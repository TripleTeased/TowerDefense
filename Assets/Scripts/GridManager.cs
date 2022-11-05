using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{

    #region Properties

    /// <summary>
    /// Height and width of playing area. 
    /// </summary>
    [SerializeField]
    private int _screenWidth = 16;

    [SerializeField]
    private int _screenHeight = 9;

    // TODO: Move these two to tile manager
    [SerializeField]
    private GameObject _tileParent;
    [SerializeField]
    private GameObject _tilePrefab;

    [SerializeField]
    private GameObject _enemy;

    /// <summary>
    /// Camera transform.
    /// This is used to center camera on the grid that is created.
    /// </summary>
    [SerializeField]
    private Transform _cam;

    public GridObject[,] Grid = null;
    private int xLength = 0;
    private int yLength = 0;

    public PathScriptableObject[] paths;
    public bool onBuildMode = false;

    #endregion

    #region Functions

    void Start()
    {
        GenerateGrid();
        SpawnPath();
        EnemySetup();
    }

    public void ToggleBuildMode()
    {
        onBuildMode = !onBuildMode;
        Debug.Log(onBuildMode);
    }

    void GenerateGrid()
    {
        xLength = (_screenWidth + 2) * 2;
        yLength = (_screenHeight + 1) * 2;

        Grid = new GridObject[xLength, yLength];

        float xMidPoint = xLength / 2;
        float yMidPoint = yLength / 2;

        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                if (x >= xMidPoint - 1 && x <= xMidPoint + 1 && y >= yMidPoint - 1 && y <= yMidPoint + 1)
                {
                    Grid[x, y] = new GridObject(ObjectType.CenterTower, new Vector2(x, y));
                    Instantiate(_tilePrefab, HelperFunctions.GetScreenLocationBasedOnArrayPosition(x, y), Quaternion.identity, _tileParent.transform);
                }
                else
                {
                    Grid[x, y] = new GridObject(ObjectType.None, new Vector2(x, y));
                }
            }
        }

        _cam.transform.position = new Vector3((float)_screenWidth / 2 + 0.75f, (float)_screenHeight / 2 + 0.25f, -10);
    }

    void SpawnPath()
    {
        foreach (PathScriptableObject path in paths)
        {
            foreach (Vector2 point in path.pathPoints)
            {
                GameObject obj = Instantiate(_tilePrefab, HelperFunctions.GetScreenLocationBasedOnArrayPosition(point.x, point.y), Quaternion.identity, _tileParent.transform);
                obj.GetComponent<SpriteRenderer>().color = path.color;
            }
        }
    }

    void EnemySetup()
    {
        foreach(PathScriptableObject path in paths)
        {
            GameObject enemy = Instantiate(_enemy);
            Enemy enemyScript = enemy.AddComponent<Enemy>();
            enemyScript.SetupEnemy(path.wayPoints);
        }

    }

    #endregion

}
