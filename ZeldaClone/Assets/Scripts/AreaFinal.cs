using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaFinal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Voce Chegou ao Fim");
        SceneManager.LoadScene("TelaFinal");       
    }
    
}
