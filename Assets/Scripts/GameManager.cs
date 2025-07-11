using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.SceneManagement.SceneManager;

public class GameManager : MonoBehaviour
{
    private Scene currentScene;

    [Header("Current Scene")]
    [SerializeField]
    //private string currentSceneName = "";

    [Header("Game Settings")]
    public float volume = 10;

    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        PlayerPrefs.SetInt("playerRecord", 0);
        //PlayerPrefs.SetInt("volume", 10);
    }

    public void PlayLevel(int level)
    {
        LoadScene(level);
        currentScene = GetSceneByBuildIndex(level);
    }

    public void PlayLevel(string level)
    {
        LoadScene(level);
        currentScene = GetSceneByName(level);
    }

    public Scene GetCurrentScene()
    {
        return currentScene;
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public void updateVolume(int newVolume)
    {
        volume = newVolume;
        PlayerPrefs.SetInt("volume", newVolume);
    }
}
