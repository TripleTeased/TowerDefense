using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] 
    private Camera _camera;

    [SerializeField] 
    private GameObject _tower;

    [SerializeField]
    private GameObject _tileParent;

    public bool blankSpace = true;


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Grid = new GridObject[xLength, yLength];
            if (GridManager.Instance.onBuildMode && blankSpace)
            {
                Vector3 worldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

                worldPosition.x *= 2;
                worldPosition.x = Mathf.Round(worldPosition.x);
                worldPosition.x /= 2;

                worldPosition.y *= 2;
                worldPosition.y = Mathf.Round(worldPosition.y);
                worldPosition.y /= 2;

                Debug.Log("Tower made at: "+ worldPosition.x +", " + worldPosition.y);

                GameObject obj = Instantiate(_tower, new Vector2(worldPosition.x, worldPosition.y), Quaternion.identity);
                //GameObject obj = Instantiate(_tower, new Vector2(worldPosition.x, worldPosition.y), Quaternion.identity);//click tile to build a tower
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            blankSpace = true;
        }
    }

    public void checkIfEmpty()
    {
        blankSpace = false;
    }

    /*void OnMouseEnter()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void OnMouseExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }*/

}
