using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 10f;
    public float firerate = 1f;
    public LayerMask EnemyLayer;
    public Transform target;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float fcountdown = 0f;

    void Update()
    {
        if(target == null)
        {
            FindNearestTarget();
        }
        else
        {
            // Rotation logic
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);

            // Distance check
            if (Vector3.Distance(transform.position, target.position) > range)
            {
                target = null;
            }
            else if (fcountdown <= 0f)
            {
                Shoot();
                fcountdown = 1f / firerate;
            }
        }
        fcountdown -= Time.deltaTime;
    }

    void FindNearestTarget()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, range, EnemyLayer);
        if(enemies.Length > 0)
        {
            target = enemies[0].transform;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null) bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}