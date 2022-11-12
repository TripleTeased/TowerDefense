using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : Singleton<BuildManager>
{

    [SerializeField] 
    private Camera _camera;

    [SerializeField] 
    private GameObject _tower;

    [SerializeField]
    private GameObject _towerParent;

    public bool buildableTile = true;

    private int _towerCount = 1; 


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GridManager.Instance.onBuildMode && buildableTile)
            {
                Vector3 worldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

                worldPosition.x *= 2;
                worldPosition.x = Mathf.Round(worldPosition.x);
                worldPosition.x /= 2;

                worldPosition.y *= 2;
                worldPosition.y = Mathf.Round(worldPosition.y);
                worldPosition.y /= 2;

                Debug.Log("Tower made at: "+ worldPosition.x +", " + worldPosition.y);

                GameObject obj = Instantiate(_tower, new Vector2(worldPosition.x, worldPosition.y), Quaternion.identity, _towerParent.transform);
                obj.name ="Tower: "+_towerCount;
                _towerCount++;
                //GameObject obj = Instantiate(_tower, new Vector2(worldPosition.x, worldPosition.y), Quaternion.identity);//click tile to build a tower
            }
        }
        if (Input.GetMouseButtonUp(0)) //reset boolean when mousebutton up
        {
            buildableTile = true;
        }
    }

    public void checkIfTileOccupied() //if there is something on the tile you click on in build mode
    {
        buildableTile = false; //no building
    }
}
