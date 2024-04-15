using UnityEngine;

public class EnemyFollowing : MonoBehaviour
{
    public int speed;
    public GameObject player;
    public Animator animator;

    private bool isAttacking = false;

    void Start()
    {
        transform.Rotate(0, 0, 0);
    }

    void Update()
    {
        // Düþmanýn oyuncuya doðru hareket etmesi
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        // Düþmanýn oyuncuya doðru dönmesi
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // Düþmanýn oyuncuya yaklaþtýðýnda ve saldýrma durumunda olmadýðýnda atak animasyonunu baþlat
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < 1f && !isAttacking)
        {
            animator.SetTrigger("Attack");
            isAttacking = true;
        }
        else if (distanceToPlayer >= 1f && isAttacking)
        {
            // Saldýrý animasyonunun bitmesini bekleyin ve sonra koþma animasyonuna geri dönün
            Invoke("ResetAttack", 0.5f);
        }
    }

    void ResetAttack()
    {
        isAttacking = false;
        animator.SetTrigger("Run");
    }
}