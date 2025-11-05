using System;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Protocol is required.")]
        [StringLength(50, ErrorMessage = "Protocol name can't exceed 50 characters.")]
        public string? Protocol { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression("^(Active|Inactive|Maintenance|Faulted)$",
            ErrorMessage = "Status must be one of: Active, Inactive, Maintenance, Faulted.")]
        public string? Status { get; set; }
    }
}
