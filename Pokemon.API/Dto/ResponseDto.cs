using System.Collections.Generic;

namespace Pokemon.API.Dto
{
    public class ResponseDto
    {
        public bool isSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessage { get; set; }
    }
}
