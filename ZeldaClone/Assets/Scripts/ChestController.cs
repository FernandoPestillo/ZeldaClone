using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public KeysManager KeysManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player tentou abrir ba�");
            if(KeysManager.chavesPrata > 0)
            {
                Debug.Log("ABRINDO BA�");
                KeysManager.UsarChavePrata();
                KeysManager.EncontrarChaveOuro();
            }
        }
    }
}
