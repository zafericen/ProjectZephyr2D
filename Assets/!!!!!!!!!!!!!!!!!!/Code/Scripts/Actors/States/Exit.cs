using UnityEngine;

namespace ProjectZephyr
{

    public class Exit : State
    {
        public override bool Check(Context context)
        {
            return context.current.status != Status.WORKING;
        }
    }
}
