using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    private bool isGameOver = false;
    public float rangeDecay = 10.0f;
    public Light light;
    public GameObject canvas;
    public ParticleSystem flameSystem;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        light.range -= rangeDecay * Time.deltaTime;

        if(light.range > 30)
        {
            light.range = 30.0f;
        }

        if(flameSystem.startSize > 0.0f)
        {
            flameSystem.startSize -= rangeDecay * Time.deltaTime / 2;
        }
        else if(flameSystem.startSize < 0.0f)
        {
            flameSystem.startSize = 0.0f;
        }

        if(flameSystem.startSize > 5.0f)
        {
            flameSystem.startSize = 5.0f;
        }

        if (light.range < 1)
        {
            StartCoroutine(Ui.instance.GameOverText("It is too dark", canvas));

            isGameOver = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGameOver)
        {
            GameManager.instance.PlayLevel("Menu");
        }
    }

    [System.Obsolete]
    public void FuelFlames(int numOfLogs)
    {
        light.range += numOfLogs * 20;
        flameSystem.startSize += numOfLogs * 10;
    }
}
