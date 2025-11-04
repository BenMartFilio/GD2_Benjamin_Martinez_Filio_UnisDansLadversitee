using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerCollect>() != null)
        {
            other.gameObject.GetComponent<PlayerCollect>().ShowImage();
            Destroy(gameObject);
        }
    }
}
