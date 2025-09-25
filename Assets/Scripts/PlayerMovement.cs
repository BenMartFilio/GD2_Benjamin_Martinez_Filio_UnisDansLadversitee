using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _movement;
    private bool _bstopMovement = true;

    [SerializeField] private float _vitesse = 2.0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        if (_bstopMovement)
        {

            _horizontalMovement = Input.GetAxis("Horizontal");
            _verticalMovement = Input.GetAxis("Vertical");
            _movement = new Vector3(_horizontalMovement, 0f, _verticalMovement);
            _movement.Normalize();
            _movement *= _vitesse;
            _movement.y = _rb.linearVelocity.y;
            

            if (_rb != null)
            {
                _rb.linearVelocity = _movement;
            }
            else
            {
                Debug.LogError("No RigidBody Attached !");
            }
        }


    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<DestroyCubeScript>() != null)
        {
            _bstopMovement = true;
            _rb.AddForce(_movement*-2);   //Mettre repoussement au contact  
            //_rb.AddExplosionForce(float 2, other.gameObject.GetComponent);
        }
        
        
    }


    
}
