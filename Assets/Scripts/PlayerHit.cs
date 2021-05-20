using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("breakable")) //requires for object to have tag "breakable" for this to work
        {
            other.GetComponent<pot>().Smash();
            this.transform.parent.gameObject.GetComponent<PlayerMovement>().decreaseHealth(1f);
        }
    }
}
