using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    public void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int newScore)
    {
        _scoreText.text = "Score : " + newScore.ToString();
    }
}
