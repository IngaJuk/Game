using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float speed = 4;
    float rotSpeed = 80;
    float rot = 0.1f;
    float rotArround;
    float rotForward;
    float gravity = 8;
    public int piks = 0;
    public int goal = 0;
    public GameObject winner;
    //------------------------ Gyro
    private Gyroscope gyros;
    private Quaternion gyroRot;
    private bool gyroEnabled;
    private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        piks = 0;
        winner.SetActive(false);
        EnableGyro();
    }

    public void EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyros = Input.gyro;
            gyros.enabled = true;//išjungta. Jei ant androido buildint, pakeisti į TRUE, kitaip neveiks gyroscope.
            gyroEnabled = gyros.enabled;
        }
    }

    private void Update()
    {
        if (gyroEnabled)
        {
            Vector3 gyroEuler = gyros.attitude.eulerAngles;
            rotArround = gyroEuler.z;
            rotForward = gyroEuler.y;
            transform.eulerAngles = new Vector3(0, -rotArround - 90, 0);
            Debug.Log(gyroEuler.y);
            if (rotForward > 320)
            {
                anim.SetInteger("Condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            else if (rotForward > 260 && rotForward < 320)
            {
                anim.SetInteger("Condition", 0);
                anim.SetInteger("ReverseCon", 0);
                moveDir = new Vector3(0, 0, 0);
            }
            if (rotForward < 260)
            {
                anim.SetInteger("ReverseCon", 2);
                moveDir = new Vector3(0, 0, -1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }
        else if (gyroEnabled == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("Condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("ReverseCon", 2);
                moveDir = new Vector3(0, 0, -1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetInteger("ReverseCon", 0);
                moveDir = new Vector3(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, rot - 90, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, rot - 90, 0);
            }
            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        piks++;
        if(piks == goal)
        {
            if(SceneManager.GetActiveScene().buildIndex == 4)
            {
                winner.SetActive(true);
                Time.timeScale = 0;
            }
            else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

}
