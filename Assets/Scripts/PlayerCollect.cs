using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private ScoreDatas _scoreData;
    [SerializeField] private UIController _uiController;   //lien fort entre les scripts (méthode de référence 1 pour update)
    [SerializeField] private GameObject _hudManager;
    private Image keyImage;
    public static Action<int> OnTargetCollected;
    public static Action OnKeyCollected;
    public bool haveKey = false;
    public int bonus = 0;

    public void UpdateScore(int value)
    {
        _scoreData.scoreValue = Mathf.Clamp(_scoreData.scoreValue + value + bonus, min:0, max: _scoreData.scoreValue + value + bonus);
        if (_scoreData.scoreValue > _scoreData.bestScore)
        {
            _scoreData.bestScore = _scoreData.scoreValue; //Défini le meilleur score du joueur
        }
        //_uiController.UpdateScore(_scoreData.scoreValue);  //cf. lien fort
        OnTargetCollected?.Invoke(_scoreData.scoreValue);
        bonus = 0;
        HideImage();
        Debug.Log(_scoreData.scoreValue);
    }
    

    void Start()
    {
        _uiController = FindFirstObjectByType<UIController>();
        _hudManager = _uiController.gameObject;
        if (_hudManager != null)
        {
            Transform child = _hudManager.transform.Find("KeyImage");
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
            haveKey = true;
        }
        else
        {
            Debug.Log("IMAGE EST NULLE");
        }
        OnKeyCollected?.Invoke();
    }

    public void HideImage()
    {
        if (keyImage != null)
        {
            keyImage.gameObject.SetActive(false);
            haveKey = false;
        }
        else
        {
            Debug.Log("IMAGE EST NULLE");
        }
    }


    public void UseKey()
    {
        if (haveKey)
        {
            bonus = 1;
            HideImage();
            Debug.Log("Clef utilisée");
        }
    }
}
