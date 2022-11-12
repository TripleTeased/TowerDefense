using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseEnter()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void OnMouseExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        BuildManager.Instance.checkIfTileOccupied();
        Debug.Log("Pathway at this location");
    }
}
