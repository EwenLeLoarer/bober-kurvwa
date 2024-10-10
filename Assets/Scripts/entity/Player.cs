using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> bobers = new List<Transform>();
    public Transform centerPoint; 
    public float radius = 5f;
    [SerializeField] private TextMeshProUGUI bobersText;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider){
        Debug.Log(collider);
        if(collider.GetComponent<bober>() != null){
            collider.transform.parent = this.transform;
            bobers.Add(collider.transform);
            Harmonize();
            CenterChildren();
            bobersText.text = bobers.Count.ToString();
        }
        if(collider.GetComponent<tronc>() != null)
        {
            collider.GetComponent<tronc>().Interact(bobers);
        }
    }

    private void CenterChildren (){
         if (transform.childCount == 0)
        {
            Debug.LogWarning("No children to center on.");
            return;
        }

        Vector3 center = Vector3.zero;
        foreach (Transform child in transform)
        {
            center += child.position;
        }
        
        center /= transform.childCount;

        // Optionally, adjust the position of the children as well so they maintain the same relative position
        Vector3 parentOldPosition = transform.position;
        transform.position = center;

        foreach (Transform child in transform)
        {
            child.position -= (center - parentOldPosition);
        }
    }

    private void Harmonize()
    {
        int count = bobers.Count;
        float angleStep = 360f / count;

        for (int i = 0; i < count; i++){
            float angle = i * angleStep * Mathf.Deg2Rad;

            Vector3 planePosition = new Vector3(
                Mathf.Cos(angle) * radius + centerPoint.position.x,
                centerPoint.position.y,
                Mathf.Sin(angle) * radius + centerPoint.position.z
            );

            bobers[i].position = planePosition;
            
        }
    }
}
