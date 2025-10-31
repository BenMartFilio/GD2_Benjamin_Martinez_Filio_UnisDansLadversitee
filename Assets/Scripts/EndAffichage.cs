using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Rendering;

public class EndAffichage : MonoBehaviour
{
    private float aValue = 0f;
    private CanvasGroup trans;
    [SerializeField] public float transitionDuree = 1.5f; //temps pour lequel l'écran apparait
    [SerializeField] private TMP_Text _scoreText; //Score
    [SerializeField] public GameObject entreNiveau;
    [SerializeField] public float dureeBeforeEnd;


    public void endOfGame()
    {
        trans = GetComponent<CanvasGroup>();
        trans.alpha = aValue;

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

    //    private void OnEnable()
    //   {
    //       PlayerCollect.OnTargetCollected += ReactionEndLevel;
    //   }

    //   private void OnDisable()
    //   {
    //       PlayerCollect.OnTargetCollected -= ReactionEndLevel;
    //   }


    //    public void Start()
    //    {
    //        ReactionEndLevel(0);
    //    }

    //  public void ReactionEndLevel(int newScore)
    // {
    //      endOfGame();
    //     _scoreText.text = "Score : " + newScore.ToString();
    // }


    public void LoseGame()
    {
        endOfGame();

    }




    

}
