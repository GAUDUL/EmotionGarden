using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;
    void Start()
    {
        UpdatePointsUI();
    }

    void Update()
    {
        UpdatePointsUI();
    }
    
    void UpdatePointsUI()
    {
        pointsText.text = $"감정포인트: {GameManager.Instance.EmotionPoints}";
    }
}
