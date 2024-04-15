using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    public float moveSpeed = 5f; // Oyuncunun hareket hýzý
    public float jumpForce = 10f; // Zýplama kuvveti
    private bool isGrounded; // Zeminde olup olmadýðýný kontrol etmek için
    public float rotationSpeed = 5f; // Silah dönme hýzý
    public float verticalLookRange = 60f; // Yukarý aþaðý bakma aralýðý
    private float verticalRotation = 0f; // Dikey dönüþ açýsý
    public GameObject flashEffect; // Silahýn ucundaki flash efekti GameObject'i
    

    void Update()
    {
        // Oyuncunun giriþleri al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket vektörünü oluþtur
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Oyuncuyu hareket ettir
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Silahý döndür
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        RotateGun(mouseX);
        RotateCamera(mouseY);

        // Zýplama kontrolü
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Ateþ etme kontrolü
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Jump()
    {
        // Zýplama kuvvetini uygula
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    // Zeminde olup olmadýðýný kontrol et
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            isGrounded = true;
        }
    }

    void RotateGun(float mouseX)
    {
        // Yatay (horizontal) mouse hareketine göre silahý döndür
        transform.Translate(Vector3.up * mouseX * rotationSpeed);
    }

    void RotateCamera(float mouseY)
    {
        // Dikey (vertical) mouse hareketine göre kamera ve oyuncuyu döndür
        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookRange, verticalLookRange);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    void Fire()
    {
        // Ateþ etme kodu
        // Örneðin:
        // Debug.Log("Ateþ edildi!");

        // Ateþ sesini çal
        
    }

    void DisableFlashEffect()
    {
        // Flash efektini devre dýþý býrak
        flashEffect.SetActive(false);
    }
}