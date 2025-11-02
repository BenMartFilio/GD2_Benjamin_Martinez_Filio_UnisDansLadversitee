using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isMenuVisible = false;
    [SerializeField] public GameObject menu;


    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }

    public void SetMenuVisibility()
    {
        isMenuVisible = true;
        CanvasGroup canvas = menu.GetComponent<CanvasGroup>();
        if (canvas != null)
        {
            canvas.alpha = 1;
            canvas.blocksRaycasts = true;
        }
        else
        {
            Debug.Log("CANVAS IS NULL");
        }
    }

    public void UnSetMenuVisibility()
    {
        isMenuVisible = false;
        CanvasGroup canvas = menu.GetComponent<CanvasGroup>();
        if (canvas != null)
        {
            canvas.alpha = 0;
            canvas.blocksRaycasts = false;
        }
        else
        {
            Debug.Log("CANVAS IS NULL");
        }
    }


    public void BackToGame()
    {
        UnSetMenuVisibility();
        UnPauseGame();
    }



    public void IsThereMenu()
    {
         if (isMenuVisible == false)
         {
             SetMenuVisibility();
             PauseGame();
         }
         else if (isMenuVisible == true)
         {
             BackToGame();
         }
    }
    



    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           IsThereMenu();
        }
    }

}
