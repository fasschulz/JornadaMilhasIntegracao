using JornadaMilhas.Dados;
using JornadaMilhas.Test.Integracao.Fixture;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao.Tests.OfertaViagemDalTests;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemDalRecuperarPorId
{
    private JornadaMilhasContext _context;

    public OfertaViagemDalRecuperarPorId(ITestOutputHelper output, ContextoFixture fixture)
    {
        _context = fixture.Context;
        output.WriteLine(_context.GetHashCode().ToString());
    }

    [Fact]
    public void RetornaNuloQuandoIdInexistente()
    {
        var dal = new OfertaViagemDAL(_context);

        var ofertaRecuperada = dal.RecuperarPorId(-2);

        Assert.Null(ofertaRecuperada);
    }
}
