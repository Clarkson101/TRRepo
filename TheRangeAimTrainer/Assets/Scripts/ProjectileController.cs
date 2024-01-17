// ProjectileController.cs
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 10f;
    public float lifespan = 3f; // Time in seconds before the projectile is destroyed

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Countdown the lifespan
        lifespan -= Time.deltaTime;

        // Check if the lifespan has expired
        if (lifespan <= 0f)
        {
            Destroy(gameObject); // Destroy the projectile
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        Destroy(gameObject); // Destroy the projectile on collision
    }
}
