using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player2Controller : MonoBehaviour
{
    public static bool p2skill;
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
        p2skill = true;
    }
    private void FixedUpdate()
    {
        if (StartTimer.isStart)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (rb.velocity.x < -5)
                {
                    currentVelocity = rb.velocity;
                    targetVelocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
                    rb.velocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);
                }
                rb.AddForce(new Vector3(speed, 0, 0));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (rb.velocity.x > 5)
                {
                    currentVelocity = rb.velocity;
                    targetVelocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
                    rb.velocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);
                }
                rb.AddForce(new Vector3(-speed, 0, 0));
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (rb.velocity.z < -5)
                {
                    currentVelocity = rb.velocity;
                    targetVelocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
                    rb.velocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);
                }
                rb.AddForce(new Vector3(0, 0, speed));
            }
            if (Input.GetKey(KeyCode.DownArrow))
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(speed+" , "+skillSpeed);
        }

        if (StartTimer.isStart)
        {
            if (Input.GetKeyDown(KeyCode.RightShift) && gameObject.transform.position.y < .5)
            {
                rb.AddForce(new Vector3(0, 300, 0));
            }

            if (Input.GetKeyDown(KeyCode.RightControl) && p2skill)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    rb.AddForce(new Vector3(skillSpeed, 0, 0));
                    p2skill = false;
                    dashS.Play();
                    StartCoroutine(ResetSkill());
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.AddForce(new Vector3(-skillSpeed, 0, 0));
                    p2skill = false;
                    dashS.Play();
                    StartCoroutine(ResetSkill());
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rb.AddForce(new Vector3(0, 0, skillSpeed));
                    p2skill = false;
                    dashS.Play();
                    StartCoroutine(ResetSkill());
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    rb.AddForce(new Vector3(0, 0, -skillSpeed));
                    p2skill = false;
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
                p2skill = true;
                sound.Play();
                break;
            }
            yield return null;
        }
    }
}
