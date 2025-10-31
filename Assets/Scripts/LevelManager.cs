using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadANewLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Lose()
    {
        LoadANewLevel(0);
    }
}
