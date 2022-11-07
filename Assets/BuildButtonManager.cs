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

    #endregion


    #region Functions

    public void ToggleBuildMode()
    {
        GridManager.Instance.onBuildMode = !GridManager.Instance.onBuildMode;
        Debug.Log(GridManager.Instance.onBuildMode);

        if (GridManager.Instance.onBuildMode)
        {
            _image.sprite = closeIcon;
        } 
        else
        {
            _image.sprite = hammerIcon;
        }
    }

    #endregion

}
