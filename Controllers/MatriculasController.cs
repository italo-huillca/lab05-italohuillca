using Lab5_ItaloHuillca.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab5_ItaloHuillca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatriculasController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public MatriculasController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_unitOfWork.Matriculas.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(_unitOfWork.Matriculas.GetById(id));

    [HttpPost]
    public async Task<IActionResult> Create(MatricularCursoRequest request)
    {
        await _unitOfWork.Matriculas.MatricularEstudiantesEnCurso(
            request.IdCurso,
            request.IdProfesor,
            request.Semestre,
            request.IdsEstudiantes
        );
        await _unitOfWork.Complete();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        _unitOfWork.Matriculas.Delete(id);
        await _unitOfWork.Complete();
        return Ok();
    }
}

public class MatricularCursoRequest
{
    public int IdCurso { get; set; }
    public int IdProfesor { get; set; }
    public string Semestre { get; set; } = null!;
    public List<int> IdsEstudiantes { get; set; } = new();
}