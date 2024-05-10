using Framework.Persistence;
using HeseTazegi.Domain.Foods;
using HeseTazegi.Domain.Ingredients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace HeseTazegi.Persistence.Foods.Mappings
{
    public class FoodMapping : BaseEntityMapping<Food>
    {
        public override void OnConfigure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(f => f.Name)
                   .HasColumnType(nameof(SqlDbType.NVarChar))
                   .HasMaxLength(500)
                   .IsRequired();

            builder.OwnsMany(f => f.Ingredients, map =>
            {
                map.ToTable("FoodIngredient", "HeseTazegi");
                map.HasOne<Ingredient>().WithMany().HasForeignKey(i => i.IngredientId);
            });
        }
    }
}
