using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CandyStore.Data.Models;

public class Order
{
    [BindNever]
    public int OrderID { get; set; }

    [Required(ErrorMessage = "Please enter your first name")]
    [Display(Name = "First Name")]
    [StringLength(25)]
    public string FirstName { get; set; } = default!;

    [Required(ErrorMessage = "Please enter your last name")]
    [Display(Name = "Last Name")]
    [StringLength(50)]
    public string LastName { get; set; } = default!;

    [Required(ErrorMessage = "Please enter your address")]
    [Display(Name = "Street Address")]
    [StringLength(100)]
    public string Address { get; set; } = default!;

    [Required(ErrorMessage = "Please enter city")]
    public string City { get; set; } = default!;

    [Required(ErrorMessage = "Please enter your state")]
    public string State { get; set; } = default!;

    [Required(ErrorMessage = "Please enter your zip")]
    [StringLength(5, MinimumLength = 5)]
    public string ZipCode { get; set; } = default!;

    [Required(ErrorMessage = "Please enter your phone")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; } = default!;

    public ICollection<OrderDetail>? OrderDetails { get; set; }

    [BindNever]
    [ScaffoldColumn(false)]
    public decimal OrderTotal { get; set; }

    [BindNever]
    [ScaffoldColumn(false)]
    public DateTime OrderPlaced { get; set; }
}