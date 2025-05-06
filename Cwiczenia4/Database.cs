using Cwiczenia4.Models;

namespace Cwiczenia4;

public static class Database
{
    public static List<Animal> Animals { get; } = new List<Animal>
    {
        new Animal
        {
            Id = 1,
            Name = "Burek",
            Category = "Pies",
            Weight = 12.5,
            FurColor = "Brązowy",
            Visits = new List<Visit>()
        },
        new Animal
        {
            Id = 2,
            Name = "Mruczek",
            Category = "Kot",
            Weight = 4.2,
            FurColor = "Czarny",
            Visits = new List<Visit>()
        }
    };
}