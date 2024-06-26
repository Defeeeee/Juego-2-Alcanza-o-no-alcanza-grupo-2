using System;
using System.Collections;
using System.Collections.Generic;
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

    void InitialSpawn() {
        Vector3 pos1 = new Vector3(-120, 20);
        Vector3 pos2 = new Vector3(256, 20);
        
        Instantiate(arrayObjetos[Random.Range(0, arrayObjetos.Length)], pos1, Quaternion.identity);
        
        Instantiate(arrayObjetos[Random.Range(0, arrayObjetos.Length)], pos2, Quaternion.identity);
    }

    int CheckAlcanza() {
        if (Convert.ToInt32(precioProducto1.text) + Convert.ToInt32(precioProducto2.text) == Convert.ToInt32(cantidadDineroTotal.text))
        {
            return 1;
        }

        return 0;
    }
    
}
