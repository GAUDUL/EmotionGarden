using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStackManager : MonoBehaviour
{
    private static Stack<string> sceneStack = new Stack<string>();
    public static SceneStackManager instance;
    
    private void Awake()
{
    if (instance != null && instance != this)
    {
        Destroy(this.gameObject);
        return;
    }
    instance = this;
    DontDestroyOnLoad(this.gameObject);
}

    public void EnterScene(string targetScene)
    {
        sceneStack.Push(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(targetScene);
    }
    
    public void Goback()
    {
        if (sceneStack.Count > 0)
        {
            SceneManager.LoadScene(sceneStack.Pop());
        }
    }
}
