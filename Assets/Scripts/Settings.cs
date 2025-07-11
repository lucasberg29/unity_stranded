using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetInt("volume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateVolume()
    {
        int newValue = (int)volumeSlider.value;
        Debug.Log("Slider moved: New volume is " + newValue);
        PlayerPrefs.SetInt("volume", newValue);
    }
}
