using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Collider>().CompareTag("Player")){
            var script = other.GetComponent<PlayerAttacking>();
            script.health += 100;
            script.updateHealth();
            Destroy(gameObject);
        }
    }
}
