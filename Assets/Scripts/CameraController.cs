using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    //Eh private pq eh um valor que precisa ser determinado aqui no codigo, apenas
    private Vector3 offset;

    void Start ()
    {
    	//Pega a distancia entre a posicao fixa da camera e a atual do jogador
        offset = transform.position - player.transform.position;
    }
    
    //Para acompanhamento das cameras, animaçao procedural e capturar os status mais recentes
    //LateUpdate eh melhor do que Update apenas
    void LateUpdate ()
    {
    	//adapta a variavel da camera a cada movimento do jogador
        transform.position = player.transform.position + offset;
    }
}