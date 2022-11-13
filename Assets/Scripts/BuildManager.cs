using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : Singleton<BuildManager>
{

    [SerializeField] 
    private Camera _camera;

    [SerializeField] 
    private GameObject _tower;

    [SerializeField]
    private GameObject _towerParent;

    [SerializeField]
    private int _towerType = 1; //1 = rock 2 = paper 3 = scissors

    [SerializeField]
    private Text _partsCounterText;
    private int _partsCounter = 0; 

    public bool buildableTile = true;

    private int _towerCount = 1;

    public Collider2D[] neighborColliders; //will store an array of colliders that are around where we wanna build


    // Start is called before the first frame update
    void Start()
    {

    }


    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        _partsCounterText.text = _partsCounter.ToString(); //updates partCounter UI

        if (Input.GetMouseButtonDown(0))
        {
            if (GridManager.Instance.onBuildMode && buildableTile)
            {
                Vector2 worldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

                worldPosition.x *= 2;
                worldPosition.x = Mathf.Round(worldPosition.x);
                worldPosition.x /= 2;

                worldPosition.y *= 2;
                worldPosition.y = Mathf.Round(worldPosition.y);
                worldPosition.y /= 2;

                neighborColliders = Physics2D.OverlapCircleAll(worldPosition, 0.5f); //stores a list of colliders that are near the tile you select

                for(int i = 0; i < neighborColliders.Length; i++) //loops through the stored list
                {
                    if (neighborColliders[i].tag == "Path") //if anything in the list is tagged as a path...
                    {
                        Debug.Log("Tower made at: " + worldPosition.x + ", " + worldPosition.y);
                        GameObject obj = Instantiate(_tower, new Vector2(worldPosition.x, worldPosition.y), Quaternion.identity, _towerParent.transform); //you can make a tower!
                        Debug.Log("Tower type being created:" + BuildButtonManager.Instance.towerType);
                        obj.GetComponent<Tower>().towerType = BuildButtonManager.Instance.towerType; 
                        obj.name = "Tower: " + _towerCount;
                        _towerCount++;
                        break;
                    }
                    else //otherwise....
                    {
                        Debug.Log("No path neighbors!"); //NOTHING 
                    }
                }

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