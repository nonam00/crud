using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public record EmployeeDto([Required] string Name, [Required]uint Age);
}
