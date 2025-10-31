using UnityEngine;

public class BackMenu : MonoBehaviour
{

    [SerializeField] public GameObject entreNiveau;
    

    public void BackToMenu()
    {
        EndAffichage end = GetComponent<EndAffichage>();
        end.DisableEnd();
        ResetScore reset = GetComponent<ResetScore>();
        reset.Reset();
        LevelManager level = entreNiveau.GetComponent<LevelManager>();
        level.Lose();
    }
}
