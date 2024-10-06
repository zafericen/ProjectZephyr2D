using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ProjectZephyr
{
    //TODO: Refactor logic so that it uses statemachines
    public class ComboStreamDetector
    {
        List<AttackInputType> comboStreams;

        public ComboStreamDetector(List<AttackInputType> comboStreams)
        {
            this.comboStreams = comboStreams;
        }

        public bool IsStreamContainsCombo(StreamList<AttackInputType> stream)
        {
            bool isComboStreamExists = stream.CheckSubStreamExists(comboStreams);

            if (isComboStreamExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}