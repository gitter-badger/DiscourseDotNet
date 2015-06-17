using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscourseDotNet
{
    public class DiscourseException : Exception
    {
        public DiscourseException() { }

        public DiscourseException(string message) : base(message) { }

        public DiscourseException(string message, Exception inner) : base(message, inner) { }
    }
}
