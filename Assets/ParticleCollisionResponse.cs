using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class ParticleCollisionResponse : MonoBehaviour {
    
    public ParticleSystem particleSystem;
    public List<ParticleCollisionEvent> collisionEvents;
    public GameObject angleUI;

    void Start()
    {
        
    }

    //void OnParticleCollision(GameObject other)
    //{
    //    part = other.GetComponent<ParticleSystem>();
        
    //    int numCollisionEvents = part.GetCollisionEvents(gameObject, collisionEvents);
    //    int i = 0;

    //    while (i < numCollisionEvents)
    //    {
    //        i++;
    //        print(collisionEvents[i].intersection);
    //    }
    //}

    void OnParticleCollision(GameObject other)
    {
        particleSystem = other.GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        int numCollisionEvents = particleSystem.GetCollisionEvents(gameObject, collisionEvents);
        
        for(int i = 0; i < numCollisionEvents; i++)
        {
            print((collisionEvents[i].intersection - collisionEvents[i].normal));
        }

        GameObject tempUI = Instantiate(angleUI, collisionEvents[0].intersection, angleUI.transform.rotation, transform);
        tempUI.GetComponentInChildren<Text>().text = (collisionEvents[0].intersection - collisionEvents[0].normal).ToString();
        Destroy(tempUI, 3f);


    }
}
