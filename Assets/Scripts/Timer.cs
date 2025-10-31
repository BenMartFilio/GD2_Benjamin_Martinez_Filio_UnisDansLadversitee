using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{

    [SerializeField] public float temps = 15;
    [SerializeField] public TMP_Text timerText;
    [SerializeField] public GameObject fondFin;
    public int tempsint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempsint = Mathf.RoundToInt(temps);
        timerText.text = (tempsint + ""); 
        if(temps>=0)
        {
            temps -= Time.deltaTime;
        }
        else
        {
            EndAffichage end = fondFin.GetComponent<EndAffichage>();
            end.LoseGame();
        }
    }
}
