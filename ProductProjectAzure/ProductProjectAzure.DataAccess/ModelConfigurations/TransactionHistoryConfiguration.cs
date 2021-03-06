﻿using System.Data.Entity.ModelConfiguration;
using ProductProjectAzure.DataAccess.Common.Models;

namespace ProductProjectAzure.DataAccess.ModelConfigurations
{
    public class TransactionHistoryConfiguration: EntityTypeConfiguration<TransactionHistory>
    {
        public TransactionHistoryConfiguration()
        {
            ToTable("Production.TransactionHistory");
            HasKey(x => x.TransactionID);
            Property(x => x.ProductID).IsRequired();
            HasRequired(x => x.Product).WithMany(p => p.TransactionHistory).HasForeignKey(x => x.ProductID);
            Property(x => x.ActualCost).IsRequired();
            Property(x => x.ModifiedDate).IsRequired();
            Property(x => x.Quantity).IsRequired();
            Property(x => x.ReferenceOrderID).IsRequired();
            Property(x => x.ReferenceOrderLineID).IsRequired();
            Property(x => x.TransactionDate).IsRequired();
            Property(x => x.TransactionType).IsRequired();
        }
    }
}
