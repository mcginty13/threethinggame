using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TimeDestroyer : MonoBehaviour
    {
    void Start()
        {
            Invoke("DestroyObject", LifeTime);
        }

        void DestroyObject()
        {
            if (GameManager.Instance.GameState != GameState.Dead)
                Destroy(gameObject);
        }

        public float LifeTime = 10f;
    }
