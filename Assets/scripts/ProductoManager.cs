using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/* Descripción: 
   En pantalla se ve una cantidad de dinero y dos productos debajo de los cuales se ven los precios de cada uno. Hay tres botones con las leyendas “Alcanza y sobra”, ”Alcanza justo” y “No alcanza”.
   Comportamientos:
   Inicio: 
   Los productos aparecen de manera aleatoria y podría pasar que ambos sean el mismo producto. La cantidad de dinero también es aleatoria. Los precios de los productos se obtienen del script Producto que tiene cada producto. 
   Al presionar los botones:
   Debe chequearse si la afirmación del botón presionado es verdadera o falsa. Para eso se compara la cantidad de dinero con la suma del precio de los dos productos: si la cantidad coincide exactamente, alcanza justo; si la excede, alcanza y sobra; y si es menor, no alcanza. Se muestra el Panel de Notificaciones indicando si el resultado es correcto o incorrecto.
   Panel de notificaciones:
    Además de si la respuesta es correcta o incorrecta, en el panel habrá dos botones que permitirán reiniciar el juego o volver a la escena de selección de juegos.
   Botón Jugar Otra Vez: 
   Si el resultado fue incorrecto el texto del botón dirá “Volver a intentarlo” y se desactivará el panel de notificaciones para que el usuario pueda volver a intentarlo. Si el resultado fue correcto el texto del botón dirá “Reiniciar el desafío” y el juego se generará nuevamente. 
   Botón Salir: 
   Ya sea correcta o incorrecta la respuesta habrá un botón Salir que cargará la escena llamada “SeleccionarJuegos”. 
   
 */

public class ProductoManager : MonoBehaviour
{
    [SerializeField] GameObject[] arrayObjetos;
    public Text cantidadDineroTotal;
    public Text precioProducto1;
    public Text precioProducto2;
    
    private GameObject obj1;
    private GameObject obj2;
    
    private int pre1;
    private int pre2;
    
    private int dinerototal;

    [SerializeField] Text text1;
    [SerializeField] Text res;
    [SerializeField] Button btnJugar;

    [SerializeField] Text btnJugarTxt;

    private void Start()
    {
        Spawn();
    }

    void Spawn() {
        Vector3 pos2 = new Vector3(2.1f,1.3f, -6.5f);
        Vector3 pos1 = new Vector3(-1.5f,1.3f, -6.5f);

        int idxobj1 = Random.Range(0, arrayObjetos.Length - 1);
        int idxobj2 = Random.Range(0, arrayObjetos.Length - 1);
        
        obj1 = Instantiate(arrayObjetos[idxobj1], pos1, Quaternion.identity);
        
        obj2 = Instantiate(arrayObjetos[idxobj2], pos2, Quaternion.identity);
        
        pre1 = obj1.GetComponent<ProductoScript>().precio;
        pre2 = obj2.GetComponent<ProductoScript>().precio;
        
        precioProducto1.text = pre1.ToString();
        precioProducto2.text = pre2.ToString();
        
        dinerototal = Random.Range(4, 18);
        cantidadDineroTotal.text = dinerototal.ToString();
    }

    public void alcanzaYSobra() {
        // Debug.Log(dinerototal > pre1 + pre2);
        ShowEndNotif();
        Check(dinerototal > pre1 + pre2);
    }
    
    public void alcanzaJusto() {
        // Debug.Log(dinerototal == pre1 + pre2);
        ShowEndNotif();
        Check(dinerototal == pre1 + pre2);
    }
    
    public void noAlcanza() {
        // Debug.Log(dinerototal < pre1 + pre2);
        ShowEndNotif();
        Check(dinerototal < pre1 + pre2);
    }

    public void clearAll()
    {
        text1.gameObject.SetActive(false);
        res.gameObject.SetActive(false);
        
        btnJugar.gameObject.SetActive(false);
        
        Destroy(obj1);
        Destroy(obj2);
        
        cantidadDineroTotal.text = "";
        precioProducto1.text = "";
        precioProducto2.text = "";
        
        Spawn();
    }

    void ShowEndNotif() {
        text1.gameObject.SetActive(true);
        res.gameObject.SetActive(true);
        
        btnJugar.gameObject.SetActive(true);
    }

    void Check(bool condition)
    {
        if (condition)
        {
            res.text = "Correcta";
            btnJugarTxt.text = "Reiniciar el desafio";
        }
        else
        {
            res.text = "Incorrecta";
            btnJugarTxt.text = "Volver a intentarlo";
        }
    }
    
}
