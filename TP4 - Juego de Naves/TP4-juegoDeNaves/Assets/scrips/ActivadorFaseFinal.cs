﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorFaseFinal : MonoBehaviour {
    // Use this for initialization
    private int activacion;
    public Enemigo Enemigo1;
    public Enemigo Enemigo2;
    public Enemigo Enemigo3;
    public MovimientoDelNivel nivel2;
    private float auxVelScrolleo;
    private bool soloUnaVez;
    void Start()
    {
        activacion = 0;
        auxVelScrolleo = 0;
        soloUnaVez = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "CamaraColicionadora")
        {
            Debug.Log("Entre");
            if (Enemigo1 != null || Enemigo2 != null && Enemigo3 != null)
            {
                if (soloUnaVez)
                {
                    soloUnaVez = false;
                    auxVelScrolleo = nivel2.GetVelScrolleo();
                }
                Debug.Log("AuxVelScroleo" + auxVelScrolleo);
                nivel2.SetVelScrolleo(0);
            }
            if (Enemigo1 == null && Enemigo2 == null && Enemigo3 == null)
            {
                Debug.Log("Estoy Scroleando");
                nivel2.SetVelScrolleo(auxVelScrolleo);
            }
            if (activacion >= 1)
            {
                Enemigo1.SetQuieto(false);
                Enemigo2.SetQuieto(false);
                Enemigo3.SetQuieto(false);

            }
        }
       
        if (other.gameObject.tag == "CamaraColicionadora")
        {
            activacion = 1;
        }
    }
}
