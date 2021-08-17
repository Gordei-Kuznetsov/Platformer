using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject capsulePrefab;
    float waitPeriod = 30f;
    float timer = 30f;
    GameObject capsule;
    bool left = true;
    Vector3 leftLocation = new Vector3(44, 2, 0);
    Vector3 rightLocation = new Vector3(65, 2, 0);

    // Update is called once per frame
    void Update()
    {
        if(!capsule){
            if(timer > 0){
                timer -= Time.deltaTime;
            }
            else{
                timer = waitPeriod;
                if(left){
                    capsule = Instantiate(capsulePrefab, leftLocation, Quaternion.identity);
                    left = false;
                }
                else{
                    capsule = Instantiate(capsulePrefab, rightLocation, Quaternion.identity);
                    left = true;
                }
                
            }
        }
    }
}
