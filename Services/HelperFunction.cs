using Meeting_Minutes.Data;
using Meeting_Minutes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

//namespace Meeting_Minutes.Services
//{
//    public class HelperFunctions
//    {
//        private readonly ApplicationDbContext _context;

//        public HelperFunctions(ApplicationDbContext context)
//        {
//            _context = context;

//        }
//        public static string RiskLevelText(int IntValue)
//        {   
            
//            //var HelperFunctions = new HelperFunctions();
//            List<RiskLevel> RiskLevelsList = _context.ListValues.Where(x => x.ListTypeID == 1).Select(x => new SelectListItem
//            {
//                Value = x.ID.ToString(),
//                Text = x.Value
//            }).ToList();
//            return ("");
//        }


//    }
//}
