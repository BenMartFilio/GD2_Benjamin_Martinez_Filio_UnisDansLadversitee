using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public string requiredComponentName = "PlayerController";
    private int numberOfObject = 0;  // nombre d'objets sur la plaque (pour ne pas répéter deux fois l'évènements, et pour le laisser activé tant qu'il y a un élément dessus)
    public UnityEvent ifPressed;
    public UnityEvent ifReleased;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CanActivatePressurePlate>() != null)
        {
            numberOfObject += 1;
            if (numberOfObject == 1)
            {
                ifPressed.Invoke();
                Debug.Log("SUR LA PLAQUE");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CanActivatePressurePlate>() != null)
        {
            numberOfObject -= 1;

            if (numberOfObject <= 0)
            {
                numberOfObject = 0;
                ifReleased.Invoke();
                Debug.Log("PLUS SUR LA PLAQUE");
            }
        }
    }

    
}
