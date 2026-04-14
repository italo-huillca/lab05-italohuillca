namespace Lab5_ItaloHuillca.Repositories.Implementations;

using Lab5_ItaloHuillca.Models;
using Lab5_ItaloHuillca.Repositories.Interfaces;

public class MatriculaRepository : GenericRepository<Matricula>, IMatriculaRepository
{
    public MatriculaRepository(ColegioDbContext context) : base(context) { }

    public async Task MatricularEstudiantesEnCurso(int idCurso, int idProfesor, string semestre, List<int> idsEstudiantes)
    {
        var curso = _context.Cursos.Find(idCurso) 
                    ?? throw new KeyNotFoundException($"Curso {idCurso} no encontrado");
        
        var profesor = _context.Profesores.Find(idProfesor) 
                       ?? throw new KeyNotFoundException($"Profesor {idProfesor} no encontrado");

        foreach (var idEstudiante in idsEstudiantes)
        {
            var estudiante = _context.Estudiantes.Find(idEstudiante)
                             ?? throw new KeyNotFoundException($"Estudiante {idEstudiante} no encontrado");

            _context.Matriculas.Add(new Matricula
            {
                IdEstudiante = estudiante.IdEstudiante,
                IdCurso = curso.IdCurso,
                Semestre = semestre
            });
        }
    }
}