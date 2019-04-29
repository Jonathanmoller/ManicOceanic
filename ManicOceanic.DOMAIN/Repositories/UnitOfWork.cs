﻿using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Data;
using ManicOceanic.DOMAIN.Repositories.Interfaces;

namespace ManicOceanic.DOMAIN.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MOContext moContext;

        public UnitOfWork(MOContext moContext)
        {
            this.moContext = moContext;
        }

        public async Task SaveChangesAsync()
        {
            await moContext.SaveChangesAsync();
        }
    }
}