using System.Diagnostics;
using System.Security.AccessControl;
using UnityEngine;

public class ContolRaycasting : MonoBehaviour
{
    public Camera Caramara;
    public GameObject bala;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        //1.Creamos un rayo desde el centro de la cámara
            Ray rayoo = Caramara.ViewportPointToRay(new Vector3(0.5f,0.5f,0.0f));
        //2.Instanciamos un Proyectil desde el origen del rayo
            GameObject pro;
            pro = Instantiate(bala, rayoo.origin, transform.rotation);
        //3.Aplicamos una fuerza de impulso sobre el objeto instanciado
            Rigidbody rb = pro.GetComponent<Rigidbody>();
            rb.AddForce(Caramara.transform.forward * 15, ForceMode.Impulse);
        //4.Lanzamos un Raycast para detectar un impacto
            RaycastHit hit;
        //5.Si recibimos un impacto, y esté fue a menos de 5 unidades
            if (Physics.Raycast(rayoo, out hit) == true && hit.distance<5)
            {
        //6.Por consola recibimos el feedback y el nombre del collider impactado
                UnityEngine.Debug.Log("Impacto: "+ hit.collider.name);
        //7.Si el collider impactado se llama "Bot" esté recibeDaño en forma de un metodo en su scrpit
                if (hit.collider.name.Substring(0, 3) == "Bot")
                {
                    GameObject objetoImpactado = GameObject.Find(hit.transform.name);
                    ControlBot scriptObjetoImpactado = (ControlBot)objetoImpactado.GetComponent(typeof(ControlBot));

                    if (scriptObjetoImpactado != null)
                    {

                        scriptObjetoImpactado.recibirDaño();

                    }
                }

            }

        }

    }
}
