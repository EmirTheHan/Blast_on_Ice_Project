using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player1Controller : MonoBehaviour
{
    public static bool p1skill;
    public Image skillImage;
    private float cd, cdTime = 10f;
    private Rigidbody rb;
    public AudioSource sound, dashS;
    public static int skillSpeed, speed = 25;
    private Vector3 currentVelocity, targetVelocity;
    private void Start()
    {
        speed = 25;
        skillSpeed = speed * 85;
    }
    void OnEnable()
    {
        skillImage.fillAmount = 1;
        rb = GetComponent<Rigidbody>();
        p1skill = true;
    }
    private void FixedUpdate()
    {
        if (StartTimer.isStart)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (rb.velocity.x < -5)
                {
                    currentVelocity = rb.velocity;
                    targetVelocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
                    rb.velocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);
                }
                rb.AddForce(new Vector3(speed, 0, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (rb.velocity.x > 5)
                {
                    currentVelocity = rb.velocity;
                    targetVelocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
                    rb.velocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);
                }
                rb.AddForce(new Vector3(-speed, 0, 0));
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (rb.velocity.z < -5)
                {
                    currentVelocity = rb.velocity;
                    targetVelocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
                    rb.velocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);
                }
                rb.AddForce(new Vector3(0, 0, speed));
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (rb.velocity.z > 5)
                {
                    currentVelocity = rb.velocity;
                    targetVelocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
                    rb.velocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);
                }
                rb.AddForce(new Vector3(0, 0, -speed));
            }
        }
    }
    void Update()
    {
        if (StartTimer.isStart)
        {
            if (Input.GetKeyDown(KeyCode.Space) && gameObject.transform.position.y < .5)
            {
                rb.AddForce(new Vector3(0, 300, 0));
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && p1skill)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(new Vector3(skillSpeed, 0, 0));
                    p1skill = false;
                    dashS.Play();
                    StartCoroutine(ResetSkill());
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rb.AddForce(new Vector3(-skillSpeed, 0, 0));
                    p1skill = false;
                    dashS.Play();
                    StartCoroutine(ResetSkill());
                }
                if (Input.GetKey(KeyCode.W))
                {
                    rb.AddForce(new Vector3(0, 0, skillSpeed));
                    p1skill = false;
                    dashS.Play();
                    StartCoroutine(ResetSkill());
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rb.AddForce(new Vector3(0, 0, -skillSpeed));
                    p1skill = false;
                    dashS.Play();
                    StartCoroutine(ResetSkill());
                }
            }
        }
    }
    IEnumerator ResetSkill()
    {
        cd = 0;
        while (true)
        {
            cd += Time.deltaTime;
            skillImage.fillAmount = cd / cdTime;
            if (cd >= cdTime)
            {
                p1skill = true;
                sound.Play();
                break;
            }
            yield return null;
        }
    }
}
