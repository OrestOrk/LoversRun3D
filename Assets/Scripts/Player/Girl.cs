using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obtacles"))
        {
            GlobalEventManager.SendLevelFinsih(false);
            Debug.Log("GirlColl");
        }
    }
}
