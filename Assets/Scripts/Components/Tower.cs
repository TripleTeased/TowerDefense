using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update

    public int towerType; //1 = rock 2 = paper 3 = scissors
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        BuildManager.Instance.checkIfTileOccupied();
        Debug.Log("Clicked\n");
    }
}
