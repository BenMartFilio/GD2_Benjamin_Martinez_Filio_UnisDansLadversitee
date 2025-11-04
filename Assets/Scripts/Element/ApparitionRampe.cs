using UnityEngine;
using System.Collections;

public class ApparitionRampe : MonoBehaviour
{
    [SerializeField] public PressurePlate pressurePlate; 
    [SerializeField] public Transform rampe;
    public float vitesseDePositionnement = 2f;
    public Vector3 bassePosition;
    public Vector3 hautePosition;
    private bool _bMonte = false;
    private Coroutine moveRoutine;

    void Start()
    {
        bassePosition = new Vector3(transform.position.x, bassePosition.y, transform.position.z);
        hautePosition = new Vector3(transform.position.x, hautePosition.y, transform.position.z);
        if (pressurePlate != null)
        {
            pressurePlate.ifPressed.AddListener(() => MouvementRampe(true));
            pressurePlate.ifReleased.AddListener(() => MouvementRampe(false));    // expression lambda (les () sont une sorte de fonction, qui appelle une autre fonction (grâce à =>), et cela exécute donc cette autre fonction)
        }
    }


    public void MouvementRampe(bool hauteur)
    {
        _bMonte = hauteur;
        if (moveRoutine != null)
        {
            StopCoroutine(moveRoutine);
        }
        moveRoutine = StartCoroutine(MoveRamp());
    }

    private IEnumerator MoveRamp()
    {
        Vector3 target = _bMonte ? hautePosition : bassePosition;  // en fonction de la valeur de _bMonte, target a la valeur de haute position ou de basse position

        while (Vector3.Distance(rampe.position, target) > 0.01f)
        {
            rampe.position = Vector3.MoveTowards(rampe.position, target, Time.deltaTime * vitesseDePositionnement);
            yield return null;

            Vector3 newTarget = _bMonte ? hautePosition : bassePosition;
            if (newTarget != target)
            {
                target = newTarget;
            }
        }
        rampe.position = target; 
    }
}
