using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int EmotionPoints { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        LoadCharacterData();
    }

    private void LoadCharacterData()
    {
        EmotionPoints = DatabaseController.Instance.GetEmotionPoints();
    }

    public void AddEmotionPoints(int points)
    {
        EmotionPoints += points;
        DatabaseController.Instance.UpdateEmotionPoints(EmotionPoints);
    }
}
