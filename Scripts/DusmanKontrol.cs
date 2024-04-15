using UnityEngine;
using UnityEngine.AI;

public class DusmanKontrol : MonoBehaviour
{
    public Transform hedef; // Oyuncunun konumu
    private NavMeshAgent agent; // Düþmanýn hareket etmesini saðlayan agent bileþeni
    private bool saldiriDurumunda; // Düþmanýn saldýrý durumunda olup olmadýðýný belirten deðiþken

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Düþmanýn NavMeshAgent bileþenini al
        hedef = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncunun konumunu hedef olarak belirle
    }

    void Update()
    {
        if (hedef != null && !saldiriDurumunda)
        {
            // Oyuncunun konumuna doðru hareket et
            agent.SetDestination(hedef.position);

            // Düþmaný oyuncuya doðru döndür
            Vector3 yon = (hedef.position - transform.position).normalized;
            Quaternion hedefRotasyon = Quaternion.LookRotation(new Vector3(yon.x, 0f, yon.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, hedefRotasyon, Time.deltaTime * 5f);
        }
    }

    // Düþman oyuncuyu algýladýðýnda çalýþacak olan fonksiyon
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            saldiriDurumunda = true;
            // Burada saldýrý durumunda yapýlacak iþlemleri ekleyebilirsiniz
        }
    }

    // Düþman oyuncuyu algýlamayý býraktýðýnda çalýþacak olan fonksiyon
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            saldiriDurumunda = false;
            // Burada saldýrý durumundan çýkýldýðýnda yapýlacak iþlemleri ekleyebilirsiniz
        }
    }
}