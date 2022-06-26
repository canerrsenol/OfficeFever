using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPoolController : MonoBehaviour
{
    [SerializeField] GameObject paperModel;
    [SerializeField] int poolSize;

    private void Awake()
    {
        CreatePool();
    }

    public GameObject GetPaperFromPool()
    {
        foreach (Transform child in transform)
        {
            if(!child.gameObject.activeSelf)
            {
                return child.gameObject;
            }
        }

        return null;
    }

    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Instantiate(paperModel, Vector3.zero, Quaternion.identity, transform);
        }
    }
}
