using Lab5_ItaloHuillca.Models;
using Lab5_ItaloHuillca.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab5_ItaloHuillca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfesoresController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProfesoresController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_unitOfWork.Repository<Profesor>().GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(_unitOfWork.Repository<Profesor>().GetById(id));

    [HttpPost]
    public async Task<IActionResult> Create(Profesor entity)
    {
        _unitOfWork.Repository<Profesor>().Add(entity);
        await _unitOfWork.Complete();
        return Ok(entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Profesor entity)
    {
        entity.IdProfesor = id;
        _unitOfWork.Repository<Profesor>().Update(entity);
        await _unitOfWork.Complete();
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        _unitOfWork.Repository<Profesor>().Delete(id);
        await _unitOfWork.Complete();
        return Ok();
    }
}