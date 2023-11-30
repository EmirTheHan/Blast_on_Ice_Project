using UnityEngine;
public class Boomer1 : MonoBehaviour
{
    Vector3 BallStartPosition = new(0, 9, 0);
    Vector3 P2StartPosition = new(13.5f, 7, 0);

    public GameObject b, s1, s2, lightning1, lightning2, p2rotation, p2skillImage;
    public Material centerMaterial;
    public Light l1, l2, groundLight;
    public GameObject p2boom;
    public GameObject sparkBoom;
    public GameObject BBoom;
    public GameObject p2;
    public AudioSource d, sparkSound;
    private float speed;

    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag("P2") && b.activeSelf)
        {
            Instantiate(p2boom, obj.transform.position, obj.transform.rotation);
            obj.gameObject.SetActive(false);
            p2skillImage.SetActive(false);
            Invoke(nameof(SpawnP2), 6);
            sparkBoom.GetComponent<ParticleSystem>().Play();
            sparkSound.Play();
            Destroy(GameObject.FindGameObjectWithTag("trash"), 12);
        }
        else if (obj.gameObject.CompareTag("B") && BallManager.owner == 2)
        {
            Instantiate(BBoom, obj.transform.position, obj.transform.rotation);
            obj.gameObject.SetActive(false);

            s1.SetActive(false);
            l1.enabled = false;
            lightning1.SetActive(false);

            s2.SetActive(false);
            l2.enabled = false;
            lightning2.SetActive(false);

            groundLight.enabled = true;
            centerMaterial.color = Color.red;

            sparkBoom.GetComponent<ParticleSystem>().Play();
            sparkSound.Play();

            Invoke(nameof(SpawnBall), 4);

            Destroy(GameObject.FindGameObjectWithTag("trash"), 12);
        }
        else
        {
            speed = obj.rigidbody.velocity.magnitude;
            if (speed >= 2f)
            {
                d.volume = .25f * speed;
                d.Play();
            }
        }
    }
    public void SpawnBall()
    {
        if (!EndGame.Gameover)
        {
            b.GetComponent<Rigidbody>().Sleep();
            b.transform.position = BallStartPosition;
            b.SetActive(true);
            s1.SetActive(true);
            l1.enabled = true;
            lightning1.SetActive(true);
            s2.SetActive(true);
            l2.enabled = true;
            lightning2.SetActive(true);
            groundLight.enabled = false;
            centerMaterial.color = Color.white;
        }
    }
    public void SpawnP2()
    {
        p2.GetComponent<Rigidbody>().Sleep();
        p2.transform.SetPositionAndRotation(P2StartPosition, p2rotation.transform.rotation);
        p2.SetActive(true);
        p2skillImage.SetActive(true);
    }
}
