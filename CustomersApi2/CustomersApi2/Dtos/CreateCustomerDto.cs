using System.ComponentModel.DataAnnotations;

namespace CustomersApi2.Dtos
{
    public class CreateCustomerDto
    {
        [Required (ErrorMessage ="El nombre propio tiene que estar especificado")]
        public string FistName { get; set; }
        [Required (ErrorMessage = "El apellido tiene que estar especificado")]

        public string LastName { get; set; }
        [RegularExpression("^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$", ErrorMessage ="El email no es correcto")]

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
