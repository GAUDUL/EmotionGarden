using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Confirm : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    private Action onConfirm;

    void Awake()
    {
        yesButton.onClick.AddListener(() =>
        {
            onConfirm?.Invoke();
            gameObject.SetActive(false);
        });

        noButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        gameObject.SetActive(false);
    }

    public void Show(string message, Action confirmCallback)
    {
        messageText.text = message;
        onConfirm = confirmCallback;
        gameObject.SetActive(true);
    }
}
