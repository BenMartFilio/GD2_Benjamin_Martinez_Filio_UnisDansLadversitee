using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Rendering;

public class TriggerEndLevel : MonoBehaviour
{
    private float aValue = 0f;
    private CanvasGroup trans;
    [SerializeField] public float transitionDuree = 1.5f; //temps pour lequel l'écran apparait
    [SerializeField] private TMP_Text _scoreText; //Score
    [SerializeField] public float dureeBetweenLevels;
    [SerializeField] public int whichLevel;
    

    public void ChangeLevelCall()
    {
        trans = GetComponent<CanvasGroup>();
        trans.alpha = aValue;
        Timer timer = GetComponent<Timer>();
        timer.DisableTimer();
        StartCoroutine(IncreaseOpacity());

    }

    private IEnumerator IncreaseOpacity()
    {
        float temps = 0f;

        while (temps < transitionDuree)
        {
            temps += Time.deltaTime;
            aValue = Mathf.Lerp(0f, 1f, temps / transitionDuree);
            trans.alpha = aValue;
            yield return null;
        }
        StartCoroutine(DelayBeforeNewLevel(dureeBetweenLevels));
    }
    private IEnumerator DecreaseOpacity()
    {
        float temps = 0f;

        while (temps < transitionDuree)
        {
            temps += Time.deltaTime;
            aValue = Mathf.Lerp(1f, 0f, temps / transitionDuree);
            trans.alpha = aValue;
            yield return null;
        }
        

    }

    private void OnEnable()
    {
        PlayerCollect.OnTargetCollected += ReactionEndLevel;
    }

    private void OnDisable()
    {
        PlayerCollect.OnTargetCollected -= ReactionEndLevel;
    }


//    public void Start()
 //   {
 //       ReactionEndLevel(0);
 //   }

    public void ReactionEndLevel(int newScore)
    {
        ChangeLevelCall();
        _scoreText.text = "Score : " + newScore.ToString();
        

    }


    

    IEnumerator DelayBeforeNewLevel(float delay) 
    {

        LevelManager level = GetComponent<LevelManager>();
        level.LoadANewLevel(whichLevel);
        Timer timer = GetComponent<Timer>();
        timer.RestartTimer();
        yield return new WaitForSeconds(delay);
        StartCoroutine(DecreaseOpacity());
       // timer.EnableTimer();
           
        // LevelManager.Instance.LoadANewLevel();
    }

}
