using UnityEngine;

public class Flash : MonoBehaviour
{
    public GameObject flashEffect; // Silah�n ucundaki flash efekti GameObject'i

    void Update()
    {
        // Ate� etme kontrol�
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        // Flash efektini aktifle�tir
        if (flashEffect != null)
        {
            flashEffect.SetActive(true);
            // Ard�ndan flash efektini belirli bir s�re sonra devre d��� b�rak�n
            Invoke("DisableFlashEffect", 0.1f);
        }
    }

    void DisableFlashEffect()
    {
        // Flash efektini devre d��� b�rak
        flashEffect.SetActive(false);
    }
}
