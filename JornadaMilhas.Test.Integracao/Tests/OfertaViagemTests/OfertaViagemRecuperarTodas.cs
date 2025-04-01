using JornadaMilhas.Dados;
using JornadaMilhas.Test.Integracao.Fixture;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao.Tests.OfertaViagemTests;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemRecuperarTodas : IDisposable
{
    private JornadaMilhasContext _context;
    private ContextoFixture _fixture;

    public OfertaViagemRecuperarTodas(ITestOutputHelper output, ContextoFixture fixture)
    {
        _context = fixture.Context;
        _fixture = fixture;
        _fixture.CriarDadosFake();
        output.WriteLine(_context.GetHashCode().ToString());
    }

    public void Dispose()
    {
        _fixture.LimparDadosDoBanco();
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
