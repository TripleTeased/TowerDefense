using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButtonManager : MonoBehaviour
{

    #region Properties

    [SerializeField]
    private Image _image;


    public Sprite hammerIcon;
    public Sprite closeIcon;

    public GameObject rockIcon;
    public GameObject paperIcon;
    public GameObject scissorIcon;

    private GameObject _rockIcon;
    private GameObject _paperIcon;
    private GameObject _scissorIcon;

    #endregion


    #region Functions

    public void ToggleBuildMode()
    {
        GridManager.Instance.onBuildMode = !GridManager.Instance.onBuildMode;
        Debug.Log(GridManager.Instance.onBuildMode);

        if (GridManager.Instance.onBuildMode)
        {
            _image.sprite = closeIcon;
            _rockIcon = Instantiate(rockIcon, transform.parent);
            _paperIcon = Instantiate(paperIcon, transform.parent);
            _scissorIcon = Instantiate(scissorIcon, transform.parent);
        } 
        else
        {
            _image.sprite = hammerIcon;
            Destroy(_rockIcon);
            Destroy(_paperIcon);
            Destroy(_scissorIcon);
        }
    }

    #endregion

}
