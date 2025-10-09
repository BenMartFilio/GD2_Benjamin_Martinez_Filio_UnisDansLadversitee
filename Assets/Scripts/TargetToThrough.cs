using System.Collections;
using UnityEngine;

public class TargetToThrough : MonoBehaviour
{
    [SerializeField] private int _targetValue = 1;
    [SerializeField] private float _shadowDuration = 3f;
    private float _shadowTimer = 0f;
    private bool _isInShadow = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerCollect>() != null)
        {
            other.gameObject.GetComponent<PlayerCollect>().UpdateScore(_targetValue);
           // Destroy(gameObject);
            //TODO : Hide Target
            ToggleVisivility(false);
            //_isInShadow = true;
            //TODO : Start Timer
            StartCoroutine(ShadowTimerControl());
        }
    }


    private void ToggleVisivility(bool newVisibility)
    {
        GetComponent<MeshRenderer>().enabled = newVisibility;
        GetComponent<Collider>().enabled = newVisibility;
    }

    //TODO : timer by deltatime

    
    
    /*private void Update()
    {
        _shadowTimer += Time.deltaTime;
        if (_isInShadow) 
        {
            _shadowTimer += Time.deltaTime;
            if (_shadowTimer >= _shadowDuration)
            {
                //Show Target
                ToggleVisivility(true);
                //Stop Timer
                _shadowTimer = 0f;
                _isInShadow = false;
           }
        }
    }*/

    //TODO : Timer by coroutine
    private IEnumerator ShadowTimerControl()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(_shadowDuration);   //Comme c'est une coroutine, ce ne s'arrête pas au return
        ToggleVisivility(true);
    }

}
