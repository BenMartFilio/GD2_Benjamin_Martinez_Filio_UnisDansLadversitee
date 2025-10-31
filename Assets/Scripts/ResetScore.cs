using UnityEngine;

public class ResetScore : MonoBehaviour
{

    [SerializeField] private ScoreDatas _scoreData;
    
    void Start()
    {
        _scoreData.scoreValue = 0;
    }
    public void Reset()
    {
        _scoreData.scoreValue = 0;
    }
    
}