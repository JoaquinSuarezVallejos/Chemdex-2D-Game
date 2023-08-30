﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atom
{
    public class NeutronLvl1 : ParticleLvl1
    {
        /// Summary: handles the bahavior of neutron particles in atom

        protected override void Awake() // called when the neutron is created
        {
            Radius = 0.5f;
            base.Awake();
        }

        public void PickUpParticle() // called when the neutron is picked up from the atom
        {
            // check if the neutron is part of the atom and can be removed
            if (inAtom && atom.Nucleus.RemoveParticle(this))
            {
                base.PickUpParticle(); // pick up the neutron (remove it from the atom)
                Debug.Log("Neutron Removed");
            }
            else
            {
                atom.RemoveExcessParticle(this);
            }
        }

        public void DropParticle() // called when the neutron is dropped into the atom
        {
            // check if not already part of the atom, within atom bounds, and can actually be added
            if (!inAtom && (!atom.Interactable || atom.Contains(transform.position) || (atom.Nucleus.ProtonCount == 0 && atom.Nucleus.NeutronCount == 0)) && atom.Nucleus.AddParticle(this))
            {
                base.DropParticle(); // drop the neutron (add it to the atom)
                Debug.Log("Neutron Added");
            }

            // neutron out of bounds or could not be added
            else
            {
                atom.AddExcessParticle(this);
            }
        }
    }
}