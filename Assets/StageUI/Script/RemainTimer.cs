using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainTimer : MonoBehaviour
{
    [SerializeField] float gameTime = 20.0f;
    Text uiText;
    float currentTime;
    void Start()
    {
        uiText = GetComponent<Text>();
        currentTime = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0.0f)
        {
            currentTime = 0.0f;
            //Œã‚ÅƒVƒ“Ø‚è‘Ö‚¦’Ç‰Á‚·‚é
        }
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        int mseconds = Mathf.FloorToInt((currentTime - minutes * 60 - seconds) * 1000);
        uiText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, mseconds);
    }
}
