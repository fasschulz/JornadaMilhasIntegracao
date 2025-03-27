using JornadaMilhas.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemRecuperarTodas
{
    private JornadaMilhasContext _context;

    public OfertaViagemRecuperarTodas(ITestOutputHelper output, ContextoFixture fixture)
    {
        _context = fixture.Context;
        output.WriteLine(_context.GetHashCode().ToString());
    }

    [Fact]
    public void RecuperaTodasAsOfertasCadastradas()
    {
        var dal = new OfertaViagemDAL(_context);
        var ofertas = dal.RecuperarTodas();

        Assert.NotNull(ofertas);
        Assert.True(ofertas.Count() > 0);
    }
}
