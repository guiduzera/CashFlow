﻿using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;
public class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=cashflow;Uid=root;Pwd=root;";
        var serverVersion = new MySqlServerVersion(new Version(9, 0, 0));

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
