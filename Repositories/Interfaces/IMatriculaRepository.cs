using Lab5_ItaloHuillca.Models;

namespace Lab5_ItaloHuillca.Repositories.Interfaces;

public interface IMatriculaRepository : IGenericRepository<Matricula>
{
    Task MatricularEstudiantesEnCurso(int idCurso, int idProfesor, string semestre, List<int> idsEstudiantes);
}