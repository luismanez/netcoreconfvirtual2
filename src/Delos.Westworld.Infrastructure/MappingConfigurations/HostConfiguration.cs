using System;
using System.Collections.Generic;
using Delos.Westworld.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delos.Westworld.Infrastructure.MappingConfigurations
{
    public class HostConfiguration: IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            //Westworld park Hosts
            builder.HasData(new List<Host>
            {
                new Host
                {
                    Biography = "Dolores had a long history of being known as the oldest active host in Westworld[2]. Later, she revealed that she was the first host, and from her, all other hosts are based.[3]",
                    CurrentParkId = Guid.Parse("306db597-a981-4072-b84a-646747387f5d"),
                    Id = Guid.Parse("53205ba8-c39a-4fc9-ab19-79cfe43a5de9"),
                    DateOfCreation = DateTime.Today.AddDays(-50),
                    LastSystemReview = DateTime.Today.AddDays(-12),
                    Name = "Dolores Abernathy"
                },
                new Host
                {
                    Biography = "Some years after Arnold died, Bernard was created by Dr. Robert Ford. Ford programmed Bernard to think of himself as a human.",
                    CurrentParkId = Guid.Parse("306db597-a981-4072-b84a-646747387f5d"),
                    Id = Guid.Parse("20f75515-cd6b-4635-88c4-03abe4a4ebf8"),
                    DateOfCreation = DateTime.Today.AddDays(-150),
                    LastSystemReview = DateTime.Today.AddDays(-19),
                    Name = "Bernard Lowe"
                },
                new Host
                {
                    Biography = "Clementine was one of the earliest hosts designed by Robert Ford's and Arnold Weber's startup called the Argos Initiative. She was though preceded by at least Dolores Abernathy.",
                    CurrentParkId = Guid.Parse("306db597-a981-4072-b84a-646747387f5d"),
                    Id = Guid.Parse("ba2608b9-23c8-4d71-a51c-6c3c9b07dfc6"),
                    DateOfCreation = DateTime.Today.AddDays(-50),
                    LastSystemReview = DateTime.Today.AddDays(-9),
                    Name = "Clementine Pennyfeather"
                }
            });

            //Shogunworld park Hosts
            builder.HasData(new List<Host>
            {
                new Host
                {
                    Biography = "Akane was created by Lee Sizemore as a Shōgunworld's counterpart to Maeve Millay. Sizemore claims he felt justified to do so, as he was under stress to create 300 new narratives in 3 weeks.",
                    CurrentParkId = Guid.Parse("b6daf08d-8f42-42a6-ab95-23c7066bd7cf"),
                    Id = Guid.Parse("6868b126-84ff-4d92-9220-fd05a76c140a"),
                    DateOfCreation = DateTime.Today.AddDays(-20),
                    LastSystemReview = DateTime.Today.AddDays(-2),
                    Name = "Akane"
                },
                new Host
                {
                    Biography = "Musashi was created by Lee Sizemore as Shōgunworld's counterpart to Hector Escaton. Sizemore claims he felt justified in copying large parts of Hector's code, as he was under stress to create 300 new narratives in 3 weeks.",
                    CurrentParkId = Guid.Parse("b6daf08d-8f42-42a6-ab95-23c7066bd7cf"),
                    Id = Guid.Parse("e734bab8-c0aa-41c7-b01c-a77b3fc20acf"),
                    DateOfCreation = DateTime.Today.AddDays(-10),
                    LastSystemReview = DateTime.Today.AddDays(-9),
                    Name = "Musashi"
                }
            });

            //Warworld park Hosts
            builder.HasData(new List<Host>
            {
                new Host
                {
                    Biography = " Maeve Millay is a main character and a host in Westworld. She is a brothel madam in the local Mariposa Saloon. She is one of the first hosts who appears to question her reality, after a series of flashback events - and an apparently chance encounter with Dolores Abernathy in the street outside the Saloon.",
                    CurrentParkId = Guid.Parse("9ebd3c29-f228-4af0-af1b-2688cc8e387c"),
                    Id = Guid.Parse("a77d4f82-8045-4b03-9e89-ec595fbfe8c0"),
                    DateOfCreation = DateTime.Today.AddDays(-123),
                    LastSystemReview = DateTime.Today.AddDays(-20),
                    Name = "Maeve Millay"
                },
                new Host
                {
                    Biography = " Hector Escaton is a host and Westworld's permanent “Most Wanted” bandit. He is a terrifying and brutal criminal, and has a dark sense of humor to match. He subscribes to the theory that the world is a mad place, and the only way to survive is to embrace the role of predator. He is portrayed by Rodrigo Santoro.",
                    CurrentParkId = Guid.Parse("9ebd3c29-f228-4af0-af1b-2688cc8e387c"),
                    Id = Guid.Parse("2f71f976-db4d-4cc4-8bc5-2726d299ef9e"),
                    DateOfCreation = DateTime.Today.AddDays(-600),
                    LastSystemReview = DateTime.Today.AddDays(-90),
                    Name = "Hector Escaton"
                }
            });
        }
    }
}