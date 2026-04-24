using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SeekerBehaviour seeker;
    public HiderBehaviour hider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seeker.SetTarget(hider.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
