using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyMove : MonoBehaviour
{
    public float speed = 8;
    bool MoveRight;
    void Update(){
        Vector3 force;
        if(MoveRight){
            force = new Vector3(speed, 0, 0);
        }
        else{
            force = new Vector3(-speed, 0, 0);
        }
        GetComponent<Rigidbody>().AddForce(force);
    }
    void OnTriggerEnter(Collider trig)
    {
        if(trig.gameObject.CompareTag("EnemyTurn"))
        {
            MoveRight = !MoveRight;
        }
    }
}