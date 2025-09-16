using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private ScoreDatas _scoreData;

    public void UpdateScore(int value)
    {
        _scoreData.scoreValue = Mathf.Clamp(_scoreData.scoreValue + value, min:0, max: _scoreData.scoreValue + value);
        Debug.Log(_scoreData.scoreValue);
    }
}
