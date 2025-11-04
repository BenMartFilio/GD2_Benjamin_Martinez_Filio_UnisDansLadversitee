using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Effect : MonoBehaviour
{

    [SerializeField] public float timeUnderEffect = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerCollect>() != null)
        {
            StartCoroutine(TempEffect(timeUnderEffect, other));
        }
    }

    IEnumerator TempEffect(float delay, Collider other)
    {
        other.gameObject.GetComponent<PlayerMovement>().SlowVitesse();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(delay);
        other.gameObject.GetComponent<PlayerMovement>().NormalVitesse();
        Destroy(gameObject);
    }

}
