using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SectorApp.Data.Entities;

namespace SectorApp.Data
{
    public class SectorSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.Migrate();
            if (context.Sectors.Any())
            {
                return;
            }
            
            context.AddRange(GetSectors());
            context.SaveChanges();
        }


        public static List<Sector> GetSectors()
        {
            return new List<Sector>
            {
                new Sector(1, "Manufacturing"),
                new Sector(19, "Construction materials"),
                new Sector(18, "Electronics and Optics"),
                new Sector(6, "Food and Beverage"),
                new Sector(342, "Bakery confectionery products"),
                new Sector(43, "Beverages"),
                new Sector(42, "Fish fish products "),
                new Sector(40, "Meat meat products"),
                new Sector(39, "Milk dairy products "),
                new Sector(437, "Other"),
                new Sector(378, "Sweets snack food"),
                new Sector(13, "Furniture"),
                new Sector(389, "Bathroom/sauna "),
                new Sector(385, "Bedroom"),
                new Sector(390, "Children’s room "),
                new Sector(98, "Kitchen "),
                new Sector(101, "Living room "),
                new Sector(392, "Office"),
                new Sector(394, "Other (Furniture)"),
                new Sector(341, "Outdoor "),
                new Sector(99, "Project furniture"),
                new Sector(12, "Machinery"),
                new Sector(94, "Machinery components"),
                new Sector(91, "Machinery equipment/tools"),
                new Sector(224, "Manufacture of machinery"),
                new Sector(97, "Maritime"),
                new Sector(271, "Aluminium and steel workboats "),
                new Sector(269, "Boat/Yacht building"),
                new Sector(230, "Ship repair and conversion"),
                new Sector(93, "Metal structures"),
                new Sector(508, "Other"),
                new Sector(227, "Repair and maintenance service"),
                new Sector(11, "Metalworking"),
                new Sector(67, "Construction of metal structures"),
                new Sector(263, "Houses and buildings"),
                new Sector(267, "Metal products"),
                new Sector(542, "Metal works"),
                new Sector(75, "CNC-machining"),
                new Sector(62, "Forgings, Fasteners "),
                new Sector(69, "Gas, Plasma, Laser cutting"),
                new Sector(66, "MIG, TIG, Aluminum welding"),
                new Sector(9, "Plastic and Rubber"),
                new Sector(54, "Packaging"),
                new Sector(556, "Plastic goods"),
                new Sector(559, "Plastic processing technology"),
                new Sector(55, "Blowing"),
                new Sector(57, "Moulding"),
                new Sector(53, "Plastics welding and processing"),
                new Sector(560, "Plastic profiles"),
                new Sector(5, "Printing "),
                new Sector(148, "Advertising"),
                new Sector(150, "Book/Periodicals printing"),
                new Sector(145, "Labelling and packaging printing"),
                new Sector(7, "Textile and Clothing"),
                new Sector(44, "Clothing"),
                new Sector(45, "Textile"),
                new Sector(8, "Wood"),
                new Sector(337, "Other (Wood)"),
                new Sector(51, "Wooden building materials"),
                new Sector(47, "Wooden houses"),
                new Sector(3, "Other"),
                new Sector(37, "Creative industries"),
                new Sector(29, "Energy technology"),
                new Sector(33, "Environment"),
                new Sector(2, "Service"),
                new Sector(25, "Business services"),
                new Sector(35, "Engineering"),
                new Sector(28, "Information Technology and Telecommunications"),
                new Sector(581, "Data processing, Web portals, E-marketing"),
                new Sector(576, "Programming, Consultancy"),
                new Sector(121, "Software, Hardware"),
                new Sector(122, "Telecommunications"),
                new Sector(22, "Tourism"),
                new Sector(141, "Translation services"),
                new Sector(21, "Transport and Logistics"),
                new Sector(111, "Air"),
                new Sector(114, "Rail"),
                new Sector(112, "Road"),
                new Sector(113, "Water"),
            };
        }
    }
}