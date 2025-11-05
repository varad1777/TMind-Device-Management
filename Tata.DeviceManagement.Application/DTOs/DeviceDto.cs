using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tata.DeviceManagement.Domain.Enums;

=======
using System.ComponentModel.DataAnnotations;
>>>>>>> e6eb3ff698c2c6fb08e8f9b563da5cf46172b475

namespace Tata.DeviceManagement.Application.DTOs
{
    public class DeviceDto
    {
        [Required(ErrorMessage = "Device name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Device name must be between 2 and 100 characters.")]
        public string? Name { get; set; }

        [StringLength(250, ErrorMessage = "Description can't exceed 250 characters.")]
        [Required(ErrorMessage = "Device Description is required.")]
        public string? Description { get; set; }

<<<<<<< HEAD
        public string Name { get; set; } = "";
        public string Protocol { get; set; } = "";
        public DeviceStatus Status { get; set; } = DeviceStatus.Offline;
    }
    public class DeviceDtoForUpdate
    {
      
=======
        [Required(ErrorMessage = "Protocol is required.")]
        [StringLength(50, ErrorMessage = "Protocol name can't exceed 50 characters.")]
        public string? Protocol { get; set; }
>>>>>>> e6eb3ff698c2c6fb08e8f9b563da5cf46172b475

        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression("^(Active|Inactive|Maintenance|Faulted)$",
            ErrorMessage = "Status must be one of: Active, Inactive, Maintenance, Faulted.")]
        public string? Status { get; set; }
    }
}
