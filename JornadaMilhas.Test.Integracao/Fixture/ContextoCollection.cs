using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test.Integracao.Fixture;

[CollectionDefinition(nameof(ContextoCollection))]
public class ContextoCollection : ICollectionFixture<ContextoFixture>
{
}
