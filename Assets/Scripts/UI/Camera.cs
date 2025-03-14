using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;      // Le Transform du joueur
    public float smoothSpeed = 0.125f;  // Vitesse de suivi
    public Vector3 offset;         // Décalage de la caméra par rapport au joueur

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
