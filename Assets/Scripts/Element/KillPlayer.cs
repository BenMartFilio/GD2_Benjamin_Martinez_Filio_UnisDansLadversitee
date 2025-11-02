using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    [SerializeField] public Timer timer;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            timer = FindFirstObjectByType<Timer>();
            timer.temps = 0;
        }
    }
}
