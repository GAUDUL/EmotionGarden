using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButton : MonoBehaviour
{
    [SerializeField] string targetScene;

    public void OnClick()
    {
        SceneStackManager.instance.EnterScene(targetScene);
    }

    public void OnBackButtonClick()
{
    SceneStackManager.instance.Goback();
}
}
