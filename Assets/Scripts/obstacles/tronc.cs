using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tronc : MonoBehaviour
{
    [SerializeField] private int _askedBober = 0;
    public float time_remaining = 3;
    public bool counting = false;
    
    private List<Transform> _bobers = new List<Transform>();

    public void Interact(List<Transform> bobers){
        Transform transform = bobers[0].transform;
        Debug.Log(bobers.Count);
        if(bobers.Count >= _askedBober){
            for(int i = 0; i < _askedBober; i++){
            bobers[i].transform.parent = this.transform;
        }
        Debug.Log("Interact");
        counting = true;
        }
        

    }

    public void Update(){
        if(counting){
            time_remaining -= Time.deltaTime;
            if(time_remaining <= 0){
                RemoveBobers();
                Destroy(this.gameObject);
            }
        }
        
    }

    public void RemoveBobers()
    {
        foreach(Transform bober in _bobers){
            bober.transform.parent = null;
        }
        if(this.gameObject.transform.childCount <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
