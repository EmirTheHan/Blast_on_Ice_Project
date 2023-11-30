using UnityEngine;

public class SpeedUp_Jeton : MonoBehaviour
{
    public AudioSource jetonSound;
    public GameObject jetonBoom;

    private void Update()
    {
       transform.Rotate(Vector3.right, 60 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("B"))
        {
            if (BallManager.owner == 1)
            {
                Player1Controller.speed = 35;
            }
            else if (BallManager.owner == 2)
            {
                Player2Controller.speed = 35;
            }

            jetonSound.pitch = Random.Range(0.5f, 0.6f);
            jetonSound.Play();

            Instantiate(jetonBoom, transform.position, transform.rotation);

            gameObject.SetActive(false);
        }
    }
}
