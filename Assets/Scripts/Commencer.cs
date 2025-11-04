using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Commencer : MonoBehaviour
{

    [SerializeField] public Timer timer; 
    [SerializeField] public float timeToWait = 4f;
    [SerializeField] private UIController _uiControle;
    [SerializeField] private GameObject _uiController;
    public CanvasRenderer startText;


    void Start()
    {
        _uiControle = FindFirstObjectByType<UIController>();
        _uiController = _uiControle.gameObject;

        if (_uiController != null)
        {
            Transform child = _uiController.transform.Find("Commencez");
            if (child != null)
            {
                startText = child.GetComponent<CanvasRenderer>();

            }
            else
            {
                Debug.Log("L'enfant n'est pas trouvé");
            }
        }
        StartGame();
    }


    public void StartGame()
    { 
        StartCoroutine(DelayBeforeNewLevel(timeToWait));
    }

    IEnumerator DelayBeforeNewLevel(float delay)
    {
        PlayerMovement playerMove = GetComponent<PlayerMovement>();
        playerMove.StopMovement();
        timer = FindFirstObjectByType<Timer>();
        timer.DisableTimer();
        yield return new WaitForSeconds(delay-0.5f);
        
        ShowText();
        yield return new WaitForSeconds(0.5f);
        playerMove.StartMovement();

        if (timer != null)
        {
            timer.EnableTimer();
        }
        else
        {
            Debug.Log("TIMER IS NULL");
        }
        yield return new WaitForSeconds(1);
        HideText();
    }



    public void ShowText()
    {
        
        if (startText != null)
        {
            startText.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Text est nul");
        }
    }

    public void HideText()
    {
        if (startText != null)
        {
            startText.gameObject.SetActive(false);
        }
    }


}
