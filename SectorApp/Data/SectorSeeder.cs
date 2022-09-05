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
            
            var sectorCodesInDb = context.Sectors
                .Select(s => s.Code)
                .ToList();
            var sectorsToAdd = GetExpectedSectors()
                .Where(s => !sectorCodesInDb.Contains(s.Code))
                .ToList();
            if (!sectorsToAdd.Any())
            {
                return;
            }
            
            context.AddRange(sectorsToAdd);
            context.SaveChanges();
        }


        public static List<Sector> GetExpectedSectors()
        {
            var manufacturingCode = 1;
            var foodAndBeverageCode = 6;
            var furnitureCode = 13;
            var machineryCode = 12;
            var maritimeCode = 97;
            var metalworkingCode = 11;
            var metalWorksCode = 542;
            var plasticAndRubberCode = 9;
            var plasticProcessingTechnologyCode = 559;
            var printingCode = 5;
            var textileAndClothingCode = 7;
            var woodCode = 8;

            var otherCode = 3;

            var serviceCode = 2;
            var informationTechnologyAndTelecommunicationsCode = 28;
            var transportAndLogisticsCode = 21;
            return new List<Sector>
            {
                new Sector(manufacturingCode, "Manufacturing"),
                new Sector(19, "Construction materials", manufacturingCode),
                new Sector(18, "Electronics and Optics", manufacturingCode),
                new Sector(foodAndBeverageCode, "Food and Beverage", manufacturingCode),
                new Sector(342, "Bakery & confectionery products", foodAndBeverageCode),
                new Sector(43, "Beverages", foodAndBeverageCode),
                new Sector(42, "Fish & fish products", foodAndBeverageCode),
                new Sector(40, "Meat & meat products", foodAndBeverageCode),
                new Sector(39, "Milk & dairy products", foodAndBeverageCode),
                new Sector(437, "Other", foodAndBeverageCode),
                new Sector(378, "Sweets & snack food", foodAndBeverageCode),
                new Sector(furnitureCode, "Furniture", manufacturingCode),
                new Sector(389, "Bathroom/sauna", furnitureCode),
                new Sector(385, "Bedroom", furnitureCode),
                new Sector(390, "Children’s room", furnitureCode),
                new Sector(98, "Kitchen", furnitureCode),
                new Sector(101, "Living room", furnitureCode),
                new Sector(392, "Office", furnitureCode),
                new Sector(394, "Other (Furniture)", furnitureCode),
                new Sector(341, "Outdoor", furnitureCode),
                new Sector(99, "Project furniture", furnitureCode),
                new Sector(machineryCode, "Machinery", manufacturingCode),
                new Sector(94, "Machinery components", machineryCode),
                new Sector(91, "Machinery equipment/tools", machineryCode),
                new Sector(224, "Manufacture of machinery", machineryCode),
                new Sector(maritimeCode, "Maritime", machineryCode),
                new Sector(271, "Aluminium and steel workboats", maritimeCode),
                new Sector(269, "Boat/Yacht building", maritimeCode),
                new Sector(230, "Ship repair and conversion", maritimeCode),
                new Sector(93, "Metal structures", machineryCode),
                new Sector(508, "Other", machineryCode),
                new Sector(227, "Repair and maintenance service", machineryCode),
                new Sector(metalworkingCode, "Metalworking", manufacturingCode),
                new Sector(67, "Construction of metal structures", metalworkingCode),
                new Sector(263, "Houses and buildings", metalworkingCode),
                new Sector(267, "Metal products", metalworkingCode),
                new Sector(metalWorksCode, "Metal works", metalworkingCode),
                new Sector(75, "CNC-machining", metalWorksCode),
                new Sector(62, "Forgings, Fasteners", metalWorksCode),
                new Sector(69, "Gas, Plasma, Laser cutting", metalWorksCode),
                new Sector(66, "MIG, TIG, Aluminum welding", metalWorksCode),
                new Sector(plasticAndRubberCode, "Plastic and Rubber", manufacturingCode),
                new Sector(54, "Packaging", plasticAndRubberCode),
                new Sector(556, "Plastic goods", plasticAndRubberCode),
                new Sector(plasticProcessingTechnologyCode, "Plastic processing technology", plasticAndRubberCode),
                new Sector(55, "Blowing", plasticProcessingTechnologyCode),
                new Sector(57, "Moulding", plasticProcessingTechnologyCode),
                new Sector(53, "Plastics welding and processing", plasticProcessingTechnologyCode),
                new Sector(560, "Plastic profiles", plasticAndRubberCode),
                new Sector(printingCode, "Printing", manufacturingCode),
                new Sector(148, "Advertising", printingCode),
                new Sector(150, "Book/Periodicals printing", printingCode),
                new Sector(145, "Labelling and packaging printing", printingCode),
                new Sector(textileAndClothingCode, "Textile and Clothing", machineryCode),
                new Sector(44, "Clothing", textileAndClothingCode),
                new Sector(45, "Textile", textileAndClothingCode),
                new Sector(woodCode, "Wood", manufacturingCode),
                new Sector(337, "Other (Wood)", woodCode),
                new Sector(51, "Wooden building materials", woodCode),
                new Sector(47, "Wooden houses", woodCode),
                new Sector(otherCode, "Other"),
                new Sector(37, "Creative industries", otherCode),
                new Sector(29, "Energy technology", otherCode),
                new Sector(33, "Environment", otherCode),
                new Sector(serviceCode, "Service"),
                new Sector(25, "Business services", serviceCode),
                new Sector(35, "Engineering", serviceCode),
                new Sector(informationTechnologyAndTelecommunicationsCode, "Information Technology and Telecommunications", serviceCode),
                new Sector(581, "Data processing, Web portals, E-marketing", informationTechnologyAndTelecommunicationsCode),
                new Sector(576, "Programming, Consultancy", informationTechnologyAndTelecommunicationsCode),
                new Sector(121, "Software, Hardware", informationTechnologyAndTelecommunicationsCode),
                new Sector(122, "Telecommunications", informationTechnologyAndTelecommunicationsCode),
                new Sector(22, "Tourism", serviceCode),
                new Sector(141, "Translation services", serviceCode),
                new Sector(transportAndLogisticsCode, "Transport and Logistics", serviceCode),
                new Sector(111, "Air", transportAndLogisticsCode),
                new Sector(114, "Rail", transportAndLogisticsCode),
                new Sector(112, "Road", transportAndLogisticsCode),
                new Sector(113, "Water", transportAndLogisticsCode),
            };
        }
    }
}