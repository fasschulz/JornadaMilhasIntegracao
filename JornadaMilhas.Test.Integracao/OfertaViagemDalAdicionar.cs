using JornadaMilhas.Dados;
using JornadaMilhasV1.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace JornadaMilhas.Test.Integracao;

public class OfertaViagemDalAdicionar
{
    private readonly DbContextOptions<JornadaMilhasContext> _options;
    private readonly JornadaMilhasContext _context;

    public OfertaViagemDalAdicionar()
    {
        _options = new DbContextOptionsBuilder<JornadaMilhasContext>()
            .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JornadaMilhas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            .Options;

        _context = new JornadaMilhasContext(_options);
    }

    [Fact]
    public void RegistraOfertaNoBanco()
    {
        Rota rota = new Rota("São Paulo", "Fortaleza");
        Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
        double preco = 350;

        var oferta = new OfertaViagem(rota, periodo, preco);
        var dal = new OfertaViagemDAL(_context);

        dal.Adicionar(oferta);

        var ofertaIncluida = dal.RecuperarPorId(oferta.Id);
        Assert.NotNull(ofertaIncluida);
        Assert.Equal(ofertaIncluida.Preco, oferta.Preco);
    }

    [Fact]
    public void RegistraOfertaNoBancoComIformacoesCorretas()
    {
        Rota rota = new Rota("São Paulo", "Fortaleza");
        Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
        double preco = 350;

        var oferta = new OfertaViagem(rota, periodo, preco);
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