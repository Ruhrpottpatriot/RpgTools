namespace RpgTools.Locations
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class Program
    {
        private static void Main(string[] args)
        {
            var context = new LocationRepository();

            var locations = context.LocationsDbSet.ToList();

            Console.Write("Number of Locations: {0}", locations.Count);
            Console.WriteLine("Details:");
            foreach (var location in locations)
            {
                Console.WriteLine("Id: {0}, Name: {1}", location.Id, location.Name);
            }

            Console.ReadLine();
        }
    }}
