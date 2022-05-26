using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysScript : MonoBehaviour
{
    private SceneManagerScript sMS;
    public GameObject explosion;

    public void Explosion()
    {
        Instantiate(explosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<CharacterControllerScript>().Knockback(gameObject.transform.position);
        }
    }
}
