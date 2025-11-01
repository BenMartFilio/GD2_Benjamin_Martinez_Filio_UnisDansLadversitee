using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _movement;
    private bool _bstopMovement = false;
    private float impulseValue = 1f;
    private int _typeOfDeplacement = 0;  //Nombre qui correspond à comment va fonctionner le mouvement (en 3D avec zqsd, en 2D avec q et d etc.) 
    private Vector3 _grappinDirection;
    private Vector3 _grappintHit; 


    [SerializeField] private float _vitesse = 2.0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        GrappinUpdateDirection(_movement);
        if (_bstopMovement == false)
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



            if (Input.GetKeyDown(KeyCode.G))
            {
                TryThrowGrappin();
            }

            if (Input.GetKeyUp(KeyCode.G))
            {
                ThrowGrappin();
            }

        }


    }

    

    private void GrappinUpdateDirection(Vector3 direction)
    {
        if (direction.sqrMagnitude > 0.1f)
        {
            _grappinDirection = direction;
        }
    }

   

    private void TryThrowGrappin()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,_grappinDirection, out hit, maxDistance:100f))
        {
            _grappintHit = hit.point+hit.normal*1.5f;
        }
    }

    private void ThrowGrappin()
    {
        transform.position = _grappintHit;
        _grappinDirection = Vector3.zero;
    }



 //   private void OnCollisionEnter(Collision other)
 //   {
  //      if (other.gameObject.GetComponent<DestroyCubeScript>() != null)
 //       {
  //          _bstopMovement = false;
  //          _rb.AddForce(_movement* impulseValue,ForceMode.Impulse);   //Mettre repoussement au contact  
                                                                       //_rb.AddExplosionForce(float 2, other.gameObject.GetComponent);
     //       Debug.Log("BOSS");

    //       StartCoroutine(DelayThenFall(1.0f));

   //        IEnumerator DelayThenFall(float delay) //Délais après une collision pour lequel le joueur ne peut plus bouger
 //           {
   //             yield return new WaitForSeconds (delay);
  //              _bstopMovement = true;
   //             Debug.Log("HEY");
                
  //          }

            

    //    }
        
        
  //  }




    // DESACTIVATION DU MOUVEMENT ET REACTIVATION

    private void OnEnable()
    {
        PlayerCollect.OnTargetCollected += ReactionEndLevel;
    }

    private void OnDisable()
    {
        PlayerCollect.OnTargetCollected -= ReactionEndLevel;
    }



    public void ReactionEndLevel(int newScore)
    {
        _bstopMovement = true;
    //    _rb.AddForce(_movement * impulseValue, ForceMode.Impulse);   //Mettre repoussement au contact  
                                                                     //_rb.AddExplosionForce(float 2, other.gameObject.GetComponent

        StartCoroutine(DelayThenFall(2.5f));

        IEnumerator DelayThenFall(float delay) //Délais après une collision pour lequel le joueur ne peut plus bouger
        {
            yield return new WaitForSeconds(delay);
   //         _bstopMovement = false;
           

        }

    }

    public void StopMovement()
    {
        _bstopMovement = true;
    }

    public void StartMovement()
    {
        _bstopMovement = false;
    }

}
