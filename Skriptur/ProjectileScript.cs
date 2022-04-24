using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private bool collided;
    public static int count;

    // skripta fyrir kúlurnar til þess að eyða þeim ef þær hitta eitthvað
    void OnCollisionEnter (Collision co) 
    {
        if (co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            Destroy(gameObject);
        }
    } 
}