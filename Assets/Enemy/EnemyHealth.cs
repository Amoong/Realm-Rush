using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [SerializeField] int currentHitPoints = 0;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if (currentHitPoints < 1)
        {
            gameObject.SetActive(false);
        }
    }
}
