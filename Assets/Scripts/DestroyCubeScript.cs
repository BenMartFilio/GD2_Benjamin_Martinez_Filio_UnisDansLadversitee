using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class DestroyCubeScript : MonoBehaviour
{
    private int _life = 5;  //Vie du cube
    [SerializeField] private int _score = 1; //Score que rapporte le cube
    public float bonus = 1; //Bonus qui peut affecter le score
    private int _trueScore; //Score*bonus


    private void OnCollisionEnter(Collision other)
    {
        _trueScore = ((int)Math.Floor(_score * bonus));

        Debug.Log("Touché !");
        
        if(other.gameObject.GetComponent<PlayerCollect>() != null)
        {
            if (_life > 1)
            {
                _life--;
            }
            else
            {
                other.gameObject.GetComponent<PlayerCollect>().UpdateScore(_trueScore); 
                Destroy(gameObject);

            }
        }
       
    }

}
