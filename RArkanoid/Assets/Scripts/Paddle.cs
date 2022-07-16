using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Velocidad de las palas
    public float padSpeed;

    //Alto de la pala y limite vertical del mundo
    float width, limitX;

    //Vector de la posición inicial y de movimiento 
    Vector3 startPosition,
            movement;

    public Joystick joystick;
    private void Start()
    {
        //Acceso al Renderer de las palas para obtener su tamaño con bounds
        Vector3 size = GetComponent<Renderer>().bounds.size;
        width = size.x;
        //limitY = GameManager.mundAlto / 2;
        startPosition = transform.position;
        movement = Vector3.zero;
        Debug.Log(width);
        limitX = 2.5f;
        
    }

    //Metodo para que vuelvan las palas a su posición inicial tras anotar un punto
    public void Reset()
    {
        transform.position = startPosition;
    }

    //Metodo que permite el movimiento de las palas; solo queremos que se muevan cuando el estado sea "play" (lo invocamos en GameManager cuando el estado es play), y no lo hacemos dentro del un update en este script para evitar el "polling"
    public void Movement()
    {
        //Vector de movimiento y limitar el movimiento para que no se salga de los limites
        //float dir = Input.GetAxisRaw("Horizontal");
        float dir = -joystick.Horizontal;
        movement = new Vector3(0, padSpeed * Time.deltaTime * dir, 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -limitX + width / 2, limitX - width / 2), transform.position.y
           , transform.position.z);
        //Mover la pala segun el input
        transform.Translate(movement);
    }

}
