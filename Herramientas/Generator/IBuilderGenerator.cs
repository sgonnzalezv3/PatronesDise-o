using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Pasos que tiene que implementar el builder */
namespace Herramientas.Generator
{


    public enum TypeFormat
    {
        Json,
        Pipes
    }

    public enum TypeCharacter
    {
        Normal,
        Uppercase,
        Lowercase
    }


    public interface IBuilderGenerator
    {
        /* Reiniciar configuracion */
        public void Reset();

        /* recibir el contenido por una lista de strings, no importa de donde viene */
        public void SetContet(List<string> contet);

        /* Ruta */
        public void SetPath(string path);

        /* Dar formato */
        public void SetFormat(TypeFormat format);

        /* Especificar tipo de caracteres */
        /* Por defecto texto normal (TypeCharacter character = TypeCharacter.Normal) opcional */
        public void SetCharacter(TypeCharacter character = TypeCharacter.Normal);

    }
}
