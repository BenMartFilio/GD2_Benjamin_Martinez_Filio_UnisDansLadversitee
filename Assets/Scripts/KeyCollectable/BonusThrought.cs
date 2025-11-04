using UnityEngine;

public class BonusThrought : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerCollect>() != null)
        {
            if (other.gameObject.GetComponent<PlayerCollect>().haveKey)
            {
                other.gameObject.GetComponent<PlayerCollect>().UseKey();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Pas de clef");
            }
            
        }
    }
}
