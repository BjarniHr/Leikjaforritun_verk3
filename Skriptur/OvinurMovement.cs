using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OvinurMovement : MonoBehaviour
{
    // Hér set ég upp allar upplýsingar sem ég þarf og mun nota
    public float health = 50;
    public float damage_take = 50;
    
    public Transform player;

    private Rigidbody rb;
    private Vector3 movement;
    public float hradi = 5f;
    public float min_distance_to_player = 30;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // finn áttinu að playernum
    void Update()
    {
        Vector3 stefna = player.position - transform.position;
        //Vector3 player_postion = player.position;
        stefna.Normalize();
        movement = stefna;
    }

    // læt óvinninn taka damage ef hann er hittur af kúlu
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Bullet"){
            if (health <= 1) {
                Destroy(gameObject);
                ProjectileScript.count += 1;
                // Debug.Log(ProjectileScript.count);
            } else {
                health -= damage_take;
                ProjectileScript.count += 1;
                // Debug.Log(ProjectileScript.count);
            }
            FPSShooter.setCountText();
        }
        // enda leikinn ef hann snertir Playerinn
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }

    // finn út hversu nálægt playerinn er hjá óvininum og kalla á fallið til þess að færa hann ef hann er nógu nálægt
    private void FixedUpdate() {
        float dist = Vector3.Distance(player.position, transform.position);
        if(dist < min_distance_to_player) {
            Hreyfing(movement);
        }
    }

    // hreyfi óvininn nær playernum
    void Hreyfing(Vector3 stefna)
    {
        rb.MovePosition(transform.position + (stefna * hradi * Time.deltaTime));
    }
    /* public void TakeDamage (string part_hit) 
    {
        Debug.Log("hiti ovin");
        if (part_hit == "ovinur"){
            Debug.Log("hiti ovin");
            health -= damage_take;
        }

        if(health <= 0){
            Destroy(gameObject);
        }
    } */
}