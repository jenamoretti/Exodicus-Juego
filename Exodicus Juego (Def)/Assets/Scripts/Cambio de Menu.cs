using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiodeMenu : MonoBehaviour
{
    public bool pasarNivel;
    public int indiceNivel;

    void Start()
    {
        
    }

    void Update(){}

    public void CambiarNivel(int indice){
        SceneManager.LoadScene(indice);
    }
}
