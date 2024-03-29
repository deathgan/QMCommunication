﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QMCommunication.Data;
using Volo.Abp.DependencyInjection;

namespace QMCommunication.EntityFrameworkCore
{
    public class EntityFrameworkCoreQMCommunicationDbSchemaMigrator
        : IQMCommunicationDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreQMCommunicationDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the QMCommunicationMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<QMCommunicationMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}