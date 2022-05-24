using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysScript : MonoBehaviour
{
    private SceneManagerScript sMS;
    public GameObject explosion;

    //void Start()
    //{
    //    sMS = FindObjectOfType<SceneManagerScript>();
    //    if (sMS != null && gameObject != null)
    //        sMS.Enemys.Add(this.gameObject);
    //}

    //private void OnDestroy()
    //{
    //    if(sMS != null && gameObject != null)
    //    {
    //        sMS.Enemys.Remove(this.gameObject);
    //        //if (sMS.Enemys.Count == 0)
    //        //{
    //        //    sMS.StartNextScene();
    //        //}
    //    }
    //}
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
