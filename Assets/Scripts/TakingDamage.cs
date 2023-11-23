using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TakingDamage : MonoBehaviour
{

    private float startHealth = 100;

    public float health;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    [PunRPC]
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);

        if (health < 0 )
        {
            Die();
        }
    }

    private void Die()
    {

    }

}
