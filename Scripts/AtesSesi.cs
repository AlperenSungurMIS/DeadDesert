using UnityEngine;

public class AtesSesi : MonoBehaviour
{
    public AudioSource gunshotSound; // Ate� sesi i�in AudioSource bile�eni

    void Update()
    {
        // Sol t�klama kontrol�
        if (Input.GetMouseButtonDown(0))
        {
            PlayGunshotSound();
        }
    }

    void PlayGunshotSound()
    {
        // Ate� sesini �al
        if (gunshotSound != null)
        {
            gunshotSound.Play();
        }
    }
}