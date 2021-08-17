using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class PlayerAttacking : MonoBehaviour
{
    public AudioSource attackSound;
    public AudioSource yeetSound;
    public bool hostile = false;
    public float health = 200f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            hostile=true;
            gameObject.GetComponent<Renderer>().material.color = new Color(1f,0f,0f,0.2735849f);
            yeetSound.Play();
            
        }
        if (Input.GetButtonUp("Fire1"))
        {
            hostile=false;
            gameObject.GetComponent<Renderer>().material.color = new Color(0.2735849f,0.2735849f,0.2735849f,0.2735849f);
        }
    }

    public void getHit(float damage, Vector3 direction){
        health -= damage;
        updateHealth();
        attackSound.Play();
        if(health <= 0){
            Task.Delay(500).Wait();
            Destroy(gameObject);
            Task.Delay(1000).Wait();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        GetComponent<Rigidbody>().AddForce(direction * 5, ForceMode.Impulse);
    }

    private void Start() {
        updateHealth();
    }
    public void updateHealth(){
        gameObject.transform.GetChild(0).GetComponent<UpdateHealth>().updateHealth(health);
    }
}
