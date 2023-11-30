using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class GoalControl1 : MonoBehaviour
{
    int k = 0;
    public Animator anm;
    Vector3 BallStartPosition = new(0, 9, 0);
    public Material centerMaterial;
    public Light light1, light2, groundLight;
    public GameObject Bboom, spark1, spark2, lightning1, lightning2, b;
    AudioSource fan1sound;
    public static int puan1;
    public Text scorboard1;
    private void OnEnable()
    {
        puan1 = 0;
        fan1sound = GetComponent<AudioSource>();
        scorboard1.text = puan1.ToString();
    }
    private void OnTriggerEnter(Collider go)
    {
        if (go.gameObject.CompareTag("B"))
        {
            SlowMotion();

            go.gameObject.SetActive(false);
            spark1.SetActive(false);
            spark2.SetActive(false);
            lightning1.SetActive(false);
            lightning2.SetActive(false);
            light1.enabled = false;
            light2.enabled = false;
            groundLight.enabled = true;
            centerMaterial.color = Color.red;

            Invoke(nameof(SpawnBall), 4);

            Instantiate(Bboom, go.transform.position, transform.rotation);
            puan1++;
            scorboard1.text = puan1.ToString();
            fan1sound.Play();
            Invoke(nameof(Set_k), .7f);
            Invoke(nameof(Reset_k), 1);

            Destroy(GameObject.FindGameObjectWithTag("trash"), 12);
        }
    }
    private void SlowMotion()
    {
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }
    public void SpawnBall()
    {
        if (!EndGame.Gameover)
        {
            b.GetComponent<Rigidbody>().Sleep();
            b.transform.position = BallStartPosition;
            b.SetActive(true);
            spark1.SetActive(true);
            light1.enabled = true;
            lightning1.SetActive(true);
            spark2.SetActive(true);
            light2.enabled = true;
            lightning2.SetActive(true);
            groundLight.enabled = false;
            centerMaterial.color = Color.white;
        }
    }
    public void Set_k()
    {
        k = Random.Range(1, 6);
        anm.SetInteger("k", k);
    }
    public void Reset_k()
    {
        k = 0;
        anm.SetInteger("k", k);
    }
}
