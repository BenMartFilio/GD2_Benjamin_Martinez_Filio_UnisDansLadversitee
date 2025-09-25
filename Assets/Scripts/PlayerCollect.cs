using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private ScoreDatas _scoreData;
    [SerializeField] private UIController _uiController;   //lien fort entre les scripts (méthode de référence 1 pour update)

    public void UpdateScore(int value)
    {
        _scoreData.scoreValue = Mathf.Clamp(_scoreData.scoreValue + value, min:0, max: _scoreData.scoreValue + value);
        _uiController.UpdateScore(_scoreData.scoreValue);  //cf. lien fort
        Debug.Log(_scoreData.scoreValue);
    }
}
