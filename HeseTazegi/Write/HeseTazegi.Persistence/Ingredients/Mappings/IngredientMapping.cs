using Framework.Persistence;
using HeseTazegi.Domain.Ingredients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace HeseTazegi.Persistence.Ingredients.Mappings
{
    public class IngredientMapping : BaseEntityMapping<Ingredient>
    {
        public override void OnConfigure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(i => i.Name)
                   .HasColumnType(nameof(SqlDbType.NVarChar))
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(i => i.IsFoodAllergen)
                   .HasColumnType(nameof(SqlDbType.Bit))
                   .IsRequired();
        }
    }
}
