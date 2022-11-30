using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace CoreEscuela.Entidades
{
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueID { get; private set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            UniqueID = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre}, {UniqueID}";
        }


    }


}