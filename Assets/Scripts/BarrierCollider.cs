using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class BarrierCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Player"){
            Task.Delay(1000).Wait();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
