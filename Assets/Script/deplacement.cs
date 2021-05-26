using UnityEngine;
using UnityEngine.AI;

public class deplacement : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] [Range(0.0F, 100.0F)] private float vitesse;
    [SerializeField] private Camera camera;
    [SerializeField] private NavMeshAgent prof;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                prof.SetDestination(hit.point);
            }
        }
    }
}
