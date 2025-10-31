using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _scoreGameOverText;
    [SerializeField] private TMP_Text _scoreBestText;
    [SerializeField] private ScoreDatas _scoreData;

    private static UIController triggerInstance;


    void Awake()
    {
        if (GetComponent<DONTDESTROY>() == null) 
        { 
            DontDestroyOnLoad(this);

            if (triggerInstance == null)
            {
                triggerInstance = this;
            }
            else
            {
                DestroyObject(gameObject);
            }
        }
    }


    private void OnEnable()
    {
        PlayerCollect.OnTargetCollected += UpdateScore;
    }

    private void OnDisable()
    {
        PlayerCollect.OnTargetCollected -= UpdateScore;
    }


    public void Start()
    {
           UpdateScore(_scoreData.scoreValue);
    }

    public void UpdateScore(int newScore)
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Score : " + newScore.ToString();
        }

        if (_scoreGameOverText != null)
        {
            _scoreGameOverText.text = "Score : " + newScore.ToString();
        }
        if (_scoreBestText != null)
        {
            _scoreBestText.text = "Best score : " + _scoreData.bestScore.ToString();
        }
    }
}
