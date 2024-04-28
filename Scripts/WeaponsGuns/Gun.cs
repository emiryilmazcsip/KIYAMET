using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;
    public float fireRate;
    public float bigDamage = 2f;
    public float smallDamage = 1f;

    public float gunShotRadius = 20f;

    private float nextTimeToFire;
    private BoxCollider gunTrigger;

    public int maxAmmo;
    private int ammo;

    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;
    public EnemyManager enemyManager;

    private Animator gunAnim;
    private Animator camAnim;

    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);

        CanvasManager.Instance.UpdateAmmo(ammo);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && ammo > 0)
        {
            ammo--;
            CanvasManager.Instance.UpdateAmmo(ammo);
            Fire();
            gunAnim.SetBool("Shoot", true);
            camAnim.SetTrigger("Shoot");
            nextTimeToFire = Time.time + fireRate;
        }
    }

    void Fire()
    {
            //simulate gun shot radius
            Collider[] enemyColliders;
            enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

            //alert any enemy in sound range
            foreach (var enemyCollider in enemyColliders)
            {
                if (enemyCollider != null && enemyCollider.gameObject != null)
                {
                    enemyCollider.GetComponent<EnemyAggro>().isAggro = true;
                }
            }
            //play test audio
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();

            //damage enemies
            foreach (var enemy in enemyManager.enemiesInTrigger)
            {
                var dir = enemy.transform.position - transform.position;

                RaycastHit hit;
                if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
                {
                    if (hit.transform == enemy.transform)
                    {
                        //range check
                        float dist = Vector3.Distance(enemy.transform.position, transform.position);

                        if (dist > range * 0.5f)
                        {
                            //damage enemy
                            if (enemy != null)
                            {
                                enemy.TakeDamage(smallDamage);
                            }
                        }
                        else
                        {
                            //damage enemy
                            if (enemy != null)
                            {
                                enemy.TakeDamage(bigDamage);
                            }
                        }
                    }
                }
            }

        //reset timer
        nextTimeToFire = Time.time + fireRate;

        //remove a slug
        camAnim.SetTrigger("Shoot");
    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        if (ammo < maxAmmo)
        {
            ammo += amount;
            Destroy(pickup);
        }

        if (ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }

        CanvasManager.Instance.UpdateAmmo(ammo);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
{
            enemyManager.RemoveEnemy(enemy);
        }
    }
}