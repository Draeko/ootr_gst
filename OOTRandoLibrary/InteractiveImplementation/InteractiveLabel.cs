using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTRandoLibrary.InteractiveImplementation
{
    public class InteractiveLabel : Label
    {
        public string[]? TextCollection { get; set; }
        public string fontName { get; set; }
        public float fontSize { get; set; }
        public FontStyle fontStyle { get; set; }
    }
}
