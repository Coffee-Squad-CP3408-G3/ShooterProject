using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public GameObject goal;
    Vector3 direction;
    public float speed = 5f;

    void Start()
    {

        
    }

    private void LateUpdate()
    {
        direction = goal.transform.position - transform.position;
        transform.LookAt(goal.transform.position);
        if (direction.magnitude > 2)
        {
            Vector3 velocity = direction.normalized * speed * Time.deltaTime;
            transform.position = transform.position + velocity;
        }

        //if (direction.magnitude > 15) 
        //{
        //    Vector3 velocity = new Vector3(0, 0, 0);
        //}
    }
}