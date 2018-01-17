using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizatorSkladniowy
{
    public class BladSkladniowy : Exception
    {
        public BladSkladniowy(string message) : base(message)
        {

        }

        public BladSkladniowy() : base()
        {

        }
    }
}
