using Bogus;
using JornadaMilhasV1.Modelos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test.Integracao.DataBuilders;

public class RotaDataBuilder : Faker<Rota>
{
    public string? Origem { get; set; }
    public string? Destino { get; set; }

    public RotaDataBuilder()
    {        
        var address = new Bogus.DataSets.Address(locale: "pt_BR");
        CustomInstantiator(f =>
        {
            string origem = string.IsNullOrEmpty(Origem) ? address.City() : Origem;
            string destino = string.IsNullOrEmpty(Destino) ? address.City() : Destino;
            return new Rota(origem, destino);
        });
    }

    public Rota Build() => Generate();
}
