using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttaking : MonoBehaviour
{
    public AudioSource attackSound;
    bool hostile = false;
    float idlePeriod = 1f;
    float hostilePeriod = 0.7f;
    float idleTimer = 2f;
    float hostileTimer = 0.5f;
    public GameObject player;
    public float health = 100f;
    private Color ownColor;
    public float damage = 30f;

    private void Start() {
        ownColor = gameObject.GetComponent<Renderer>().material.color;
        updateHealth();
    }

    private void updateHealth(){
        gameObject.transform.GetChild(0).GetComponent<UpdateHealth>().updateHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if(hostile){
            if(hostileTimer > 0){
                hostileTimer -= Time.deltaTime;
            }
            else{
                hostile = false;
                hostileTimer = hostilePeriod;
                gameObject.GetComponent<Renderer>().material.color = ownColor;
            }
        }
        else{
            if(idleTimer > 0){
                idleTimer -= Time.deltaTime;
            }
            else{
                hostile = true;
                idleTimer = idlePeriod;
                gameObject.GetComponent<Renderer>().material.color = new Color(1f,0f,0f,0.2735849f);
            }
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Player") && other.gameObject.GetComponent<PlayerAttacking>().hostile){
            health -= 50;
            updateHealth();
            attackSound.Play();
            if(health <= 0){
                Destroy(gameObject);
            }
            Vector3 direction = (other.transform.position - transform.position).normalized;
            getKicked(other, direction);
        }
        if(other.collider.CompareTag("Player") && hostile){
            Vector3 direction = (other.transform.position - transform.position).normalized;
            other.gameObject.GetComponent<PlayerAttacking>().getHit(damage,direction);
        }
    }
    public void getKicked(Collision other, Vector3 direction){
        GetComponent<Rigidbody>().AddForce(-direction * 5, ForceMode.Impulse);
    }
}
