using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScript
{
    public interface PlayerSetup
    {
        GameObject GameObject { get; }

        PlayerInput Input { get; }
    }
}

