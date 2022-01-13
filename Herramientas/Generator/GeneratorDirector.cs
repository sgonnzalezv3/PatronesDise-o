using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas.Generator
{
    public class GeneratorDirector
    {
        private IBuilderGenerator _builderGenerator;

        public GeneratorDirector(IBuilderGenerator generatorBuilder)
        {
            SetBuilder(generatorBuilder);
        }

        /* Cambiar el builder cuando ya esta creado */
        public void SetBuilder(IBuilderGenerator builderGenerator) => _builderGenerator = builderGenerator;

        /* Product */
        public void CreateSimpleJsonGenerator(List<string> content, string path)
        {
            _builderGenerator.Reset();
            _builderGenerator.SetContet(content);
            _builderGenerator.SetPath(path);
            _builderGenerator.SetFormat(TypeFormat.Json);
        }

        /* Product */
        public void CreateSimplePipeGenerator(List<string> content, string path)
        {
            _builderGenerator.Reset();
            _builderGenerator.SetContet(content);
            _builderGenerator.SetPath(path);
            _builderGenerator.SetFormat(TypeFormat.Pipes);
            _builderGenerator.SetCharacter(TypeCharacter.Uppercase);
        }
    }
}
