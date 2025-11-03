using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneButtonManager : MonoBehaviour
{
    public void LoadScene(string targetScene){
        SceneManager.LoadScene(targetScene);
    }
}
