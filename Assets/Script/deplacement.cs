using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class deplacement : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] [Range(0.0F, 100.0F)] private float vitesse;
    [SerializeField] private Camera camera;
    [SerializeField] private NavMeshAgent prof;
    public Animator animator;
    int lePath;
    int size;

    public GameObject[] paths;

    private void Start()
    {
        size = paths.Length - 1;
        lePath = Random.Range(0, size);
        Debug.Log("" + paths.Length);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                prof.SetDestination(hit.point);
            }
        }*/

        //Debug.Log("" + prof.transform.position);
        if (prof.transform.position == paths[lePath].transform.position)
        {

            //Debug.Log("" + (paths[lePath].transform.position == prof.transform.position));
            //animator.SetTrigger("SurPlace");
            //StartCoroutine(Wait());
            lePath = Random.Range(0, size);
            prof.SetDestination(paths[lePath].transform.position);
        }
        else
        {
            //animator.SetTrigger("Marche");
            //Debug.Log("" + (paths[lePath].transform.position == prof.transform.position));
            prof.SetDestination(paths[lePath].transform.position);
        }
    }
}
