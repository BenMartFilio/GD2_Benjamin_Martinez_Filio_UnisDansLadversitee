using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private ScoreDatas _scoreData;
    [SerializeField] private UIController _uiController;   //lien fort entre les scripts (méthode de référence 1 pour update)
    private Image keyImage;
    public static Action<int> OnTargetCollected;

    public void UpdateScore(int value)
    {
        _scoreData.scoreValue = Mathf.Clamp(_scoreData.scoreValue + value, min:0, max: _scoreData.scoreValue + value);
        if (_scoreData.scoreValue > _scoreData.bestScore)
        {
            _scoreData.bestScore = _scoreData.scoreValue; //Défini le meilleur score du joueur
        }
        //_uiController.UpdateScore(_scoreData.scoreValue);  //cf. lien fort
        OnTargetCollected?.Invoke(_scoreData.scoreValue);
        Debug.Log(_scoreData.scoreValue);
    }
    

    void Start()
    {
        if (_uiController != null)
        {
            Transform child = _uiController.transform.Find("KeyImage");
            if (child != null)
            {
                keyImage = child.GetComponent<Image>();
            }
        }
    }
    public void ShowImage()
    {
        if (keyImage != null)
        {
            keyImage.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("IMAGE EST NULLE");
        }
    }

    public void HideImage()
    {
        if (keyImage != null)
        {
            keyImage.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("IMAGE EST NULLE");
        }
    }

}
