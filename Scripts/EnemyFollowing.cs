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
        // D��man�n oyuncuya do�ru hareket etmesi
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        // D��man�n oyuncuya do�ru d�nmesi
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // D��man�n oyuncuya yakla�t���nda ve sald�rma durumunda olmad���nda atak animasyonunu ba�lat
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < 1f && !isAttacking)
        {
            animator.SetTrigger("Attack");
            isAttacking = true;
        }
        else if (distanceToPlayer >= 1f && isAttacking)
        {
            // Sald�r� animasyonunun bitmesini bekleyin ve sonra ko�ma animasyonuna geri d�n�n
            Invoke("ResetAttack", 0.5f);
        }
    }

    void ResetAttack()
    {
        isAttacking = false;
        animator.SetTrigger("Run");
    }
}