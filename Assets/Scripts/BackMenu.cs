using UnityEngine;

public class BackMenu : MonoBehaviour
{

    [SerializeField] public GameObject entreNiveau;
    

    public void BackToMenu()
    {
        LevelManager level = entreNiveau.GetComponent<LevelManager>();
        level.Lose();
    }
}
