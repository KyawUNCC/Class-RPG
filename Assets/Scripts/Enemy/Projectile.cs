using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float duration;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        transform.right = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= duration)
            Destroy(this.gameObject);
    }
}
