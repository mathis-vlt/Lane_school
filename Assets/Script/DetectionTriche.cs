using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectionTriche : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cible;

    [Range(0, 360)]
    public float angle;
    public float rayon; //de detection

    public LayerMask targetMask;
    public LayerMask obstacleTarget;

    public bool canSeePlayer;
    public bool trichePlayer;

    public playerCamera player;
    void Start()
    {
        cible = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Routine());
        trichePlayer = false;
        player = FindObjectOfType<playerCamera>();
    }
    IEnumerator Routine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    public void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, rayon, targetMask);
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleTarget))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(canSeePlayer && (player.estEnTrainDeTricher || player.tricheOrdi))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Solo");

        }
    }
}
