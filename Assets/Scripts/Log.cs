using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public float movementSpeed;
    public float minY;
    public float maxY;

    public GameObject canvas;

    private void Start()
    {

    }

    public void ToggleInteractionPopUp(bool isInReach)
    {
        if (isInReach)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }

}
