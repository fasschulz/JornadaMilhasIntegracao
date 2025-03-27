using JornadaMilhas.Dados;
using JornadaMilhasV1.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao;

public class OfertaViagemDalAdicionar : IClassFixture<ContextoFixture>
{    
    private readonly JornadaMilhasContext _context;

    public OfertaViagemDalAdicionar(ITestOutputHelper output, ContextoFixture fixture)
    {
        _context = fixture.Context;
        output.WriteLine(_context.GetHashCode().ToString());
    }

    private static OfertaViagem OfertaViagemSetup()
    {
        Rota rota = new Rota("São Paulo", "Fortaleza");
        Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
        double preco = 350;

        return new OfertaViagem(rota, periodo, preco);
    }

    [Fact]
    public void RegistraOfertaNoBanco()
    {
        var oferta = OfertaViagemSetup();
        var dal = new OfertaViagemDAL(_context);

        dal.Adicionar(oferta);

        var ofertaIncluida = dal.RecuperarPorId(oferta.Id);
        Assert.NotNull(ofertaIncluida);
        Assert.Equal(ofertaIncluida.Preco, oferta.Preco);
    }

    [Fact]
    public void RegistraOfertaNoBancoComIformacoesCorretas()
    {
        var oferta = OfertaViagemSetup();
        var dal = new OfertaViagemDAL(_context);

        dal.Adicionar(oferta);

        var ofertaIncluida = dal.RecuperarPorId(oferta.Id);

        Assert.Equal(ofertaIncluida.Rota.Origem, oferta.Rota.Origem);
        Assert.Equal(ofertaIncluida.Rota.Destino, oferta.Rota.Destino);
        Assert.Equal(ofertaIncluida.Periodo.DataInicial, oferta.Periodo.DataInicial);
        Assert.Equal(ofertaIncluida.Periodo.DataFinal, oferta.Periodo.DataFinal);
        Assert.Equal(ofertaIncluida.Preco, oferta.Preco, 0.001);
    }
        
}