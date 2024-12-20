using UnityEngine;

namespace CreateScript
{
    public interface CharacterSetup
    {
        GameObject GameObject { get; }
    }

    public interface PlayerSetup : CharacterSetup
    {

        PlayerInput Input { get; }
    }

    public interface BossSetup : CharacterSetup
    {

    }
}

