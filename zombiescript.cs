using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float speed = 2f; // Speed of the enemy
    public float biteRange = 0.1f; // Range at which the enemy can bite

    public Animator animator;
    private int i = 0;
    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < biteRange)
        {
            // Trigger the bite animation
            animator.SetTrigger("Bite");
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) < 20f)
            {
                animator.SetBool("IssWalking", true);
                MoveTowardsPlayer();
                LookAtPlayer();
            }

        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Optionally, update animation for walking
        animator.SetBool("IssWalking", true);
    }

    void LookAtPlayer()
    {
        // Calculer la direction vers le joueur
        Vector3 direction = (player.position - transform.position).normalized;
        // Créer une rotation basée sur cette direction
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        // Appliquer la rotation en douceur
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
