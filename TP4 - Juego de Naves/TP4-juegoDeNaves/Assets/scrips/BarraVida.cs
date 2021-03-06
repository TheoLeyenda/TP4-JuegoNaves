﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BarraVida : MonoBehaviour {

	public Scrollbar BarraDeVida;
	public float Vida = 100;
    private float danio = 0.5f;
    private float sanacion = 0;
    public AudioClip audioPickUp;
    public AudioClip audioVidaPotente;
    AudioSource fuenteAudio;
    private void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Vida<0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BalaEnemigo")
        {
            danio = 4f;
            Vida -= danio;
            BarraDeVida.size = Vida / 100f;
            danio = 0.5f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemigo")
        {
            danio = 8;
            Vida -= danio;
            BarraDeVida.size = Vida / 100f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "ItemVida")
        {
            fuenteAudio.clip = audioPickUp;
            fuenteAudio.Play();
            if (Vida < 100)
            {
                sanacion = 2f;
                Vida = Vida + sanacion;
                BarraDeVida.size = Vida / 100;
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "ItemPoder")
        {
            fuenteAudio.clip = audioPickUp;
            fuenteAudio.Play();
            if (GameManager.tipoDisparo < 6)
            {
                GameManager.tipoDisparo++;
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "ItemVidaGigante")
        {
            fuenteAudio.clip = audioVidaPotente;
            fuenteAudio.Play();
            if (Vida < 100)
            {
                sanacion = 15f;
                Vida = Vida + sanacion;
                BarraDeVida.size = Vida / 100;
            }
            Destroy(other.gameObject);
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnemigoResistente")
        {
            danio = 8;
            Vida -= danio;
            BarraDeVida.size = Vida / 100f;
        }
    }

}
