using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas.Generator
{
    public class GeneratorConcreteBuilder : IBuilderGenerator
    {

        private Generator _generator;
        public GeneratorConcreteBuilder()
        {
            Reset();
        }
        public void Reset() => _generator = new Generator();

        public void SetCharacter(TypeCharacter character) => _generator.Character = character;

        public void SetContet(List<string> contet) => _generator.Content = contet;

        public void SetFormat(TypeFormat format) => _generator.Format = format;

        public void SetPath(string path) => _generator.Path = path;

        public Generator GetGenerator() => _generator;
    }
}
