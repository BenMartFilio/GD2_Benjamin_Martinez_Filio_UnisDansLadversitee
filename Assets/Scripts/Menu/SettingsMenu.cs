using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public bool isSettingsVisible = false;
    [SerializeField] public GameObject menu;
    [SerializeField] public GameObject settings;

    public void SetSettingsVisibility()
    {
        isSettingsVisible = true;
        CanvasGroup canvas = settings.GetComponent<CanvasGroup>();
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

    public void UnSetSettingsVisibility()
    {
        isSettingsVisible = false;
        CanvasGroup canvas = settings.GetComponent<CanvasGroup>();
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

    public void SetMenuVisibility()
    {
        PauseMenu pauseMenu = menu.GetComponent<PauseMenu>();
        pauseMenu.SetMenuVisibility();
    }

    public void UnSetMenuVisibility()
    {
        PauseMenu pauseMenu = menu.GetComponent<PauseMenu>();
        pauseMenu.UnSetMenuVisibility();
    }

    public void OpenSettings()
    {
        SetSettingsVisibility();
        UnSetMenuVisibility();
    }

    public void CloseSettings()
    {
        UnSetSettingsVisibility();
        SetMenuVisibility();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnSetSettingsVisibility();
        }
    }


    public void ApplyButton()
    {
        CloseSettings();
    }

    public void CancelButton()
    {
        CloseSettings();
    }
}
