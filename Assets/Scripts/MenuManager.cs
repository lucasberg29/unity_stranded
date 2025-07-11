using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Animator playerAnimation;

    void Start()
    {
        int volume = PlayerPrefs.GetInt("volume");
        Debug.Log("Menu started: volume is " + volume);

        
        playerAnimation.SetLayerWeight(1, 1.0f);
    }
}
