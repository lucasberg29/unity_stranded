using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public static Ui instance;

    private void Awake()
    {
        instance = this;
    }

    public TextMeshProUGUI text;

    public IEnumerator FadeText()
    {
        if (text != null)
        {
            Color textColor = text.color;

            for (float alpha = 1.0f; alpha >= 0; alpha -= 0.45f * Time.deltaTime)
            {
                textColor.a = alpha;
                text.color = textColor;
                yield return null;
            }
        }
    }

    public IEnumerator GameOverText(string text, GameObject canvas)
    {
        Image image = canvas.GetComponentInChildren<Image>();
        TextMeshProUGUI gameOverText = image.GetComponentInChildren<TextMeshProUGUI>();
        gameOverText.text = text;

        Color imageColor = image.color;
        Color textColor  = gameOverText.color;

        for (float alpha = 0.0f; alpha <= 1.0f; alpha += 0.45f * Time.deltaTime)
        {
            imageColor.a = alpha * 2;
            textColor.a = alpha / 2;

            image.color = imageColor;
            gameOverText.color = textColor;

            yield return null;
        }
    }
}
