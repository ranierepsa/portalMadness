using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    int mapSize = 3;
    bool isEasyMode = false;

    public int MapSize { get => mapSize; set => mapSize = value; }
    public bool IsEasyMode { get => isEasyMode; set => isEasyMode = value; }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Game");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void InitialGameConfig()
    {
        SetMapSize();
        SetEasyMode();
    }

    private void SetMapSize()
    {
        int value = int.Parse(FindObjectOfType<InputField>().text);
        if (value >= 2 && value <= 10)
            MapSize = value;
    }

    private void SetEasyMode()
    {
        IsEasyMode = FindObjectOfType<Toggle>().isOn;
    }
}
