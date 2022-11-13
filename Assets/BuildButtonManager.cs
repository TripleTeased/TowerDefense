using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButtonManager : Singleton<BuildButtonManager>
{

    #region Properties

    [SerializeField]
    private Image _image;


    public Sprite hammerIcon;
    public Sprite closeIcon;

    public GameObject rockIcon;
    public GameObject paperIcon;
    public GameObject scissorIcon;

    public int towerType;

    #endregion


    #region Functions


        public void ToggleBuildMode()
    {
        GridManager.Instance.onBuildMode = !GridManager.Instance.onBuildMode;
        Debug.Log(GridManager.Instance.onBuildMode);

        if (GridManager.Instance.onBuildMode)
        {
            _image.sprite = closeIcon;
            rockIcon.SetActive(true);
            paperIcon.SetActive(true);
            scissorIcon.SetActive(true);
        } 
        else
        {
            _image.sprite = hammerIcon;
            rockIcon.SetActive(false);
            paperIcon.SetActive(false);
            scissorIcon.SetActive(false);
        }
    }


    public void OnRockClick()
    {
        towerType = 1;
        Debug.Log("CLICKED ROCK");
    }

    public void OnPaperClick()
    {
        towerType = 2;
        Debug.Log("CLICKED PAPER");   
    }

    public void OnScissorsClick()
    {
        towerType = 3;
        Debug.Log("CLICKED SCISSORS");
    }
    #endregion

}
