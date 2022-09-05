using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SectorApp.Models.Sector
{
    public class UpdateSectorViewModel
    {
        public string Name { get; set; }
        public List<SectorViewModel> Sectors { get; set; }

        [DisplayName("Sector")] public int? SelectedSectorCode { get; set; }

        [DisplayName("Agree to terms")] public bool AgreeToTerms { get; set; }
        
        public IEnumerable<SelectListItem> ArrangeSectorListItems()
        {
            var result = new List<SelectListItem>();
            foreach (var mainSector in Sectors)
            {
                result.Add(Map(mainSector));
        
                if (!mainSector.SubSectors.Any())
                {
                    continue;
                }

                foreach (var subSector in mainSector.SubSectors)
                {
                    result.Add(Map(subSector, SubSectorLevel.Sub));
                    if (!subSector.SubSectors.Any())
                    {
                        continue;
                    }
                    var subSubSectors = subSector.SubSectors.Select(s => Map(s, SubSectorLevel.SubSub)).ToList();
                    result.AddRange(subSubSectors);
                }
            }
        
            return result.Prepend(CreateDefaultSelectListItem());
        }

        private SelectListItem Map(SectorViewModel model, SubSectorLevel? level = null)
        {
            return new SelectListItem
            {
                Selected = model.Code == SelectedSectorCode,
                Text = GetNameWithIndentation(model.Name, level),
                Value = model.Code.ToString(),
            };
        }

        private string GetNameWithIndentation(string value, SubSectorLevel? level = null)
        {
            if (level == null)
            {
                return value;
            }
            var indentation = String.Join("", Enumerable.Range(0, (int)level)
                .Select(x => "\xA0\xA0\xA0\xA0")
                .ToList());
            return $"{indentation}{value}";
        }

        private SelectListItem CreateDefaultSelectListItem()
        {
            return new SelectListItem
            {
                Selected = SelectedSectorCode == null,
                Text = "Choose sector",
                Disabled = true,
            };
        }
    }
}