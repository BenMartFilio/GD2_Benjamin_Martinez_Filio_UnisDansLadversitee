using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _movement;
    private bool _bstopMovement = true;
    private float impulseValue = 1f;
    private int _typeOfDeplacement = 0;  //Nombre qui correspond à comment va fonctionner le mouvement (en 3D avec zqsd, en 2D avec q et d etc.) 

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
            if (_typeOfDeplacement == 0)
            {
                _movement = new Vector3(_horizontalMovement, 0f, _verticalMovement);
            }
            else if (_typeOfDeplacement == 1)
            {
                _movement = new Vector3(_horizontalMovement, 0f, 0f);
            }

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
            _bstopMovement = false;
            _rb.AddForce(_movement* impulseValue,ForceMode.Impulse);   //Mettre repoussement au contact  
                                                                       //_rb.AddExplosionForce(float 2, other.gameObject.GetComponent);
            Debug.Log("BOSS");

           StartCoroutine(DelayThenFall(1.0f));

           IEnumerator DelayThenFall(float delay) //Délais après une collision pour lequel le joueur ne peut plus bouger
            {
                yield return new WaitForSeconds (delay);
                _bstopMovement = true;
                Debug.Log("HEY");
                //   Fall = true;
                //  Animator.SetBool("Fall", Fall);
            }

            

        }
        
        
    }


    
}
