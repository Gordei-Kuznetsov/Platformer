using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHealth : MonoBehaviour
{
    public float health = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.005f*health, 0.25f, 0.25f);
    }
    public void updateHealth(float newHealth){
        health = newHealth;
        transform.localScale = new Vector3(0.005f*health, 0.25f, 0.25f);
    }
}
