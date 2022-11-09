using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TutorialHandler : MonoBehaviour
{
    public TMP_Text tutorial;
    public RoundHandler roundHandler;
    public InventoryManager inventory;
    public bool skipTutorial;
    [System.NonSerialized] public int currentMessage;
    [System.NonSerialized] public List<string> messages;

    // Start is called before the first frame update
    void Start()
    {
        string messageStart = "La partida ha comenzado! \n\nEl temporizador del cielo indica el tiempo para la llegada de los enemigos";
        string message0 = "Presione el trigger de cualquier mano para disparar \n\nderecha -> frutas \nizquierda -> semillas \n\nPruebe apuntar a la ventana derecha y disparar para pasar a la siguiente instrucción, o a la izquierda para devolverse";
        string message1 = "Mantenga presionado el botón X y seleccione con el joystick derecho para cambiar el tipo de fruta y semilla. \n\nLas semillas se disparan a la tierra para plantar y las frutas hacen diferentes cantidades de daño a los enemigos";
        string message2 = "Mantenga presionado el boton A y aproxime su mano derecha a una herramienta. Para agarrarla presione una vez el grab derecho y luego suelte A. Para soltarla presione el grab derecho otra vez. \n\nLos usos de las herramientas se pueden ver en la pared izquierda.";
        string message3 = "Para plantar acerquese a una base de plantación y are la tierra tocandola con la azada. Cuando la tierra haya cambiado puede disparar una semilla. Una vez que la planta haya crecido a su máxima altura la puede cortar con la guadaña";
        string message4 = "Los objetos que caigan al suelo se colectan con solo aproximarse al jugador. Hay un tiempo limitado para plantar y recolectar municiones para disparar antes de que lleguen los enemigos. No deje que lleguen a la casa! \n\nDispare una vez más para comenzar";
        messages = new List<string> {message0, message1, message2, message3, message4, messageStart};
        if (skipTutorial){
            inventory.ResetInventory();
            StartCoroutine(roundHandler.StartRound());
            currentMessage = messages.Count - 1;
        } else {
            currentMessage = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        tutorial.text = messages[currentMessage];
    }
}
