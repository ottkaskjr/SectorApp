using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SectorApp.Models.Sector
{
    public class UpdateSectorViewModel
    {
        public string Name { get; set; }
        public List<SectorViewModel> Sectors { get; set; }
        
        [DisplayName("Sector")]
        public int? SelectedSectorCode { get; set; }
        
        [DisplayName("Agree to terms")]
        public bool AgreeToTerms { get; set; }

        public IEnumerable<SelectListItem> GetSectorListItems()
        {
            return Sectors.Select(s => new SelectListItem
            {
                Selected = s.Code == SelectedSectorCode,
                Text = s.Name,
                Value = s.Code.ToString()
            }).Prepend(CreateDefaultSelectListItem());
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