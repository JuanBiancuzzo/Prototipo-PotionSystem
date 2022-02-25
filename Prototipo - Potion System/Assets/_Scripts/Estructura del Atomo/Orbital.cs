using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Orbital
    {
        private Electron _electron1, _electron2;

        public Orbital(Electron electron1 = null, Electron electron2 = null)
        {
            _electron1 = electron1;
            _electron2 = electron2;
        }
    }

    public class Shell
    {

    }
}
