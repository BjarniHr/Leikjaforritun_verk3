using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FPSShooter : MonoBehaviour
{
    // Hér set ég upp allar upplýsingar sem ég þarf og mun nota
    public Camera cam;
    public GameObject projectile;
    public Transform firePointPos;
    public float projectileSpeed = 30;
    public float fireRate = 2;
    public static Text PointsText;
    public Text CanvasScript;

    private Vector3 destination;
    private float timeToFire;

    // Geri Awake fall hér fyrir Points textann
    private void Awake()
    {
        PointsText = CanvasScript;
        setCountText();
    }

    // Kíki hvort ég er að skjóta eða hvort gæjinn er búinn að detta af mappinu
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= timeToFire && SceneManager.GetActiveScene().name != "Endasena") 
        {
            timeToFire = Time.time + 1 / fireRate;
            ShootProjectile();
        }
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    // sé herna hvort ég snerti pening, vatn eða endaplatformið og geri hlutina sem þeir eiga að gera
    private void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.tag == "Water")
        {
            // Debug.Log("Water");
            SceneManager.LoadScene(2);
        }
        if (co.gameObject.tag == "SilverCoin")
        {
            ProjectileScript.count += 3;
            Destroy(co.gameObject);
            Debug.Log(ProjectileScript.count);
        }
        if (co.gameObject.tag == "GoldCoin")
        {
            ProjectileScript.count += 5;
            Destroy(co.gameObject);
            Debug.Log(ProjectileScript.count);
        }
        if (co.gameObject.tag == "StoneCoin")
        {
            ProjectileScript.count += 1;
            Destroy(co.gameObject);
            Debug.Log(ProjectileScript.count);
        }
        if (co.gameObject.tag == "EndPlatform")
        {
            SceneManager.LoadScene(2);
        }
        setCountText();
    }

    // finn út hvert kúlann á að fara og kall svo á annað fall til þess að búa til kúluna
    void ShootProjectile() 
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        } else 
        {
            destination = ray.GetPoint(1000);
        }
        InstantiateProjectile(firePointPos);
    }

    // fall til þess að updatea points textann
    public static void setCountText() 
    {
        // Debug.Log("Coins: " + ProjectileScript.count.ToString());
        PointsText.text = "Coins: " + ProjectileScript.count.ToString();
    }

    // bý til skot
    void InstantiateProjectile(Transform firePoint) 
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }
}
