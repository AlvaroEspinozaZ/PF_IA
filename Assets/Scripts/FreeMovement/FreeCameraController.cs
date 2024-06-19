using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        // Movimiento lateral (teclas A y D o flechas izquierda y derecha)
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        // Movimiento vertical (teclas W y S o flechas arriba y abajo)
        float verticalMovement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        // Rotación de la cámara con el mouse
        yaw += mouseSensitivity * Input.GetAxis("Mouse X");
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");

        // Limitar el ángulo de pitch entre -90 y 90 grados para evitar giros excesivos
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        // Aplicar rotación y movimiento
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.Translate(new Vector3(horizontalMovement, 0.0f, verticalMovement));
    }
}
