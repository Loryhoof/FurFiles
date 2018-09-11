using UnityEngine;

public class HitHatchet : MonoBehaviour
{

    public AudioSource treeHit;

    private int hitCount = 0;

    private bool collideTree = false;

    private int maxHitCount = 12;


    private float chopRate = Random.Range(6f, 21f);

    ActionBar actionBar;
 

    void Start ()
    {
        actionBar = FindObjectOfType<ActionBar>();
        
       
    }

    void FixedUpdate()
    {


    }

    public void OnTriggerEnter(Collider other)
    {
        //if (hitCount >= maxHitCount)
        //{
        //    //hitCount = 0;
        //    Destroy(other.transform.root.gameObject);
        //}

        if (other.gameObject.tag == "Tree")
        {
            //if (treeHit.isPlaying == false)
            //{
            //    treeHit.pitch = Random.Range(0.9f, 1.1f);
            //    treeHit.Play();
            //}
            ////Destroy(other.transform.root.gameObject);  TRYING SOMETHING NEW. UNCOMMENT IT WHEN NOT WORKING
            //actionBar.Wood += chopRate;
            //hitCount++; This is for having to hit tree multiple times, not just once
            collideTree = true;
        }

        
    }

    void OnTriggerExit(Collider other) {

        //if (other.gameObject.tag == "Tree")
        //{
        //    collideTree = true;

        if (hitCount == maxHitCount)
        {
            Destroy(other.transform.root.gameObject);
            hitCount = 0;
        }

        //}
        if (other.gameObject.tag == "Tree")
            collideTree = true;


    }

    public void HitTree()
    {
        

        if (collideTree == true)
        {

            treeHit.pitch = Random.Range(0.9f, 1.1f);
            treeHit.Play();
            collideTree = false;
            hitCount++;
            actionBar.Wood += chopRate;
            //AddWoodToInventory();
        }
    }

    public void Update()
    {
        
    }
    
}
