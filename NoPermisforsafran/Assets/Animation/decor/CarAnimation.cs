using UnityEngine;

public class DeplacementVoiture : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float vitesse = 5.0f;

    private void Update()
    {
        float step = vitesse * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pointB.position, step);

        if (Vector3.Distance(transform.position, pointB.position) < 0.001f)
        {
            // La voiture est arrivée à B, on la ramène à A pour boucler le mouvement
            transform.position = pointA.position;
        }
    }
}
