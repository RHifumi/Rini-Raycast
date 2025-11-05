using System;
using UnityEngine;

public class MoverCamara : MonoBehaviour
{

    Vector2 mouseMirar;
    Vector2 suavidadV;

    private float sensibilidad = 3.0f;
    private float suavizado = 0.5f;

    GameObject cuerpoJugador;

    void Start()
    {

        //Parent, hace referencia a la madre en la jerarquia. 
        cuerpoJugador = transform.parent.gameObject;

    }

    void Update()
    {
        //md va a ser la ubicación del mouse, donde esta?
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //Escalo el vector, modifico el tamaño para cambiar, la sensibilidad
        md = Vector2.Scale(md, new Vector2(sensibilidad * suavizado, sensibilidad * suavizado));


        suavidadV.x = Mathf.Lerp(suavidadV.x, md.x, 1f / suavizado);
        suavidadV.y = Mathf.Lerp(suavidadV.y, md.y, 1f / suavizado);

        mouseMirar += suavidadV;

        //Recibe una variable, y se encarga de restringir los valores
        mouseMirar.y = Mathf.Clamp(mouseMirar.y, -90, 90);

        //de arriba a abajo, rota la camara
        transform.localRotation = Quaternion.AngleAxis(-mouseMirar.y, Vector3.right);
        //De lados, rota el cuerpo del jugador,Queaternion. número para expresar rotaciones
        cuerpoJugador.transform.localRotation = Quaternion.AngleAxis(mouseMirar.x, cuerpoJugador.transform.up);
    }
}
