using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class FinishScript2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            Task.Delay(2000).Wait();
            SceneManager.LoadScene("Level3");
        }
    }
}
