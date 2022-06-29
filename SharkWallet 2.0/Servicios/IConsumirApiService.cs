using SharkWallet_2._0.entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharkWallet_2._0.Models;

namespace SharkWallet_2._0.entidades
{
    public interface IConsumirApiService
    {
        Task<Ethereum> GetValor();
    }

}
