using System.ComponentModel.DataAnnotations;

namespace MorseApp_API.Dtos
{
    public class MessageDto
    {
        [Required]
        public string Code { get; set; }
        public string Message { get; set; }

    }
}