using UnityEngine;
using UnityEngine.AI;

public class DusmanKontrol : MonoBehaviour
{
    public Transform hedef; // Oyuncunun konumu
    private NavMeshAgent agent; // D��man�n hareket etmesini sa�layan agent bile�eni
    private bool saldiriDurumunda; // D��man�n sald�r� durumunda olup olmad���n� belirten de�i�ken

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // D��man�n NavMeshAgent bile�enini al
        hedef = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncunun konumunu hedef olarak belirle
    }

    void Update()
    {
        if (hedef != null && !saldiriDurumunda)
        {
            // Oyuncunun konumuna do�ru hareket et
            agent.SetDestination(hedef.position);

            // D��man� oyuncuya do�ru d�nd�r
            Vector3 yon = (hedef.position - transform.position).normalized;
            Quaternion hedefRotasyon = Quaternion.LookRotation(new Vector3(yon.x, 0f, yon.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, hedefRotasyon, Time.deltaTime * 5f);
        }
    }

    // D��man oyuncuyu alg�lad���nda �al��acak olan fonksiyon
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            saldiriDurumunda = true;
            // Burada sald�r� durumunda yap�lacak i�lemleri ekleyebilirsiniz
        }
    }

    // D��man oyuncuyu alg�lamay� b�rakt���nda �al��acak olan fonksiyon
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            saldiriDurumunda = false;
            // Burada sald�r� durumundan ��k�ld���nda yap�lacak i�lemleri ekleyebilirsiniz
        }
    }
}