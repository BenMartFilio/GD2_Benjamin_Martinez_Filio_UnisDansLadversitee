using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Rendering;

public class Commencer : MonoBehaviour
{

    [SerializeField] public Timer timer;



    void Start()
    {
        StartGame();
    }


    public void StartGame()
    { 
        StartCoroutine(DelayBeforeNewLevel(4));
    }

    IEnumerator DelayBeforeNewLevel(float delay)
    {
        PlayerMovement playerMove = GetComponent<PlayerMovement>();
        playerMove.StopMovement();
        timer = FindFirstObjectByType<Timer>();
        timer.DisableTimer();
        yield return new WaitForSeconds(delay);
        playerMove.StartMovement();

        if (timer != null)
        {
            timer.EnableTimer();
        }
        else
        {
            Debug.Log("TIMER IS NULL");
        }
        
    }
    

}
