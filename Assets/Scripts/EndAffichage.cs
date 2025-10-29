using UnityEngine;
using System.Collections;

public class EndAffichage : MonoBehaviour
{
    private float aValue = 0f;
    private CanvasGroup trans;
    [SerializeField] public float transitionDuration = 1.5f; //temps pour lequel l'écran apparait

    
    public void endOfGame()
    {
        trans = GetComponent<CanvasGroup>();
        trans.alpha = aValue;


        StartCoroutine(DecreaseOpacity());
    }

    private IEnumerator DecreaseOpacity()
    {
        float temps = 0f;

        while (temps < transitionDuration)
        {
            temps += Time.deltaTime;
            aValue = Mathf.Lerp(0f, 1f, temps / transitionDuration);
            trans.alpha = aValue;
            yield return null;
        }
        
    }

}
