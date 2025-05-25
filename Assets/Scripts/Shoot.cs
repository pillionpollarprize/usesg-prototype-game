using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;
    public GameObject shooter;

    public int gunDamage = 3;
    public float cooldown = 0.3f;
    public float reload = 2;
    public int magazineCapacity = 2;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public WaitForSeconds effectDuration = new WaitForSeconds(.07f);
    private LineRenderer trail;
    private float nextFire;
    private int currentAmmo = 0;
    private bool canShoot = true;
    private bool reloading = false;

    public TextMeshProUGUI magazineText;
    private void Start()
    {
        trail = GetComponent<LineRenderer>();
        currentAmmo = magazineCapacity;
        magazineText.text = currentAmmo.ToString();
        shooter = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (currentAmmo > 0 && canShoot && Input.GetMouseButtonDown(0))
        {
            nextFire = Time.time + cooldown;

            StartCoroutine(ShotEffect());
            trail.SetPosition(0, muzzle.position);
            currentAmmo--;
            //var bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            //var bulletProperties = bullet.GetComponent<Bullet>();

            //bulletProperties.shooter = GameObject.FindWithTag("Player");
            RaycastHit hit;
            var screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            var ray = Camera.main.ScreenPointToRay(screenCenter);
            if (Physics.Raycast(ray, out hit, weaponRange))
            {
                Debug.DrawRay(muzzle.position, Camera.main.transform.forward * weaponRange, Color.red, 1.0f);
                trail.SetPosition(1, hit.point);
                var health = hit.collider.GetComponent<Health>();

                if (health != null)
                {
                    health?.TakeDamage(gunDamage);
                    print($"Hit {hit} for {gunDamage} damage");
                }
                else
                {
                    print("no health");
                }
            }
            else
            {
                trail.SetPosition(1, ray.GetPoint(weaponRange));
                print("Missed the target");
            }
            StartCoroutine(Cooldown());
            print($"currentammo: {currentAmmo} cooldown: {cooldown} shoot?: {canShoot}");
        }
        else if (currentAmmo == 0)
        {
            if (reloading == false)
            {
                print("reloading");
                StartCoroutine(Reload());
                reloading = true;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
        magazineText.text = currentAmmo.ToString();
    }
    private IEnumerator ShotEffect()
    {
        trail.enabled = true;

        yield return effectDuration;

        trail.enabled = false;
    }
    IEnumerator disableAgent(Enemy enemy)
    {
        enemy.agent.enabled = false;
        yield return new WaitForSeconds(1);
        enemy.agent.enabled = true;

    }
    IEnumerator Reload()
    {
        canShoot = false;
        for(int i = 0; i < 360; i++)
        {
            yield return new WaitForSeconds(0.0001f);
            transform.localRotation = Quaternion.Euler(i*-1, 0, 0);
        }
        yield return new WaitForSeconds(reload);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        currentAmmo = magazineCapacity;
        canShoot = true;
        reloading = false;
    }

    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
