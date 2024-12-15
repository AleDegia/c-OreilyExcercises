using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Constraints
{
    // classe generica con una restrizione sui tipi che possono essere usati come parametro generico T
    //T deve essere un tipo classe (ossia un riferimento) e deve avere costruttore pubblico senza parametri
    public class SampleClass<T> where T : class, new()
    {
    }
}
