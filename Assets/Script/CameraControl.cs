using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] float fSpeed;
    [SerializeField] Vector3 offset;
    private Transform ball;
    private float ballSpeed;
    private Vector3 targetPos;
    private Ball ballSc;
    private void Awake()
    {
        ball = GameObject.FindWithTag("ball").transform;    
        ballSc = ball.gameObject.GetComponent<Ball>();
        offset += transform.position;
        ballSpeed = ballSc.startSpeed;
    }
    void Update()
    {
        Vector3 camPos = Camera.main.transform.position;
        targetPos = ball.position;
        float acc = ballSc.speed / ballSpeed;
        transform.position= Vector3.Lerp(camPos, targetPos + offset, fSpeed*acc * Time.deltaTime);
    }
}
