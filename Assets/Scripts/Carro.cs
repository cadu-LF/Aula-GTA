using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    [SerializeField] WheelCollider RodaTraseiraDireita;
    [SerializeField] WheelCollider RodaFrenteDireita;
    [SerializeField] WheelCollider RodaFrenteEsquerda;
    [SerializeField] WheelCollider RodaTraseiraEsquerda;
    
    public float aceleracao = 500f;
    public float freio = 300f;
    public float anguloTorque = 15f;
    private float aceleracaoAtual = 0f;
    private float freioAtual = 0f;
    private float anguloTorqueAtual = 0f;

    public Light luzCenario;
    private bool deDia = true;

    public Light farolDireito;
    public Light farolEsquerdo;
    private bool ligado = false;

    public Light luzTraseiraDireita;
    public Light luzTraseiraEsquerda;

    public Camera cameraInicial;
    public Camera cameraInterna;
    public Camera cameraRoda;

    private void FixedUpdate()
    {
        aceleracaoAtual = aceleracao * Input.GetAxis("Vertical");
        RodaFrenteDireita.motorTorque = aceleracaoAtual;
        RodaFrenteEsquerda.motorTorque = aceleracaoAtual;
        anguloTorqueAtual = anguloTorque * Input.GetAxis("Horizontal");
        RodaFrenteDireita.steerAngle = anguloTorqueAtual;
        RodaFrenteEsquerda.steerAngle = anguloTorqueAtual;

        if (Input.GetKey(KeyCode.Space)) {
            freioAtual = freio;
            luzTraseiraDireita.enabled = true;
            luzTraseiraEsquerda.enabled = true;
        } else {
            freioAtual = 0f;
            luzTraseiraDireita.enabled = false;
            luzTraseiraEsquerda.enabled = false;
        }

        RodaFrenteDireita.brakeTorque = freioAtual;
        RodaFrenteEsquerda.brakeTorque = freioAtual;
        RodaTraseiraDireita.brakeTorque = freioAtual;
        RodaTraseiraEsquerda.brakeTorque = freioAtual;
        
        // Faz mudar de dia para noite
        if (Input.GetKey(KeyCode.Q)) {
            luzCenario.enabled = !deDia;
            deDia = !deDia;
        }

        // Acende os faróis do carro
        if (Input.GetKey(KeyCode.E)) {
            farolDireito.enabled = !ligado;
            farolEsquerdo.enabled = !ligado;

            ligado = !ligado;
        }

        // Utiliza a câmera de terceira pessoa
        if (Input.GetKey(KeyCode.Alpha1)){
            cameraInicial.enabled = true;
            cameraInterna.enabled = false;
            cameraRoda.enabled = false;
        }

        // Utiliza a câmera interna
        if (Input.GetKey(KeyCode.Alpha2)){
            cameraInicial.enabled = false;
            cameraInterna.enabled = true;
            cameraRoda.enabled = false;
        }

        // Utiliza a câmera da roda
        if (Input.GetKey(KeyCode.Alpha3)){
            cameraInicial.enabled = false;
            cameraInterna.enabled = false;
            cameraRoda.enabled = true;
        }
    }
}
