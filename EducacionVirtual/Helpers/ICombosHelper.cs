using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace EducacionVitual.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboRoles();
    }
}
