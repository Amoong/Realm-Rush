
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;

    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    // 매번 업데이트마다 타겟을 찾는건 비효율적이라 
    // 적이 죽거나 범위에서 벗어난 경우만 계산하도록 개선
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        Transform closestTarget = null;

        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        if (target == null)
        {
            return;
        }

        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);
        Attack(targetDistance <= range);
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
