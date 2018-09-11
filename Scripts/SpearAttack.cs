using UnityEngine;


namespace MalbersAnimations
{


    public class SpearAttack : MonoBehaviour
    {

        public AudioSource onHitSound;

        private int hitWolf = 0;
        public bool wolfDead = false;

        ActionBar actionBar;

        void Start()
        {
            actionBar = FindObjectOfType<ActionBar>();
        }



        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Animal")
            {
                other.gameObject.GetComponentInParent<SheepMOVE>().enabled = false;
                onHitSound.Play();
                Destroy(other.gameObject);

                actionBar.rawLamb += Random.Range(0.1f, 0.3f);

            }

            if (other.gameObject.tag == "Player")
            {
                //////////////
            }

            if (other.gameObject.tag == "Enemy")
            {
                onHitSound.Play();

                hitWolf++;

                //wolfDead = true;


                Animal animal = other.gameObject.GetComponent<Animal>();

                

                if (hitWolf >= 5)
                {
                    //Destroy(other.gameObject);
                    //wolfDead = true;
                    animal.Death = true;
                    hitWolf = 0;
                }
            }



        }
    }

}



