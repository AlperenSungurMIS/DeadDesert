using UnityEngine;

public class Flash : MonoBehaviour
{
    public GameObject flashEffect; // Silahýn ucundaki flash efekti GameObject'i

    void Update()
    {
        // Ateþ etme kontrolü
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        // Flash efektini aktifleþtir
        if (flashEffect != null)
        {
            flashEffect.SetActive(true);
            // Ardýndan flash efektini belirli bir süre sonra devre dýþý býrakýn
            Invoke("DisableFlashEffect", 0.1f);
        }
    }

    void DisableFlashEffect()
    {
        // Flash efektini devre dýþý býrak
        flashEffect.SetActive(false);
    }
}
