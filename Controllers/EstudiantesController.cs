using Lab5_ItaloHuillca.Models;
using Lab5_ItaloHuillca.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab5_ItaloHuillca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstudiantesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public EstudiantesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_unitOfWork.Repository<Estudiante>().GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(_unitOfWork.Repository<Estudiante>().GetById(id));

    [HttpPost]
    public async Task<IActionResult> Create(Estudiante entity)
    {
        _unitOfWork.Repository<Estudiante>().Add(entity);
        await _unitOfWork.Complete();
        return Ok(entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Estudiante entity)
    {
        entity.IdEstudiante = id;
        _unitOfWork.Repository<Estudiante>().Update(entity);
        await _unitOfWork.Complete();
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        _unitOfWork.Repository<Estudiante>().Delete(id);
        await _unitOfWork.Complete();
        return Ok();
    }
}