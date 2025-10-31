using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    [SerializeField] public static float baseTemps = 5;
    public float temps = baseTemps; //Temps fixe pour LE PREMIER NIVEAU SEULEMENT
    [SerializeField] public TMP_Text timerText;
    [SerializeField] public GameObject fondFin;
    [SerializeField] private ScoreDatas _scoreData;
    public int tempsint;
    public int score = 0;
    public bool disabled = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        score = _scoreData.scoreValue;
        temps = Mathf.Clamp(temps - (score/5), 5, temps);
    }
        
    
    

    // Update is called once per frame
    void Update()
    {
        tempsint = Mathf.RoundToInt(temps);
        timerText.text = (tempsint + ""); 
        if (temps>=0 && disabled==false)
        {
            temps -= Time.deltaTime;
        }
        if (disabled == true)
        {

        }
        if (temps<=0 && disabled == false)
        {
            EndAffichage end = fondFin.GetComponent<EndAffichage>();
            end.LoseGame();
            disabled = true;
            
        }
    }

    public void DisableTimer()
    {
        disabled = true;
    }

    public void RestartTimer()
    {
        temps = 10;
        score = _scoreData.scoreValue;
        temps = Mathf.Clamp(temps - (score / 5), 5, temps); //Clamp pour ne pas que le temps tombe en dessous de 5 secondes
    }

    public void EnableTimer()
    {
        disabled = false;
    }
    public void BaseTimer()
    {
        temps = baseTemps;
    }
}
