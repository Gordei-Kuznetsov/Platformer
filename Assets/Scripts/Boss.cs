using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float damage = 30f;
    public float speed = 8;
    public float health = 1000f;
    public Text endText;
    public Button endButton;
    public AudioSource attackSound;
    public GameObject player;
    public GameObject enemyPrefab;
    bool hostile = false;
    float idlePeriod = 7f;
    float hostilePeriod = 10f;
    float idleTimer = 7f;
    float hostileTimer = 10f;
    Color ownColor;
    bool MoveRight;
    GameObject enemy;


    private void Start() {
        ownColor = gameObject.GetComponent<Renderer>().material.color;
        updateHealth();
        endText.enabled = false;
        endButton.gameObject.SetActive(false);
    }
    void endTask(){
        SceneManager.LoadScene("Menu");
    }
    private void updateHealth(){
        gameObject.transform.GetChild(0).GetComponent<UpdateHealth>().updateHealth(health);
    }
    public void getKicked(Collision other, Vector3 direction){
        GetComponent<Rigidbody>().AddForce(-direction * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(hostile){
            if(hostileTimer > 0){
                hostileTimer -= Time.deltaTime;
                Vector3 force;
                if(MoveRight){
                    force = new Vector3(speed, 0, 0);
                }
                else{
                    force = new Vector3(-speed, 0, 0);
                }
                GetComponent<Rigidbody>().AddForce(force);
            }
            else{
                hostile = false;
                hostileTimer = hostilePeriod;
                gameObject.GetComponent<Renderer>().material.color = ownColor;
                Vector3 offset = new Vector3(0, 3, 0);
                enemy = Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
            }
        }
        else{
            if(idleTimer > 0){
                idleTimer -= Time.deltaTime;
            }
            else{
                hostile = true;
                idleTimer = idlePeriod;
                Destroy(enemy);
                gameObject.GetComponent<Renderer>().material.color = new Color(1f,0f,0f,0.2735849f);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Player") && player.GetComponent<PlayerAttacking>().hostile){
            health -= 50;
            updateHealth();
            attackSound.Play();
            if(health <= 0){
                Task.Delay(2000).Wait();
                endButton.gameObject.SetActive(true);
                endButton.onClick.AddListener(endTask);
                endText.enabled = true;
                gameObject.SetActive(false);
            }
            Vector3 direction = (other.transform.position - transform.position).normalized;
            getKicked(other, direction);
        }
        if(other.collider.CompareTag("Player") && hostile){
            Vector3 direction = (other.transform.position - transform.position).normalized;
            player.GetComponent<PlayerAttacking>().getHit(damage,direction);
        }
    }

    void OnTriggerEnter(Collider trig)
    {
        if(trig.gameObject.CompareTag("EnemyTurn"))
        {
            MoveRight = !MoveRight;
        }
    }
}
