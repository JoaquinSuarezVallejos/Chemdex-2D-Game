using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atom
{
    public class ParticleTaker : MonoBehaviour
    {
        Levysabe parent;
        public ParticleLvl1 assignedParticle;
        public GameObject particleGO;
        [SerializeField] NeutronLvl1 neutronScript;
        [SerializeField] ProtonLvl1 protonScript;


        private void Awake()
        {
            parent = GetComponentInParent<Levysabe>();
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
        private void OnCollisionStay(Collision coll)
        {
            var part = coll.gameObject.GetComponent<ParticleLvl1>();
            if (!part.selected && particleGO == null)
            {
                if (transform.childCount > 1)
                {
                    Debug.Log("No puede entrar m�s de una particula por espacio");
                }
                else
                {
                    Debug.Log("puede entrar la particula");
                    particleGO = part.gameObject;
                    particleGO.transform.parent = gameObject.transform;
                    //particleGO.transform.position = gameObject.transform.position;
                    if (part.GetType() == assignedParticle.GetType())
                    {
                        parent.AddParticle(particleGO);
                    }
                }
            }
        }

        //private void OnCollisionExit(Collision coll)
        //{
        //    Debug.Log("salio");
        //    fed = false;
        //    particleCollision.gameObject.transform.parent = null;
        //}

        private void Update()
        {
            Debug.Log(particleGO);
            if (particleGO != null)
            {
                Debug.Log("boca boca boca");
                particleGO.transform.position = Vector3.Lerp(particleGO.transform.position, transform.position, Time.deltaTime * 3);
                if (Vector3.Distance(transform.position, particleGO.transform.position) > 1 && !particleGO.GetComponent<ParticleLvl1>().selected)
                {
                    particleGO.transform.parent = null;
                    if (particleGO.GetComponent<NeutronLvl1>() != null)
                    {
                        neutronScript = particleGO.GetComponent<NeutronLvl1>();
                        parent.CheckList(neutronScript);
                    }
                    else if (particleGO.GetComponent<ProtonLvl1>() != null)
                    {
                        protonScript = particleGO.GetComponent<ProtonLvl1>();
                        parent.CheckList(protonScript);
                    }
                    //Destroy(particleGO.gameObject); Si la destruyo se destruye el script.
                    particleGO = null;
                }
            }
        }
    }
    
}
