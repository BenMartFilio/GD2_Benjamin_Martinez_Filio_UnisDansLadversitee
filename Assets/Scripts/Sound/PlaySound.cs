using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public void playSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }
    }
}
