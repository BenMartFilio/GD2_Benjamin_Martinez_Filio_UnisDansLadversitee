using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR       ///Fonction qui quitte l'éditeur si on est en mode édition, et l'application si le build est fait (le dièse sert au moment de la compilation (le code qui est dans le dièse n'est présent que s'il rempli la condition (ici le fait que l'on soit dans l'éditeur)))
        UnityEditor.EditorApplication.isPlaying = false;   
#endif
    }
}
