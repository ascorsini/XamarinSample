using System;
namespace BaseProject.Models.Responses
{
    public class GenericResponse<T>
    {
        public T Id { get; set; }
        public GenericResponse()
        {
        }
    }
}

