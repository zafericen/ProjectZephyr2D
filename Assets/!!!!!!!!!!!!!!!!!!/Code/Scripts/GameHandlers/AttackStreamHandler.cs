using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZephyr
{
    public class AttackStreamHandler: MonoSingleton<AttackStreamHandler>, IStream<AttackInputType>
    {
        public StreamList<AttackInputType> stream { get; set; }

        private void Awake()
        {
            InitializeStream();
        }

        public void InitializeStream(int capacity = 20)
        {
            stream = new StreamList<AttackInputType>(capacity);
        }
    }
}
