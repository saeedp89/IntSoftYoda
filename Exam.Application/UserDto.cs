using System.ComponentModel.DataAnnotations;

namespace Exam.Application;

public class UserDto
{
    public long Id { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; }
    [RegularExpression("\\d{10}$")] public string NationalCode { get; set; }

    [RegularExpression("^(\\+\\d{1,2}\\s?)?\\(?\\d{3}\\)?[\\s.-]?\\d{3}[\\s.-]?\\d{4}$")] public string PhoneNumber { get; set; }
}