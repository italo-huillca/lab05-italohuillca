using Lab5_ItaloHuillca.Models;
using Lab5_ItaloHuillca.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab5_ItaloHuillca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MateriasController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public MateriasController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_unitOfWork.Repository<Materia>().GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(_unitOfWork.Repository<Materia>().GetById(id));

    [HttpPost]
    public async Task<IActionResult> Create(Materia entity)
    {
        _unitOfWork.Repository<Materia>().Add(entity);
        await _unitOfWork.Complete();
        return Ok(entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Materia entity)
    {
        entity.IdMateria = id;
        _unitOfWork.Repository<Materia>().Update(entity);
        await _unitOfWork.Complete();
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        _unitOfWork.Repository<Materia>().Delete(id);
        await _unitOfWork.Complete();
        return Ok();
    }
}