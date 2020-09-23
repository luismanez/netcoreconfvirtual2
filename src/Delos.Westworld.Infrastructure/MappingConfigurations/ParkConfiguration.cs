using System;
using System.Collections.Generic;
using Delos.Westworld.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delos.Westworld.Infrastructure.MappingConfigurations
{
    public class ParkConfiguration: IEntityTypeConfiguration<Park>
    {
        public void Configure(EntityTypeBuilder<Park> builder)
        {
            builder.HasMany(p => p.Hosts)
                .WithOne(h => h.CurrentPark)
                .HasForeignKey(h => h.CurrentParkId);

            builder.HasData(new List<Park>
            {
                new Park
                {
                    Id = Guid.Parse("306db597-a981-4072-b84a-646747387f5d"),
                    Name = "Westworld",
                    Description = "Experience the first vacation destination where you can live without limits. Westworld is a meticulously crafted and artfully designed park offering an unparalleled, immersive world where you have the freedom to become who you’ve always wanted to be — or who you never knew you were."
                },
                new Park
                {
                    Id = Guid.Parse("b6daf08d-8f42-42a6-ab95-23c7066bd7cf"),
                    Name = "Shogunworld ",
                    Description = "\"Shōgunworld\" is park two at Delos Destinations, intended for those who find Westworld too tame. Based on the Edo period in Japanese history, Shōgunworld is an artfully-curated vacation destination, where guests can experience the full complexity of nature - beauty and danger, good and evil - in a place nestled from the passage of time."
                },
                new Park
                {
                    Id = Guid.Parse("9ebd3c29-f228-4af0-af1b-2688cc8e387c"),
                    Name = "Warworld",
                    Description = "\"Warworld\" is a simulated world and could possibly be park three at Delos Destinations. This park is based on Italian history during World War II, more specifically when Italy was occupied by Nazi Germany between 1943 and 1945 and made into the Italian Social Republic - popularly and historically known as the Republic of Salò."
                },
                new Park
                {
                    Id = Guid.Parse("5cda564c-7f41-429d-b151-ca0aa941a99d"),
                    Name = "The Raj",
                    Description = "\"The Raj\" is park six at Delos Destinations and the first park revealed that doesn't use the \"-world\" suffix in its name. The park is named after and inspired by the \"British Raj\", the period between 1858 and 1947 in which the British Crown ruled over the Indian subcontinent."
                }
            });
        }
    }
}