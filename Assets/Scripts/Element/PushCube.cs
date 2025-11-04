using UnityEngine;

public class PushCube : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float forcePoussee = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation; 
    }

    private void OnCollisionStay(Collision collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player == null)
        {
            return;
        }

        Vector3 pousseeDirection = new Vector3(collision.contacts[0].normal.x, 0, collision.contacts[0].normal.z);
        rb.AddForce(-pousseeDirection * forcePoussee, ForceMode.Force);
    }
}
