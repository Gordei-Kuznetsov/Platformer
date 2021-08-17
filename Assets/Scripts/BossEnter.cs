using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnter : MonoBehaviour
{
    bool opened = true;
    private void OnTriggerEnter(Collider other) {
        if(opened && other.CompareTag("Player")){
            opened = false;
            transform.Translate(0, -1, 0);
        }
    }
}
