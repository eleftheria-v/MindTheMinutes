using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meeting_Minutes.Models
{
    public class FileUpd
    {
        [NotMapped]
        public List<IFormFile> FileList { get; set; }
    }
}
