using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
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
    public void OpenModal(GameObject modal)
    {
        if (modal != null)
            modal.SetActive(true);
    }

    public void CloseModal(GameObject modal)
    {
        if (modal != null)
            modal.SetActive(false);
    }
}
