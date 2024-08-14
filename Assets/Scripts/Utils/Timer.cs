using UnityEngine;

namespace ProjectZephyr
{

    public class Timer
    {
        private float last = 0;

        public Timer()
        {
        }

        public void Reset()
        {
            last = Time.time;
        }

        public float Seconds()
        {
            return Time.time - last;
        }

        public float Milliseconds()
        {
            return (Time.time - last) * 1000;
        }

    }

}