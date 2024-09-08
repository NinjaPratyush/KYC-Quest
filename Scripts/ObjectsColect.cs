using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectsColect : MonoBehaviour
{
    public int ObjectCollection;

    void Start()
    {
        ObjectCollection=0;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.CompareTag("Box"))
        {
            ObjectCollection+=1;
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        if(ObjectCollection==4)
        {
            SceneManager.LoadScene(4);
        }
    }
}
