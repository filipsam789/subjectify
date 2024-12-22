namespace Domain.DTO;

public class SubjectDetailsDTO
{
    public string Name { get; set; }
    public Guid? SubjectId { get; set; }
    public List<ProfessorDTO> Professors { get; set; }
    public List<ReviewDTO> Reviews { get; set; }
    public double AverageReviewScore { get; set; }
}

