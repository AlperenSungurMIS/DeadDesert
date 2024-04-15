using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    public float moveSpeed = 5f; // Oyuncunun hareket h�z�
    public float jumpForce = 10f; // Z�plama kuvveti
    private bool isGrounded; // Zeminde olup olmad���n� kontrol etmek i�in
    public float rotationSpeed = 5f; // Silah d�nme h�z�
    public float verticalLookRange = 60f; // Yukar� a�a�� bakma aral���
    private float verticalRotation = 0f; // Dikey d�n�� a��s�
    public GameObject flashEffect; // Silah�n ucundaki flash efekti GameObject'i
    

    void Update()
    {
        // Oyuncunun giri�leri al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket vekt�r�n� olu�tur
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Oyuncuyu hareket ettir
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Silah� d�nd�r
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        RotateGun(mouseX);
        RotateCamera(mouseY);

        // Z�plama kontrol�
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Ate� etme kontrol�
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Jump()
    {
        // Z�plama kuvvetini uygula
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    // Zeminde olup olmad���n� kontrol et
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            isGrounded = true;
        }
    }

    void RotateGun(float mouseX)
    {
        // Yatay (horizontal) mouse hareketine g�re silah� d�nd�r
        transform.Translate(Vector3.up * mouseX * rotationSpeed);
    }

    void RotateCamera(float mouseY)
    {
        // Dikey (vertical) mouse hareketine g�re kamera ve oyuncuyu d�nd�r
        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookRange, verticalLookRange);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    void Fire()
    {
        // Ate� etme kodu
        // �rne�in:
        // Debug.Log("Ate� edildi!");

        // Ate� sesini �al
        
    }

    void DisableFlashEffect()
    {
        // Flash efektini devre d��� b�rak
        flashEffect.SetActive(false);
    }
}