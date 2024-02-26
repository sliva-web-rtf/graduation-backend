using ScientificWork.UseCases.Students.Common.Dtos;

namespace ScientificWork.UseCases.Students.GetStudents;

public class GetStudentsResult
{
    public ICollection<StudentDto> StudentsDtos { get; set; }
}
