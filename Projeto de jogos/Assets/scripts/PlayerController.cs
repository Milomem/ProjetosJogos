using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private Vector2 velocidadeAtual;

    public float velocidade;
    public float tempoDesaceleracao = 0.3f; // Tempo para desacelerar completamente

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D> ();
    }

    //Chamado em um intervalo fixo, independente do FrameRate
    void FixedUpdate()
    {
        float moverV = Input.GetAxis ("Vertical");
        float moverH = Input.GetAxis ("Horizontal");

        Vector2 movimento = new Vector2 (moverH, moverV) * velocidade;

        // Suave transição da velocidade atual para a desejada
        rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, movimento, ref velocidadeAtual, tempoDesaceleracao);
    }
}
