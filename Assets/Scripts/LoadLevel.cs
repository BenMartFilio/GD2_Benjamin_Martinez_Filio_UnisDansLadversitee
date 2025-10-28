using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void loadingLevels(int whichLevel)
    {
        SceneManager.LoadScene(whichLevel);
    }
}
