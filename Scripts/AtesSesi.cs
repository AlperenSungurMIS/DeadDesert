using UnityEngine;

public class AtesSesi : MonoBehaviour
{
    public AudioSource gunshotSound; // Ateþ sesi için AudioSource bileþeni

    void Update()
    {
        // Sol týklama kontrolü
        if (Input.GetMouseButtonDown(0))
        {
            PlayGunshotSound();
        }
    }

    void PlayGunshotSound()
    {
        // Ateþ sesini çal
        if (gunshotSound != null)
        {
            gunshotSound.Play();
        }
    }
}